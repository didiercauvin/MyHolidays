using MyHolidays.Core.Models;

namespace MyHolidays.Core.TripUseCases.PrepareTrip
{
    public class PrepareTripCommand : ICommand
    {
        public string Label { get; set; }

        public class Handler : ICommandHandler<PrepareTripCommand>
        {
            private ITripRepository tripRepository;

            public Handler(ITripRepository tripRepository)
            {
                this.tripRepository = tripRepository;
            }

            public void Handle(PrepareTripCommand command)
            {
                var id = tripRepository.GetNextIdentity();
                var trip = new Trip(id, command.Label);

                tripRepository.Add(trip);
            }
        }
    }
}
