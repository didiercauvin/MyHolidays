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
            private readonly IEventStore _eventStore;
            private IItemRepository _itemRepository;

            public Handler(IItemRepository itemRepository, IEventStore eventStore)
            {
                this._itemRepository = itemRepository;
                this._eventStore = eventStore;
            }

            public void Handle(SelectItemToTripCommand command)
            {
                var tripEvents = _eventStore.GetAllEvents(command.TripId);

                Trip trip = Trip.CreateFrom(tripEvents);
                Item item = _itemRepository.Get(command.ItemId);

                trip.SelectItem(item);

                _eventStore.Save(command.TripId, trip.GetChanges());
            }
        }

    }

}
