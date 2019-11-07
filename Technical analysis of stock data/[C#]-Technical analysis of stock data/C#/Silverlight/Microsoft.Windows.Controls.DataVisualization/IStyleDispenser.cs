// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Windows;

namespace Microsoft.Windows.Controls.DataVisualization
{
    /// <summary>
    /// Represents a service that dispenses Styles.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    public interface IStyleDispenser
    {
        /// <summary>
        /// Returns a style matching a given target type from the pool of 
        /// available styles and removes it from the collection of styles.
        /// </summary>
        /// <param name="targetType">The target type of the requested style.
        /// </param>
        /// <param name="inherit">Whether to return ancestors of the 
        /// target type.</param>
        /// <returns>The next applicable style in the Styles collection.
        /// </returns>
        /// <remarks>
        /// When all of the styles are removed from the available pool of 
        /// styles, the styles are reset.
        /// </remarks>
        Style NextStyle(Type targetType, bool inherit);
    }
}