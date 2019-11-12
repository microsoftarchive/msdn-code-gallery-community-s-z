// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Globalization;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;

namespace Microsoft.Windows.Controls.DataVisualization
{
    /// <summary>
    /// A set of functions for data conversion operations.
    /// </summary>
    internal static class ValueHelper
    {
        /// <summary>
        /// Returns a value indicating whether this value can be graphed on a 
        /// linear axis.
        /// </summary>
        /// <param name="value">The value to evaluate.</param>
        /// <returns>A value indicating whether this value can be graphed on a 
        /// linear axis.</returns>
        public static bool CanGraph(double value)
        {
            return !double.IsNaN(value) && !double.IsNegativeInfinity(value) && !double.IsPositiveInfinity(value) && !double.IsInfinity(value);
        }

        /// <summary>
        /// Attempts to convert an object into a double.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="doubleValue">The double value.</param>
        /// <returns>A value indicating whether the value can be converted to a 
        /// double.</returns>
        public static bool TryConvert(object value, out double doubleValue)
        {
            doubleValue = default(double);
            try
            {
                if (value == null)
                {
                    return false;
                }
                if (value is DateTime)
                {
                    return false;
                }
                string stringValue = value as string;
                if (stringValue != null)
                {
                    return double.TryParse(stringValue, out doubleValue);
                }

                if (value is IConvertible)
                {
                    doubleValue = ValueHelper.ToDouble(value);
                    return true;
                }
            }
            catch (FormatException)
            {
            }
            catch (InvalidCastException)
            {
            }
            return false;
        }

        /// <summary>
        /// Attempts to convert an object into a date time.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <param name="dateTimeValue">The double value.</param>
        /// <returns>A value indicating whether the value can be converted to a 
        /// date time.</returns>
        public static bool TryConvert(object value, out DateTime dateTimeValue)
        {
            dateTimeValue = default(DateTime);
            try
            {
                if (value == null)
                {
                    return false;
                }
                string dateTimeString = value as string;
                if (dateTimeString != null)
                {
                    return (DateTime.TryParse(dateTimeString, out dateTimeValue));
                }

                if (value is IConvertible)
                {
                    dateTimeValue = ValueHelper.ToDateTime(value);
                    return true;
                }
            }
            catch (FormatException)
            {
            }
            catch (InvalidCastException)
            {
            }
            return false;
        }

        /// <summary>
        /// Converts a value in an IComparable.
        /// </summary>
        /// <param name="value">The value to convert.</param>
        /// <returns>The converted value.</returns>
        public static IComparable ToComparable(object value)
        {
            double doubleValue;
            DateTime dateTimeValue;
            if (TryConvert(value, out doubleValue))
            {
                return doubleValue;
            }
            else if (TryConvert(value, out dateTimeValue))
            {
                return dateTimeValue;
            }
            IComparable comparable = value as IComparable;
            return (comparable != null);
        }

        /// <summary>
        /// Converts an object into a double.
        /// </summary>
        /// <param name="value">The value to convert to a double.</param>
        /// <returns>The converted double value.</returns>
        public static double ToDouble(object value)
        {
            return Convert.ToDouble(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a value to a date.
        /// </summary>
        /// <param name="value">The value to convert to a date.</param>
        /// <returns>The converted date value.</returns>
        public static DateTime ToDateTime(object value)
        {
            return Convert.ToDateTime(value, CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Returns a sequence of date time values from a start and end date 
        /// time inclusive.
        /// </summary>
        /// <param name="start">The start date time.</param>
        /// <param name="end">The end date time.</param>
        /// <param name="count">The number of values to return.</param>
        /// <returns>A sequence of date time values.</returns>
        public static IEnumerable<DateTime> GetDateTimesBetweenInclusive(DateTime start, DateTime end, long count)
        {
            Debug.Assert(count >= 2L, "Count must be at least 2.");

            return GetIntervalsInclusive(start.Ticks, end.Ticks, count).Select(value => new DateTime(value));
        }

        /// <summary>
        /// Returns a sequence of time span values within a time span inclusive.
        /// </summary>
        /// <param name="timeSpan">The time span to split.</param>
        /// <param name="count">The number of time spans to return.</param>
        /// <returns>A sequence of time spans.</returns>
        public static IEnumerable<TimeSpan> GetTimeSpanIntervalsInclusive(TimeSpan timeSpan, long count)
        {
            Debug.Assert(count >= 2L, "Count must be at least 2.");

            long distance = timeSpan.Ticks;

            return GetIntervalsInclusive(0, distance, count).Select(value => new TimeSpan(value));
        }

        /// <summary>
        /// Returns that intervals between a start and end value, including those
        /// start and end values.
        /// </summary>
        /// <param name="start">The start value.</param>
        /// <param name="end">The end value.</param>
        /// <param name="count">The total number of intervals.</param>
        /// <returns>A sequence of intervals.</returns>
        public static IEnumerable<long> GetIntervalsInclusive(long start, long end, long count)
        {
            Debug.Assert(count >= 2L, "Count must be at least 2.");

            long interval = end - start;
            for (long i = 0; i < count; i++)
            {
                double ratio = (double)i / (double)(count - 1);
                long value = (long)((ratio * interval) + start);
                yield return value;
            }
        }

        /// <summary>
        /// Removes the noise from double math.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>A double without a noise.</returns>
        internal static double RemoveNoiseFromDoubleMath(double value)
        {
            if (value == 0.0 || Math.Abs((Math.Log10(Math.Abs(value)))) < 27)
            {
                return (double)((decimal)value);
            }
            return Double.Parse(value.ToString(CultureInfo.InvariantCulture), CultureInfo.InvariantCulture);
        }

        /// <summary>
        /// Converts a range into a double range.
        /// </summary>
        /// <param name="range">The range to convert.</param>
        /// <returns>A range with its members converted to doubles.</returns>
        public static Range<double> ToDoubleRange(this Range<IComparable> range)
        {
            if (!range.HasData)
            {
                return new Range<double>();
            }
            else
            {
				if (range.Minimum is DateTime && range.Maximum is DateTime)
				{
					return new Range<double>(((DateTime)range.Minimum).ToOADate(), ((DateTime)range.Maximum).ToOADate());
				}
				else
				{
					return new Range<double>((double)range.Minimum, (double)range.Maximum);
				}
            }
        }

        /// <summary>
        /// Compares two IComparables returning -1 if the left is null and 1 if
        /// the right is null.
        /// </summary>
        /// <param name="left">The left comparable.</param>
        /// <param name="right">The right comparable.</param>
        /// <returns>A value indicating which is larger.</returns>
        public static int Compare(IComparable left, IComparable right)
        {
            if (left == null && right == null)
            {
                return 0;
            }
            else if (left == null && right != null)
            {
                return -1;
            }
            else if (left != null && right == null)
            {
                return 1;
            }
            else
            {
                return left.CompareTo(right);
            }    
        }
    }
}