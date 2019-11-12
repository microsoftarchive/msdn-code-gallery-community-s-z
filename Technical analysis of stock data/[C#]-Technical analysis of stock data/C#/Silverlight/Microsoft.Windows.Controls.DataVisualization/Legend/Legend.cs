// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Microsoft.Windows.Controls.DataVisualization
{
    /// <summary>
    /// Represents a control that displays a list of items and has a title.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    [StyleTypedProperty(Property = "TitleStyle", StyleTargetType = typeof(Title))]
    [TemplatePart(Name = Legend.LegendItemsAreaName, Type = typeof(Panel))]
    public partial class Legend : Control
    {
        /// <summary>
        /// Legend area name.
        /// </summary>
        private const string LegendItemsAreaName = "LegendItemsArea";

        #region public object Title
        /// <summary>
        /// Gets or sets the title content of the Legend.
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
                typeof(Legend),
                new PropertyMetadata(null, OnTitlePropertyChanged));

        /// <summary>
        /// TitleProperty property changed handler.
        /// </summary>
        /// <param name="d">Legend that changed its Title.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnTitlePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((Legend)d).UpdateLegendVisibility();
        }
        #endregion public object Title

        #region public Style TitleStyle
        /// <summary>
        /// Gets or sets the style applied to the Title property of the Legend.
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
                typeof(Legend),
                null);
        #endregion public Style TitleStyle

        /// <summary>
        /// Initializes a new instance of the Legend class.
        /// </summary>
        public Legend()
        {
            DefaultStyleKey = typeof(Legend);
            ObservableCollection<UIElement> legendItems = new ObservableCollection<UIElement>();
            legendItems.CollectionChanged += this.CollectionChanged;
            this.LegendItems = legendItems;
            _legendItemsLegendItemsAreaAdapter.Collection = legendItems;
        }

        /// <summary>
        /// Loads template parts when template is applied.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            if (LegendItemsArea != null)
            {
                LegendItemsArea.Children.Clear();
                _legendItemsLegendItemsAreaAdapter.TargetList = null;
            }

            LegendItemsArea = GetTemplateChild(LegendItemsAreaName) as Panel;
            if (LegendItemsArea != null)
            {
                _legendItemsLegendItemsAreaAdapter.TargetList = LegendItemsArea.Children;
                _legendItemsLegendItemsAreaAdapter.Populate();
            }
        }

        /// <summary>
        /// Gets or sets the reference to the LegendItemsArea.
        /// </summary>
        private Panel LegendItemsArea { get; set; }

        /// <summary>
        /// Object that synchronizes the collection of legend items with the 
        /// children in the legend items area container.
        /// </summary>
        private ObservableCollectionListAdapter<UIElement> _legendItemsLegendItemsAreaAdapter = new ObservableCollectionListAdapter<UIElement>();

        #region public IList LegendItems
        /// <summary>
        /// Gets a collection of legend items to insert into the legend 
        /// area.
        /// </summary>
        public IList LegendItems
        {
            get { return GetValue(LegendItemsProperty) as IList; }
            private set { SetValue(LegendItemsProperty, value); }
        }

        /// <summary>
        /// Identifies the LegendItems dependency property.
        /// </summary>
        public static readonly DependencyProperty LegendItemsProperty =
            DependencyProperty.Register(
                "LegendItems",
                typeof(IList),
                typeof(Legend),
                new PropertyMetadata(null));

        #endregion public IList LegendItems

        /// <summary>
        /// Handles the CollectionChanged event for ItemsSource.
        /// </summary>
        /// <param name="sender">Event source.</param>
        /// <param name="e">Event arguments.</param>
        private void CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
        {
            UpdateLegendVisibility();
        }

        /// <summary>
        /// Updates the Legend's Visibility property according to whether it has anything to display.
        /// </summary>
        private void UpdateLegendVisibility()
        {
            IList legendItems = LegendItems;
            bool implementsINotifyCollectionChanged = null != (legendItems as INotifyCollectionChanged);
            // Visible iff: Title is set OR ItemsSource is set and it (doesn't implement INCC OR (does AND is currently empty))
            bool visible = (null != Title) || ((null != legendItems && legendItems.Count != 0) && (!implementsINotifyCollectionChanged || !legendItems.Cast<object>().IsEmpty()));
            Visibility = visible ? Visibility.Visible : Visibility.Collapsed;
        }
    }
}
