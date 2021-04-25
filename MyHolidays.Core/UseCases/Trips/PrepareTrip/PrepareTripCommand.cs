using MyHolidays.Core.Models;
using System;

namespace MyHolidays.Core.UseCases.Trips.PrepareTrip
{
    public class PrepareTripCommand : ICommand
    {
        public string Label { get; set; }
        public Guid Id { get; set; }

        public class Handler : ICommandHandler<PrepareTripCommand>
        {
            private IRepository tripRepository;

            public Handler(IRepository tripRepository)
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
