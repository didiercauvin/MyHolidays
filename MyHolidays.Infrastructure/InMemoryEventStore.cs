using MyHolidays.Core;
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
        private List<EventInStore> _eventsToPublish = new List<EventInStore>();

        public List<IDomainEvent> GetAllEvents(Guid id)
        {
            return _eventsToPublish
                .Where(x => x.Id == id)
                .SelectMany(x => x.Events).ToList();
        }

        public void Save(Guid id, IEnumerable<IDomainEvent> domainEvents)
        {
            _eventsToPublish.Add(new EventInStore(id, domainEvents));
        }
    }
}
