using MyHolidays.Core;
using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.Infrastructure
{
    public class Repository : IRepository
    {
        private readonly IEventStore _eventStore;
        private readonly AggregateFactory _factory;

        public Repository(IEventStore eventStore, AggregateFactory factory)
        {
            _eventStore = eventStore;
            _factory = factory;
        }

        public T GetBy<T>(Guid id) where T : AggregateRoot
        {
            return _factory.Create<T>(_eventStore.GetAllEvents(id));
        }

        public void Save(AggregateRoot aggregate)
        {
            _eventStore.Save(new[] { new EventInStore(aggregate.Id, aggregate.GetChanges()) });
        }
    }
}