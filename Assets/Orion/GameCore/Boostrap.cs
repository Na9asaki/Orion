using System;
using System.Collections.Generic;
using Orion.GameCore.Modules;
using UnityEngine;
using Zenject;

namespace Orion.GameCore
{
    public class Boostrap : MonoBehaviour
    {
        private SceneContext _sceneContext;

        private void Awake()
        {
            _sceneContext = FindFirstObjectByType<SceneContext>();
        }

        public void Run(IReadOnlyList<MonoInstaller> installers, IReadOnlyList<IFunctionalModule> modules)
        {
            _sceneContext.Installers = installers;
            _sceneContext.Run();
            foreach (var module in modules)
            {
                module.Run();
            }
        }
    }
}