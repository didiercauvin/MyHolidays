using MyHolidays.Core;
using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.ConsoleApp.Items
{
    public class EventSourcingRepository<T> : IRepository<T>
        where T: Aggregate
    {
        private readonly IEventStore _eventStore;
        private readonly AggregateFactory _factory;

        public EventSourcingRepository(IEventStore eventStore, AggregateFactory factory)
        {
            _eventStore = eventStore;
            _factory = factory;
        }

        public T GetById(Guid id)
        {
            return _factory.Create<T>(_eventStore.GetAllEvents(id));
        }

        public void Save(T aggregate)
        {
            _eventStore.Save(new[] { new EventInStore(aggregate.Id, aggregate.GetChanges()) });

            aggregate.Commit();
        }
    }
}
