using Orion.GameCore.EntityService;
using UnityEditor;
using UnityEngine;

namespace Orion.GameCore.Editor
{
    public class EntityDefinitionCreator : UnityEditor.Editor
    {
        [MenuItem("Orion/Create Entity Definition")]
        public static void CreateEntityDefinition()
        {
            var path = EditorUtility.SaveFilePanelInProject("Create Entity Definition",
                "NewEntityDefinition", "asset", "Select location to save Entity Definition");

            if (string.IsNullOrEmpty(path))
                return;

            var definition = ScriptableObject.CreateInstance<EntityDefinition>();

            definition.GetType().GetProperty("Id").SetValue(definition, Random.Range(100000, 999999));

            AssetDatabase.CreateAsset(definition, path);
            AssetDatabase.SaveAssets();

            EditorUtility.FocusProjectWindow();
            Selection.activeObject = definition;
        }
    }
}