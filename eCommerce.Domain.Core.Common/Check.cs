using System;

namespace eCommerce.Domain.Core.Common
{
    public class Check
    {
        public static void IsNull(string title, object value)
        {
            if (value == null)
                throw new ArgumentNullException($"Specified value for '{title}' is null.");
        }

        public static void IsNullOrEmpty(string title, Guid value)
        {
            if (value == null)
                throw new ArgumentNullException($"Specified value for '{title}' is null.");

            if (value != null && value == Guid.Empty)
                throw new ArgumentNullException($"Specified value for '{title}' is empty.");
        }

        public static void IsNullOrWhiteSpace(string title, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentNullException($"Specified value for '{title}' is null, empty, or consists only of white-space characters.");
        }
    }
}