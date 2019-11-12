using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;
using PixelLab.Common;

namespace Tasks.Show.Models
{
    public static class TaskParser
    {
		#region Fields 

        private const string c_importantChar = "!";
        private const char c_markerChar = ':';
        // {0} |-separated list of markers
        // {1} Marker Char
        private const string c_markerRegExFormat = @"(?:\s+|^)(?:({0}){1})";
        private static readonly Regex s_regex = new Regex(
            string.Format(c_markerRegExFormat, getMarkerNamesRegex(), c_markerChar),
            RegexOptions.IgnoreCase | RegexOptions.Compiled | RegexOptions.CultureInvariant);

		#endregion Fields 

		#region Enums 

        private enum TaskMarker { AT, IN, FOR, IMPORTANT, ON, BY };

		#endregion Enums 

		#region Public Methods 

        public static DraftTask Parse(string value)
        {
            string error = null;
            var task = TryParse(value, out error);
            if (error != null)
            {
                throw new ArgumentException(error, "value");
            }
            return task;
        }

        public static DraftTask TryParse(string value, out string error)
        {
            Util.RequireNotNull(value, "value");
            var task = new DraftTask();

            var tokens = tokenize(value);

            if (tokens.Count > 0 && tokens[0] is string)
            {
                var description = (string)tokens[0];
                if (description != null)
                {
                    Debug.Assert(description == description.Trim());
                    if (description.StartsWith(c_importantChar))
                    {
                        task.IsImportant = true;
                        description = description.Substring(c_importantChar.Length);
                    }
                    else if (description.EndsWith(c_importantChar))
                    {
                        task.IsImportant = true;
                    }
                }

                task.Description = description;
            }
            else
            {
                task.Description = null;
            }

            var markers = new Dictionary<TaskMarker, string>();

            for (int i = 0; i < tokens.Count; i++)
            {
                if (tokens[i] is TaskMarker)
                {
                    var marker = (TaskMarker)tokens[i];
                    var val = stringAtIndex(tokens, i + 1);
                    if (markers.ContainsKey(marker))
                    {
                        error = string.Format("Got many instances of {0}", marker);
                        return null;
                    }
                    else
                    {
                        markers.Add(marker, val);
                    }
                }
            }

            if (markers.ContainsKey(TaskMarker.IN))
            {
                task.FolderName = markers[TaskMarker.IN];
            }
            if (markers.ContainsKey(TaskMarker.ON))
            {
                var onString = markers[TaskMarker.ON];

                Nullable<DateTime> onValue = DateParser.ParseDate(onString);
                task.Due = onValue;
                if (!onValue.HasValue)
                {
                    error = string.Format("Could not parse '{0}'.", onString);
                    return null;
                }
            }

            error = null;
            return task;
        }

		#endregion Public Methods 

		#region Private Methods 

        private static string getMarkerName(TaskMarker tm)
        {
            return Enum.GetName(typeof(TaskMarker), tm);
        }

        private static string getMarkerNamesRegex()
        {
            var names = Enum.GetNames(typeof(TaskMarker));
            return names.Aggregate((current, next) => { return current + "|" + next; });
        }

        private static TaskMarker parseMarker(string markerString)
        {
            markerString = markerString.ToUpperInvariant();
            var marker = (TaskMarker)Enum.Parse(typeof(TaskMarker), markerString);

            // BY is an alias for ON
            marker = (marker == TaskMarker.BY) ? TaskMarker.ON : marker;

            return marker;
        }

        private static string stringAtIndex(IList<object> objects, int index)
        {
            if (index >= objects.Count)
            {
                return null;
            }
            else
            {
                return objects[index] as string;
            }
        }

        private static List<object> tokenize(string input)
        {
            Debug.Assert(input != null);

            var objects = new List<object>();

            do
            {
                input = input.Trim();
                var match = s_regex.Match(input);

                if (match.Success)
                {
                    match.Groups.Cast<Group>().ToArray();
                    string first = input.Substring(0, match.Index);
                    objects.Add(first);

                    TaskMarker second = parseMarker(match.Groups[1].Value);
                    objects.Add(second);

                    input = input.Substring(match.Index + match.Length);
                }
                else
                {
                    objects.Add(input);
                    input = "";
                }

            } while (input.Length > 0);

            return objects;
        }

		#endregion Private Methods 
    }

}
