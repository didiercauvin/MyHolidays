using System;

namespace MyHolidays.Core.Trips
{
    public class DateAller : ValueObject<DateAller>
    {
        public DateAller(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; }

        protected override bool BaseEquals(DateAller other)
        {
            return Date == other.Date;
        }

        protected override int BaseGetHashCode()
        {
            return Date.GetHashCode();
        }
    }
}