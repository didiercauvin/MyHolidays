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
            private IRepository _repository;

            public Handler(IRepository repository)
            {
                this._repository = repository;
            }

            public void Handle(PrepareTripCommand command)
            {
                var trip = Trip.Create(command.Id, command.Label);

                _repository.Save(trip);
            }
        }
    }
}
