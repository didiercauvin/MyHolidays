namespace MyHolidays.Core
{

    public class ItemId : ValueObject<ItemId>
    {
        public int Id { get; private set; }

        public ItemId(int itemId)
        {
            this.Id = itemId;
        }
    }
}