namespace MyHolidays.Core
{
    public abstract class ValueObject<T>
    {
        protected abstract bool BaseEquals(T other);
        protected abstract int BaseGetHashCode();

        public override bool Equals(object obj)
        {
            if (obj is T other)
            {
                return BaseEquals((T)obj);
            }

            return false;

        }

        public override int GetHashCode()
        {
            return BaseGetHashCode();
        }
    }
}