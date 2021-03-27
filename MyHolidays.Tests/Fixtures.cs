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
        private IEventStore _eventStore;
        private ITripRepository _tripRepository;
        private IItemRepository _itemRepository;

        public Fixtures()
        {
            _eventStore = new InMemoryEventStore();
            _tripRepository = new InMemoryTripRepository(_eventStore);
            _itemRepository = new InMemoryItemRepository(_eventStore);
        }

        public ICommandHandler<TCommand> GetHandler<TCommand>()
            where TCommand : ICommand
        {
            if (typeof(TCommand) == typeof(SelectItemToTripCommand))
            {
                return (ICommandHandler<TCommand>)new SelectItemToTripCommand.Handler(_itemRepository, _eventStore);
            }

            if (typeof(TCommand) == typeof(AddItemCommand))
            {
                return (ICommandHandler<TCommand>)new AddItemCommand.Handler(_itemRepository);
            }

            return (ICommandHandler<TCommand>)new PrepareTripCommand.Handler(_tripRepository, _eventStore);
        }

        public void Execute<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            GetHandler<TCommand>().Handle(command);
        }

        internal void Add(Item item)
        {
            _itemRepository.Add(item);
        }

        public void Add(Trip trip)
        {
            _tripRepository.Add(trip);
        }

        public List<IDomainEvent> GetAllEventsFor(Guid id)
        {
             return _eventStore.GetAllEvents(id);
        }

        public Item GetItemWhere(Func<Item, bool> request)
        {
            return _itemRepository.GetAll().Where(request).FirstOrDefault();
        }
    }
}
