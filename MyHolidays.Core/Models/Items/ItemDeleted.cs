using System;

namespace MyHolidays.Core.Models.Items
{
    public class ItemDeleted : IDomainEvent
    {
        public ItemDeleted(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; }
    }
}
