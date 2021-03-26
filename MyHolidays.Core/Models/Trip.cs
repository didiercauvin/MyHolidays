using System;
using System.Collections.Generic;

namespace MyHolidays.Core.Models
{
    public class Trip : Entity
    {
        public List<ItemId> Items = new List<ItemId>();
        public TripId Id { get; private set; }
        public string Label { get; set; }

        public Trip(int tripId, string label)
        {
            Id = new TripId(tripId);
            Label = label;
        }

        public void SelectItem(ItemId item)
        {
            Items.Add(item);
        }
    }
}
