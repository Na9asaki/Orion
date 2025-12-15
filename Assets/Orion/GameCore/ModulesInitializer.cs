using System.Collections.Generic;
using Orion.GameCore.Modules;
using Zenject;

namespace Orion.GameCore
{
    public class ModulesInitializer
    {
        public List<MonoInstaller> Init(IReadOnlyList<IFunctionalModule> modules, SceneContext sceneContext)
        {
            var installers = new List<MonoInstaller>();
            foreach (var module in modules)
            {
                module.Init(installers, sceneContext);
            }

            return installers;
        }
    }
}