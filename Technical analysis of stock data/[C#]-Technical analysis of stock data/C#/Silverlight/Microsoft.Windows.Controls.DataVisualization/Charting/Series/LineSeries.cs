// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// Represents a control that contains a data series to be rendered in X/Y 
    /// line format.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    [StyleTypedProperty(Property = "DataPointStyle", StyleTargetType = typeof(LineDataPoint))]
    [StyleTypedProperty(Property = "LegendItemStyle", StyleTargetType = typeof(LegendItem))]
    [StyleTypedProperty(Property = "PolylineStyle", StyleTargetType = typeof(Polyline))]
	public sealed partial class LineSeries : DataPointSingleSeriesWithAxes, ISeriesWithRangeAxis
    {
        #region public PointCollection Points
        /// <summary>
        /// Gets the collection of points that make up the line.
        /// </summary>
        public PointCollection Points
        {
            get { return GetValue(PointsProperty) as PointCollection; }
            private set { SetValue(PointsProperty, value); }
        }

        /// <summary>
        /// Identifies the Points dependency property.
        /// </summary>
        public static readonly DependencyProperty PointsProperty =
            DependencyProperty.Register(
                "Points",
                typeof(PointCollection),
                typeof(LineSeries),
                null);

        #endregion public PointCollection Points

        /// <summary>
        /// Gets or sets the style of the Polyline object that follows the data 
        /// points.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Polyline", Justification = "Matches System.Windows.Shapes.Polyline.")]
        public Style PolylineStyle
        {
            get { return GetValue(PolylineStyleProperty) as Style; }
            set { SetValue(PolylineStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the PolylineStyle dependency property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1704:IdentifiersShouldBeSpelledCorrectly", MessageId = "Polyline", Justification = "Matches System.Windows.Shapes.Polyline.")]
        public static readonly DependencyProperty PolylineStyleProperty =
            DependencyProperty.Register(
                "PolylineStyle",
                typeof(Style),
                typeof(LineSeries),
                null);

        /// <summary>
        /// Gets or sets the height of the marker objects that follow the data 
        /// points.
        /// </summary>
        public double MarkerHeight
        {
            get { return (double)GetValue(MarkerHeightProperty); }
            set { SetValue(MarkerHeightProperty, value); }
        }

        /// <summary>
        /// Identifies the MarkerHeight dependency property.
        /// </summary>
        public static readonly DependencyProperty MarkerHeightProperty =
            DependencyProperty.Register(
                "MarkerHeight",
                typeof(double),
                typeof(LineSeries),
                new PropertyMetadata(double.NaN));

        /// <summary>
        /// Gets or sets the width of the marker objects that follow the data 
        /// points.
        /// </summary>
        public double MarkerWidth
        {
            get { return (double)GetValue(MarkerWidthProperty); }
            set { SetValue(MarkerWidthProperty, value); }
        }

        /// <summary>
        /// Identifies the MarkerWidth dependency property.
        /// </summary>
        public static readonly DependencyProperty MarkerWidthProperty =
            DependencyProperty.Register(
                "MarkerWidth",
                typeof(double),
                typeof(LineSeries),
                new PropertyMetadata(double.NaN));

        /// <summary>
        /// Initializes a new instance of the LineSeries class.
        /// </summary>
        public LineSeries()
        {
            this.DefaultStyleKey = typeof(LineSeries);
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
                (value) => { InternalActualIndependentAxis = (IAxis) value; },
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
                (value) => { InternalActualDependentAxis = (IAxis) value; },
                (dataPoint) => dataPoint.DependentValue);
        }

        /// <summary>
        /// Creates a new line data point.
        /// </summary>
        /// <returns>A line data point.</returns>
        protected override DataPoint CreateDataPoint()
        {
            return new LineDataPoint();
        }

        /// <summary>
        /// Returns the style to use for all data points.
        /// </summary>
        /// <returns>The style to use for all data points.</returns>
        protected override Style GetDataPointStyleFromHost()
        {
            return SeriesHost.NextStyle(typeof(LineDataPoint), true);
        }

        /// <summary>
        /// This method executes after all data points have been updated.
        /// </summary>
        protected override void OnAfterUpdateDataPoints()
        {
            if (InternalActualDependentAxis != null && InternalActualIndependentAxis != null)
            {
                UpdatePointsCollection();
            }
        }

        /// <summary>
        /// Creates a DataPoint for determining the line color.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
            if (null != PlotArea)
            {
                Grid grid = new Grid();
                DataPoint dataPoint = CreateDataPoint();
                dataPoint.Visibility = Visibility.Collapsed;
                dataPoint.Loaded += delegate
                {
                    if (null == dataPoint.Style)
                    {
                        dataPoint.Style = ActualDataPointStyle;
                    }
                    Background = dataPoint.Background;
                    if (null != PlotArea)
                    {
                        PlotArea.Children.Remove(grid);
                    }
                };
                grid.Children.Add(dataPoint);
                PlotArea.Children.Add(grid);
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
                typeof(LineSeries),
                new PropertyMetadata(null, OnDependentRangeAxisPropertyChanged));

        /// <summary>
        /// DependentRangeAxisProperty property changed handler.
        /// </summary>
        /// <param name="d">LineSeries that changed its DependentRangeAxis.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnDependentRangeAxisPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LineSeries source = (LineSeries)d;
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
        /// Gets or sets the independent range axis.
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
                typeof(LineSeries),
                new PropertyMetadata(null, OnIndependentRangeAxisPropertyChanged));

        /// <summary>
        /// IndependentRangeAxisProperty property changed handler.
        /// </summary>
        /// <param name="d">LineSeries that changed its IndependentRangeAxis.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnIndependentRangeAxisPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LineSeries source = (LineSeries)d;
            IRangeAxis newValue = (IRangeAxis)e.NewValue;
            source.OnIndependentRangeAxisPropertyChanged(newValue);
        }

        /// <summary>
        /// IndependentRangeAxisProperty property changed handler.
        /// </summary>
        /// <param name="newValue">New value.</param>        
        private void OnIndependentRangeAxisPropertyChanged(IRangeAxis newValue)
        {
            this.InternalIndependentAxis = (IAxis) newValue;
        }
        #endregion public IRangeAxis IndependentRangeAxis

        /// <summary>
        /// Updates the visual representation of the data point.
        /// </summary>
        /// <param name="dataPoint">The data point to update.</param>
        protected override void UpdateDataPoint(DataPoint dataPoint)
        {
            double maximum = ActualDependentRangeAxis.GetPlotAreaCoordinate(ActualDependentRangeAxis.Range.Maximum);
            if (ValueHelper.CanGraph(maximum))
            {
                double x = ActualIndependentRangeAxis.GetPlotAreaCoordinate(ValueHelper.ToComparable(dataPoint.ActualIndependentValue));
                double y = ActualDependentRangeAxis.GetPlotAreaCoordinate(ValueHelper.ToDouble(dataPoint.ActualDependentValue));

                if (ValueHelper.CanGraph(x) && ValueHelper.CanGraph(y))
                {
                    if (!double.IsNaN(MarkerHeight))
                    {
                        dataPoint.Height = MarkerHeight;
                    }
                    if (!double.IsNaN(MarkerWidth))
                    {
                        dataPoint.Width = MarkerWidth;
                    }

                    // Call UpdateLayout to ensure ActualWidth/ActualHeight are correct
                    if (dataPoint.ActualWidth == 0.0 || dataPoint.ActualHeight == 0.0)
                    {
                        dataPoint.UpdateLayout();
                    }

                    double coordinateY = Math.Round(maximum - (y + (dataPoint.ActualHeight / 2)));
                    Canvas.SetTop(dataPoint, coordinateY);
                    double coordinateX = Math.Round(x - (dataPoint.ActualWidth / 2));
                    Canvas.SetLeft(dataPoint, coordinateX);
                }

                if (!UpdatingAllDataPoints)
                {
                    UpdatePointsCollection();
                }
            }
        }

        /// <summary>
        /// Updates the point collection object.
        /// </summary>
        private void UpdatePointsCollection()
        {
            double maximum = ActualDependentRangeAxis.GetPlotAreaCoordinate(ActualDependentRangeAxis.Range.Maximum);
            if (ValueHelper.CanGraph(maximum))
            {
                IEnumerable<Point> points =
                    ActiveDataPoints
                        .OrderBy(dataPoint => dataPoint.IndependentValue)
                        .Select(dataPoint =>
                            new Point(
                                ActualIndependentRangeAxis.GetPlotAreaCoordinate((IComparable) dataPoint.ActualIndependentValue),
                                maximum - ActualDependentRangeAxis.GetPlotAreaCoordinate((IComparable) dataPoint.ActualDependentValue)));

                if (!points.IsEmpty())
                {
                    this.Points = new PointCollection();
                    foreach (Point point in points)
                    {
                        this.Points.Add(point);
                    }
                }
                else
                {
                    this.Points = null;
                }
            }
        }
    }
}
