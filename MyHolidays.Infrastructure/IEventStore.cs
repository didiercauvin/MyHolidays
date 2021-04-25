using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;

namespace MyHolidays.Infrastructure
{
    public interface IEventStore
    {
        void Save(IEnumerable<EventInStore> events);
        List<IDomainEvent> GetAllEvents(Guid id);
    }
}