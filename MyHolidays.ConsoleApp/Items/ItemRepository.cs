using MyHolidays.Core;
using MyHolidays.Core.Models;
using MyHolidays.Core.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.ConsoleApp.Items
{
    public class ItemRepository : IRepository<Item>
    {
        private readonly InMemoryDatabase _database;

        public ItemRepository(InMemoryDatabase database)
        {
            _database = database;
        }

        public Item GetById(Guid id)
        {
            return _database.Items
                .Select(x => Item.CreateItem(x.Id, x.Label, x.Recurring))
                .First(x => x.Id == id);
        }

        public void Save(Item aggregate)
        {
            foreach (var @event in aggregate.GetChanges())
            {
                ApplyChanges(@event);
            }
        }

        private void ApplyChanges(IDomainEvent @event)
        {
            switch (@event)
            {
                case NewItemCreated e:
                    Handle(e);
                    break;
            }
        }

        private void Handle(NewItemCreated newItemCreated)
        {
            var item = new DbItem { Id = newItemCreated.Id, Label = newItemCreated.Label, Recurring = newItemCreated.Recurring };
            _database.Items.Add(item);
        }
    }
}
