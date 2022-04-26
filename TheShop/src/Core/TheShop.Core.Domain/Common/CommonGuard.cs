namespace TheShop.Core.Domain.Common
{
    public static class CommonGuard
    {
        public static void NotNull<T>(T obj)
        {
            if(obj is null)
                throw new ArgumentNullException($"{nameof(obj)} is null");
        }

        public static void NotNullOrEmpty(string value)
        {
            if(string.IsNullOrEmpty(value))
                throw new ArgumentNullException($"{nameof(value)} is null or empty space");
        }

        public static void NotNone<T>(T obj, T noneValue) where T : Enum
        {
            if (obj.Equals(noneValue))
            {
                throw new ArgumentException($"{typeof(T).Name} has None value");
            }
        }
        public static void StringLenghtLessThanOrEqualTo(string value, int lenght)
        {
            if ((value?.Length ?? 0) > lenght)
                throw new ArgumentException($"String {value} length is longer than than {lenght}");
        }

        public static void NotNegative(decimal value)
        {
            if (value < 0)
                throw new ArgumentException($"Value {value} is less than zero.");
        }

    }
}
