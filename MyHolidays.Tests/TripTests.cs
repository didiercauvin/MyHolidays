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

            var preparedTrip = Trip.CreateFrom(_fixtures.GetAllEventsFor(guid));
            Assert.Equal(guid, preparedTrip.Id.Id);
            Assert.Equal("some", preparedTrip.Label);
        }

        [Fact]
        public void SelectItem()
        {
            var itemId = Guid.NewGuid();
            var tripId = Guid.NewGuid();

            _fixtures.Execute(new PrepareTripCommand { Id = tripId, Label = "some" });

            _fixtures.Add(new Item(itemId, "item"));

            var command = new SelectItemToTripCommand { ItemId = itemId, TripId = tripId };

            _fixtures.Execute(command);

            var trip = Trip.CreateFrom(_fixtures.GetAllEventsFor(tripId));

            Assert.Equal(itemId, trip.Items[0].Id.Id);
        }

    }
}
