using MyHolidays.Core.Models;
using System;

namespace MyHolidays.Core.Trips
{
    public class TripItemAdded : IDomainEvent
    {
        public TripItemAdded(Guid id, ItemDto item)
        {
            Id = id;
            Item = item;
        }

        public Guid Id { get; }
        public ItemDto Item { get; }
    }
}
