// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// Represents a control that contains a data series to be rendered in X/Y 
    /// line format.  A third binding determines the size of the data point.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    [StyleTypedProperty(Property = "DataPointStyle", StyleTargetType = typeof(BubbleDataPoint))]
    [StyleTypedProperty(Property = "LegendItemStyle", StyleTargetType = typeof(LegendItem))]
    public sealed class BubbleSeries : DataPointSingleSeriesWithAxes
    {
        /// <summary>
        /// The maximum bubble size as a ratio of the smallest dimension.
        /// </summary>
        private const double MaximumBubbleSizeAsRatioOfSmallestDimension = 0.25;

        /// <summary>
        /// Gets or sets the binding that determines the size of the bubble.
        /// </summary>
        public Binding SizeValueBinding { get; set; }

        /// <summary>
        /// Initializes a new instance of the bubble series.
        /// </summary>
        public BubbleSeries()
        {
        }

        /// <summary>
        /// Creates a new instance of bubble data point.
        /// </summary>
        /// <returns>A new instance of bubble data point.</returns>
        protected override DataPoint CreateDataPoint()
        {
            return new BubbleDataPoint();
        }

        /// <summary>
        /// Returns the style to use for all data points.
        /// </summary>
        /// <returns>The style to use for all data points.</returns>
        protected override Style GetDataPointStyleFromHost()
        {
            return SeriesHost.NextStyle(typeof(BubbleDataPoint), true);
        }

        /// <summary>
        /// Acquire a horizontal linear axis and a vertical linear axis.
        /// </summary>
        /// <param name="firstDataPoint">The first data point.</param>
        protected override void GetAxes(DataPoint firstDataPoint)
        {
            GetRangeAxis(
                InternalIndependentAxis,
                firstDataPoint,
                AxisOrientation.Horizontal,
                () => CreateRangeAxisFromData(firstDataPoint.IndependentValue),
                () => InternalActualIndependentAxis as IRangeAxis,
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
                () => InternalActualDependentAxis as IRangeAxis,
                (value) => { InternalActualDependentAxis = (IAxis)value; },
                (dataPoint) => dataPoint.DependentValue);
        }

        /// <summary>
        /// Prepares a bubble data point by binding the size value binding to
        /// the size property.
        /// </summary>
        /// <param name="dataPoint">The data point to prepare.</param>
        /// <param name="dataContext">The data context of the data point.
        /// </param>
        protected override void PrepareDataPoint(DataPoint dataPoint, object dataContext)
        {
            base.PrepareDataPoint(dataPoint, dataContext);

            BubbleDataPoint bubbleDataPoint = (BubbleDataPoint)dataPoint;
            bubbleDataPoint.SetBinding(BubbleDataPoint.SizeProperty, SizeValueBinding ?? DependentValueBinding ?? IndependentValueBinding);
        }

        /// <summary>
        /// Attaches size change and actual size change event handlers to the
        /// data point.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        protected override void AttachEventHandlersToDataPoint(DataPoint dataPoint)
        {
            BubbleDataPoint bubbleDataPoint = (BubbleDataPoint)dataPoint;
            bubbleDataPoint.SizePropertyChanged += new RoutedPropertyChangedEventHandler<double>(BubbleDataPointSizePropertyChanged);
            bubbleDataPoint.ActualSizePropertyChanged += new RoutedPropertyChangedEventHandler<double>(BubbleDataPointActualSizePropertyChanged);
            base.AttachEventHandlersToDataPoint(dataPoint);
        }

        /// <summary>
        /// Detaches size change and actual size change event handlers from the
        /// data point.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        protected override void DetachEventHandlersFromDataPoint(DataPoint dataPoint)
        {
            BubbleDataPoint bubbleDataPoint = (BubbleDataPoint)dataPoint;
            bubbleDataPoint.SizePropertyChanged -= new RoutedPropertyChangedEventHandler<double>(BubbleDataPointSizePropertyChanged);
            bubbleDataPoint.ActualSizePropertyChanged -= new RoutedPropertyChangedEventHandler<double>(BubbleDataPointActualSizePropertyChanged);
            base.DetachEventHandlersFromDataPoint(dataPoint);
        }

        /// <summary>
        /// Updates all data points when the actual size property of a data 
        /// point changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Information about the event.</param>
        private void BubbleDataPointActualSizePropertyChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            UpdateAllDataPoints();
        }

        /// <summary>
        /// Animates the value of the ActualSize property to the size property
        /// when it changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Information about the event.</param>
        private void BubbleDataPointSizePropertyChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            BubbleDataPoint dataPoint = (BubbleDataPoint)sender;
            DependencyPropertyAnimationHelper.BeginAnimation(
                dataPoint, 
                BubbleDataPoint.ActualSizeProperty, 
                "ActualSize", 
                e.NewValue, 
                TransitionDuration);
        }

        /// <summary>
        /// Gets or sets the sum of all data point actual size values.
        /// </summary>
        private double? MaxOfDataPointActualSizeValues { get; set; }

        /// <summary>
        /// Calculates the sum of all data point actual size values before all
        /// data points are updated.
        /// </summary>
        protected override void OnBeforeUpdateDataPoints()
        {
            // Get the largest size value of all data points to determine the size of each bubble when we update the data points.
            MaxOfDataPointActualSizeValues = 
                ActiveDataPoints
                    .OfType<BubbleDataPoint>()
                    .Select(currentBubbleDataPoint => Math.Abs(currentBubbleDataPoint.ActualSize))
                    .MaxOrNullable();
        }

        /// <summary>
        /// Updates the data point's visual representation.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        protected override void UpdateDataPoint(DataPoint dataPoint)
        {
            double maximumDiameter = Math.Min(PlotAreaSize.Width, PlotAreaSize.Height) * MaximumBubbleSizeAsRatioOfSmallestDimension;

            BubbleDataPoint bubbleDataPoint = (BubbleDataPoint)dataPoint;

            double ratioOfLargestBubble = 
                (MaxOfDataPointActualSizeValues.HasValue && MaxOfDataPointActualSizeValues.Value != 0.0 && bubbleDataPoint.ActualSize >= 0.0) ? Math.Abs(bubbleDataPoint.ActualSize) / MaxOfDataPointActualSizeValues.Value : 0.0;

            bubbleDataPoint.Width = ratioOfLargestBubble * maximumDiameter;
            bubbleDataPoint.Height = ratioOfLargestBubble * maximumDiameter;

            // Call UpdateLayout to ensure ActualWidth/ActualHeight are correct
            if (bubbleDataPoint.ActualWidth == 0.0 || bubbleDataPoint.ActualHeight == 0.0)
            {
                bubbleDataPoint.UpdateLayout();
            }

            double left = 
                (ActualIndependentRangeAxis.GetPlotAreaCoordinate((IComparable)bubbleDataPoint.ActualIndependentValue))
                    - (bubbleDataPoint.Width / 2.0);

            double top = 
                (PlotAreaSize.Height
                    - (bubbleDataPoint.Height / 2.0))
                    - ActualDependentRangeAxis.GetPlotAreaCoordinate((IComparable)bubbleDataPoint.ActualDependentValue);

            if (ValueHelper.CanGraph(left) && ValueHelper.CanGraph(top))
            {
                Canvas.SetLeft(bubbleDataPoint, left);
                Canvas.SetTop(bubbleDataPoint, top);
            }
        }

        /// <summary>
        /// Gets the dependent axis as a range axis.
        /// </summary>
        public IRangeAxis ActualDependentRangeAxis { get { return this.InternalActualDependentAxis as IRangeAxis; } }

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
                typeof(BubbleSeries),
                new PropertyMetadata(null, OnDependentRangeAxisPropertyChanged));

        /// <summary>
        /// DependentRangeAxisProperty property changed handler.
        /// </summary>
        /// <param name="d">BubbleSeries that changed its DependentRangeAxis.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnDependentRangeAxisPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BubbleSeries source = (BubbleSeries)d;
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

        /// <summary>
        /// Gets the independent axis as a range axis.
        /// </summary>
        public IRangeAxis ActualIndependentRangeAxis { get { return this.InternalActualIndependentAxis as IRangeAxis; } }

        #region public IRangeAxis IndependentRangeAxis
        /// <summary>
        /// Gets or sets independent range axis.
        /// </summary>
        public IRangeAxis IndependentRangeAxis
        {
            get { return GetValue(IndependentRangeAxisProperty) as IRangeAxis; }
            set { SetValue(IndependentRangeAxisProperty, value); }
        }

        /// <summary>
        /// Identifies the IndependentRangeAxis dependency property.
        /// </summary>
        public static readonly DependencyProperty IndependentRangeAxisProperty =
            DependencyProperty.Register(
                "IndependentRangeAxis",
                typeof(IRangeAxis),
                typeof(BubbleSeries),
                new PropertyMetadata(null, OnIndependentRangeAxisPropertyChanged));

        /// <summary>
        /// IndependentRangeAxisProperty property changed handler.
        /// </summary>
        /// <param name="d">BubbleSeries that changed its IndependentRangeAxis.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnIndependentRangeAxisPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            BubbleSeries source = (BubbleSeries)d;
            IRangeAxis newValue = (IRangeAxis)e.NewValue;
            source.OnIndependentRangeAxisPropertyChanged(newValue);
        }

        /// <summary>
        /// IndependentRangeAxisProperty property changed handler.
        /// </summary>
        /// <param name="newValue">New value.</param>        
        private void OnIndependentRangeAxisPropertyChanged(IRangeAxis newValue)
        {
            this.InternalIndependentAxis = (IAxis)newValue;
        }
        #endregion public IRangeAxis IndependentRangeAxis

        /// <summary>
        /// Overrides the requested axis range to include the width and height
        /// necessary for the bubbles.
        /// </summary>
        /// <param name="rangeAxis">The range axis.</param>
        /// <param name="range">The data range.</param>
        /// <returns>The requested axis range.</returns>
        protected override Range<IComparable> OverrideRequestedAxisRange(IRangeAxis rangeAxis, Range<IComparable> range)
        {
            if (ActiveDataPoints.Any())
            {
                if (rangeAxis == ActualIndependentRangeAxis)
                {
                    double smallestXCoordinate =
                        ActiveDataPoints
                            .Select(dataPoint =>
                                ActualIndependentRangeAxis.GetPlotAreaCoordinate((IComparable)dataPoint.IndependentValue) - dataPoint.ActualWidth)
                            .Min();

                    double largestXCoordinate =
                        ActiveDataPoints
                            .Select(dataPoint =>
                                ActualIndependentRangeAxis.GetPlotAreaCoordinate((IComparable)dataPoint.IndependentValue) + dataPoint.ActualWidth)
                            .Max();

                    return new Range<IComparable>(
                        ActualIndependentRangeAxis.GetPlotAreaCoordinateValueRange(smallestXCoordinate).Minimum,
                        ActualIndependentRangeAxis.GetPlotAreaCoordinateValueRange(largestXCoordinate).Maximum);
                }
                else if (rangeAxis == ActualDependentRangeAxis)
                {
                    double smallestYCoordinate =
                        ActiveDataPoints
                            .Select(dataPoint =>
                                ActualDependentRangeAxis.GetPlotAreaCoordinate((IComparable)dataPoint.DependentValue) - dataPoint.ActualHeight)
                            .Min();

                    double largestYCoordinate =
                        ActiveDataPoints
                            .Select(dataPoint =>
                                ActualDependentRangeAxis.GetPlotAreaCoordinate((IComparable)dataPoint.DependentValue) + dataPoint.ActualHeight)
                            .Max();

                    return new Range<IComparable>(
                        ActualDependentRangeAxis.GetPlotAreaCoordinateValueRange(smallestYCoordinate).Minimum,
                        ActualDependentRangeAxis.GetPlotAreaCoordinateValueRange(largestYCoordinate).Maximum);
                }
            }
            return new Range<IComparable>();
        }
    }
}