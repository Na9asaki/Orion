using System;
using UnityEngine;

namespace Orion.GameCore.EntityService
{
    public class EntityIdentifier : MonoBehaviour
    {
        public Guid InstanceId { get; private set; }

        private void Awake()
        {
            InstanceId = Guid.NewGuid();
        }
    }
}