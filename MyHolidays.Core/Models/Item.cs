namespace MyHolidays.Core.Models
{
    public class Item : Entity
    {
        public string Label { get; set; }

        public ItemId Id { get; set; }

        public Item(int id, string label)
        {
            Id = new ItemId(id);
            Label = label;
        }
    }
}
