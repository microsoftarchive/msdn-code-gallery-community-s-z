// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// Represents a control that contains a data series to be rendered in bar format.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    [StyleTypedProperty(Property = "DataPointStyle", StyleTargetType = typeof(BarDataPoint))]
    [StyleTypedProperty(Property = "LegendItemStyle", StyleTargetType = typeof(LegendItem))]
    public sealed partial class BarSeries : DataPointSingleSeriesWithAxes
    {
        /// <summary>
        /// Keeps a list of DataPoints that share the same category.
        /// </summary>
        private IDictionary<object, IGrouping<object, DataPoint>> _categoriesWithMultipleDataPoints;

        /// <summary>
        /// Initializes a new instance of the BarSeries class.
        /// </summary>
        public BarSeries()
        {
        }

        /// <summary>
        /// Acquire a horizontal category axis and a vertical linear axis.
        /// </summary>
        /// <param name="firstDataPoint">The first data point.</param>
        protected override void GetAxes(DataPoint firstDataPoint)
        {
            GetCategoryAxis(
                InternalIndependentAxis,
                firstDataPoint,
                AxisOrientation.Vertical,
                () => new CategoryAxis(),
                () => ActualIndependentCategoryAxis,
                (value) => { InternalActualIndependentAxis = (IAxis) value; },
                (dataPoint) => dataPoint.IndependentValue);

            GetRangeAxis(
                InternalDependentAxis,
                firstDataPoint,
                AxisOrientation.Horizontal,
                () => 
                {
                    HybridAxis axis = (HybridAxis) CreateRangeAxisFromData(firstDataPoint.DependentValue);
                    axis.ShowGridLines = true;
                    return (IRangeAxis) axis;
                },
                () => ActualDependentRangeAxis,
                (value) => { InternalActualDependentAxis = (IAxis) value; },
                (dataPoint) => dataPoint.DependentValue);
        }

        /// <summary>
        /// Returns the style to use for all data points.
        /// </summary>
        /// <returns>The style to use for all data points.</returns>
        protected override Style GetDataPointStyleFromHost()
        {
            return SeriesHost.NextStyle(typeof(BarDataPoint), true);
        }

        /// <summary>
        /// Creates the bar data point.
        /// </summary>
        /// <returns>A bar data point.</returns>
        protected override DataPoint CreateDataPoint()
        {
            return new BarDataPoint();
        }

        /// <summary>
        /// Redraw other bar series when removed from a series host.
        /// </summary>
        /// <param name="oldValue">The old value of the series host property.
        /// </param>
        /// <param name="newValue">The new value of the series host property.
        /// </param>
        protected override void OnSeriesHostPropertyChanged(ISeriesHost oldValue, ISeriesHost newValue)
        {
            base.OnSeriesHostPropertyChanged(oldValue, newValue);

            // If being removed from series host, redraw all bar series.
            if (newValue == null || oldValue != null)
            {
                RedrawOtherBarSeries(oldValue);
            }
        }

        /// <summary>
        /// Redraws all other bar series when data points have been loaded.
        /// </summary>
        protected override void OnDataPointsLoaded()
        {
            base.OnDataPointsLoaded();

            if (this.SeriesHost != null)
            {
                RedrawOtherBarSeries(this.SeriesHost);
            }
        }

        /// <summary>
        /// Redraws other bar series to assure they allocate the right amount
        /// of space for their bars.
        /// </summary>
        /// <param name="seriesHost">The series host to update.</param>
        private void RedrawOtherBarSeries(ISeriesHost seriesHost)
        {
            // redraw all other bar series to ensure they make space for new one
            foreach (BarSeries series in seriesHost.Series.OfType<BarSeries>().Where(series => series != this))
            {
                series.UpdateAllDataPoints();
            }
        }

        /// <summary>
        /// Ensures that if the desired range is below or above zero and the
        /// data does not cross zero then the minimum of the desired range is
        /// adjusted to zero.
        /// </summary>
        /// <param name="rangeAxis">The axis to request the range for.</param>
        /// <param name="range">The range of the data.</param>
        /// <returns>The desired data range.</returns>
        protected override Range<IComparable> OverrideRequestedAxisRange(IRangeAxis rangeAxis, Range<IComparable> range)
        {
            Range<IComparable> desiredRange = base.OverrideRequestedAxisRange(rangeAxis, range);

            if (range.HasData && desiredRange.HasData)
            {
                Range<double> doubleRange = range.ToDoubleRange();
                Range<double> doubleDesiredRange = desiredRange.ToDoubleRange();
                if (rangeAxis == InternalActualDependentAxis)
                {
                    double minimum = doubleDesiredRange.Minimum;
                    double maximum = doubleDesiredRange.Maximum;

                    if (doubleRange.Minimum >= 0.0 && minimum < 0.0)
                    {
                        minimum = 0.0;
                    }
                    if (doubleRange.Maximum <= 0.0 && maximum >= 0.0)
                    {
                        maximum = 0.0;
                    }

                    return new Range<IComparable>(minimum, maximum);
                }
            }
            return desiredRange;
        }

        /// <summary>
        /// Method run before DataPoints are updated.
        /// </summary>
        protected override void OnBeforeUpdateDataPoints()
        {
            base.OnBeforeUpdateDataPoints();

            // Update the list of DataPoints with the same category
            _categoriesWithMultipleDataPoints = ActiveDataPoints
                .Where(point => null != point.IndependentValue)
                .OrderBy(point => point.DependentValue)
                .GroupBy(point => point.IndependentValue)
                .Where(grouping => 1 < grouping.Count())
                .ToDictionary(grouping => grouping.Key);
        }

        /// <summary>
        /// Gets the dependent axis as a range axis.
        /// </summary>
        public IRangeAxis ActualDependentRangeAxis { get { return this.InternalActualDependentAxis as IRangeAxis; } }

        /// <summary>
        /// Gets the independent axis as a category axis.
        /// </summary>
        public ICategoryAxis ActualIndependentCategoryAxis { get { return this.InternalActualIndependentAxis as ICategoryAxis; } }

        #region public IRangeAxis DependentRangeAxis
        /// <summary>
        /// Gets or sets the dependent range axis.
        /// </summary>
        public IRangeAxis DependentRangeAxis
        {
            get { return GetValue(DependentRangeAxisProperty) as IRangeAxis; }
            set { SetValue(DependentRangeAxisProperty, value); }
        }

        /// <summary>
        /// Identifies the DependentRangeAxis dependency property.
        /// </summary>
        public static readonly DependencyProperty DependentRangeAxisProperty =
            DependencyProperty.Register(
                "DependentRangeAxis",
                typeof(IRangeAxis),
                typeof(BarSeries),
                new PropertyMetadata(null, OnDependentRangeAxisPropertyChanged));

        /// <summary>
        /// DependentRangeAxisProperty property changed handler.
        /// </summary>
        /// <param name="d">BarSeries that changed its DependentRangeAxis.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnDependentRangeAxisPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BarSeries source = (BarSeries)d;
            IRangeAxis newValue = (IRangeAxis)e.NewValue;
            source.OnDependentRangeAxisPropertyChanged(newValue);
        }

        /// <summary>
        /// DependentRangeAxisProperty property changed handler.
        /// </summary>
        /// <param name="newValue">New value.</param>
        private void OnDependentRangeAxisPropertyChanged(IRangeAxis newValue)
        {
            this.InternalDependentAxis = (IAxis) newValue;
        }
        #endregion public IRangeAxis DependentRangeAxis

        #region public ICategoryAxis IndependentCategoryAxis
        /// <summary>
        /// Gets or sets the independent category axis.
        /// </summary>
        public ICategoryAxis IndependentCategoryAxis
        {
            get { return GetValue(IndependentCategoryAxisProperty) as ICategoryAxis; }
            set { SetValue(IndependentCategoryAxisProperty, value); }
        }

        /// <summary>
        /// Identifies the IndependentCategoryAxis dependency property.
        /// </summary>
        public static readonly DependencyProperty IndependentCategoryAxisProperty =
            DependencyProperty.Register(
                "IndependentCategoryAxis",
                typeof(ICategoryAxis),
                typeof(BarSeries),
                new PropertyMetadata(null, OnIndependentCategoryAxisPropertyChanged));

        /// <summary>
        /// IndependentCategoryAxisProperty property changed handler.
        /// </summary>
        /// <param name="d">BarSeries that changed its IndependentCategoryAxis.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnIndependentCategoryAxisPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BarSeries source = (BarSeries)d;
            ICategoryAxis newValue = (ICategoryAxis)e.NewValue;
            source.OnIndependentCategoryAxisPropertyChanged(newValue);
        }

        /// <summary>
        /// IndependentCategoryAxisProperty property changed handler.
        /// </summary>
        /// <param name="newValue">New value.</param>
        private void OnIndependentCategoryAxisPropertyChanged(ICategoryAxis newValue)
        {
            this.InternalIndependentAxis = (IAxis) newValue;
        }
        #endregion public ICategoryAxis IndependentCategoryAxis

        /// <summary>
        /// Updates each point.
        /// </summary>
        /// <param name="dataPoint">The data point to update.</param>
        protected override void UpdateDataPoint(DataPoint dataPoint)
        {
            if (SeriesHost == null || PlotArea == null)
            {
                return;
            }

            object category = dataPoint.IndependentValue ?? (this.ActiveDataPoints.IndexOf(dataPoint) + 1);
            Range<double> coordinateRange = ActualIndependentCategoryAxis.GetPlotAreaCoordinateRange(category);
            if (!coordinateRange.HasData)
            {
                return;
            }

            IEnumerable<BarSeries> barSeries = SeriesHost.Series.OfType<BarSeries>().Where(series => series.ActualIndependentCategoryAxis == ActualIndependentCategoryAxis);
            int numberOfSeries = barSeries.Count();
            double coordinateRangeHeight = (coordinateRange.Maximum - coordinateRange.Minimum);
            double segmentHeight = coordinateRangeHeight * 0.8;
            double barHeight = segmentHeight / numberOfSeries;
            int seriesIndex = barSeries.IndexOf(this);

            double dataPointX = ActualDependentRangeAxis.GetPlotAreaCoordinate(ValueHelper.ToDouble(dataPoint.ActualDependentValue));
            double zeroPointX = ActualDependentRangeAxis.GetPlotAreaCoordinate(0);

            double offset = seriesIndex * Math.Round(barHeight) + coordinateRangeHeight * 0.1;
            double dataPointY = coordinateRange.Minimum + offset;

            if (_categoriesWithMultipleDataPoints.ContainsKey(category))
            {
                // Multiple DataPoints share this category; offset and overlap them appropriately
                IGrouping<object, DataPoint> categoryGrouping = _categoriesWithMultipleDataPoints[category];
                int index = categoryGrouping.IndexOf(dataPoint);
                dataPointY += (index * (barHeight * 0.2)) / (categoryGrouping.Count() - 1);
                barHeight *= 0.8;
                Canvas.SetZIndex(dataPoint, -index);
            }

            if (ValueHelper.CanGraph(dataPointX) && ValueHelper.CanGraph(dataPointY) && ValueHelper.CanGraph(zeroPointX))
            {
                double top = Math.Round(dataPointY);
                double height = Math.Round(barHeight);

                double left = Math.Round(Math.Min(dataPointX, zeroPointX) - 0.5);
                double right = Math.Round(Math.Max(dataPointX, zeroPointX) - 0.5);
                double width = right - left + 1;

                Canvas.SetLeft(dataPoint, left);
                Canvas.SetTop(dataPoint, top);
                dataPoint.Width = width;
                dataPoint.Height = height;
            }
        }
    }
}
