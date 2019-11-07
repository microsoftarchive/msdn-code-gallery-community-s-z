// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using System.Globalization;
using System.ComponentModel;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// Represents a control that displays a Chart.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    [TemplatePart(Name = Chart.ChartAreaName, Type = typeof(Grid))]
    [TemplatePart(Name = Chart.PlotAreaName, Type = typeof(Grid))]
    [TemplatePart(Name = Chart.SeriesContainerName, Type = typeof(Panel))]
    [TemplatePart(Name = Chart.GridLinesContainerName, Type = typeof(Panel))]
    [TemplatePart(Name = Chart.LegendName, Type = typeof(Legend))]
    [StyleTypedProperty(Property = "TitleStyle", StyleTargetType = typeof(Title))]
    [StyleTypedProperty(Property = "LegendStyle", StyleTargetType = typeof(Legend))]
    [StyleTypedProperty(Property = "ChartAreaStyle", StyleTargetType = typeof(Grid))]
    [StyleTypedProperty(Property = "PlotAreaStyle", StyleTargetType = typeof(Grid))]
    [ContentProperty("Series")]
    public sealed partial class Chart : Control, ISeriesHost
    {
        /// <summary>
        /// Specifies the name of the ChartArea TemplatePart.
        /// </summary>
        private const string ChartAreaName = "ChartArea";

        /// <summary>
        /// Specifies the name of the PlotArea TemplatePart.
        /// </summary>
        private const string PlotAreaName = "PlotArea";

        /// <summary>
        /// Specifies the name of the SeriesContainer TemplatePart.
        /// </summary>
        private const string SeriesContainerName = "SeriesContainer";

        /// <summary>
        /// Specifies the name of the GridLinesContainer TemplatePart.
        /// </summary>
        private const string GridLinesContainerName = "GridLinesContainer";

        /// <summary>
        /// Specifies the name of the legend TemplatePart.
        /// </summary>
        private const string LegendName = "Legend";

        /// <summary>
        /// Event fired when axes collection changes.
        /// </summary>
        internal event NotifyCollectionChangedEventHandler AxesChanged;

        /// <summary>
        /// Stores the grid line container children.
        /// </summary>
        private ObservableCollection<UIElement> _gridLinesContainerChildren = new ObservableCollection<UIElement>();

        /// <summary>
        /// Migrates changes from the chart area children list to the chart area panel.
        /// </summary>
        private ObservableCollectionListAdapter<UIElement> _gridLinesContainerChildrenChartAreaAdapter = new ObservableCollectionListAdapter<UIElement>();

        /// <summary>
        /// Stores the legend children.
        /// </summary>
        private ObservableCollectionListAdapter<UIElement> _legendChildrenLegendAdapter = new ObservableCollectionListAdapter<UIElement>();
            
        /// <summary>
        /// Gets or sets a collection of Axes in the ISeriesHost.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Setter is public to work around a limitation with the XAML editing tools.")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value", Justification = "Setter is public to work around a limitation with the XAML editing tools.")]
        public IList Axes
        {
            get
            {
                return _axes;
            }
            set
            {
                throw new NotSupportedException(Properties.Resources.Chart_Axes_SetterNotSupported);
            }
        }

        /// <summary>
        /// Stores the collection of Axes in the ISeriesHost.
        /// </summary>
        private IList _axes;

        /// <summary>
        /// Gets or sets the axes that are currently in the chart.
        /// </summary>
        private IList<IAxis> InternalActualAxes { get; set; }

        /// <summary>
        /// Gets the actual axes displayed in the chart.
        /// </summary>
        public ReadOnlyCollection<IAxis> ActualAxes { get; private set; }

        /// <summary>
        /// Gets or sets the reference to the template's ChartArea.
        /// </summary>
        private Grid ChartArea { get; set; }

        /// <summary>
        /// Gets or sets the reference to the ISeriesHost's PlotArea.
        /// </summary>
        private Grid PlotArea { get; set; }

        /// <summary>
        /// Gets or sets the reference to the ISeriesHost's SeriesContainer.
        /// </summary>
        private Panel SeriesContainer { get; set; }

        /// <summary>
        /// Gets or sets the reference to the ISeriesHost's GridLinesContainer.
        /// </summary>
        private Panel GridLinesContainer { get; set; }

        /// <summary>
        /// Gets or sets the reference to the Chart's Legend.
        /// </summary>
        private Legend Legend { get; set; }

        /// <summary>
        /// The adapter that synchronizes the series collection with the series 
        /// container children.
        /// </summary>
        private ObservableCollectionListAdapter<Series> _seriesCollectionSeriesContainerAdapter = new ObservableCollectionListAdapter<Series>();

        /// <summary>
        /// Gets or sets the collection of Series displayed by the ISeriesHost.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Setter is public to work around a limitation with the XAML editing tools.")]
        [SuppressMessage("Microsoft.Usage", "CA1801:ReviewUnusedParameters", MessageId = "value", Justification = "Setter is public to work around a limitation with the XAML editing tools.")]
        public IList Series
        {
            get
            {
                return _series;
            }
            set
            {
                throw new NotSupportedException(Properties.Resources.Chart_Series_SetterNotSupported);
            }
        }
        
        /// <summary>
        /// Stores the collection of Series displayed by the ISeriesHost.
        /// </summary>
        private IList _series;

        #region public Style ChartAreaStyle
        /// <summary>
        /// Gets or sets the Style of the ISeriesHost's ChartArea.
        /// </summary>
        public Style ChartAreaStyle
        {
            get { return GetValue(ChartAreaStyleProperty) as Style; }
            set { SetValue(ChartAreaStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the ChartAreaStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty ChartAreaStyleProperty =
            DependencyProperty.Register(
                "ChartAreaStyle",
                typeof(Style),
                typeof(Chart),
                null);
        #endregion public Style ChartAreaStyle

        #region public IList LegendItems

        /// <summary>
        /// A value indicating whether the legend items is being set by the
        /// class.
        /// </summary>
        private bool _isSettingLegendItems;

        /// <summary>
        /// Gets the collection of legend items.
        /// </summary>
        public IList LegendItems
        {
            get { return GetValue(LegendItemsProperty) as IList; }
            private set 
            {
                _isSettingLegendItems = true;
                try
                {
                    SetValue(LegendItemsProperty, value);
                }
                finally
                {
                    _isSettingLegendItems = false;
                }
            }
        }

        /// <summary>
        /// Identifies the LegendItems dependency property.
        /// </summary>
        public static readonly DependencyProperty LegendItemsProperty =
            DependencyProperty.Register(
                "LegendItems",
                typeof(IList),
                typeof(Chart),
                new PropertyMetadata(null, OnLegendItemsPropertyChanged));

        /// <summary>
        /// Called when the value of the LegendItems property is changed.
        /// </summary>
        /// <param name="d">Chart that changed its LegendItems.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnLegendItemsPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Chart source = (Chart)d;
            IList oldValue = (IList)e.OldValue;
            source.OnLegendItemsPropertyChanged(oldValue);
        }

        /// <summary>
        /// LegendItemsProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        private void OnLegendItemsPropertyChanged(IList oldValue)
        {
            if (!_isSettingLegendItems)
            {
                this.LegendItems = oldValue;
                throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Properties.Resources.DataVisualization_ReadOnlyDependencyPropertyChange, "LegendItems"));
            }
        }
        #endregion public IList LegendItems

        #region public Style LegendStyle
        /// <summary>
        /// Gets or sets the Style of the ISeriesHost's Legend.
        /// </summary>
        public Style LegendStyle
        {
            get { return GetValue(LegendStyleProperty) as Style; }
            set { SetValue(LegendStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the LegendStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty LegendStyleProperty =
            DependencyProperty.Register(
                "LegendStyle",
                typeof(Style),
                typeof(Chart),
                null);
        #endregion public Style LegendStyle

        #region public object LegendTitle
        /// <summary>
        /// Gets or sets the Title content of the Legend.
        /// </summary>
        public object LegendTitle
        {
            get { return GetValue(LegendTitleProperty); }
            set { SetValue(LegendTitleProperty, value); }
        }

        /// <summary>
        /// Identifies the LegendTitle dependency property.
        /// </summary>
        public static readonly DependencyProperty LegendTitleProperty =
            DependencyProperty.Register(
                "LegendTitle",
                typeof(object),
                typeof(Chart),
                null);
        #endregion public object LegendTitle

        #region public Style PlotAreaStyle
        /// <summary>
        /// Gets or sets the Style of the ISeriesHost's PlotArea.
        /// </summary>
        public Style PlotAreaStyle
        {
            get { return GetValue(PlotAreaStyleProperty) as Style; }
            set { SetValue(PlotAreaStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the PlotAreaStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty PlotAreaStyleProperty =
            DependencyProperty.Register(
                "PlotAreaStyle",
                typeof(Style),
                typeof(Chart),
                null);
        #endregion public Style PlotAreaStyle

        #region public IList StylePalette
        /// <summary>
        /// Gets or sets a palette of styles used by the children of the ISeriesHost.
        /// </summary>
        [SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly", Justification = "Want to allow this to be set from XAML.")]
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
                typeof(Chart),
                new PropertyMetadata(OnStylePalettePropertyChanged));

        /// <summary>
        /// Called when the value of the StylePalette property is changed.
        /// </summary>
        /// <param name="d">Chart that contains the changed StylePalette.
        /// </param>
        /// <param name="e">Event arguments.</param>
        private static void OnStylePalettePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            Chart source = (Chart) d;
            IList newValue = (IList) e.NewValue;
            source.OnStylePalettePropertyChanged(newValue);
        }

        /// <summary>
        /// Called when the value of the StylePalette property is changed.
        /// </summary>
        /// <param name="newValue">The new value for the StylePalette.</param>
        private void OnStylePalettePropertyChanged(IList newValue)
        {
            StyleDispenser.Styles = newValue;
            foreach (Series series in this.Series)
            {
                series.RefreshStyles();
            }
        }
        #endregion public IList StylePalette

        /// <summary>
        /// Gets or sets an object that rotates through the palette.
        /// </summary>
        private StyleDispenser StyleDispenser { get; set; }

        #region public object Title
        /// <summary>
        /// Gets or sets the title displayed for the Chart.
        /// </summary>
        public object Title
        {
            get { return GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies the Title dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                "Title",
                typeof(object),
                typeof(Chart),
                null);
        #endregion

        #region public Style TitleStyle
        /// <summary>
        /// Gets or sets the Style of the ISeriesHost's Title.
        /// </summary>
        public Style TitleStyle
        {
            get { return GetValue(TitleStyleProperty) as Style; }
            set { SetValue(TitleStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the TitleStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleStyleProperty =
            DependencyProperty.Register(
                "TitleStyle",
                typeof(Style),
                typeof(Chart),
                null);
        #endregion public Style TitleStyle

        /// <summary>
        /// Initializes a new instance of the ISeriesHost class.
        /// </summary>
        public Chart()
        {
            DefaultStyleKey = typeof(Chart);

            // Create the backing collection for Series
            ObservableCollection<Series> series = new NoResetObservableCollection<Series>();
            series.CollectionChanged += new NotifyCollectionChangedEventHandler(OnSeriesCollectionChanged);
            _series = series;
            _seriesCollectionSeriesContainerAdapter.Collection = series;

            // Create the backing collection for Axes
            ObservableCollection<IAxis> axes = new NoResetObservableCollection<IAxis>();
            axes.CollectionChanged += new NotifyCollectionChangedEventHandler(OnAxesCollectionChanged);
            _axes = axes;

            ObservableCollection<IAxis> actualAxes = new ObservableCollection<IAxis>();
            actualAxes.CollectionChanged += new NotifyCollectionChangedEventHandler(ActualAxesCollectionChanged);
            this.InternalActualAxes = actualAxes;
            this.ActualAxes = new ReadOnlyCollection<IAxis>(InternalActualAxes);

            _gridLinesContainerChildrenChartAreaAdapter.Collection = _gridLinesContainerChildren;

            // Create collection for LegendItems
            AggregatedObservableCollection<UIElement> chartLegendItems = new AggregatedObservableCollection<UIElement>();
            _legendChildrenLegendAdapter.Collection = chartLegendItems;
            LegendItems = chartLegendItems;

            ISeriesHost host = this as ISeriesHost;
            host.GlobalSeriesIndexesInvalidated += OnGlobalSeriesIndexesInvalidated;

            // Create style dispenser
            StyleDispenser = new StyleDispenser();
        }

        /// <summary>
        /// This method is fired when an axis's grid lines property changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">Information about the event.</param>
        private void AxisGridLinesElementChanged(object sender, RoutedPropertyChangedEventArgs<UIElement> args)
        {
            if (args.OldValue != null)
            {
                _gridLinesContainerChildren.Remove(args.OldValue);
            }
            if (args.NewValue != null)
            {
                _gridLinesContainerChildren.Add(args.NewValue);
            }
        }

        /// <summary>
        /// Adds an axis to the ISeriesHost area.
        /// </summary>
        /// <param name="axis">The axis to add to the ISeriesHost area.</param>
        private void AddAxisToChartArea(Axis axis)
        {          
            IAxisGridLinesElementProvider axisGridLinesElementProvider = axis as IAxisGridLinesElementProvider;
            if (axisGridLinesElementProvider != null)
            {
                axisGridLinesElementProvider.GridLinesElementChanged += AxisGridLinesElementChanged;
                if (axisGridLinesElementProvider.GridLinesElement != null)
                {
                    _gridLinesContainerChildren.Add(axisGridLinesElementProvider.GridLinesElement);
                }
            }
            axis.LocationChanged += AxisLocationChanged;
            axis.OrientationChanged += AxisOrientationChanged;

            if (ChartArea != null)
            {
                ChartArea.Children.Add(axis);
                RebuildChartArea();
            }
        }

        /// <summary>
        /// Rebuilds the chart area if an axis orientation is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">Information about the event.</param>
        private void AxisOrientationChanged(object sender, RoutedPropertyChangedEventArgs<AxisOrientation> args)
        {
            if (sender is Axis)
            {
                RebuildChartArea();
            }
        }

        /// <summary>
        /// Rebuild the chart area if an axis location is changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">Information about the event.</param>
        private void AxisLocationChanged(object sender, RoutedPropertyChangedEventArgs<AxisLocation> args)
        {
            if (sender is Axis)
            {
                RebuildChartArea();
            }
        }

        /// <summary>
        /// Rebuilds the chart area.
        /// </summary>
        private void RebuildChartArea()
        {
            if (ChartArea != null && PlotArea != null)
            {
                ISeriesHost seriesHost = this as ISeriesHost;
                IEnumerable<Axis> axes = seriesHost.Axes.OfType<Axis>();
                ChartArea.Children.Clear();
                ChartArea.RowDefinitions.Clear();
                ChartArea.ColumnDefinitions.Clear();

                IEnumerable<Axis> leftAxes = axes.Where(axis => axis.Location == AxisLocation.Left);
                IEnumerable<Axis> topAxes = axes.Where(axis => axis.Location == AxisLocation.Top);
                IEnumerable<Axis> rightAxes = axes.Where(axis => axis.Location == AxisLocation.Right);
                IEnumerable<Axis> bottomAxes = axes.Where(axis => axis.Location == AxisLocation.Bottom);

                // Choosing appropriate actual axis location values for Auto            
                int leftAxesCount = leftAxes.Count();
                int topAxesCount = topAxes.Count();
                int rightAxesCount = rightAxes.Count();
                int bottomAxesCount = bottomAxes.Count();

                IEnumerable<Axis> autoAxes = axes.Where(axis => axis.Location == AxisLocation.Auto);
                Axis autoAxis = autoAxes.FirstOrDefault();
                while (autoAxis != null)
                {
                    autoAxis.LocationChanged -= AxisLocationChanged;
                    if (autoAxis.Orientation == AxisOrientation.Horizontal)
                    {
                        if (bottomAxesCount <= topAxesCount)
                        {
                            autoAxis.Location = AxisLocation.Bottom;
                            bottomAxesCount++;
                        }
                        else
                        {
                            autoAxis.Location = AxisLocation.Top;
                            topAxesCount++;
                        }
                    }
                    else if (autoAxis.Orientation == AxisOrientation.Vertical)
                    {
                        if (leftAxesCount <= rightAxesCount)
                        {
                            autoAxis.Location = AxisLocation.Left;
                            leftAxesCount++;
                        }
                        else
                        {
                            autoAxis.Location = AxisLocation.Right;
                            rightAxesCount++;
                        }
                    }
                    autoAxis.LocationChanged += AxisLocationChanged;
                    autoAxis = autoAxes.FirstOrDefault();
                }

                // building grid
                int numTopAxes = topAxes.Count();
                int numLeftAxes = leftAxes.Count();

                topAxes.Reverse().ForEachWithIndex((axis, index) =>
                {
                    axis.HorizontalAlignment = HorizontalAlignment.Stretch;
                    axis.VerticalAlignment = VerticalAlignment.Bottom;
                    ChartArea.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    Grid.SetColumn(axis, numLeftAxes);
                    Grid.SetRow(axis, index);
                });

                leftAxes.Reverse().ForEachWithIndex((axis, index) =>
                {
                    axis.VerticalAlignment = VerticalAlignment.Stretch;
                    axis.HorizontalAlignment = HorizontalAlignment.Right;
                    ChartArea.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                    Grid.SetRow(axis, numTopAxes);
                    Grid.SetColumn(axis, index);
                });

                ChartArea.RowDefinitions.Add(new RowDefinition());
                ChartArea.ColumnDefinitions.Add(new ColumnDefinition());

                Grid.SetRow(PlotArea, numTopAxes);
                Grid.SetColumn(PlotArea, numLeftAxes);

                bottomAxes.ForEachWithIndex((axis, index) =>
                {
                    axis.HorizontalAlignment = HorizontalAlignment.Stretch;
                    axis.VerticalAlignment = VerticalAlignment.Top;
                    ChartArea.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                    Grid.SetColumn(axis, numLeftAxes);
                    Grid.SetRow(axis, numTopAxes + index + 1);
                });

                rightAxes.ForEachWithIndex((axis, index) =>
                {
                    axis.VerticalAlignment = VerticalAlignment.Stretch;
                    axis.HorizontalAlignment = HorizontalAlignment.Left;
                    ChartArea.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                    Grid.SetRow(axis, numTopAxes);
                    Grid.SetColumn(axis, numLeftAxes + index + 1);
                });

                foreach (Axis axis in seriesHost.Axes)
                {
                    ChartArea.Children.Add(axis);
                }

                ChartArea.Children.Add(PlotArea);
            }
        }

        /// <summary>
        /// Adds a series to the plot area and injects chart services.
        /// </summary>
        /// <param name="series">The series to add to the plot area.</param>
        private void AddSeriesToPlotArea(Series series)
        {
            series.SeriesHost = this;
            AggregatedObservableCollection<UIElement> chartLegendItems = this.LegendItems as AggregatedObservableCollection<UIElement>;

            int indexOfSeries = this.Series.IndexOf(series);
            chartLegendItems.ChildCollections.Insert(indexOfSeries, series.LegendItems);
            
            ISeriesHost host = series as ISeriesHost;
            if (host != null)
            {
                host.GlobalSeriesIndexesInvalidated += OnChildSeriesGlobalSeriesIndexesInvalidated;
            }
        }

        /// <summary>
        /// Builds the visual tree for the Chart control when a new template 
        /// is applied.
        /// </summary>
        public override void OnApplyTemplate()
        {
            // Call base implementation
            base.OnApplyTemplate();

            // Unhook events from former template parts
            if (null != ChartArea)
            {
                ChartArea.Children.Clear();
            }

            if (null != PlotArea)
            {
                PlotArea.Children.Clear();
            }

            if (null != SeriesContainer)
            {
                SeriesContainer.Children.Clear();
                _seriesCollectionSeriesContainerAdapter.TargetList = null;
            }

            if (null != GridLinesContainer)
            {
                GridLinesContainer.Children.Clear();
                _gridLinesContainerChildrenChartAreaAdapter.TargetList = null;
            }

            if (null != Legend)
            {
                Legend.LegendItems.Clear();
                _legendChildrenLegendAdapter.TargetList = null;
            }

            // Access new template parts
            ChartArea = GetTemplateChild(ChartAreaName) as Grid;
            PlotArea = GetTemplateChild(PlotAreaName) as Grid;
            SeriesContainer = GetTemplateChild(SeriesContainerName) as Panel;
            GridLinesContainer = GetTemplateChild(GridLinesContainerName) as Panel;
            Legend = GetTemplateChild(LegendName) as Legend;

            StyleDispenser.Reset();

            if (Legend != null)
            {
                _legendChildrenLegendAdapter.TargetList = Legend.LegendItems;
                _legendChildrenLegendAdapter.Populate();
            }

            if (SeriesContainer != null)
            {
                _seriesCollectionSeriesContainerAdapter.TargetList = SeriesContainer.Children;
                _seriesCollectionSeriesContainerAdapter.Populate();
            }

            if (GridLinesContainer != null)
            {
                _gridLinesContainerChildrenChartAreaAdapter.TargetList = GridLinesContainer.Children;
                _gridLinesContainerChildrenChartAreaAdapter.Populate();
            }

            if (ChartArea != null)
            {
                foreach (Axis axis in ActualAxes.OfType<Axis>())
                {
                    ChartArea.Children.Add(axis);
                }

                RebuildChartArea();
            }
        }

        /// <summar
        /// Ensures that ISeriesHost is in a consistent state when axes collection is
        /// changed.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event arguments.</param>
        private void OnAxesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (IAxis axis in e.NewItems)
                {
                    if (!InternalActualAxes.Contains(axis))
                    {
                        InternalActualAxes.Add(axis);
                    }
                }
            }
            if (e.OldItems != null)
            {
                foreach (IAxis axis in e.OldItems)
                {
                    if (!axis.IsUsed)
                    {
                        InternalActualAxes.Remove(axis);
                    }
                    else
                    {
                        throw new InvalidOperationException(Properties.Resources.Chart_OnAxesCollectionChanged_AnAxisCannotBeRemovedFromTheChartWhenItIsInUseByAnObject);
                    }
                }
            }

            NotifyCollectionChangedEventHandler handler = AxesChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        /// <summary>
        /// Ensures that ISeriesHost is in a consistent state when axes collection is
        /// changed.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event arguments.</param>
        private void ActualAxesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems != null)
            {
                foreach (Axis axis in e.NewItems.OfType<Axis>())
                {
                    AddAxisToChartArea(axis);
                }
            }
            if (e.OldItems != null)
            {
                foreach (Axis axis in e.OldItems.OfType<Axis>())
                {
                    RemoveAxisFromChartArea(axis);
                }
            }

            NotifyCollectionChangedEventHandler handler = AxesChanged;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        /// <summary>
        /// Updates the ISeriesHost legend items collection to reflect changes in any
        /// of the series legend items collections.
        /// </summary>
        /// <param name="sender">The series that had its legend items collection
        /// change.</param>
        /// <param name="args">Information about what changes were made to the
        /// collection.</param>
        private void OnSeriesLegendItemsChanged(object sender, NotifyCollectionChangedEventArgs args)
        {
            ReadOnlyObservableCollection<UIElement> chartLegendItems = LegendItems as ReadOnlyObservableCollection<UIElement>;
            if (args.OldItems != null)
            {
                foreach (UIElement item in args.OldItems)
                {
                    chartLegendItems.Mutate((items) => items.Remove(item));
                }
            }
            if (args.NewItems != null)
            {
                foreach (UIElement item in args.NewItems)
                {
                    chartLegendItems.Mutate((items) => items.Add(item));
                }
            }
        }

        /// <summary>
        /// Causes the Chart to refresh the data obtained from its data source 
        /// and render the resulting series.
        /// </summary>
        public void Refresh()
        {
            foreach (Series series in Series)
            {
                series.Refresh();
            }
        }

        /// <summary>
        /// Signals to the ISeriesHost that a series would like to use an axis.
        /// </summary>
        /// <param name="series">The series that would like to use the axis.
        /// </param>
        /// <param name="axis">The axis the series would like to use.</param>
        void ISeriesHost.RegisterWithAxis(Series series, IAxis axis)
        {
            if (series == null)
            {
                throw new ArgumentNullException("series");
            }
            if (axis == null)
            {
                throw new ArgumentNullException("axis");
            }

            axis.Register(series);
            if (!InternalActualAxes.Contains(axis))
            {
                InternalActualAxes.Add(axis);
            }
        }

        /// <summary>
        /// Removes an axis from the Chart area.
        /// </summary>
        /// <param name="axis">The axis to remove from the ISeriesHost area.</param>
        private void RemoveAxisFromChartArea(Axis axis)
        {
            IAxisGridLinesElementProvider axisGridLinesElementProvider = axis as IAxisGridLinesElementProvider;
            if (axisGridLinesElementProvider != null)
            {
                axisGridLinesElementProvider.GridLinesElementChanged -= AxisGridLinesElementChanged;
                if (axisGridLinesElementProvider.GridLinesElement != null)
                {
                    _gridLinesContainerChildren.Remove(axisGridLinesElementProvider.GridLinesElement);
                }
            }
            axis.LocationChanged -= AxisLocationChanged;
            axis.OrientationChanged -= AxisOrientationChanged;

            RebuildChartArea();
        }

        /// <summary>
        /// Removes a series from the plot area.
        /// </summary>
        /// <param name="series">The series to remove from the plot area.
        /// </param>
        private void RemoveSeriesFromPlotArea(Series series)
        {
            AggregatedObservableCollection<UIElement> legendItemsList = LegendItems as AggregatedObservableCollection<UIElement>;
            legendItemsList.ChildCollections.Remove(series.LegendItems);

            ISeriesHost host = series as ISeriesHost;
            if (host != null)
            {
                host.GlobalSeriesIndexesInvalidated -= OnChildSeriesGlobalSeriesIndexesInvalidated;
            }
            series.SeriesHost = null;
        }

        /// <summary>
        /// Called when the ObservableCollection.CollectionChanged property 
        /// changes.
        /// </summary>
        /// <param name="sender">The object that raised the event.</param>
        /// <param name="e">The event data.</param>
        private void OnSeriesCollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            // Clear ISeriesHost property of old Series
            if (null != e.OldItems)
            {
                foreach (Series series in e.OldItems)
                {
                    ISeriesHost host = series as ISeriesHost;
                    if (host != null)
                    {
                        foreach (IRequireGlobalSeriesIndex tracksGlobalIndex in host.GetDescendentSeries().OfType<IRequireGlobalSeriesIndex>())
                        {
                            tracksGlobalIndex.GlobalSeriesIndexChanged(-1);
                        }
                    }

                    RemoveSeriesFromPlotArea(series);
                }
            }

            // Set ISeriesHost property of new Series
            if (null != e.NewItems)
            {
                foreach (Series series in e.NewItems)
                {
                    AddSeriesToPlotArea(series);
                }
            }

            if (e.Action != NotifyCollectionChangedAction.Replace)
            {
                OnGlobalSeriesIndexesInvalidated(this, new RoutedEventArgs());
            }
        }

        /// <summary>
        /// Returns a style matching the specified target type from a pool of 
        /// available styles. Once all styles are used the available pool of 
        /// styles is reset.
        /// </summary>
        /// <param name="targetType">The target type of the requested style.
        /// </param>
        /// <param name="inherit">Whether to return ancestors of the 
        /// target type.</param>
        /// <returns>The next applicable style in the Styles collection.
        /// </returns>
        public Style NextStyle(Type targetType, bool inherit)
        {
            return StyleDispenser.NextStyle(targetType, inherit);
        }

        /// <summary>
        /// Method handles the event raised when a child series' global series
        /// indexes have changed.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">Information about the event.</param>
        private void OnChildSeriesGlobalSeriesIndexesInvalidated(object sender, RoutedEventArgs args)
        {
            if (_globalSeriesIndicesInvalidated != null)
            {
                _globalSeriesIndicesInvalidated(sender, args);
            }
        }

        /// <summary>
        /// Updates the global indexes of all descendents that require a global 
        /// index.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="args">The event data.</param>
        private void OnGlobalSeriesIndexesInvalidated(object sender, RoutedEventArgs args)
        {
            UpdateGlobalIndexes();
        }

        /// <summary>
        /// Updates the global index property of all Series that track their
        /// global index.
        /// </summary>
        private void UpdateGlobalIndexes()
        {
            (this as ISeriesHost).GetDescendentSeries().OfType<IRequireGlobalSeriesIndex>().ForEachWithIndex(
                (seriesThatTracksGlobalIndex, index) =>
                {
                    seriesThatTracksGlobalIndex.GlobalSeriesIndexChanged(index);
                });
        }

        /// <summary>
        /// Signals to the Chart that a Series no longer needs to use the axis 
        /// within this series host.
        /// </summary>
        /// <param name="series">The Series object that no longer needs to use 
        /// the axis.</param>
        /// <param name="axis">The axis that the Series no longer needs to use.
        /// </param>
        void ISeriesHost.UnregisterWithAxis(Series series, IAxis axis)
        {
            if (series == null)
            {
                throw new ArgumentNullException("series");
            }
            if (axis == null)
            {
                throw new ArgumentNullException("axis");
            }
            if (!ActualAxes.Contains(axis))
            {
                throw new InvalidOperationException(Properties.Resources.Chart_UnregisterWithSeries_OneAxisCannotBeUsedByMultipleCharts);
            }

            axis.Unregister(series);
            // If axis is no longer used and is not in external axes collection
            if (!axis.IsUsed && !Axes.Contains(axis))
            {
                InternalActualAxes.Remove(axis);
            }
        }

        /// <summary>
        /// Gets the Series host of the chart.
        /// </summary>
        /// <remarks>This will always return null.</remarks>
        ISeriesHost ISeriesHost.Parent
        {
            get { return null; }
        }

        /// <summary>
        /// Gets the axes collection of the chart.
        /// </summary>
        ReadOnlyCollection<IAxis> ISeriesHost.Axes
        {
            get { return ActualAxes; }
        }

        /// <summary>
        /// Gets the Series collection of the chart.
        /// </summary>
        IList<Series> ISeriesHost.Series
        {
            get { return this.Series as IList<Series>; }
        }

        /// <summary>
        /// This field is used to track listeners to the 
        /// GlobalSeriesIndexesInvalidated event.
        /// </summary>
        private RoutedEventHandler _globalSeriesIndicesInvalidated;

        /// <summary>
        /// This event is raised when global Series indices are invalidated.
        /// </summary>
        event RoutedEventHandler ISeriesHost.GlobalSeriesIndexesInvalidated
        {
            add { _globalSeriesIndicesInvalidated += value; }
            remove { _globalSeriesIndicesInvalidated -= value; }
        }
    }
}
