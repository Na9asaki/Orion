using System;
using System.Collections.Generic;
using UnityEngine;

namespace Orion.GameCore.EventBusService
{
    public class EventBus
    {
        private readonly Dictionary<Type, List<Subscriber>> _events = new Dictionary<Type, List<Subscriber>>();

        private Subscriber Make<T>(Action<T> handler, bool once)
        {
            return new Subscriber(handler, once);
        }

        private void Subscribe<T>(Subscriber subscriber)
        {
            if (!_events.ContainsKey(typeof(T)))
            {
                _events[typeof(T)] = new List<Subscriber>();
            }
            _events[typeof(T)].Add(subscriber);
        }

        public void Subscribe<T>(Action<T> handler)
        {
            var sub = Make(handler, once: false);
            Subscribe<T>(sub);
        }

        public void UnSubscribe<T>(Action<T> handler)
        {
            var sub = Make(handler, once: false);
            #if UNITY_EDITOR
            if (!_events.ContainsKey(typeof(T)))
            {
                Debug.LogWarning($"[EventBus] {typeof(T)} doesn't exist!");
                return;
            }
            #endif
            _events[typeof(T)].Remove(sub);
        }

        public void Publish<T>(T ev)
        {
            if (!_events.ContainsKey(typeof(T))) return;
            foreach (var subscriber in _events[typeof(T)])
            {
                subscriber.Handle(ev);
            }

            _events[typeof(T)].RemoveAll(subscriber => subscriber.Once);
        }

        public void UnSubscribeAll<T>()
        {
            #if UNITY_EDITOR
            if (!_events.ContainsKey(typeof(T)))
            {
                Debug.LogWarning($"[EventBus] {typeof(T)} doesn't exist!");
            }
            #endif
            _events[typeof(T)].Clear();
            _events.Remove(typeof(T));
        }

        public void SubscribeOnce<T>(Action<T> handler)
        {
            var sub = Make(handler, once: true);
            Subscribe<T>(sub);
        }
    }
}
