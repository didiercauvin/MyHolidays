﻿using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.Infrastructure
{
    public class InMemoryEventStore : IEventStore
    {
        public List<IDomainEvent> Events { get; } = new List<IDomainEvent>();

        private List<EventInStore> _eventsToPublish = new List<EventInStore>();

        public List<IDomainEvent> GetAllEvents(StreamIdentifier id)
        {
            return _eventsToPublish
                .Where(x => x.Id == id.Value)
                .SelectMany(x => x.Events).ToList();
        }

        public void Save(IEnumerable<EventInStore> events)
        {
            Events.AddRange(events.SelectMany(x => x.Events));
            _eventsToPublish.AddRange(events);
        }

        public void AddEvents(IEnumerable<EventInStore> events)
        {
            _eventsToPublish.AddRange(events);
        }
    }
}
