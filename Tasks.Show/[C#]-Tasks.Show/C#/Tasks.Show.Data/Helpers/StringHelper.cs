using System;

namespace Tasks.Show.Helpers
{
    public static class StringHelper
    {
        public static bool EasyEquals(this string a, string b)
        {
            if (a == null)
            {
                if (b == null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (b == null)
                {
                    return false;
                }
                else
                {
                    return a.Equals(b, StringComparison.InvariantCultureIgnoreCase);
                }
            }
        }

        public static string SuperTrim(this string value)
        {
            if (value != null)
            {
                value.Trim();
                if (value.Length == 0)
                {
                    value = null;
                }
            }
            return value;
        }
    }
}
