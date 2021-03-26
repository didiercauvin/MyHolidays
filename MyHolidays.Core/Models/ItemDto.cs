namespace MyHolidays.Core.Models
{
    public class ItemDto
    {
        public int Id { get; set; }
        public string Label { get; set; }

        public ItemDto(int id, string label)
        {
            this.Id = id;
            this.Label = label;
        }
    }
}