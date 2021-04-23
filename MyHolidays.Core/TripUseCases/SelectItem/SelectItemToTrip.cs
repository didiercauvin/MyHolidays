using MyHolidays.Core.Models;
using System;

namespace MyHolidays.Core.TripUseCases.SelectItem
{
    public class SelectItemToTripCommand : ICommand
    {
        public Guid ItemId { get; set; }
        public Guid TripId { get; set; }


        public class Handler : ICommandHandler<SelectItemToTripCommand>
        {
            private readonly IRepository<Item> _itemRepository;
            private readonly IRepository<Trip> _tripRepository;

            public Handler(IRepository<Item> itemRepository, IRepository<Trip> tripRepository)
            {
                this._itemRepository = itemRepository;
                _tripRepository = tripRepository;
            }

            public void Handle(SelectItemToTripCommand command)
            {
                Trip trip = _tripRepository.GetBy(command.TripId);
                Item item = _itemRepository.GetBy(command.ItemId);

                trip.SelectItem(item.Id);

                _tripRepository.Save(trip);
            }
        }

    }

}
