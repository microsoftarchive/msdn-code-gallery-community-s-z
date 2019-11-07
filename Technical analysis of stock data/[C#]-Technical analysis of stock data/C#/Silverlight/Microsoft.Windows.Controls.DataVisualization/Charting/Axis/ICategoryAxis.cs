// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// An axis that is arranged by category.
    /// </summary>
    public interface ICategoryAxis : IAxis
    {
        /// <summary>
        /// Accepts a category and returns the coordinate range of that category
        /// on the axis.
        /// </summary>
        /// <param name="category">A category for which to retrieve the 
        /// coordinate location.</param>
        /// <returns>The coordinate range of the category on the axis.</returns>        
        Range<double> GetPlotAreaCoordinateRange(object category);

        /// <summary>
        /// Returns the category at a given coordinate.
        /// </summary>
        /// <param name="coordinate">The plot are coordinate.</param>
        /// <returns>The category at the given plot area coordinate.</returns>
        object GetCategoryAtPlotAreaCoordinate(double coordinate);

        /// <summary>
        /// Informs the axis which categories to plot.
        /// </summary>
        /// <param name="usesCategoryAxis">The information provider.</param>
        /// <param name="categories">The categories used by the information 
        /// provider.</param>
        void Update(ICategoryAxisInformationProvider usesCategoryAxis, IEnumerable<object> categories);
    }
}
