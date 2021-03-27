using System;
using System.Collections.Generic;

namespace MyHolidays.Core.Models
{
    public class Trip : Entity
    {
        public List<Item> Items = new List<Item>();
        public TripId Id { get; private set; }
        public string Label { get; set; }

        private Trip(Guid tripId, string label)
        {
            Id = new TripId(tripId);
            Label = label;
            Apply(new NewTripCreated(tripId, label));
        }

        private Trip(List<IDomainEvent> tripEvents)
        {
            foreach (var ev in tripEvents)
            {
                When(ev);
            };
        }

        public void SelectItem(Item item)
        {
            var dto = new ItemDto(item.Id.Id, item.Label);
            NewItemSelected ev = new NewItemSelected(this.Id.Id, dto);
            Apply(ev);
        }

        protected override void When(IDomainEvent ev)
        {
            switch (ev)
            {
                case NewItemSelected e:
                    Items.Add(Item.FromEvent(e.Item));
                    break;
                case NewTripCreated e:
                    this.Id = new TripId(e.TripId);
                    this.Label = e.Label;
                    break;
            }
        }

        public static Trip CreateFrom(List<IDomainEvent> tripEvents)
        {
            return new Trip(tripEvents);
        }

        public static Trip CreateFor(Guid tripId, string label)
        {
            return new Trip(tripId, label);
        }
    }
}
