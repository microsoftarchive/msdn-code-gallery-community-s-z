// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// An axis with a range.
    /// </summary>
    public interface IRangeAxis : IAxis
    {
        /// <summary>
        /// Gets the range of values displayed on the axis.
        /// </summary>
        Range<IComparable> Range { get; }

        /// <summary>
        /// The plot area coordinate of a value.
        /// </summary>
        /// <param name="value">The value for which to retrieve the plot area 
        /// coordinate.</param>
        /// <returns>The plot area coordinate.</returns>
        double GetPlotAreaCoordinate(IComparable value);

        /// <summary>
        /// The plot area coordinate of a value.
        /// </summary>
        /// <param name="coordinate">The value for which to retrieve the plot area 
        /// coordinate.</param>
        /// <returns>The plot area coordinate.</returns>
        Range<IComparable> GetPlotAreaCoordinateValueRange(double coordinate);

        /// <summary>
        /// Updates the axis with information about a provider's data range.
        /// </summary>
        /// <param name="usesRangeAxis">The information provider.</param>
        /// <param name="range">The range of data in the information provider.
        /// </param>
        void Update(IRangeAxisInformationProvider usesRangeAxis, Range<IComparable> range);
    }
}
