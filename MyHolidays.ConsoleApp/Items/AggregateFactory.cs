using MyHolidays.Core.Models;
using MyHolidays.Core.Models.Items;
using System;
using System.Collections.Generic;

namespace MyHolidays.ConsoleApp.Items
{
    public class AggregateFactory
    {
        internal T Create<T>(List<IDomainEvent> domainEvents)
            where T : Aggregate
        {
            if (typeof(T) == typeof(Item))
            {
                return Item.CreateFrom(domainEvents) as T;
            }

            throw new Exception("mauvais type");
        }
    }
}