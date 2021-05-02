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
        public DbItem(Guid id, string label, bool recurring)
        {
            Id = id;
            Label = label;
            Recurring = recurring;
        }

        public Guid Id { get; set; }
        public string Label { get; set; }
        public bool Recurring { get; set; }
    }
}
