using Orion.GameCore.Configuration;
using Orion.GameCore.EntityService;
using Orion.GameCore.EventBusService;
using UnityEditor;
using UnityEngine;
using Zenject;

namespace Orion.GameCore
{
    public class GameCoreInstaller : MonoInstaller
    {
        public override void InstallBindings()
        {
            var config = Resources.Load<ProjectConfiguration>("ProjectConfiguration");
            Container.Bind<EventBus>().AsSingle().NonLazy();
            #if UNITY_EDITOR
            var entity = AssetDatabase.LoadAssetAtPath<EntityRegistry>(config.EntityRegistryPath);
            Container.BindInstance(entity).AsSingle().NonLazy();
            #else
            Container.Bind<EntityRegistry>().FromResources("EntityRegistry").AsSingle().NonLazy();
            #endif
            Container.Bind<EntityService.EntityService>().AsSingle().NonLazy();
            Container.Bind<EntityFactory>().AsSingle().NonLazy();
        }
    }
}