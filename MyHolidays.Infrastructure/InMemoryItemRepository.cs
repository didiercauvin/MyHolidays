using MyHolidays.Core;
using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.Infrastructure
{
    public class InMemoryItemRepository : IItemRepository
    {
        private IEventStore _eventStore;
        private List<Item> _items = new List<Item>();

        public InMemoryItemRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public Item Get(Guid itemId)
        {
            return _items.Where(x => x.Id.Id == itemId).FirstOrDefault();
        }

        public List<Item> GetAll()
        {
            return _items;
        }

        public Guid NextIdentity()
        {
            return Guid.NewGuid();
        }
    }
}
