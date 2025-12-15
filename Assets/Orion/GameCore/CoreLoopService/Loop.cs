using System;
using UnityEngine;

namespace Orion.GameCore.CoreLoopService
{
    public class Loop : MonoBehaviour
    {
        public static event Action OnUpdate;
        public static event Action OnUnscaledTimeUpdate;
        public static event Action OnFixedUpdate;
        public static event Action OnLateUpdate;

        private bool _paused;

        public void Enable()
        {
            _paused = false;
        }

        public void Disable()
        {
            _paused = true;
        }

        private void Update()
        {
            if (!_paused)
                OnUpdate?.Invoke();
            OnUnscaledTimeUpdate?.Invoke();
        }

        private void FixedUpdate()
        {
            if (_paused) return;
            OnFixedUpdate?.Invoke();
        }

        private void LateUpdate()
        {
            if  (_paused) return;
            OnLateUpdate?.Invoke();
        }
    }
}