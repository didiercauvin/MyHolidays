using MyHolidays.Core;
using MyHolidays.Core.ItemUseCases;
using MyHolidays.Core.Models;
using MyHolidays.Core.TripUseCases.PrepareTrip;
using MyHolidays.Core.TripUseCases.SelectItem;
using MyHolidays.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace MyHolidays.Tests
{
    [CollectionDefinition(nameof(Fixtures))]
    public class SliceFixtureCollection : ICollectionFixture<Fixtures> { }

    public class Fixtures
    {
        private InMemoryEventStore _eventStore;
        private IRepository<Trip> _tripRepository;
        private IRepository<Item> _itemRepository;

        public Fixtures()
        {
            _eventStore = new InMemoryEventStore();
            _tripRepository = new Repository<Trip>(_eventStore, new AggregateFactory());
            _itemRepository = new Repository<Item>(_eventStore, new AggregateFactory());
        }

        public bool ContainsOnly<T>(Func<T, bool> predicate)
        {
            return _eventStore.Events.Cast<T>().Where(predicate).Count() == 1;
        }

        public void Given(Guid tripId, IDomainEvent domainEvent)
        {
            _eventStore.AddEvents(tripId, new[] { domainEvent });
        }

        public ICommandHandler<TCommand> GetHandler<TCommand>()
            where TCommand : ICommand
        {
            if (typeof(TCommand) == typeof(SelectItemToTripCommand))
            {
                return (ICommandHandler<TCommand>)new SelectItemToTripCommand.Handler(_itemRepository, _tripRepository);
            }

            if (typeof(TCommand) == typeof(AddItemCommand))
            {
                return (ICommandHandler<TCommand>)new AddItemCommand.Handler(_itemRepository);
            }

            return (ICommandHandler<TCommand>)new PrepareTripCommand.Handler(_tripRepository);
        }

        public void Execute<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            _eventStore.Events.Clear();
            GetHandler<TCommand>().Handle(command);
        }
    }
}
