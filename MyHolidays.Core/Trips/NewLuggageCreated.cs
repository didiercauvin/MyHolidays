using BuildingBlocks;
using MyHolidays.Core.Models;
using System;

namespace MyHolidays.Core.Trips
{
    public class NewLuggageCreated : IDomainEvent
    {
        public NewLuggageCreated(Guid id, string label)
        {
            Id = id;
            Label = label;
        }

        public Guid Id { get; }
        public string Label { get; }
    }
}