using System;
using System.Collections.Generic;

namespace MyHolidays.Core.Models
{
    public class Trip : EventStream
    {
        private List<Guid> Items = new List<Guid>();
        private string _label;

        public Trip()
        {

        }

        private Trip(Guid tripId, string label)
        {
            Id = tripId;
            _label = label;
            Apply(new NewTripCreated(tripId, label));
        }

        private Trip(List<IDomainEvent> tripEvents)
        {
            foreach (var ev in tripEvents)
            {
                When(ev);
            }
        }


        public void SelectItem(Guid itemId)
        {
            Apply(new NewItemSelected(this.Id, itemId));
        }

        protected override void When(IDomainEvent ev)
        {
            switch (ev)
            {
                case NewItemSelected e:
                    Items.Add(e.ItemId);
                    break;
                case NewTripCreated e:
                    this.Id = e.TripId;
                    this._label = e.Label;
                    break;
            }
        }

        public static Trip CreateFrom(List<IDomainEvent> tripEvents)
        {
            return new Trip(tripEvents);
        }

        public static Trip Create(Guid tripId, string label)
        {
            return new Trip(tripId, label);
        }
    }
}
