using System;
using System.Collections.Generic;

namespace MyHolidays.Core.Models
{
    public class Item : AggregateRoot
    {
        private string Label { get; set; }

        public ItemId ItemId { get; set; }

        public override Guid Id { get; set; }

        public Item(Guid id, string label)
        {
            Id = id;
            ItemId = new ItemId(id);
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

        public static Item FromEvent(ItemDto item)
        {
            return new Item(item.Id, item.Label);
        }

        public static Item CreateFrom(List<IDomainEvent> events)
        {
            return new Item(events);
        }
    }
}
