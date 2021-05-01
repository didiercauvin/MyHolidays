using MyHolidays.Core.Models.Items;
using System;
using System.Collections.Generic;

namespace MyHolidays.ConsoleApp
{
    public class InMemoryDatabase
    {
        public List<Item> Items { get; set; } = new List<Item>();
    }
}
