using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.Core.Trips
{
    public class NewTripCreated : IDomainEvent
    {
        public NewTripCreated(Guid id, IEnumerable<ItemDto> items)
        {
            Id = id;
            Items = items.ToList();
        }

        public Guid Id { get; }
        public List<ItemDto> Items { get; }
    }
}
