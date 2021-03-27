using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;

namespace MyHolidays.Core
{
    public interface IEventStore
    {
        void Save(Guid id, IEnumerable<IDomainEvent> domainEvents);
        List<IDomainEvent> GetAllEvents(Guid id);
    }
}