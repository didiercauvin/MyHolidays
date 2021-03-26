using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.Core.Models
{
    public abstract class Entity
    {
        protected List<IDomainEvent> Events { get; set; } = new List<IDomainEvent>();

        protected void Apply(IDomainEvent e)
        {
            When(e);
            Events.Add(e);
        }

        protected abstract void When(IDomainEvent e);
    }
}
