﻿using MyHolidays.Core.ItemUseCases;
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
            var handler = _fixtures.GetHandler<AddItemCommand>();

            handler.Handle(command);

            var item = _fixtures.GetItemWhere(x => x.Label == "item");

            Assert.NotNull(item);
        }
    }
}
