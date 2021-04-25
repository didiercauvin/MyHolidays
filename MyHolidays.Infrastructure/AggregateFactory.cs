using MyHolidays.Core.Models;
using System;
using System.Collections.Generic;

namespace MyHolidays.Infrastructure
{
    public class AggregateFactory
    {
        internal T Create<T>(IEnumerable<IDomainEvent> domainEvents)
            where T: AggregateRoot
        {
            if (typeof(T) == typeof(Trip))
            {
                return Trip.CreateFrom(domainEvents) as T;
            }

            if (typeof(T) == typeof(Item))
            {
                return Item.CreateFrom(domainEvents) as T;
            }

            throw new Exception("mauvais type");
        }
    }
}