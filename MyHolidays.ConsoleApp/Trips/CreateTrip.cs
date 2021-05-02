using MyHolidays.Core;
using MyHolidays.Core.Trips;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyHolidays.ConsoleApp.Trips
{
    public class CreateTripCommand : ICommand
    {
        public Guid Id { get; set; }
        public DateAller DateAller { get; set; }
        public DateRetour DateRetour { get; set; }

        public class Handler : ICommandHandler<CreateTripCommand>
        {
            private readonly IRepository<Trip> _repository;

            public Handler(IRepository<Trip> repository)
            {
                _repository = repository;
            }

            public void Handle(CreateTripCommand command)
            {
                var trip = Trip.CreateTrip(command.Id, command.DateAller, command.DateRetour);

                _repository.Save(trip);
            }
        }
    }
}
