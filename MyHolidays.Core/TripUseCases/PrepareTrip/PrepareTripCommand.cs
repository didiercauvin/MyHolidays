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
            private ITripRepository tripRepository;
            private readonly IEventStore _eventStore;

            public Handler(ITripRepository tripRepository, IEventStore eventStore)
            {
                this.tripRepository = tripRepository;
                _eventStore = eventStore;
            }

            public void Handle(PrepareTripCommand command)
            {
                var trip = Trip.CreateFor(command.Id, command.Label);

                _eventStore.Save(command.Id, trip.GetChanges());
            }
        }
    }
}
