namespace MyHolidays.Core.Models
{
    public class NewItemSelected : IDomainEvent
    {
        public int TripId { get; set; }
        public ItemDto Item { get; set; }

        public NewItemSelected(int id, ItemDto item)
        {
            this.TripId = id;
            this.Item = item;
        }
    }
}