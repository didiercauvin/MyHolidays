using MyHolidays.Core.Models;
using System;

namespace MyHolidays.Core.UseCases.Trips.SelectItem
{
    public class SelectItemToTripCommand : ICommand
    {
        public Guid ItemId { get; set; }
        public Guid TripId { get; set; }


        public class Handler : ICommandHandler<SelectItemToTripCommand>
        {
            private readonly IRepository _repository;

            public Handler(IRepository itemRepository)
            {
                _repository = itemRepository;
            }

            public void Handle(SelectItemToTripCommand command)
            {
                Trip trip = _repository.GetBy<Trip>(command.TripId);

                trip.SelectItem(command.ItemId);

                _repository.Save(trip);
            }
        }

    }

}
