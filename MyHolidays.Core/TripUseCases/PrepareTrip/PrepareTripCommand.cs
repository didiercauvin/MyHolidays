using MyHolidays.Core.Models;
using System;

namespace MyHolidays.Core.TripUseCases.PrepareTrip
{
    public class PrepareTripCommand : ICommand
    {
        public string Label { get; set; }
        public System.Guid Id { get; set; }

        public class Handler : ICommandHandler<PrepareTripCommand>
        {
            private IRepository<Trip> tripRepository;

            public Handler(IRepository<Trip> tripRepository)
            {
                this.tripRepository = tripRepository;
            }

            public void Handle(PrepareTripCommand command)
            {
                var trip = Trip.CreateFor(command.Id, command.Label);

                tripRepository.Save(trip);
            }
        }
    }
}
