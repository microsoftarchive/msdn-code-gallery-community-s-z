// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.Collections.Generic;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// Provides information to a category axis.
    /// </summary>
    public interface ICategoryAxisInformationProvider
    {
        /// <summary>
        /// Retrieves the categories to plot on the axis.
        /// </summary>
        /// <param name="axis">The axis to retrieve the categories for.</param>
        /// <returns>The categories the plot on the axis.</returns>
        IEnumerable<object> GetCategories(ICategoryAxis axis);
    }
}
