﻿using MyHolidays.Core;
using MyHolidays.Core.Models;
using MyHolidays.Core.UseCases.Items.AddItem;
using MyHolidays.Core.UseCases.Trips.PrepareTrip;
using MyHolidays.Core.UseCases.Trips.SelectItem;
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
        private Repository _repository;

        public Fixtures()
        {
            _eventStore = new InMemoryEventStore();
            _repository = new Repository(_eventStore, new AggregateFactory());
        }

        public bool ContainsOnly<T>(Func<T, bool> predicate)
        {
            return _eventStore.EventsToPublish
                .SelectMany(x => x.Events)
                .Where(x => x.GetType() == typeof(T)).Cast<T>()
                .Where(predicate).Count() == 1;
        }

        public void Given<TAggregate>(Guid id, IDomainEvent domainEvent)
            where TAggregate: EventStream
        {
            var identifier = new StreamIdentifier(typeof(TAggregate).Name, id);
            _eventStore.Save(new[] { new EventInStore(identifier, new[] { domainEvent }) });
        }

        public ICommandHandler<TCommand> GetHandler<TCommand>()
            where TCommand : ICommand
        {
            if (typeof(TCommand) == typeof(SelectItemToTripCommand))
            {
                return (ICommandHandler<TCommand>)new SelectItemToTripCommand.Handler(_repository);
            }

            if (typeof(TCommand) == typeof(AddItemCommand))
            {
                return (ICommandHandler<TCommand>)new AddItemCommand.Handler(_repository);
            }

            return (ICommandHandler<TCommand>)new PrepareTripCommand.Handler(_repository);
        }

        public void Execute<TCommand>(TCommand command)
            where TCommand : ICommand
        {
            GetHandler<TCommand>().Handle(command);
        }
    }
}
