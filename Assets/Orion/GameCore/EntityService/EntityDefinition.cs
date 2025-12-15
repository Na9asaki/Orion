using System;
using UnityEngine;

namespace Orion.GameCore.EntityService
{
    public class EntityDefinition : ScriptableObject
    {
        [field: SerializeField] public EntityIdentifier Prefab {get; private set;}
        [field: SerializeField] public string UniqueName { get; private set; }
        [field: SerializeField] public int Id { get; private set; }
        
        
    }
}