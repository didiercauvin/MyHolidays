using System;
using System.Collections.Generic;

namespace MyHolidays.Core.Models
{
    public class Item : EventStream
    {
        private string Label { get; set; }

        private Item(Guid id, string label)
        {
            Id = id;
            Label = label;

            Apply(new NewItemCreated(id, label));
        }

        public Item(List<IDomainEvent> events)
        {
            foreach (var ev in events)
            {
                When(ev);
            }
        }

        protected override void When(IDomainEvent ev)
        {
            switch (ev)
            {
                case NewItemCreated e:
                    this.Id = e.Id;
                    this.Label = e.Label;
                    break;
            }
        }

        public static Item Create(Guid id, string label)
        {
            return new Item(id, label);
        }

        public static Item CreateFrom(List<IDomainEvent> events)
        {
            return new Item(events);
        }
    }
}
