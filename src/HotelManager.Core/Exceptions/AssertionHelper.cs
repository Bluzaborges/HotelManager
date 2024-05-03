using HotelManager.Abstraction.Exceptions;

namespace HotelManager.Core.Exceptions
{
    public class AssertionHelper
    {
        public static void ArgumentNotEmpty(string? value, string message)
        {
            if (string.IsNullOrEmpty(value) || value.Trim().Length == 0)
            {
                throw new UserFriendlyException(message);
            }
        }

        public static void ArgumentLength(string? value, int max, string message)
        {
            var length = value?.Trim().Length;
            if (length > max)
            {
                throw new UserFriendlyException(message);
            }
        }

        public static void ArgumentLessThanOrEqual(DateTime value, DateTime min, string message)
        {
            if (value <= min)
            {
                throw new UserFriendlyException(message);
            }
        }

        public static void ArgumentLessThanOrEqual(double value, double min, string message)
        {
            if (value <= min)
            {
                throw new UserFriendlyException(message);
            }
        }

        public static void ArgumentLessThan(DateTime value, DateTime min, string message)
        {
            if (value < min)
            {
                throw new UserFriendlyException(message);
            }
        }

        public static void ArgumentLessThan(double value, double min, string message)
        {
            if (value < min)
            {
                throw new UserFriendlyException(message);
            }
        }

        public static void ArgumentGraterThan(DateTime value, DateTime max, string message)
        {
            if (value > max)
            {
                throw new UserFriendlyException(message);
            }
        }
    }
}