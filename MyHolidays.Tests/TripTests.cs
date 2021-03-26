using MyHolidays.Core.Models;
using MyHolidays.Core.TripUseCases.PrepareTrip;
using MyHolidays.Core.TripUseCases.SelectItem;
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
            var command = new PrepareTripCommand { Label = "some" };
            var handler = _fixtures.GetHandler<PrepareTripCommand>();

            handler.Handle(command);

            var preparedTrip = _fixtures.GetTripWhere(x => x.Label == "some");
            Assert.NotNull(preparedTrip);
        }

        [Fact]
        public void SelectItem()
        {
            var command = new SelectItemToTripCommand { ItemId = 1, TripId = 1 };

            _fixtures.Add(new Trip(1, "some"));

            var handler = _fixtures.GetHandler<SelectItemToTripCommand>();

            handler.Handle(command);

            var trip = _fixtures.GetTripWhere(x => x.Id.Id == 1);

            Assert.Equal(1, trip.Items.First().Id);
        }

    }
}
