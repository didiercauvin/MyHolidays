using System;

namespace MyHolidays.Core.Models
{
    public class Item : Entity
    {
        public string Label { get; set; }

        public ItemId Id { get; set; }

        public Item(int id, string label)
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
    }
}
