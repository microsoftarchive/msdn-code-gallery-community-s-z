// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System;
using System.Windows.Shapes;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// Represents a data point used for scatter series.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    [TemplateVisualState(Name = DataPoint.StateCommonNormal, GroupName = DataPoint.GroupCommonStates)]
    [TemplateVisualState(Name = DataPoint.StateCommonMouseOver, GroupName = DataPoint.GroupCommonStates)]
    [TemplateVisualState(Name = DataPoint.StateSelectionUnselected, GroupName = DataPoint.GroupSelectionStates)]
    [TemplateVisualState(Name = DataPoint.StateSelectionSelected, GroupName = DataPoint.GroupSelectionStates)]
    [TemplateVisualState(Name = DataPoint.StateRevealShown, GroupName = DataPoint.GroupRevealStates)]
    [TemplateVisualState(Name = DataPoint.StateRevealHidden, GroupName = DataPoint.GroupRevealStates)]
    public sealed partial class StockBarDataPoint : DataPoint
    {
        #region public double Open
        /// <summary>
        /// Gets or sets the size value of the bubble data point.
        /// </summary>
        public double Open
        {
            get { return (double)GetValue(OpenProperty); }
            set { SetValue(OpenProperty, value); }
        }

        /// <summary>
        /// Identifies the Size dependency property.
        /// </summary>
        public static readonly DependencyProperty OpenProperty =
            DependencyProperty.Register(
                "Open",
                typeof(double),
                typeof(StockBarDataPoint),
                new PropertyMetadata(0.0, OnOpenPropertyChanged));

        /// <summary>
        /// SizeProperty property changed handler.
        /// </summary>
        /// <param name="d">BubbleDataPoint that changed its Size.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnOpenPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //BubbleDataPoint source = (BubbleDataPoint)d;
            //double oldValue = (double)e.OldValue;
            //double newValue = (double)e.NewValue;
            //source.OnSizePropertyChanged(oldValue, newValue);
        }

        /// <summary>
        /// SizeProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>        
        private void OnOpenPropertyChanged(double oldValue, double newValue)
        {
            //RoutedPropertyChangedEventHandler<double> handler = SizePropertyChanged;
            //if (handler != null)
            //{
            //    handler(this, new RoutedPropertyChangedEventArgs<double>(oldValue, newValue));
            //}

            //if (this.State == DataPointState.Created)
            //{
            //    this.ActualSize = newValue;
            //}
        }

        /// <summary>
        /// This event is raised when the size property is changed.
        /// </summary>
        internal event RoutedPropertyChangedEventHandler<double> OpenPropertyChanged;

        #endregion public double Open

        #region public double Close
        /// <summary>
        /// Gets or sets the size value of the bubble data point.
        /// </summary>
        public double Close
        {
            get { return (double)GetValue(CloseProperty); }
            set { SetValue(CloseProperty, value); }
        }

        /// <summary>
        /// Identifies the Size dependency property.
        /// </summary>
        public static readonly DependencyProperty CloseProperty =
            DependencyProperty.Register(
                "Close",
                typeof(double),
                typeof(StockBarDataPoint),
                new PropertyMetadata(0.0, OnClosePropertyChanged));

        /// <summary>
        /// SizeProperty property changed handler.
        /// </summary>
        /// <param name="d">BubbleDataPoint that changed its Size.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnClosePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //BubbleDataPoint source = (BubbleDataPoint)d;
            //double oldValue = (double)e.OldValue;
            //double newValue = (double)e.NewValue;
            //source.OnSizePropertyChanged(oldValue, newValue);
        }

        /// <summary>
        /// SizeProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>        
        private void OnClosePropertyChanged(double oldValue, double newValue)
        {
            //RoutedPropertyChangedEventHandler<double> handler = SizePropertyChanged;
            //if (handler != null)
            //{
            //    handler(this, new RoutedPropertyChangedEventArgs<double>(oldValue, newValue));
            //}

            //if (this.State == DataPointState.Created)
            //{
            //    this.ActualSize = newValue;
            //}
        }

        /// <summary>
        /// This event is raised when the size property is changed.
        /// </summary>
        internal event RoutedPropertyChangedEventHandler<double> ClosePropertyChanged;

        #endregion public double Close

        #region public double High
        /// <summary>
        /// Gets or sets the size value of the bubble data point.
        /// </summary>
        public double High
        {
            get { return (double)GetValue(HighProperty); }
            set { SetValue(HighProperty, value); }
        }

        /// <summary>
        /// Identifies the Size dependency property.
        /// </summary>
        public static readonly DependencyProperty HighProperty =
            DependencyProperty.Register(
                "High",
                typeof(double),
                typeof(StockBarDataPoint),
                new PropertyMetadata(0.0, OnHighPropertyChanged));

        /// <summary>
        /// SizeProperty property changed handler.
        /// </summary>
        /// <param name="d">BubbleDataPoint that changed its Size.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnHighPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //BubbleDataPoint source = (BubbleDataPoint)d;
            //double oldValue = (double)e.OldValue;
            //double newValue = (double)e.NewValue;
            //source.OnSizePropertyChanged(oldValue, newValue);
        }

        /// <summary>
        /// SizeProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>        
        private void OnHighPropertyChanged(double oldValue, double newValue)
        {
            //RoutedPropertyChangedEventHandler<double> handler = SizePropertyChanged;
            //if (handler != null)
            //{
            //    handler(this, new RoutedPropertyChangedEventArgs<double>(oldValue, newValue));
            //}

            //if (this.State == DataPointState.Created)
            //{
            //    this.ActualSize = newValue;
            //}
        }

        /// <summary>
        /// This event is raised when the size property is changed.
        /// </summary>
        internal event RoutedPropertyChangedEventHandler<double> HighPropertyChanged;

        #endregion public double High

        #region public double Low
        /// <summary>
        /// Gets or sets the size value of the bubble data point.
        /// </summary>
        public double Low
        {
            get { return (double)GetValue(LowProperty); }
            set { SetValue(LowProperty, value); }
        }

        /// <summary>
        /// Identifies the Size dependency property.
        /// </summary>
        public static readonly DependencyProperty LowProperty =
            DependencyProperty.Register(
                "Low",
                typeof(double),
                typeof(StockBarDataPoint),
                new PropertyMetadata(0.0, OnLowPropertyChanged));

        /// <summary>
        /// SizeProperty property changed handler.
        /// </summary>
        /// <param name="d">BubbleDataPoint that changed its Size.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnLowPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //BubbleDataPoint source = (BubbleDataPoint)d;
            //double oldValue = (double)e.OldValue;
            //double newValue = (double)e.NewValue;
            //source.OnSizePropertyChanged(oldValue, newValue);
        }

        /// <summary>
        /// SizeProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>        
        private void OnLowPropertyChanged(double oldValue, double newValue)
        {
            //RoutedPropertyChangedEventHandler<double> handler = SizePropertyChanged;
            //if (handler != null)
            //{
            //    handler(this, new RoutedPropertyChangedEventArgs<double>(oldValue, newValue));
            //}

            //if (this.State == DataPointState.Created)
            //{
            //    this.ActualSize = newValue;
            //}
        }

        /// <summary>
        /// This event is raised when the size property is changed.
        /// </summary>
        internal event RoutedPropertyChangedEventHandler<double> LowPropertyChanged;

        #endregion public double Low

		private const String OpenLineName = "OpenLine";

		private Rectangle OpenLine { get; set; }

		private const String CloseLineName = "CloseLine";

		private Rectangle CloseLine { get; set; }

		private const String MinMaxLineName = "MinMaxLine";

		private Rectangle MinMaxLine { get; set; }


        /// <summary>
        /// Initializes a new instance of the ScatterDataPoint class.
        /// </summary>
		public StockBarDataPoint()
        {
			this.DefaultStyleKey = typeof(StockBarDataPoint);
        }

        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

			OpenLine = GetTemplateChild(OpenLineName) as Rectangle;

			CloseLine = GetTemplateChild(CloseLineName) as Rectangle;

			MinMaxLine = GetTemplateChild(MinMaxLineName) as Rectangle;
        }

        public void UpdateBody(IRangeAxis rangeAxis)
        {
			if (OpenLine == null || CloseLine == null || MinMaxLine == null)
			{
				return;
			}

            Double highPointY = rangeAxis.GetPlotAreaCoordinate(High);

            Double lowPointY = rangeAxis.GetPlotAreaCoordinate(Low);

            Double openPointY = rangeAxis.GetPlotAreaCoordinate(Open);

            Double closePointY = rangeAxis.GetPlotAreaCoordinate(Close);

			OpenLine.Width = (Int32)(((DataPoint)this).Width / 2);

			CloseLine.Width = (Int32)(((DataPoint)this).Width / 2);

			Double openLineMargin = openPointY - lowPointY;

			if ((Int32)openLineMargin >= (Int32)this.Height)
			{
				openLineMargin = this.Height - 1;
			}

			if (openLineMargin < 0.0)
			{
				openLineMargin = 0.0;
			}

			Double closeLineMargin = highPointY - closePointY;

			if ((Int32)closeLineMargin >= (Int32)this.Height)
			{
				closeLineMargin = this.Height - 1;
			}

			if (closeLineMargin < 0.0)
			{
				closeLineMargin = 0.0;
			}

			OpenLine.Margin = new Thickness(0, 0, 0, openLineMargin);

			CloseLine.Margin = new Thickness(0, closeLineMargin, 0, 0);

			MinMaxLine.Width = 2.0;
        }
    }
}


