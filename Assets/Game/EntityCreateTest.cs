using Orion.GameCore.EntityService;
using UnityEngine;
using Zenject;

namespace Game
{
    public class EntityCreateTest : MonoBehaviour
    {
        private EntityFactory _entityFactory;
        private EntityIdentifier eId;
        [Inject]
        public void Init(EntityFactory factory)
        {
            _entityFactory = factory;
            Debug.Log($"Created: {factory}");
            eId = factory.CreateEntity(0);
        }

        private void OnDestroy()
        {
            _entityFactory.DestroyEntity(eId);
        }
    }
}