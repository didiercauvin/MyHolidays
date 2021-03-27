using System;

namespace MyHolidays.Core
{

    public class ItemId : ValueObject<ItemId>
    {
        public Guid Id { get; private set; }

        public ItemId(Guid itemId)
        {
            this.Id = itemId;
        }
    }
}