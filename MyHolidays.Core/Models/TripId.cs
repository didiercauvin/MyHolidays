using System;

namespace MyHolidays.Core.Models
{
    public class TripId : ValueObject<TripId>
    {
        public Guid Id { get; private set; }

        public TripId(Guid tripId)
        {
            Id = tripId;
        }
    }
}