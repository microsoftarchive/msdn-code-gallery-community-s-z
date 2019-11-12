using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace Tasks.Show.Models
{
    public static class DateParser
    {
		#region Fields 

        private static readonly Regex s_dayMatchRegex = new Regex(
            @"(^(?:next )?[a-z]{1,})\s*(.*)",
            RegexOptions.Compiled | RegexOptions.CultureInvariant | RegexOptions.IgnoreCase);

		#endregion Fields 

		#region Public Methods 

        public static Nullable<DateTime> ParseDate(string input)
        {
            if (input == null)
            {
                return null;
            }

            DateTime value;
            if (DateTime.TryParse(input, out value))
            {
                return value;
            }
            else if (tryParseDay(input, out value))
            {
                return value;
            }
            else
            {
                return null;
            }
        }

		#endregion Public Methods 

		#region Private Methods 

        private static Dictionary<string, DateTime> getMapping()
        {
            var vals = new Dictionary<string, DateTime>();
            var now = DateTime.Now.Date;
            vals["someday"] = DateTime.MaxValue;
            vals["today"] = now;
            vals["tomorrow"] = now.AddDays(1);
            for (int i = 0; i < 7; i++)
            {
                var date = now.AddDays(i);
                vals[date.DayOfWeek.ToString().ToLowerInvariant()] = date;
            }
            for (int i = 7; i < 14; i++)
            {
                var date = now.AddDays(i);
                vals[("next " + date.DayOfWeek.ToString()).ToLowerInvariant()] = date;
            }
            return vals;
        }

        private static bool tryParseDay(string input, out DateTime value)
        {
            var mapping = getMapping();
            Debug.Assert(input != null);
            value = DateTime.MinValue;

            if (s_dayMatchRegex.IsMatch(input))
            {
                var match = s_dayMatchRegex.Match(input);
                Debug.Assert(match.Groups.Count == 3);

                string maybeDay = match.Groups[1].Value.ToLowerInvariant();
                string theRest = match.Groups[2].Value;

                var matches = mapping.Keys.Where(key => key.StartsWith(maybeDay)).ToArray();
                if (matches.Length == 1)
                {
                    // we have a match!...maybe
                    maybeDay = string.Format("{0} {1}", mapping[matches[0]].ToString("yyyy-MM-dd"), theRest);
                    return DateTime.TryParse(maybeDay, out value);
                }

                return false;
            }
            else
            {
                return false;
            }
        }

		#endregion Private Methods 
    }
}
