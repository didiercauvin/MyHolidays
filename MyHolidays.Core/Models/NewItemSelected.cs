using System;

namespace MyHolidays.Core.Models
{
    public class NewItemSelected : IDomainEvent
    {
        public Guid TripId { get; set; }
        public ItemDto Item { get; set; }

        public NewItemSelected(Guid id, ItemDto item)
        {
            this.TripId = id;
            this.Item = item;
        }
    }
}