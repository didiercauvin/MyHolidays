using System;

namespace MyHolidays.Core
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Label { get; set; }
        public bool Recurring { get; set; }
    }
}