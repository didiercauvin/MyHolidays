using System;

namespace MyHolidays.Core.Models
{
    public class NewItemSelected : IDomainEvent
    {
        public Guid TripId { get; set; }
        public Guid ItemId { get; set; }

        public NewItemSelected(Guid id, Guid itemId)
        {
            this.TripId = id;
            this.ItemId = itemId;
        }
    }
}