// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections.Generic;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// Defines an object that uses an axis.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    public interface IAxisInformationProvider
    {
        /// <summary>
        /// Returns the categories to plot on a given axis.
        /// </summary>
        /// <param name="axis">The axis for which to retrieve the categories.
        /// </param>
        /// <returns>The categories to plot on a given axis.</returns>
        IEnumerable<object> GetCategories(Axis axis);

        /// <summary>
        /// If data is found returns the minimum and maximum date values for the
        /// axis.
        /// </summary>
        /// <param name="axis">The Axis that requires the data.</param>
        /// <returns>The range of values or null if no data is present.
        /// </returns>
        Range<DateTime> GetDateTimeRange(Axis axis);

        /// <summary>
        /// If data is found returns the minimum and maximum dependent numeric 
        /// values.
        /// </summary>
        /// <param name="axis">The Axis that requires the data.</param>
        /// <returns>The range of values or null if no data is present.
        /// </returns>
        Range<double> GetNumericRange(Axis axis);

        /// <summary>
        /// Returns the minimum difference between two values on a given axis.
        /// </summary>
        /// <param name="axis">The axis to retrieve the minimum difference 
        /// for.</param>
        /// <returns>The minimum difference between two values on the specified
        /// axis.</returns>        
        double GetMinimumValueDelta(Axis axis);

        /// <summary>
        /// Returns the minimum time span between two dates on a given axis.
        /// </summary>
        /// <param name="axis">The axis to retrieve the minimum time span 
        /// for.</param>
        /// <returns>The minimum difference between two values on the specified
        /// axis.</returns>  
        TimeSpan GetMinimumTimeSpanDelta(Axis axis);
    }
}