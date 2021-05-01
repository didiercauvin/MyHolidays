using MyHolidays.Core.Models;
using System;

namespace MyHolidays.Core.Trips
{
    public class NewTripItemCreated : IDomainEvent
    {
        public NewTripItemCreated(Guid id, Guid itemId, string label, bool recurring)
        {
            Id = id;
            Label = label;
            Recurring = recurring;
            ItemId = itemId;
        }

        public Guid Id { get; }
        public Guid ItemId { get; }
        public string Label { get; }
        public bool Recurring { get; }
    }
}
