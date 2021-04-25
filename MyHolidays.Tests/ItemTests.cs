using MyHolidays.Core.Models;
using MyHolidays.Core.UseCases.Items.AddItem;
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

            Assert.True(_fixtures.ContainsOnly<NewItemCreated>(x => x.Id == guid && x.Label == "item"));
        }
    }
}
