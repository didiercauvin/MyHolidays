using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;

namespace MyHolidays.Core
{
    public interface ITripRepository
    {
        Trip Get(int tripId);
        int GetNextIdentity();
        void Add(Trip trip);
        List<Trip> GetAll();
    }
}