using MyHolidays.Core;
using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.Infrastructure
{
    public class Repository : IRepository   
    {
        public List<IDomainEvent> Events { get; } = new List<IDomainEvent>();
        private List<AggregateRoot> _aggregates = new List<AggregateRoot>();
        private readonly AggregateFactory _aggregateFactory;

        public Repository(AggregateFactory aggregateFactory)
        {
            _aggregateFactory = aggregateFactory;
        }

        public T GetBy<T>(Guid id) where T : AggregateRoot
        {
            return _aggregates.First(x => x.Id == id) as T;
        }

        public void Save(AggregateRoot aggregate)
        {
            Events.AddRange(aggregate.GetChanges());
            _aggregates.Add(aggregate);
        }

        public void AddEvents<TAggregate>(IDomainEvent[] domainEvents)
            where TAggregate : AggregateRoot
        {
            var aggregate = _aggregateFactory.Create<TAggregate>(domainEvents);
            _aggregates.Add(aggregate);
        }
    }
}