using MyHolidays.Core;
using MyHolidays.Core.Models;
using System.Collections.Generic;
using System.Linq;

namespace MyHolidays.Infrastructure
{
    public class InMemoryTripRepository : ITripRepository
    {
        private List<Trip> _trips = new List<Trip>();

        public Trip Get(int tripId)
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

        public int GetNextIdentity()
        {
            return _trips.Select(x => x.Id.Id).FirstOrDefault() + 1;
        }
    }
}