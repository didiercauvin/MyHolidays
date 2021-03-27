using System;
using System.Collections.Generic;

namespace MyHolidays.Core.Models
{
    public class Item : Entity
    {
        public string Label { get; set; }

        public ItemId Id { get; set; }

        public Item(Guid id, string label)
        {
            Id = new ItemId(id);
            Label = label;
        }

        protected override void When(IDomainEvent e)
        {
            
        }

        public static Item FromEvent(ItemDto item)
        {
            return new Item(item.Id, item.Label);
        }

        internal static Item CreateFrom(List<IDomainEvent> itemEvents)
        {
            throw new NotImplementedException();
        }
    }
}
