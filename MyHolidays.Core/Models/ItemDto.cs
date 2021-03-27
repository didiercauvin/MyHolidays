using System;

namespace MyHolidays.Core.Models
{
    public class ItemDto
    {
        public Guid Id { get; set; }
        public string Label { get; set; }

        public ItemDto(Guid id, string label)
        {
            this.Id = id;
            this.Label = label;
        }
    }
}