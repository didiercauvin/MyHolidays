using System;
using System.Collections.Generic;
using System.Linq;
using MyHolidays.Core.Models;

namespace MyHolidays.Infrastructure
{
    public class EventInStore
    {
        public string Id { get; }
        public List<IDomainEvent> Events { get; } = new List<IDomainEvent>();

        public EventInStore(StreamIdentifier id, IEnumerable<IDomainEvent> events)
        {
            this.Id = id.Value;
            Events = events.ToList();
        }
    }
}