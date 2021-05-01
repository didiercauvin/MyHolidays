using MyHolidays.Core.Models;
using MyHolidays.Core.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.Core.Trips
{
    public class Trip : Aggregate
    {
        private List<Item> _items = new List<Item>();
        public IReadOnlyCollection<Item> Items => _items;

        protected override void RegisterAppliers()
        {
            RegisterApplier<NewTripCreated>(Apply);
            RegisterApplier<TripItemAdded>(Apply);
            RegisterApplier<NewTripItemCreated>(Apply);
        }

        private Trip(Guid id, IEnumerable<Item> items)
        {
            ApplyChange(new NewTripCreated(id, items.Select(x => new ItemDto { Id = x.Id, Label = x.Label, Recurring = x.Recurring })));
        }

        public static Trip CreateTrip(Guid id, IEnumerable<Item> items)
        {
            return new Trip(id, items);
        }

        public void AddItem(Item item)
        {
            ApplyChange(new TripItemAdded(Id, new ItemDto { Id = item.Id, Label = item.Label, Recurring = item.Recurring }));
        }

        public void AddNewItem(Guid itemId, string label, bool recurring)
        {
            ApplyChange(new NewTripItemCreated(Id, itemId, label, recurring));
        }

        private void Apply(NewTripCreated @event)
        {
            Id = @event.Id;
            _items = @event.Items.Select(x => Item.FromEvent(x)).ToList();
        }

        private void Apply(TripItemAdded @event)
        {
            _items.Add(Item.FromEvent(@event.Item));
        }

        private void Apply(NewTripItemCreated @event)
        {
            _items.Add(Item.CreateItem(@event.ItemId, @event.Label, @event.Recurring));
        }
    }
}
