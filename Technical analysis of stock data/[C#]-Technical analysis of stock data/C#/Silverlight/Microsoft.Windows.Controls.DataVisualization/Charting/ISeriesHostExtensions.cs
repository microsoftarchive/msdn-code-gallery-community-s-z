// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.Collections.Generic;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// Extension methods for series hosts.
    /// </summary>
    internal static class ISeriesHostExtensions
    {
        /// <summary>
        /// Gets all series that track their global indexes recursively.
        /// </summary>
        /// <param name="rootSeriesHost">The root series host.</param>
        /// <returns>A sequence of series.</returns>
        public static IEnumerable<Series> GetDescendentSeries(this ISeriesHost rootSeriesHost)
        {
            Queue<Series> series = new Queue<Series>(rootSeriesHost.Series);
            while (series.Count != 0)
            {
                Series currentSeries = series.Dequeue();
                yield return currentSeries;

                ISeriesHost seriesHost = currentSeries as ISeriesHost;
                if (seriesHost != null)
                {
                    foreach (Series childSeries in seriesHost.Series)
                    {
                        series.Enqueue(childSeries);
                    }
                }
            }
        }
    }
}