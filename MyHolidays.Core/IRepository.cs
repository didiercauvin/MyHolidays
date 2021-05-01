using MyHolidays.Core.Models;
using System;

namespace MyHolidays.Core
{
    public interface IRepository<T>
        where T: Aggregate
    {
        T GetById(Guid id);
        void Add(T aggregate);
    }
}
