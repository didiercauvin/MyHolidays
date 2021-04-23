using MyHolidays.Core.ItemUseCases;
using MyHolidays.Core.Models;
using System;
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
            Guid guid = Guid.NewGuid();
            var command = new AddItemCommand() { Id = guid, Label = "item" };

            _fixtures.Execute(command);

            _fixtures.ContainsOnly<NewItemCreated>(x => x.Label == "item");
        }
    }
}
