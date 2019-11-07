using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// A date time interval.
    /// </summary>
    public enum DateTimeIntervalType
    {
        /// <summary>
        /// Automatically determine interval.
        /// </summary>
        Auto = 0,

        /// <summary>
        /// Interval type is milliseconds.
        /// </summary>
        Milliseconds = 1,

        /// <summary>
        /// Interval type is seconds.
        /// </summary>
        Seconds = 2,

        /// <summary>
        /// Interval type is minutes.
        /// </summary>
        Minutes = 3,

        /// <summary>
        /// Interval type is hours.
        /// </summary>
        Hours = 4,

        /// <summary>
        /// Interval type is days.
        /// </summary>
        Days = 5,

        /// <summary>
        /// Interval type is weeks.
        /// </summary>
        Weeks = 6,

        /// <summary>
        /// Interval type is months.
        /// </summary>
        Months = 7,

        /// <summary>
        /// Interval type is years.
        /// </summary>
        Years = 8,
    }
}