// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// A dynamic series with axes and only one legend item and style for all 
    /// data points.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    public abstract class DataPointSingleSeriesWithAxes : DataPointSeriesWithAxes, IRequireGlobalSeriesIndex
    {
        /// <summary>
        /// Gets the single legend item associated with the series.
        /// </summary>
        protected LegendItem LegendItem
        {
            get
            {
                if (LegendItems.Count == 0)
                {
                    this.LegendItems.Add(CreateLegendItem());
                }
                return this.LegendItems[0] as LegendItem;
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether a custom title is in use.
        /// </summary>
        private bool CustomTitleInUse { get; set; }

        #region public Style DataPointStyle
        /// <summary>
        /// Gets or sets the style to use for the data points.
        /// </summary>
        public Style DataPointStyle
        {
            get { return GetValue(DataPointStyleProperty) as Style; }
            set { SetValue(DataPointStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the DataPointStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty DataPointStyleProperty =
            DependencyProperty.Register(
                "DataPointStyle",
                typeof(Style),
                typeof(DataPointSingleSeriesWithAxes),
                null);

        #endregion public Style DataPointStyle

        /// <summary>
        /// Gets or sets the actual style of used for the data points.
        /// </summary>
        protected Style ActualDataPointStyle { get; set; }

        #region public int GlobalSeriesIndex
        /// <summary>
        /// Gets the index of the series in the Parent's series collection.
        /// </summary>
        public int GlobalSeriesIndex
        {
            get { return (int)GetValue(GlobalSeriesIndexProperty); }
            private set { SetValue(GlobalSeriesIndexProperty, value); }
        }

        /// <summary>
        /// Identifies the GlobalSeriesIndex dependency property.
        /// </summary>
        public static readonly DependencyProperty GlobalSeriesIndexProperty =
            DependencyProperty.Register(
                "GlobalSeriesIndex",
                typeof(int),
                typeof(Series),
                new PropertyMetadata(-1, OnGlobalSeriesIndexPropertyChanged));

        /// <summary>
        /// GlobalSeriesIndexProperty property changed handler.
        /// </summary>
        /// <param name="d">Series that changed its Index.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnGlobalSeriesIndexPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            DataPointSingleSeriesWithAxes source = (DataPointSingleSeriesWithAxes)d;
            int oldValue = (int)e.OldValue;
            int newValue = (int)e.NewValue;
            source.OnGlobalSeriesIndexPropertyChanged(oldValue, newValue);
        }

        /// <summary>
        /// GlobalSeriesIndexProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2233:OperationsShouldNotOverflow", MessageId = "newValue+1", Justification = "Impractical to add as many Series as it would take to overflow.")]
        protected virtual void OnGlobalSeriesIndexPropertyChanged(int oldValue, int newValue)
        {
            LegendItem.Content = Title;

            if (!CustomTitleInUse)
            {
                Title = (0 <= newValue) ? string.Format(CultureInfo.CurrentCulture, Properties.Resources.Series_OnGlobalSeriesIndexPropertyChanged_UntitledSeriesFormatString, newValue + 1) : null;
                // Setting Title will set CustomTitleInUse; reset it now
                CustomTitleInUse = false;
            }
        }
        #endregion public int GlobalSeriesIndex

        /// <summary>
        /// Called when the Title property changes.
        /// </summary>
        /// <param name="oldValue">Old value of the Title property.</param>
        /// <param name="newValue">New value of the Title property.</param>
        protected override void OnTitleChanged(object oldValue, object newValue)
        {
            // Title property is being set, so a custom Title is in use
            CustomTitleInUse = true;
            LegendItem.Content = Title;
        }

        /// <summary>
        /// Initializes a new instance of the DynamicSingleSeries class.
        /// </summary>
        internal DataPointSingleSeriesWithAxes()
        {
        }

        /// <summary>
        /// Returns the data point style to use for all data points in the 
        /// series.
        /// </summary>
        /// <returns>The data point style to use for all charts in the series.
        /// </returns>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "This property does more work than get functions typically do.")]
        protected abstract Style GetDataPointStyleFromHost();

        /// <summary>
        /// Insert grid containing data point used for legend item into the 
        /// plot area.
        /// </summary>
        /// <param name="oldValue">The old plot area.</param>
        /// <param name="newValue">The new plot area.</param>
        protected override void OnPlotAreaChanged(Canvas oldValue, Canvas newValue)
        {
            if (newValue != null)
            {
                CreateLegendItemDataPoint();
            }
            base.OnPlotAreaChanged(oldValue, newValue);
        }

        /// <summary>
        /// When the series host property is set retrieves a style to use for all the
        /// data points.
        /// </summary>
        /// <param name="oldValue">The old series host value.</param>
        /// <param name="newValue">The new series host value.</param>
        protected override void OnSeriesHostPropertyChanged(ISeriesHost oldValue, ISeriesHost newValue)
        {
            base.OnSeriesHostPropertyChanged(oldValue, newValue);

            if (newValue != null)
            {
                ActualDataPointStyle = DataPointStyle ?? GetDataPointStyleFromHost();
                CreateLegendItemDataPoint();
            }
        }

        /// <summary>
        /// Creates the LegendItem Control if conditions are right.
        /// </summary>
        private void CreateLegendItemDataPoint()
        {
            DataPoint dataPoint = CreateDataPoint();
            dataPoint.Style = ActualDataPointStyle;
            LegendItem.Content = Title;
            LegendItem.Loaded += delegate
            {
                // Wait for Loaded to set the DataPoint
                LegendItem.DataContext = dataPoint;
            };
        }

        /// <summary>
        /// Method invoked after data points have been loaded from the ItemsSource.
        /// </summary>
        protected override void OnDataPointsLoaded()
        {
            base.OnDataPointsLoaded();

            if (null != PlotArea)
            {
                // Create the Control for use by LegendItem
                // Add it to the visual tree so that its style will be applied
                if (null != LegendItem.DataContext)
                {
                    PlotArea.Children.Remove(LegendItem.DataContext as UIElement);
                }
            }
        }

        /// <summary>
        /// Sets the style of the data point to the single style used for all
        /// data points.
        /// </summary>
        /// <param name="dataPoint">The data point to apply the style to.
        /// </param>
        /// <param name="dataContext">The object associated with the data point.
        /// </param>
        protected override void PrepareDataPoint(DataPoint dataPoint, object dataContext)
        {
            if (dataPoint.Style == null)
            {
                dataPoint.Style = ActualDataPointStyle;
            }

            base.PrepareDataPoint(dataPoint, dataContext);
        }

        /// <summary>
        /// This method updates the global series index property.
        /// </summary>
        /// <param name="globalIndex">The global index of the series.</param>
        public void GlobalSeriesIndexChanged(int globalIndex)
        {
            this.GlobalSeriesIndex = globalIndex;
        }

        /// <summary>
        /// Refreshes the styles in the series.
        /// </summary>
        public override void RefreshStyles()
        {
            if (this.SeriesHost != null)
            {
                ActualDataPointStyle = DataPointStyle ?? GetDataPointStyleFromHost();
                CreateLegendItemDataPoint();
                Refresh();
            }
        }
    }
}