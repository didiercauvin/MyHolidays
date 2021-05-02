using MyHolidays.Core.Models;
using MyHolidays.Core.Models.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.Core.Trips
{
    public class Trip : Aggregate
    {
        public DateAller Aller { get; private set; }
        public DateRetour Retour { get; private set; }

        protected override void RegisterAppliers()
        {
            RegisterApplier<NewTripCreated>(Apply);
        }

        private Trip(Guid id, DateAller aller, DateRetour retour)
        {
            ApplyChange(new NewTripCreated(id, aller.Date, retour.Date));
        }

        public static Trip CreateTrip(Guid id, DateAller aller, DateRetour retour)
        {
            return new Trip(id, aller, retour);
        }

        public Luggage CreateLuggage(Guid id, string label)
        {
            return Luggage.CreateLuggage(id, label);
        }


        private void Apply(NewTripCreated @event)
        {
            Id = @event.Id;
            Aller = new DateAller(@event.Aller);
            Retour = new DateRetour(@event.Retour);
        }

    }
}
