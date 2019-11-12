// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// Defines properties, methods and events for classes that host a 
    /// collection of Series objects.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    public interface ISeriesHost : IStyleDispenser
    {
        /// <summary>
        /// Gets the parent host of the series host.
        /// </summary>
        ISeriesHost Parent { get; }

        /// <summary>
        /// Gets the collection of axes the series host has available.
        /// </summary>
        ReadOnlyCollection<IAxis> Axes { get; }

        /// <summary>
        /// Gets the collection of series the series host has available.
        /// </summary>
        IList<Series> Series { get; }

        /// <summary>
        /// Signals to a series host that a specified series no longer 
        /// requires the use of the specified axis.
        /// </summary>
        /// <param name="series">The series that does not require the axis.
        /// </param>
        /// <param name="axis">The axis that is not required.
        /// </param>
        void UnregisterWithAxis(Series series, IAxis axis);

        /// <summary>
        /// Signals to the series host that the specified series requires the 
        /// specified axis.
        /// </summary>
        /// <param name="series">The series that requires the axis.
        /// </param>
        /// <param name="axis">The axis the series requires.</param>
        void RegisterWithAxis(Series series, IAxis axis);

        /// <summary>
        /// Occurs when the series descendents in the series host have changed.
        /// </summary>
        event RoutedEventHandler GlobalSeriesIndexesInvalidated;
    }
}