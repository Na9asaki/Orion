using System.IO;
using Orion.GameCore.Configuration;
using Orion.GameCore.EntityService;
using UnityEditor;
using UnityEditor.Build;
using UnityEditor.Build.Reporting;
using UnityEngine;

namespace Orion.GameCore
{
    public class PreBuild : IPreprocessBuildWithReport
    {
        public int callbackOrder => 0;
        public void OnPreprocessBuild(BuildReport report)
        {
            var config = Resources.Load<ProjectConfiguration>("ProjectConfiguration");
            if (config == null)
            {
                Debug.LogError("[PreBuild] ProjectConfiguration not found in Resources!");
                return;
            }

            var registry = AssetDatabase.LoadAssetAtPath<EntityRegistry>(config.EntityRegistryPath);
            if (registry == null)
            {
                Debug.LogError("[PreBuild] EntityRegistry not found at path: " + config.EntityRegistryPath);
                return;
            }

            string resourcesDir = "Assets/Resources";
            if (!Directory.Exists(resourcesDir))
            {
                Directory.CreateDirectory(resourcesDir);
            }

            string targetPath = Path.Combine(resourcesDir, "EntityRegistry.asset");

            if (File.Exists(targetPath))
            {
                AssetDatabase.DeleteAsset(targetPath);
            }

            // Копируем SO в Resources
            AssetDatabase.CopyAsset(config.EntityRegistryPath, targetPath);
            AssetDatabase.SaveAssets();

            Debug.Log("[PreBuild] EntityRegistry copied to Resources for build");
        }
    }
}