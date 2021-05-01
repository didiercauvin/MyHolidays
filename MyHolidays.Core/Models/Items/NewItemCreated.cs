using System;

namespace MyHolidays.Core.Models.Items
{
    public class NewItemCreated : IDomainEvent
    {
        public NewItemCreated(Guid id, string label)
        {
            Id = id;
            Label = label;
        }

        public Guid Id { get; }
        public string Label { get; }
    }
}
