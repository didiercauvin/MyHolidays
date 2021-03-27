using System;
using System.Collections.Generic;
using System.Linq;
using MyHolidays.Core.Models;

namespace MyHolidays.Infrastructure
{
    public class EventInStore
    {
        public Guid Id { get; set; }
        public List<IDomainEvent> Events = new List<IDomainEvent>();

        public EventInStore(Guid id, IEnumerable<IDomainEvent> events)
        {
            this.Id = id;
            Events = events.ToList();
        }
    }
}