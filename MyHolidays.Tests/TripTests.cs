using MyHolidays.Core.Models;
using MyHolidays.Core.TripUseCases.PrepareTrip;
using MyHolidays.Core.TripUseCases.SelectItem;
using System;
using System.Linq;
using Xunit;

namespace MyHolidays.Tests
{
    [Collection(nameof(Fixtures))]
    public class TripTests
    {
        private readonly Fixtures _fixtures;

        public TripTests(Fixtures fixture)
        {
            _fixtures = fixture;
        }

        [Fact]
        public void PrepareTrip()
        {
            Guid guid = Guid.NewGuid();

            var command = new PrepareTripCommand { Id = guid, Label = "some" };

            _fixtures.Execute(command);

            Assert.True(_fixtures.ContainsOnly<NewTripCreated>(x => x.TripId == guid && x.Label == "some"));
        }

        [Fact]
        public void SelectItem()
        {
            var itemId = Guid.NewGuid();
            var tripId = Guid.NewGuid();

            _fixtures.Given(tripId, new NewTripCreated(tripId, "trip"));
            _fixtures.Given(itemId, new NewItemCreated(itemId, "item"));

            var command = new SelectItemToTripCommand { ItemId = itemId, TripId = tripId };

            _fixtures.Execute(command);

            Assert.True(_fixtures.ContainsOnly<NewItemSelected>(x => x.ItemId == itemId));
        }

    }
}
