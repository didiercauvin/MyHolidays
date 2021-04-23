using MyHolidays.Core.ItemUseCases;
using MyHolidays.Core.Models;
using Xunit;

namespace MyHolidays.Tests
{
    [Collection(nameof(Fixtures))]
    public class ItemTests
    {
        private Fixtures _fixtures;

        public ItemTests(Fixtures fixture)
        {
            _fixtures = fixture;
        }

        [Fact]
        public void AddItem()
        {
            var command = new AddItemCommand() { Label = "item" };

            _fixtures.Execute(command);

            _fixtures.ContainsOnly<NewItemCreated>(x => x.Label == "item");
        }
    }
}
