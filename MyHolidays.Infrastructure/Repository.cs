using MyHolidays.Core;
using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.Infrastructure
{
    public class Repository<T> : IRepository<T>
        where T: AggregateRoot
    {
        private readonly IEventStore _eventStore;
        private readonly AggregateFactory _factory;

        public Repository(IEventStore eventStore, AggregateFactory factory)
        {
            _eventStore = eventStore;
            _factory = factory;
        }

        public T GetBy(Guid id)
        {
            return _factory.Create<T>(_eventStore.GetAllEvents(id));
        }

        public void Save(T aggregate)
        {
            _eventStore.Save(aggregate.Id, aggregate.GetChanges());
        }

        public Guid GetNextIdentity()
        {
            return Guid.NewGuid();
        }
    }
}