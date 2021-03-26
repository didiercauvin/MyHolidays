using MyHolidays.Core.Models;
using System.Collections.Generic;

namespace MyHolidays.Core
{
    public interface IItemRepository
    {
        Item Get(int itemId);
        List<Item> GetAll();
        int NextIdentity();
    }
}