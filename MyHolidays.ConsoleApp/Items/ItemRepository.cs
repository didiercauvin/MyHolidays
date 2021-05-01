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
            return _database.Items.First(x => x.Id == id);
        }

        public void Add(Item aggregate)
        {
            _database.Items.Add(aggregate);
        }
    }
}
