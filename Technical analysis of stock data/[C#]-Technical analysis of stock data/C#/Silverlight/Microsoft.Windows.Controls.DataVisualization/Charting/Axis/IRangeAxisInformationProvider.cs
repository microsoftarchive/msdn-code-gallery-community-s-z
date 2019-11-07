// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// Provides information to a RangeAxis.
    /// </summary>
    public interface IRangeAxisInformationProvider
    {
        /// <summary>
        /// Returns the range of values of the data to plot on the axis.
        /// </summary>
        /// <param name="rangeAxis">The axis corresponding to the range.</param>
        /// <returns>The range for the axis to include.</returns>
        Range<IComparable> GetActualRange(IRangeAxis rangeAxis);

        /// <summary>
        /// Returns the range of values for the axis to include.
        /// </summary>
        /// <param name="rangeAxis">The axis corresponding to the range.</param>
        /// <returns>The range for the axis to include.</returns>
        Range<IComparable> GetDesiredRange(IRangeAxis rangeAxis);
    }
}
