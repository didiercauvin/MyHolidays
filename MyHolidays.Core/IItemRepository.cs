using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;

namespace MyHolidays.Core
{
    public interface IItemRepository
    {
        Item Get(Guid itemId);
        List<Item> GetAll();
        Guid NextIdentity();
        void Add(Item item);
    }
}