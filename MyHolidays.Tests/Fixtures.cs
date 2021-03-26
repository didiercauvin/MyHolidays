using MyHolidays.Core;
using MyHolidays.Core.ItemUseCases;
using MyHolidays.Core.Models;
using MyHolidays.Core.TripUseCases.PrepareTrip;
using MyHolidays.Core.TripUseCases.SelectItem;
using MyHolidays.Infrastructure;
using System;
using System.Linq;
using Xunit;

namespace MyHolidays.Tests
{
    [CollectionDefinition(nameof(Fixtures))]
    public class SliceFixtureCollection : ICollectionFixture<Fixtures> { }

    public class Fixtures
    {
        private ITripRepository _tripRepository = new InMemoryTripRepository();
        private IItemRepository _itemRepository = new InMemoryItemRepository();

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

        internal void Add(Item item)
        {
            _itemRepository.Add(item);
        }

        public void Add(Trip trip)
        {
            _tripRepository.Add(trip);
        }

        public Trip GetTripWhere(Func<Trip, bool> request)
        {
            return _tripRepository.GetAll().Where(request).FirstOrDefault();
        }

        public Item GetItemWhere(Func<Item, bool> request)
        {
            return _itemRepository.GetAll().Where(request).FirstOrDefault();
        }
    }
}
