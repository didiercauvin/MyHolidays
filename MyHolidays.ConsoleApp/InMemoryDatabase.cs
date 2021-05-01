using MyHolidays.Core.Models.Items;
using System;
using System.Collections.Generic;

namespace MyHolidays.ConsoleApp
{
    public class InMemoryDatabase
    {
        public List<DbItem> Items { get; set; } = new List<DbItem>();
    }

    public class DbItem
    {
        public Guid Id { get; internal set; }
        public string Label { get; internal set; }
        public bool Recurring { get; internal set; }
    }
}
