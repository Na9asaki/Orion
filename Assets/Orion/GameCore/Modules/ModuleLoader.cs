using System.Collections.Generic;
using Orion.GameCore.LevelService;
using Zenject;

namespace Orion.GameCore.Modules
{
    public static class ModuleLoader
    {
        public static IFunctionalModule Load(LevelModuleData data)
        {
            return ModuleFromTypeFactory.Create(data.Module);
        }

        public static IReadOnlyList<IFunctionalModule> LoadAll(IEnumerable<string> types)
        {
            var list =  new List<IFunctionalModule>();
            foreach (var module in types)
            {
                list.Add(ModuleFromTypeFactory.Create(module));
            }

            return list;
        }
    }
}