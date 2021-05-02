using System;

namespace MyHolidays.Core.Trips
{
    public class DateRetour : ValueObject<DateRetour>
    {
        public DateRetour(DateTime date)
        {
            Date = date;
        }

        public DateTime Date { get; }

        protected override bool BaseEquals(DateRetour other)
        {
            return Date == other.Date;
        }

        protected override int BaseGetHashCode()
        {
            return Date.GetHashCode();
        }
    }
}