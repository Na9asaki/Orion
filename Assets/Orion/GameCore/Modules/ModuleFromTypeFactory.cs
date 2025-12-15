using System;
using System.Linq;
using UnityEngine;
using Zenject;

namespace Orion.GameCore.Modules
{
    public static class ModuleFromTypeFactory
    {
        public static IFunctionalModule Create(string type)
        {
            var systemType = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(asm => asm.GetTypes())
                .FirstOrDefault(t => type.Equals(t.FullName));
            if (systemType == null)
            {
                Debug.LogError($"Type {type}  not found in current domain!");
                return null;
            }
            var @object = Activator.CreateInstance(systemType) as IFunctionalModule;
            return @object;
        }
    }
}