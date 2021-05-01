using System;
using System.Collections.Generic;

namespace MyHolidays.Core.Models
{
    public abstract class Aggregate
    {
        protected Guid Id { get; set; }

        protected List<IDomainEvent> Events { get; set; } = new List<IDomainEvent>();

        protected void ApplyChange(IDomainEvent e)
        {
            When(e);
            Events.Add(e);
        }

        public List<IDomainEvent> GetChanges()
        {
            return Events;
        }

        protected abstract void When(IDomainEvent e);

        public void Commit()
        {
            Events.Clear();
        }
    }
}
