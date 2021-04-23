﻿using System;

namespace MyHolidays.Core.Models
{
    public class NewTripCreated : IDomainEvent
    {
        public NewTripCreated(Guid tripId, string label)
        {
            TripId = tripId;
            Label = label;
        }

        public Guid TripId { get; }
        public string Label { get; }
    }
}