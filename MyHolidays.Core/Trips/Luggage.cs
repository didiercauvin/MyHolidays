using MyHolidays.Core.Models;
using System;

namespace MyHolidays.Core.Trips
{
    public class Luggage : Aggregate
    {
        public string Label { get; private set; }

        private Luggage(Guid id, string label)
        {
            ApplyChange(new NewLuggageCreated(id, label));
        }

        protected override void RegisterAppliers()
        {
            RegisterApplier<NewLuggageCreated>(Apply);
        }

        public static Luggage CreateLuggage(Guid id, string label)
        {
            return new Luggage(id, label);
        }

        private void Apply(NewLuggageCreated @event)
        {
            Id = @event.Id;
            Label = @event.Label;
        }
    }
}
