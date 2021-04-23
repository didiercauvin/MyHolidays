using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.Core
{
    public interface IRepository<T>
        where T: AggregateRoot
    {
        T GetBy(Guid id);
        void Save(T aggregate);
    }
}
