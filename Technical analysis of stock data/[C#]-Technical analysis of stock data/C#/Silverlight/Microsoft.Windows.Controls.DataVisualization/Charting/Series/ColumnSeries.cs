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
    /// Represents a control that contains a data series to be rendered in column format.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    [StyleTypedProperty(Property = "DataPointStyle", StyleTargetType = typeof(ColumnDataPoint))]
    [StyleTypedProperty(Property = "LegendItemStyle", StyleTargetType = typeof(LegendItem))]
    public sealed partial class ColumnSeries : DataPointSingleSeriesWithAxes
    {
        /// <summary>
        /// Keeps a list of DataPoints that share the same category.
        /// </summary>
        private IDictionary<object, IGrouping<object, DataPoint>> _categoriesWithMultipleDataPoints;

        /// <summary>
        /// Initializes a new instance of the ColumnSeries class.
        /// </summary>
        public ColumnSeries()
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
                AxisOrientation.Horizontal,
                () => new CategoryAxis(),
                () => ActualIndependentCategoryAxis,
                (value) => { InternalActualIndependentAxis = (IAxis)value; },
                (dataPoint) => dataPoint.IndependentValue);

            GetRangeAxis(
                InternalDependentAxis,
                firstDataPoint,
                AxisOrientation.Vertical,
                () =>
                {
                    HybridAxis axis = (HybridAxis) CreateRangeAxisFromData(firstDataPoint.DependentValue);
                    axis.ShowGridLines = true;
                    return (IRangeAxis) axis;
                },
                () => ActualDependentRangeAxis,
                (value) => { InternalActualDependentAxis = (IAxis)value; },
                (dataPoint) => dataPoint.DependentValue);
        }

        /// <summary>
        /// Creates the column data point.
        /// </summary>
        /// <returns>A column data point.</returns>
        protected override DataPoint CreateDataPoint()
        {
            return new ColumnDataPoint();
        }

        /// <summary>
        /// Redraw other column series when removed from a series host.
        /// </summary>
        /// <param name="oldValue">The old value of the series host property.</param>
        /// <param name="newValue">The new value of the series host property.</param>
        protected override void OnSeriesHostPropertyChanged(ISeriesHost oldValue, ISeriesHost newValue)
        {
            base.OnSeriesHostPropertyChanged(oldValue, newValue);

            // If being removed from series host, redraw all column series.
            if (newValue == null || oldValue != null)
            {
                RedrawOtherColumnSeries(oldValue);
            }
        }

        /// <summary>
        /// Redraws all other column series when data points have been loaded.
        /// </summary>
        protected override void OnDataPointsLoaded()
        {
            base.OnDataPointsLoaded();

            if (this.SeriesHost != null)
            {
                RedrawOtherColumnSeries(this.SeriesHost);
            }
        }

        /// <summary>
        /// Redraws other column series to assure they allocate the right amount
        /// of space for their columns.
        /// </summary>
        /// <param name="seriesHost">The series host to update.</param>
        private void RedrawOtherColumnSeries(ISeriesHost seriesHost)
        {
            // redraw all other column series to ensure they make space for new one
            foreach (ColumnSeries series in seriesHost.Series.OfType<ColumnSeries>().Where(series => series != this))
            {
                series.UpdateAllDataPoints();
            }
        }

        /// <summary>
        /// Updates a data point when its actual dependent value has changed.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected override void OnDataPointActualDependentValueChanged(DataPoint dataPoint, object oldValue, object newValue)
        {
            UpdateDataPoint(dataPoint);
            base.OnDataPointActualDependentValueChanged(dataPoint, oldValue, newValue);
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
        /// Returns the style to use for all data points.
        /// </summary>
        /// <returns>The style to use for all data points.</returns>
        protected override Style GetDataPointStyleFromHost()
        {
            return SeriesHost.NextStyle(typeof(ColumnDataPoint), true);
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
                typeof(ColumnSeries),
                new PropertyMetadata(null, OnDependentRangeAxisPropertyChanged));

        /// <summary>
        /// DependentRangeAxisProperty property changed handler.
        /// </summary>
        /// <param name="d">ColumnSeries that changed its DependentRangeAxis.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnDependentRangeAxisPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColumnSeries source = (ColumnSeries)d;
            IRangeAxis newValue = (IRangeAxis)e.NewValue;
            source.OnDependentRangeAxisPropertyChanged(newValue);
        }

        /// <summary>
        /// DependentRangeAxisProperty property changed handler.
        /// </summary>
        /// <param name="newValue">New value.</param>
        private void OnDependentRangeAxisPropertyChanged(IRangeAxis newValue)
        {
            this.InternalDependentAxis = (IAxis)newValue;
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
                typeof(ColumnSeries),
                new PropertyMetadata(null, OnIndependentCategoryAxisPropertyChanged));

        /// <summary>
        /// IndependentCategoryAxisProperty property changed handler.
        /// </summary>
        /// <param name="d">ColumnSeries that changed its IndependentCategoryAxis.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnIndependentCategoryAxisPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ColumnSeries source = (ColumnSeries)d;
            ICategoryAxis newValue = (ICategoryAxis)e.NewValue;
            source.OnIndependentCategoryAxisPropertyChanged(newValue);
        }

        /// <summary>
        /// IndependentCategoryAxisProperty property changed handler.
        /// </summary>
        /// <param name="newValue">New value.</param>
        private void OnIndependentCategoryAxisPropertyChanged(ICategoryAxis newValue)
        {
            this.InternalIndependentAxis = (IAxis)newValue;
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

            double plotAreaHeight = ActualDependentRangeAxis.GetPlotAreaCoordinate(ActualDependentRangeAxis.Range.Maximum);
            IEnumerable<ColumnSeries> columnSeries = SeriesHost.Series.OfType<ColumnSeries>().Where(series => series.ActualIndependentCategoryAxis == ActualIndependentCategoryAxis);
            int numberOfSeries = columnSeries.Count();
            double coordinateRangeWidth = (coordinateRange.Maximum - coordinateRange.Minimum);
            double segmentWidth = coordinateRangeWidth * 0.8;
            double columnWidth = segmentWidth / numberOfSeries;
            int seriesIndex = columnSeries.IndexOf(this);

            double dataPointY = ActualDependentRangeAxis.GetPlotAreaCoordinate(ValueHelper.ToDouble(dataPoint.ActualDependentValue));
            double zeroPointY = ActualDependentRangeAxis.GetPlotAreaCoordinate(0);

            double offset = seriesIndex * Math.Round(columnWidth) + coordinateRangeWidth * 0.1;
            double dataPointX = coordinateRange.Minimum + offset;

            if (_categoriesWithMultipleDataPoints.ContainsKey(category))
            {
                // Multiple DataPoints share this category; offset and overlap them appropriately
                IGrouping<object, DataPoint> categoryGrouping = _categoriesWithMultipleDataPoints[category];
                int index = categoryGrouping.IndexOf(dataPoint);
                dataPointX += (index * (columnWidth * 0.2)) / (categoryGrouping.Count() - 1);
                columnWidth *= 0.8;
                Canvas.SetZIndex(dataPoint, -index);
            }

            if (!double.IsNaN(dataPointY) && !double.IsNaN(dataPointX) && !double.IsNaN(zeroPointY))
            {
                double left = Math.Round(dataPointX);
                double width = Math.Round(columnWidth);

                double top = Math.Round(plotAreaHeight - Math.Max(dataPointY, zeroPointY) + 0.5);
                double bottom = Math.Round(plotAreaHeight - Math.Min(dataPointY, zeroPointY) + 0.5);
                double height = bottom - top + 1;

                Canvas.SetLeft(dataPoint, left);
                Canvas.SetTop(dataPoint, top);
                dataPoint.Width = width;
                dataPoint.Height = height;
            }
        }
    }
}
