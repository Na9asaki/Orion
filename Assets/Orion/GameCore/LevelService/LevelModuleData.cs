using System;
using Orion.GameCore.Utils.Attributes;
using UnityEngine;

namespace Orion.GameCore.LevelService
{
    [Serializable]
    public class LevelModuleData
    {
        [SerializeField, ModuleType] public string Module;
    }
}