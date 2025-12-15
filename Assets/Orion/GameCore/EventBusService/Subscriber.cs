using System;

namespace Orion.GameCore.EventBusService
{
    public readonly struct Subscriber : IEquatable<Subscriber>
    {
        private readonly Delegate _handler;
        private readonly bool _once;

        public bool Once => _once;

        public Subscriber(Delegate handler, bool once)
        {
            _handler = handler;
            _once = once;
        }

        public void Handle<T>(T @event)
        {
            (_handler as Action<T>)?.Invoke(@event);
        }

        public bool Equals(Subscriber other)
        {
            return Equals(_handler, other._handler) && _once == other._once;
        }

        public override bool Equals(object obj)
        {
            return obj is Subscriber other && Equals(other);
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_handler, _once);
        }
    }
}