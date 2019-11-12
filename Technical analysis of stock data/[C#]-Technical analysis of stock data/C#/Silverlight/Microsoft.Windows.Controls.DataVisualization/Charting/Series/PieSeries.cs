// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// Represents a control that contains a data series to be rendered in pie
    /// format.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    [StyleTypedProperty(Property = "LegendItemStyle", StyleTargetType = typeof(LegendItem))]
    public sealed partial class PieSeries : DataPointSeries, IStyleDispenser, IRequireGlobalSeriesIndex
    {
        #region public IList StylePalette
        /// <summary>
        /// Gets or sets a palette of styles used by the pie series.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Want to allow this to be set from XAML.")]
        public IList StylePalette
        {
            get { return GetValue(StylePaletteProperty) as IList; }
            set { SetValue(StylePaletteProperty, value); }
        }

        /// <summary>
        /// Identifies the StylePalette dependency property.
        /// </summary>
        public static readonly DependencyProperty StylePaletteProperty =
            DependencyProperty.Register(
                "StylePalette",
                typeof(IList),
                typeof(Series),
                new PropertyMetadata(OnStylePalettePropertyChanged));

        /// <summary>
        /// StylePaletteProperty property changed handler.
        /// </summary>
        /// <param name="d">Parent that changed its StylePalette.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnStylePalettePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            PieSeries source = d as PieSeries;
            IList newValue = e.NewValue as IList;
            source.OnStylePalettePropertyChanged(newValue);
        }

        /// <summary>
        /// StylePaletteProperty property changed handler.
        /// </summary>
        /// <param name="newValue">New value.</param>
        private void OnStylePalettePropertyChanged(IList newValue)
        {
            StyleDispenser.Styles = newValue;
            RefreshStyles();
        }
        #endregion public IList StylePalette

        /// <summary>
        /// Initializes a new instance of the PieSeries class.
        /// </summary>
        public PieSeries()
        {
            this.DefaultStyleKey = typeof(PieSeries);
            this.StyleDispenser = new StyleDispenser();
        }

        /// <summary>
        /// A dictionary that links data points to their legend items.
        /// </summary>
        private Dictionary<DataPoint, LegendItem> _dataPointLegendItems = new Dictionary<DataPoint, LegendItem>();

        /// <summary>
        /// Accepts a ratio of a full rotation, the x and y length and returns
        /// the 2D point using trigonometric functions.
        /// </summary>
        /// <param name="ratio">The ratio of a full rotation [0..1].</param>
        /// <param name="radiusX">The x radius.</param>
        /// <param name="radiusY">The y radius.</param>
        /// <returns>The corresponding 2D point.</returns>
        private static Point ConvertRatioOfRotationToPoint(double ratio, double radiusX, double radiusY)
        {
            double radians = (((ratio * 360) - 90) * (Math.PI / 180));
            return new Point(radiusX * Math.Cos(radians), radiusY * Math.Sin(radians));
        }

        /// <summary>
        /// Creates a legend item for each data point.
        /// </summary>
        /// <param name="dataPoint">The data point added.</param>
        protected override void AddDataPoint(DataPoint dataPoint)
        {
            base.AddDataPoint(dataPoint);

            int index = ActiveDataPoints.IndexOf(dataPoint) + 1;
            Style style = NextStyle(typeof(PieDataPoint), true);
            if (dataPoint.Style == null)
            {
                dataPoint.Style = style;
            }

            LegendItem legendItem = CreatePieLegendItem(dataPoint, index);
            _dataPointLegendItems[dataPoint] = legendItem;
            LegendItems.Add(legendItem);
            UpdateLegendItemIndexes();
        }

        /// <summary>
        /// Removes data point's legend item when the data point is removed.
        /// </summary>
        /// <param name="dataPoint">The data point to remove.</param>
        protected override void RemoveDataPoint(DataPoint dataPoint)
        {
            base.RemoveDataPoint(dataPoint);
            if (dataPoint != null)
            {
                LegendItem legendItem = _dataPointLegendItems[dataPoint];
                _dataPointLegendItems.Remove(dataPoint);

                LegendItems.Remove(legendItem);
                UpdateLegendItemIndexes();
            }
        }

        /// <summary>
        /// Creates a data point.
        /// </summary>
        /// <returns>A data point.</returns>
        protected override DataPoint CreateDataPoint()
        {
            return new PieDataPoint();
        }

        /// <summary>
        /// Gets the active pie data points.
        /// </summary>
        private IEnumerable<PieDataPoint> ActivePieDataPoints
        {
            get { return ActiveDataPoints.OfType<PieDataPoint>(); }
        }

        /// <summary>
        /// Updates all ratios before data points are updated.
        /// </summary>
        protected override void OnBeforeUpdateDataPoints()
        {
            UpdateRatios();

            base.OnBeforeUpdateDataPoints();
        }

        /// <summary>
        /// This method executes after all data points are loaded.
        /// </summary>
        protected override void OnDataPointsLoaded()
        {
            UpdateRatios();

            base.OnDataPointsLoaded();
        }

        /// <summary>
        /// Updates the indexes of all legend items when a change is made to the collection.
        /// </summary>
        private void UpdateLegendItemIndexes()
        {
            int index = 0;
            foreach (DataPoint dataPoint in ActiveDataPoints)
            {
                LegendItem legendItem = _dataPointLegendItems[dataPoint];
                legendItem.Content = dataPoint.IndependentValue ?? (index + 1);
                index++;
            }
        }

        /// <summary>
        /// Updates the ratios of each data point.
        /// </summary>
        private void UpdateRatios()
        {
            double sum = ActivePieDataPoints.Select(pieDataPoint => Math.Abs(ValueHelper.ToDouble(pieDataPoint.DependentValue))).Sum();

            // Priming the loop by calculating initial value of 
            // offset ratio and its corresponding points.
            double offsetRatio = 0;
            foreach (PieDataPoint dataPoint in ActivePieDataPoints)
            {
                double dependentValue = Math.Abs(ValueHelper.ToDouble(dataPoint.DependentValue));
                double ratio = dependentValue / sum;
                if (!ValueHelper.CanGraph(ratio))
                {
                    ratio = 0.0;
                }
                dataPoint.Ratio = ratio;
                dataPoint.OffsetRatio = offsetRatio;
                offsetRatio += ratio;
            }
        }

        /// <summary>
        /// Updates a data point.
        /// </summary>
        /// <param name="dataPoint">The data point to update.</param>
        protected override void UpdateDataPoint(DataPoint dataPoint)
        {
            PieDataPoint pieDataPoint = (PieDataPoint) dataPoint;
            pieDataPoint.Width = ActualWidth;
            pieDataPoint.Height = ActualHeight;
            UpdatePieDataPointGeometry(pieDataPoint, ActualWidth, ActualHeight);
            Canvas.SetLeft(pieDataPoint, 0);
            Canvas.SetTop(pieDataPoint, 0);
        }

        /// <summary>
        /// Updates the PieDataPoint's Geometry property.
        /// </summary>
        /// <param name="pieDataPoint">PieDataPoint instance.</param>
        /// <param name="plotAreaWidth">PlotArea width.</param>
        /// <param name="plotAreaHeight">PlotArea height.</param>
        internal static void UpdatePieDataPointGeometry(PieDataPoint pieDataPoint, double plotAreaWidth, double plotAreaHeight)
        {
            double diameter = (plotAreaWidth < plotAreaHeight) ? plotAreaWidth : plotAreaHeight;
            diameter *= 0.95;
            double plotAreaRadius = diameter / 2;
            double maxDistanceFromCenter = 0.0;
            double sliceRadius = plotAreaRadius - maxDistanceFromCenter;

            Point translatePoint = new Point(plotAreaWidth / 2, plotAreaHeight / 2);

            if (pieDataPoint.ActualRatio == 1)
            {
                foreach (DependencyProperty dependencyProperty in new DependencyProperty[] { PieDataPoint.GeometryProperty, PieDataPoint.GeometrySelectionProperty, PieDataPoint.GeometryHighlightProperty })
                {
                    Geometry geometry =
                        new EllipseGeometry
                        {
                            Center = translatePoint,
                            RadiusX = sliceRadius,
                            RadiusY = sliceRadius
                        };
                    pieDataPoint.SetValue(dependencyProperty, geometry);
                }
            }
            else
            {
                if (pieDataPoint.ActualRatio == 0.0)
                {
                    pieDataPoint.Geometry = null;
                    pieDataPoint.GeometryHighlight = null;
                    pieDataPoint.GeometrySelection = null;
                }
                else
                {
                    double ratio = pieDataPoint.ActualRatio;
                    double offsetRatio = pieDataPoint.ActualOffsetRatio;
                    double currentRatio = offsetRatio + ratio;

                    Point offsetRatioPoint = ConvertRatioOfRotationToPoint(offsetRatio, sliceRadius, sliceRadius);

                    Point adjustedOffsetRatioPoint = Translate(offsetRatioPoint, translatePoint);

                    // Calculate the last clockwise point in the pie slice
                    Point currentRatioPoint =
                        ConvertRatioOfRotationToPoint(currentRatio, sliceRadius, sliceRadius);

                    // Adjust point using center of plot area as origin
                    // instead of 0,0
                    Point adjustedCurrentRatioPoint =
                        Translate(currentRatioPoint, translatePoint);

                    foreach (DependencyProperty dependencyProperty in new DependencyProperty[] { PieDataPoint.GeometryProperty, PieDataPoint.GeometrySelectionProperty, PieDataPoint.GeometryHighlightProperty })
                    {
                        // Creating the pie slice geometry object
                        PathFigure pathFigure = new PathFigure { IsClosed = true };
                        pathFigure.StartPoint = translatePoint;
                        pathFigure.Segments.Add(new LineSegment { Point = adjustedOffsetRatioPoint });
                        bool isLargeArc = (currentRatio - offsetRatio) > 0.5;
                        pathFigure.Segments.Add(
                            new ArcSegment
                            {
                                Point = adjustedCurrentRatioPoint,
                                IsLargeArc = isLargeArc,
                                Size = new Size(sliceRadius, sliceRadius),
                                SweepDirection = SweepDirection.Clockwise
                            });

                        PathGeometry pathGeometry = new PathGeometry();
                        pathGeometry.Figures.Add(pathFigure);
                        pieDataPoint.SetValue(dependencyProperty, pathGeometry);
                    }
                }
            }
        }

        /// <summary>
        /// Creates a legend item from a data point.
        /// </summary>
        /// <param name="dataPoint">The data point to use to create the legend item.</param>
        /// <param name="index">The 1-based index of the Control.</param>
        /// <returns>The series host legend item.</returns>
        private LegendItem CreatePieLegendItem(DataPoint dataPoint, int index)
        {
            LegendItem legendItem = CreateLegendItem();
            // Set the Content of the LegendItem
            legendItem.Content = dataPoint.IndependentValue ?? index;
            // Create a representative DataPoint for access to styled properties
            DataPoint legendDataPoint = CreateDataPoint();
            legendDataPoint.Style = dataPoint.Style;
            legendItem.DataContext = legendDataPoint;
            return legendItem;
        }

        /// <summary>
        /// Applies the translate transform to a point.
        /// </summary>
        /// <param name="origin">The origin point.</param>
        /// <param name="offset">The offset point.</param>
        /// <returns>The translated point.</returns>
        private static Point Translate(Point origin, Point offset)
        {
            return new Point(origin.X + offset.X, origin.Y + offset.Y);
        }

        /// <summary>
        /// Attach event handlers to a data point.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        protected override void AttachEventHandlersToDataPoint(DataPoint dataPoint)
        {
            PieDataPoint pieDataPoint = dataPoint as PieDataPoint;

            pieDataPoint.ActualRatioChanged += OnPieDataPointActualRatioChanged;
            pieDataPoint.ActualOffsetRatioChanged += OnPieDataPointActualOffsetRatioChanged;
            pieDataPoint.RatioChanged += OnPieDataPointRatioChanged;
            pieDataPoint.OffsetRatioChanged += OnPieDataPointOffsetRatioChanged;

            base.AttachEventHandlersToDataPoint(dataPoint);
        }

        /// <summary>
        /// Detaches event handlers from a data point.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        protected override void DetachEventHandlersFromDataPoint(DataPoint dataPoint)
        {
            PieDataPoint pieDataPoint = dataPoint as PieDataPoint;

            pieDataPoint.ActualRatioChanged -= OnPieDataPointActualRatioChanged;
            pieDataPoint.ActualOffsetRatioChanged -= OnPieDataPointActualOffsetRatioChanged;
            pieDataPoint.RatioChanged -= OnPieDataPointRatioChanged;
            pieDataPoint.OffsetRatioChanged -= OnPieDataPointOffsetRatioChanged;

            base.DetachEventHandlersFromDataPoint(dataPoint);
        }

        /// <summary>
        /// This method updates the global series index property.
        /// </summary>
        /// <param name="globalIndex">The global index of the series.</param>
        public void GlobalSeriesIndexChanged(int globalIndex)
        {
            // Do nothing because we want to use up an index but do nothing 
            // with it.
        }

        /// <summary>
        /// Updates the data point when the dependent value is changed.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected override void OnDataPointDependentValueChanged(DataPoint dataPoint, object oldValue, object newValue)
        {
            UpdateRatios();
            base.OnDataPointDependentValueChanged(dataPoint, oldValue, newValue);
        }

        /// <summary>
        /// Updates the data point when the independent value is changed.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected override void OnDataPointIndependentValueChanged(DataPoint dataPoint, object oldValue, object newValue)
        {
            _dataPointLegendItems[dataPoint].Content = newValue;
            base.OnDataPointIndependentValueChanged(dataPoint, oldValue, newValue);
        }

        /// <summary>
        /// Updates the data point when the pie data point's actual ratio is
        /// changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">Information about the event.</param>
        private void OnPieDataPointActualRatioChanged(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            UpdateDataPoint(sender as DataPoint);
        }

        /// <summary>
        /// Updates the data point when the pie data point's actual offset ratio
        /// is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">Information about the event.</param>
        private void OnPieDataPointActualOffsetRatioChanged(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            UpdateDataPoint(sender as DataPoint);
        }

        /// <summary>
        /// Updates the data point when the pie data point's ratio is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">Information about the event.</param>
        private void OnPieDataPointRatioChanged(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            DataPoint dataPoint = sender as DataPoint;
            dataPoint.BeginAnimation(PieDataPoint.ActualRatioProperty, "ActualRatio", args.NewValue, TransitionDuration);
        }

        /// <summary>
        /// Updates the data point when the pie data point's offset ratio is 
        /// changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">Information about the event.</param>
        private void OnPieDataPointOffsetRatioChanged(object sender, RoutedPropertyChangedEventArgs<double> args)
        {
            DataPoint dataPoint = sender as DataPoint;
            dataPoint.BeginAnimation(PieDataPoint.ActualOffsetRatioProperty, "ActualOffsetRatio", args.NewValue, TransitionDuration);
        }

        /// <summary>
        /// Gets or sets an object used to dispense styles from the style 
        /// palette.
        /// </summary>
        private StyleDispenser StyleDispenser { get; set; }

        /// <summary>
        /// Returns the next applicable style for a given data point type.
        /// </summary>
        /// <param name="targetType">The target type of a data point.</param>
        /// <param name="inherit">A value indicating whether to accept
        /// super classes of the target type.</param>
        /// <returns>The next applicable style.</returns>
        public Style NextStyle(Type targetType, bool inherit)
        {
            Style output = StyleDispenser.NextStyle(targetType, inherit);
            if (output == null)
            {
                output = this.SeriesHost.NextStyle(targetType, inherit);
            }
            return output;
        }

        /// <summary>
        /// Refreshes styles in the pie series.
        /// </summary>
        public override void RefreshStyles()
        {
            Refresh();
        }
    }
}
