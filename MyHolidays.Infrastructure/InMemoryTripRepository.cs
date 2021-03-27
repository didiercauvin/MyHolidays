using MyHolidays.Core;
using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.Infrastructure
{
    public class InMemoryTripRepository : ITripRepository
    {
        private List<Trip> _trips = new List<Trip>();
        private readonly IEventStore _eventStore;

        public InMemoryTripRepository(IEventStore eventStore)
        {
            _eventStore = eventStore;
        }

        public Trip Get(Guid tripId)
        {
            return _trips
                .Where(x => x.Id.Id == tripId)
                .FirstOrDefault();
        }

        public void Add(Trip trip)
        {
            _trips.Add(trip);
        }

        public List<Trip> GetAll()
        {
            return _trips;
        }

        public Guid GetNextIdentity()
        {
            return Guid.NewGuid();
        }
    }
}