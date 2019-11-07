// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.Collections.ObjectModel;
using System.Windows;

namespace Microsoft.Windows.Controls.DataVisualization
{
    /// <summary>
    /// Represents a collection of Style objects.
    /// </summary>
    /// <remarks>
    /// For more information, see Microsoft.Windows.Controls.ObjectCollection.
    /// </remarks>
    /// <QualityBand>Preview</QualityBand>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "Avoids a naming conflict with the StyleCollection class defined in a different assembly.")]
    public partial class StylePalette : Collection<Style>
    {
        /// <summary>
        /// Initializes a new instance of the StylePalette class.
        /// </summary>
        public StylePalette()
        {
        }
    }
}