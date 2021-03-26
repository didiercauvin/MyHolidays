namespace MyHolidays.Core.Models
{
    public class TripId : ValueObject<TripId>
    {
        public int Id { get; private set; }

        public TripId(int tripId)
        {
            Id = tripId;
        }
    }
}