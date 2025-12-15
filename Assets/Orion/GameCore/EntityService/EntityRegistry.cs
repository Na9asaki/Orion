using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

namespace Orion.GameCore.EntityService
{
    [CreateAssetMenu(fileName = "EntityRegistry", menuName = "Orion/Entity Registry")]
    public class EntityRegistry : ScriptableObject
    {
        [SerializeField] private List<EntityDefinition> _entities = new List<EntityDefinition>();
        [SerializeField] private int nextId = 1;

        public IReadOnlyList<EntityDefinition> Entities => _entities;

        public int GetNextId()
        {
            return nextId++;
        }

        public EntityDefinition GetById(int id)
        {
            return _entities.First(x => x.Id == id);
        }

        public EntityDefinition GetByName(string name)
        {
            return _entities.Find(x => name.Equals(x.UniqueName));
        }

        public void Register(EntityDefinition def)
        {
            if (!_entities.Contains(def))
            {
                _entities.Add(def);
                EditorUtility.SetDirty(this);
            }
        }
    }
}