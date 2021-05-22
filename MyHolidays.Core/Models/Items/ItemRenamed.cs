using BuildingBlocks;
using System;

namespace MyHolidays.Core.Models.Items
{
    public class ItemRenamed : IDomainEvent
    {
        public ItemRenamed(Guid id, string newLabel)
        {
            Id = id;
            NewLabel = newLabel;
        }

        public Guid Id { get; }
        public string NewLabel { get; }
    }
}
