using System;

namespace MyHolidays.Core.Models.Items
{
    public class ItemMarkedAsRecurring : IDomainEvent
    {
        public ItemMarkedAsRecurring(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
