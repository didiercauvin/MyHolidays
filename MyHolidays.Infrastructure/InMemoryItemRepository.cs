using MyHolidays.Core;
using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.Infrastructure
{
    public class InMemoryItemRepository : IItemRepository
    {
        private List<Item> _items = new List<Item>();

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public Item Get(int itemId)
        {
            return _items.Where(x => x.Id.Id == itemId).FirstOrDefault();
        }

        public List<Item> GetAll()
        {
            return _items;
        }

        public int NextIdentity()
        {
            return _items.Select(x => x.Id.Id).FirstOrDefault() + 1;
        }
    }
}
