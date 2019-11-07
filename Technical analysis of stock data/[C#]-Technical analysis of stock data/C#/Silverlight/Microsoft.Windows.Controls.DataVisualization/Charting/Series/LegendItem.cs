// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.ComponentModel;
using System.Windows.Media;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// Represents an item used by a Series in the Legend of a Chart.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    public class LegendItem : ContentControl
    {
        /// <summary>
        /// Initializes a new instance of the LegendItem class.
        /// </summary>
        public LegendItem()
        {
            this.DefaultStyleKey = typeof(LegendItem);
        }
    }
}
