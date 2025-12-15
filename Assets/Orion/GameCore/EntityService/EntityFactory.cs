using Orion.GameCore.EntityService.Events;
using Orion.GameCore.EventBusService;
using UnityEngine;
using Zenject;

namespace Orion.GameCore.EntityService
{
    public class EntityFactory
    {
        private EntityService _entityService;
        private EntityRegistry _entityRegistry;
        private EventBus _eventBus;

        private EntitySpawnEvent _evSpawn;
        private EntityDestroyEvent _evDestroy;
        
        [Inject]
        public void Init(EntityService entityService, EntityRegistry entityRegistry, EventBus eventBus)
        {
            _entityService = entityService;
            _entityRegistry = entityRegistry;
            _eventBus = eventBus;
            _evSpawn = new EntitySpawnEvent();
            _evDestroy =  new EntityDestroyEvent();
        }

        public EntityIdentifier CreateEntity(int id)
        {
            var definition = _entityRegistry.GetById(id);
            var entity = GameObject.Instantiate(definition.Prefab);
            _entityService.Register(entity);
            _evSpawn.EntityIdentifier = entity;
            _eventBus.Publish(_evSpawn);
            return entity;
        }

        public void DestroyEntity(EntityIdentifier entity)
        {
            _entityService.UnRegister(entity);
            _evDestroy.EntityIdentifier = entity;
            _eventBus.Publish(_evDestroy);
            GameObject.Destroy(entity.gameObject);
        }
    }
}