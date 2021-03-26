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
            private readonly IItemRepository _itemRepository;

            public Handler(
                IItemRepository itemRepository,
                ITripRepository tripRepository)
            {
                _tripRepository = tripRepository;
                _itemRepository = itemRepository;
            }

            public void Handle(SelectItemToTripCommand command)
            {
                Trip trip = _tripRepository.Get(command.TripId);
                Item item = _itemRepository.Get(command.ItemId);

                trip.SelectItem(item);
            }
        }

    }

}
