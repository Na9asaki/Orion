using Orion.GameCore.Configuration;
using Orion.GameCore.EntityService;
using UnityEditor;
using UnityEngine;

namespace Orion.GameCore.Editor
{
    [CustomEditor(typeof(GameObject))]
    public class PrefabEntityDefinitionEditor : UnityEditor.Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();

            if (PrefabUtility.IsPartOfPrefabAsset(target))
            {
                if (GUILayout.Button("Create Entity Definition"))
                {
                    CreateEntityDefinition((GameObject)target);
                }
            }
        }

        private void CreateEntityDefinition(GameObject prefab)
        {
            var config = AssetDatabase.LoadAssetAtPath<ProjectConfiguration>("Assets/ProjectConfiguration.asset");
            var registry = AssetDatabase.LoadAssetAtPath<EntityRegistry>(config.EntityRegistryPath);
            if (!registry)
            {
                Debug.LogError("EntityRegistry.asset not found! Please create it first.");
                return;
            }

            var path = config.EntitiesPath + prefab.name + "_Definition.asset";
            var definition = ScriptableObject.CreateInstance<EntityDefinition>();
            definition.GetType().GetProperty("Prefab").SetValue(definition, prefab.GetComponent<EntityIdentifier>());
            definition.GetType().GetProperty("UniqueName").SetValue(definition, prefab.name);
            definition.GetType().GetProperty("Id").SetValue(definition, registry.GetNextId());

            AssetDatabase.CreateAsset(definition, path);
            AssetDatabase.SaveAssets();

            registry.Register(definition);
            Debug.Log($"EntityDefinition created for prefab {prefab.name}");
        }
    }
}