using System.Collections.Generic;
using System.Linq;
using Orion.GameCore.LevelService;
using Orion.GameCore.Modules;
using UnityEngine;
using Zenject;

namespace Orion.GameCore
{
    public class Game : MonoBehaviour
    {
        [SerializeField] private SceneContext _context;
        [SerializeField] private LevelDefinition _levelDefinition;
        
        private List<MonoInstaller> _installers;
        private Boostrap _boostrap;
        private ModulesInitializer _modulesInitializer;
        
        public IReadOnlyList<IFunctionalModule> ActiveModules { get; private set; }

        private void Awake()
        {
            _modulesInitializer = new ModulesInitializer();
            ActiveModules = ModuleLoader.LoadAll(_levelDefinition.Modules.Select(x => x.Module));
            _boostrap = gameObject.AddComponent<Boostrap>();
            _installers = _modulesInitializer.Init(ActiveModules, _context);
            var coreInstaller = _context.gameObject.AddComponent<GameCoreInstaller>();
            _installers.Insert(0, coreInstaller);
            _boostrap.Run(_installers, ActiveModules);
        }

        private void OnDestroy()
        {
            foreach (var module in ActiveModules)
            {
                module.Dispose();
            }
        }
    }
}