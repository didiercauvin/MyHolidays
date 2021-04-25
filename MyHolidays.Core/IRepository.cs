using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.Core
{
    public interface IRepository
    {
        T GetBy<T>(Guid id) where T : EventStream;
        void Save(EventStream aggregate);
    }
}
