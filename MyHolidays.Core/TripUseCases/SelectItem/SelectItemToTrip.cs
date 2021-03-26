using MyHolidays.Core.Models;

namespace MyHolidays.Core.TripUseCases.SelectItem
{
    public class SelectItemToTripCommand : ICommand
    {
        public int ItemId { get; set; }
        public int TripId { get; set; }

        public class Handler : ICommandHandler<SelectItemToTripCommand>
        {
            private readonly ITripRepository _tripRepository;

            public Handler(ITripRepository tripRepository)
            {
                _tripRepository = tripRepository;
            }

            public void Handle(SelectItemToTripCommand command)
            {
                Trip trip = _tripRepository.Get(command.TripId);

                trip.SelectItem(new ItemId(command.ItemId));
            }
        }

    }

}
