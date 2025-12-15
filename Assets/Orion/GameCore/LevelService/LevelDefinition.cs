using System.Collections.Generic;
using UnityEngine;

namespace Orion.GameCore.LevelService
{
    [CreateAssetMenu(fileName = "Level", menuName = "Orion/Level/Definition", order = 0)]
    public class LevelDefinition : ScriptableObject
    {
        [field: SerializeField] public List<LevelModuleData> Modules {get; private set;}
    }
}