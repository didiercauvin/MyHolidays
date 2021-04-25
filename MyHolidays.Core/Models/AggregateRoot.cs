using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.Core.Models
{
    public abstract class AggregateRoot
    {
        public Guid Id { get; set; }

        protected List<IDomainEvent> Events { get; set; } = new List<IDomainEvent>();

        protected void Apply(IDomainEvent e)
        {
            When(e);
            Events.Add(e);
        }

        public List<IDomainEvent> GetChanges()
        {
            return Events;
        }

        protected abstract void When(IDomainEvent e);
    }
}
