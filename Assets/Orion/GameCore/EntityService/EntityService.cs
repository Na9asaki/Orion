using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Orion.GameCore.EntityService
{
    public class EntityService
    {
        private Dictionary<Guid, EntityIdentifier> _entities = new Dictionary<Guid, EntityIdentifier>();
        public void Register(EntityIdentifier entityIdentifier)
        {
            _entities[entityIdentifier.InstanceId] =  entityIdentifier;
        }

        public void UnRegister(EntityIdentifier entityIdentifier)
        {
            _entities.Remove(entityIdentifier.InstanceId);
        }

        public EntityIdentifier GetBy(Guid guid)
        {
            return  _entities.ContainsKey(guid) ? _entities[guid] : null;
        }
    }
}