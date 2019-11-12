// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.Diagnostics.CodeAnalysis;
using System.Windows;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// An object that provides an axis grid lines UIElement.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLines", Justification = "This is the expected capitalization.")]
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLine", Justification = "This is the expected capitalization.")]
    public interface IAxisGridLinesElementProvider
    {
        /// <summary>
        /// Gets the grid lines element used by the axis.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLines", Justification = "This is the expected capitalization.")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLine", Justification = "This is the expected capitalization.")]
        UIElement GridLinesElement
        {
            get;
        }

        /// <summary>
        /// An event raised when the grid lines element property changes.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLines", Justification = "This is the expected capitalization.")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLine", Justification = "This is the expected capitalization.")]
        event RoutedPropertyChangedEventHandler<UIElement> GridLinesElementChanged;
    }
}
