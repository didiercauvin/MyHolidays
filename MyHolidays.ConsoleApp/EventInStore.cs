using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.ConsoleApp
{
    public class EventInStore
    {
        public Guid Id { get; }
        public List<IDomainEvent> Events { get; } = new List<IDomainEvent>();

        public EventInStore(Guid id, IEnumerable<IDomainEvent> events)
        {
            this.Id = id;
            Events = events.ToList();
        }
    }
}