using UnityEngine;

namespace Orion.GameCore.Configuration
{
    [CreateAssetMenu(fileName = "ProjectConfiguration", menuName = "Orion/Configuration")]
    public class ProjectConfiguration : ScriptableObject
    {
        [field: SerializeField] public string EntitiesPath { get; private set; }
        [field: SerializeField] public string EntityRegistryPath { get; private set; }
    }
}