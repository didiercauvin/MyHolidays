using System;

namespace MyHolidays.Core.Models.Items
{
    public class NewItemCreated : IDomainEvent
    {
        public NewItemCreated(Guid id, string label, bool recurring)
        {
            Id = id;
            Label = label;
            Recurring = recurring;
        }

        public Guid Id { get; }
        public string Label { get; }
        public bool Recurring { get; }
    }
}
