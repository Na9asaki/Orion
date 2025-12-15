using System;
using UnityEngine;

namespace Orion.GameCore.Utils.Attributes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class ModuleTypeAttribute : PropertyAttribute
    {
        public ModuleTypeAttribute() {}
    }
}