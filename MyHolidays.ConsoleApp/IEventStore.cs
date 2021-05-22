using BuildingBlocks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.ConsoleApp
{
    public interface IEventStore
    {
        void Save(IEnumerable<EventInStore> events);
        List<IDomainEvent> GetAllEvents(Guid id);
    }
}
