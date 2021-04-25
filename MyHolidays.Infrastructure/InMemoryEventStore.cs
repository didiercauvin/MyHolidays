using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.Infrastructure
{
    public class InMemoryEventStore : IEventStore
    {
        public List<EventInStore> EventsToPublish { get; } = new List<EventInStore>();

        public List<IDomainEvent> GetAllEvents(StreamIdentifier id)
        {
            return EventsToPublish
                .Where(x => x.Id == id.Value)
                .SelectMany(x => x.Events)
                .ToList();
        }

        public void Save(IEnumerable<EventInStore> events)
        {
            EventsToPublish.AddRange(events);
        }
    }
}
