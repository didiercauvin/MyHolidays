using System;
using System.Collections.Generic;

namespace MyHolidays.Core.Models
{
    public class Trip : Entity
    {
        public List<Item> Items = new List<Item>();
        public TripId Id { get; private set; }
        public string Label { get; set; }

        public Trip(int tripId, string label)
        {
            Id = new TripId(tripId);
            Label = label;
        }

        public void SelectItem(Item item)
        {
            Apply(new NewItemSelected(this.Id.Id, new ItemDto(item.Id.Id, item.Label)));
        }

        protected override void When(IDomainEvent ev)
        {
            switch (ev)
            {
                case NewItemSelected e:
                    Items.Add(Item.FromEvent(e.Item));
                    break;
            }
        }
    }
}
