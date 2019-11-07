// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
	[StyleTypedProperty(Property = "DataPointStyle", StyleTargetType = typeof(StockBarDataPoint))]
	[StyleTypedProperty(Property = "LegendItemStyle", StyleTargetType = typeof(LegendItem))]
	public sealed partial class StockBarSeries : DataPointSingleSeriesWithAxes, ISeriesWithRangeAxis
	{
		public Binding OpenValueBinding { get; set; }
		public Binding CloseValueBinding { get; set; }
		public Binding HighValueBinding { get; set; }
		public Binding LowValueBinding { get; set; }

		public Color StockBarColour
		{
			get { return (Color)this.GetValue(StockBarColourProperty); }
			set { this.SetValue(StockBarColourProperty, value); }
		}

		public static readonly DependencyProperty StockBarColourProperty = DependencyProperty.Register(
		  "StockBarColourProperty", typeof(Color), typeof(StockBarSeries), new PropertyMetadata(Colors.Black, OnStockBarColourPropertyChanged));

		private Brush stockBarBrush;

		private static void OnStockBarColourPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			StockBarSeries source = (StockBarSeries)d;

			source.stockBarBrush = new SolidColorBrush((Color)e.NewValue);
		}

		public StockBarSeries()
		{
			stockBarBrush = new SolidColorBrush(StockBarColour);
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
				typeof(StockBarSeries),
				new PropertyMetadata(null, OnDependentRangeAxisPropertyChanged));

		/// <summary>
		/// DependentRangeAxisProperty property changed handler.
		/// </summary>
		/// <param name="d">StockBarSeries that changed its DependentRangeAxis.</param>
		/// <param name="e">Event arguments.</param>
		private static void OnDependentRangeAxisPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			StockBarSeries source = (StockBarSeries)d;
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
				typeof(StockBarSeries),
				new PropertyMetadata(null, OnIndependentRangeAxisPropertyChanged));

		/// <summary>
		/// IndependentRangeAxisProperty property changed handler.
		/// </summary>
		/// <param name="d">StockBarSeries that changed its IndependentRangeAxis.</param>
		/// <param name="e">Event arguments.</param>
		private static void OnIndependentRangeAxisPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
		{
			StockBarSeries source = (StockBarSeries)d;
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
					HybridAxis axis = (HybridAxis)CreateRangeAxisFromData(firstDataPoint.DependentValue);
					axis.ShowGridLines = true;
					return (IRangeAxis)axis;
				},
				() => InternalActualDependentAxis as IRangeAxis,
				(value) => { InternalActualDependentAxis = (IAxis)value; },
				(dataPoint) => dataPoint.DependentValue);
		}

		protected override void PrepareDataPoint(DataPoint dataPoint, object dataContext)
		{
			base.PrepareDataPoint(dataPoint, dataContext);

			StockBarDataPoint candlestickDataPoint = (StockBarDataPoint)dataPoint;
			candlestickDataPoint.SetBinding(StockBarDataPoint.OpenProperty, OpenValueBinding);
			candlestickDataPoint.SetBinding(StockBarDataPoint.CloseProperty, CloseValueBinding);
			candlestickDataPoint.SetBinding(StockBarDataPoint.HighProperty, HighValueBinding);
			candlestickDataPoint.SetBinding(StockBarDataPoint.LowProperty, LowValueBinding);
		}

		protected override Range<IComparable> OverrideRequestedAxisRange(IRangeAxis rangeAxis, Range<IComparable> range)
		{
			Range<IComparable> desiredRange = base.OverrideRequestedAxisRange(rangeAxis, range);

			if (range.HasData && desiredRange.HasData)
			{
				if (rangeAxis == InternalActualDependentAxis)
				{
					Range<Double> doubleDesiredRange = desiredRange.ToDoubleRange();

					Double minValue = (from adp in ActiveDataPoints select ((StockBarDataPoint)adp).Low).Min();

					Double maxValue = (from adp in ActiveDataPoints select ((StockBarDataPoint)adp).High).Max();

					Double minimum;

					Double maximum;

					if (doubleDesiredRange.Minimum < minValue)
					{
						minimum = doubleDesiredRange.Minimum;
					}
					else
					{
						minimum = minValue;
					}

					if (doubleDesiredRange.Maximum > maxValue)
					{
						maximum = doubleDesiredRange.Maximum;
					}
					else
					{
						maximum = maxValue;
					}

					return new Range<IComparable>(minimum, maximum);
				}
			}

			return desiredRange;
		}

		/// <summary>
		/// Creates a new Candlestick data point.
		/// </summary>
		/// <returns>A Candlestick data point.</returns>
		protected override DataPoint CreateDataPoint()
		{
			return new StockBarDataPoint();
		}

		/// <summary>
		/// Returns the style to use for all data points.
		/// </summary>
		/// <returns>The style to use for all data points.</returns>
		protected override Style GetDataPointStyleFromHost()
		{
			return SeriesHost.NextStyle(typeof(StockBarDataPoint), true);
		}

		/// <summary>
		/// Redraws all other column series when data points have been loaded.
		/// </summary>
		protected override void OnDataPointsLoaded()
		{
			singleBlockWidth = null;

			base.OnDataPointsLoaded();
		}

		private Nullable<Double> singleBlockWidth = null;

		/// <summary>
		/// This method updates a single data point.
		/// </summary>
		/// <param name="dataPoint">The data point to update.</param>
		protected override void UpdateDataPoint(DataPoint dataPoint)
		{
			StockBarDataPoint candlestickDataPoint = (StockBarDataPoint)dataPoint;

			Double PlotAreaHeight = ActualDependentRangeAxis.GetPlotAreaCoordinate(ActualDependentRangeAxis.Range.Maximum);
			Double dataPointX = ActualIndependentRangeAxis.GetPlotAreaCoordinate(ValueHelper.ToComparable(dataPoint.ActualIndependentValue));
			Double highPointY = ActualDependentRangeAxis.GetPlotAreaCoordinate(candlestickDataPoint.High);
			Double lowPointY = ActualDependentRangeAxis.GetPlotAreaCoordinate(candlestickDataPoint.Low);
			Double openPointY = ActualDependentRangeAxis.GetPlotAreaCoordinate(candlestickDataPoint.Open);
			Double closePointY = ActualDependentRangeAxis.GetPlotAreaCoordinate(candlestickDataPoint.Close);

			if (!singleBlockWidth.HasValue)
			{
				Range<Double> doubleRange = ActualIndependentRangeAxis.Range.ToDoubleRange();

				Double rangeLength = doubleRange.Maximum - doubleRange.Minimum;

				if (rangeLength > 0.0)
				{
					singleBlockWidth = PlotArea.Width * 1.0 / rangeLength;

					if (singleBlockWidth < 4.0)
					{
						singleBlockWidth = 4.0;
					}
				}
				else
				{
					singleBlockWidth = 4.0;
				}
			}

			if (ValueHelper.CanGraph(dataPointX))
			{
				candlestickDataPoint.Background = new SolidColorBrush(Colors.Transparent);

				dataPoint.Height = Math.Abs(highPointY - lowPointY);

				dataPoint.Width = singleBlockWidth.Value * 0.8;

				if (dataPoint.Width > 16.0)
				{
					dataPoint.Width = 16.0;
				}

				candlestickDataPoint.UpdateBody(ActualDependentRangeAxis);

				//if (dataPoint.ActualWidth == 0.0 || dataPoint.ActualHeight == 0.0)
				{
					dataPoint.UpdateLayout();
				}

				Canvas.SetLeft(dataPoint, Math.Round(dataPointX - (dataPoint.ActualWidth / 2)));

				Canvas.SetTop(dataPoint, Math.Round(PlotAreaHeight - highPointY));
			}
		}
	}
}
