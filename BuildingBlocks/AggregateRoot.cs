using System;
using System.Collections.Generic;

namespace BuildingBlocks
{
    public interface IEntity
    {
        public Guid Id { get; }
    }

    public abstract class AggregateRoot : IEntity
    {
        public Guid Id { get; protected set; }

        protected List<IDomainEvent> Events { get; set; } = new List<IDomainEvent>();
        private Dictionary<Type, Action<IDomainEvent>> _appliers = new Dictionary<Type, Action<IDomainEvent>>();

        public AggregateRoot()
        {
            RegisterAppliers();
        }

        protected void ApplyChange(IDomainEvent e)
        {
            _appliers[e.GetType()](e);
            Events.Add(e);
        }

        public List<IDomainEvent> GetChanges()
        {
            return Events;
        }

        protected void RegisterApplier<TEvent>(Action<TEvent> apply) where TEvent : IDomainEvent
        {
            _appliers.Add(typeof(TEvent), x => apply((TEvent)x));
        }

        protected abstract void RegisterAppliers();

        public void Commit()
        {
            Events.Clear();
        }
    }
}
