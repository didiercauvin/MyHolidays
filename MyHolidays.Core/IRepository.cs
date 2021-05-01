using MyHolidays.Core.Models;
using System;

namespace MyHolidays.Core
{
    public interface IRepository
    {
        T GetBy<T>(Guid id) where T : Aggregate, new();
        void Save(Aggregate aggregate);
    }
}
