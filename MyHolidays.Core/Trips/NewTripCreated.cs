using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.Core.Trips
{
    public class NewTripCreated : IDomainEvent
    {
        public NewTripCreated(Guid id, DateTime aller, DateTime retour)
        {
            Id = id;
            Aller = aller;
            Retour = retour;
        }

        public Guid Id { get; }
        public DateTime Aller { get; }
        public DateTime Retour { get; }
    }
}
