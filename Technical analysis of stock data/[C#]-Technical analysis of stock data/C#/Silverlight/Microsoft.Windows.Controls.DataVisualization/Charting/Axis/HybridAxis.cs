// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Media;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// An axis that has a range.
    /// </summary>
    public abstract class HybridAxis : Axis, IAxisGridLinesElementProvider
    {
        /// <summary>
        /// Maximum intervals per 200 pixels.
        /// </summary>
        protected const double MaximumAxisIntervalsPer200Pixels = 8;

        /// <summary>
        /// The name of the axis grid template part.
        /// </summary>
        protected const string AxisGridName = "AxisGrid";

        /// <summary>
        /// The name of the axis title template part.
        /// </summary>
        protected const string AxisTitleName = "AxisTitle";

        #region public Style AxisLabelStyle
        /// <summary>
        /// Gets or sets the style used for the axis labels.
        /// </summary>
        public Style AxisLabelStyle
        {
            get { return GetValue(AxisLabelStyleProperty) as Style; }
            set { SetValue(AxisLabelStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the AxisLabelStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty AxisLabelStyleProperty =
            DependencyProperty.Register(
                "AxisLabelStyle",
                typeof(Style),
                typeof(HybridAxis),
                new PropertyMetadata(null));
        #endregion public Style AxisLabelStyle

        /// <summary>
        /// Gets the axis length.
        /// </summary>
        protected double ActualLength
        {
            get
            {
                return (OrientedPanel.Orientation == System.Windows.Controls.Orientation.Horizontal)
                    ? OrientedPanel.ActualWidth : OrientedPanel.ActualHeight;
            }
        }

        #region private GridLines GridLines

        /// <summary>
        /// This field stores the grid lines element.
        /// </summary>
        private GridLines _gridLines;

        /// <summary>
        /// Gets or sets the grid lines property.
        /// </summary>
        private GridLines GridLines
        {
            get { return _gridLines; }
            set 
            { 
                if (value != _gridLines)
                {
                    GridLines oldValue = _gridLines;
                    _gridLines = value;
                    OnGridLinesPropertyChanged(oldValue, value);
                }
            }
        }

        /// <summary>
        /// GridLinesProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>        
        private void OnGridLinesPropertyChanged(GridLines oldValue, GridLines newValue)
        {
            RoutedPropertyChangedEventHandler<UIElement> listeners = _gridLinesElementPropertyChanged;
            if (listeners != null)
            {
                listeners(this, new RoutedPropertyChangedEventArgs<UIElement>(oldValue, newValue));
            }
        }
        #endregion private GridLines GridLines

        #region public Style MajorTickMarkStyle
        /// <summary>
        /// Gets or sets the style applied to the Axis tick marks.
        /// </summary>
        /// <value>The Style applied to the Axis tick marks.</value>
        public Style MajorTickMarkStyle
        {
            get { return GetValue(MajorTickMarkStyleProperty) as Style; }
            set { SetValue(MajorTickMarkStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the MajorTickMarkStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty MajorTickMarkStyleProperty =
            DependencyProperty.Register(
                "MajorTickMarkStyle",
                typeof(Style),
                typeof(HybridAxis),
                null);
        #endregion

        #region public object Title
        /// <summary>
        /// Gets or sets the title property.
        /// </summary>
        public object Title
        {
            get { return GetValue(TitleProperty) as object; }
            set { SetValue(TitleProperty, value); }
        }

        /// <summary>
        /// Identifies the Title dependency property.
        /// </summary>
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register(
                "Title",
                typeof(object),
                typeof(HybridAxis),
                new PropertyMetadata(null, OnTitlePropertyChanged));

        /// <summary>
        /// TitleProperty property changed handler.
        /// </summary>
        /// <param name="d">HybridAxis that changed its Title.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnTitlePropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HybridAxis source = (HybridAxis)d;
            object oldValue = (object)e.OldValue;
            object newValue = (object)e.NewValue;
            source.OnTitlePropertyChanged(oldValue, newValue);
        }

        /// <summary>
        /// TitleProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>        
        protected virtual void OnTitlePropertyChanged(object oldValue, object newValue)
        {
            if (this.AxisTitle != null)
            {
                this.AxisTitle.Content = Title;
            }
        }
        #endregion public object Title

        /// <summary>
        /// Gets or sets the LayoutTransformControl used to rotate the title.
        /// </summary>
        private LayoutTransformControl TitleLayoutTransformControl { get; set; }

        #region public Style TitleStyle
        /// <summary>
        /// Gets or sets the style applied to the Axis title.
        /// </summary>
        /// <value>The Style applied to the Axis title.</value>
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
                typeof(HybridAxis),
                null);
        #endregion

        #region public bool ShowGridLines
        /// <summary>
        /// Gets or sets a value indicating whether grid lines should be shown.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLines", Justification = "This is the expected casing.")]
        public bool ShowGridLines
        {
            get { return (bool)GetValue(ShowGridLinesProperty); }
            set { SetValue(ShowGridLinesProperty, value); }
        }

        /// <summary>
        /// Identifies the ShowGridLines dependency property.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLines", Justification = "This is the expected capitalization.")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLine", Justification = "This is the expected capitalization.")]
        public static readonly DependencyProperty ShowGridLinesProperty =
            DependencyProperty.Register(
                "ShowGridLines",
                typeof(bool),
                typeof(HybridAxis),
                new PropertyMetadata(false, OnShowGridLinesPropertyChanged));

        /// <summary>
        /// ShowGridLinesProperty property changed handler.
        /// </summary>
        /// <param name="d">Axis that changed its ShowGridLines.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnShowGridLinesPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            HybridAxis source = (HybridAxis)d;
            bool oldValue = (bool)e.OldValue;
            bool newValue = (bool)e.NewValue;
            source.OnShowGridLinesPropertyChanged(oldValue, newValue);
        }

        /// <summary>
        /// ShowGridLinesProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>        
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLine", Justification = "This is the expected capitalization.")]
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLines", Justification = "This is the expected capitalization.")]
        protected virtual void OnShowGridLinesPropertyChanged(bool oldValue, bool newValue)
        {
            if (newValue == true)
            {
                this.GridLines = new GridLines(this);
            }
            else
            {
                this.GridLines = null;
            }
        }
        #endregion public bool ShowGridLines

        #region public Style GridLineStyle
        /// <summary>
        /// Gets or sets the Style of the Axis's gridlines.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLine", Justification = "Current casing is the expected one.")]
        public Style GridLineStyle
        {
            get { return GetValue(GridLineStyleProperty) as Style; }
            set { SetValue(GridLineStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the GridlineStyle dependency property.
        /// </summary>
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLine", Justification = "Current casing is the expected one.")]
        public static readonly DependencyProperty GridLineStyleProperty =
            DependencyProperty.Register(
                "GridLineStyle",
                typeof(Style),
                typeof(HybridAxis),
                null);
        #endregion

        /// <summary>
        /// The grid used to layout the axis.
        /// </summary>
        private Grid _grid;

        /// <summary>
        /// Gets or sets the grid used to layout the axis.
        /// </summary>
        private Grid AxisGrid
        {
            get
            {
                return _grid;
            }
            set
            {
                if (_grid != value)
                {
                    if (_grid != null)
                    {
                        _grid.Children.Clear();
                    }

                    _grid = value;

                    if (_grid != null)
                    {
                        _grid.Children.Add(this.OrientedPanel);
                        if (this.AxisTitle != null)
                        {
                            _grid.Children.Add(this.AxisTitle);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Gets the oriented panel used to layout the axis labels.
        /// </summary>
        internal OrientedPanel OrientedPanel { get; private set; }

        /// <summary>
        /// The control used to display the axis title.
        /// </summary>
        private Title _axisTitle;

        /// <summary>
        /// Gets or sets the title control used to display the title.
        /// </summary>
        public Title AxisTitle
        {
            get
            {
                return _axisTitle;
            }
            set
            {
                if (_axisTitle != value)
                {
                    if (_axisTitle != null)
                    {
                        _axisTitle.Content = null;
                    }

                    _axisTitle = value;
                    if (Title != null)
                    {
                        _axisTitle.Content = Title;
                    }
                }
            }
        }

        /// <summary>
        /// Creates a major axis tick mark.
        /// </summary>
        /// <returns>A line to used to render a tick mark.</returns>
        protected virtual Line CreateMajorTickMark()
        {
            return CreateTickMark(MajorTickMarkStyle);
        }

        /// <summary>
        /// Creates a tick mark and applies a style to it.
        /// </summary>
        /// <param name="style">The style to apply.</param>
        /// <returns>The newly created tick mark.</returns>
        protected Line CreateTickMark(Style style)
        {
            Line line = new Line();
            line.Style = style;
            if (this.Orientation == AxisOrientation.Vertical)
            {
                line.Y1 = 0.5;
                line.Y2 = 0.5;
            }
            else if (this.Orientation == AxisOrientation.Horizontal)
            {
                line.X1 = 0.5;
                line.X2 = 0.5;
            }
            return line;
        }

        /// <summary>
        /// This method is used to share the grid line coordinates with the
        /// internal grid lines control.
        /// </summary>
        /// <returns>A sequence of the major grid line coordinates.</returns>
        internal IEnumerable<double> InternalGetMajorGridLineCoordinates()
        {
            return GetMajorGridLineCoordinates();
        }
        
        /// <summary>
        /// Returns the coordinates to use for the grid line control.
        /// </summary>
        /// <returns>A sequence of coordinates at which to draw grid lines.
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLine", Justification = "This is the expected capitalization.")]
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "Returns the coordinates of the grid lines.")]
        protected abstract IEnumerable<double> GetMajorGridLineCoordinates();

        /// <summary>
        /// Instantiates a new instance of the HybridAxis class.
        /// </summary>
        internal HybridAxis()
        {
            this.DefaultStyleKey = typeof(HybridAxis);
            this.OrientedPanel = new OrientedPanel();
            this.OrientedPanel.UseLayoutRounding = true;
            this.OrientedPanel.SizeChanged += new SizeChangedEventHandler(OnOrientedPanelSizeChanged);
            this.TitleLayoutTransformControl = new LayoutTransformControl();
            this.TitleLayoutTransformControl.HorizontalAlignment = HorizontalAlignment.Center;
            this.TitleLayoutTransformControl.VerticalAlignment = VerticalAlignment.Center;
        }

        /// <summary>
        /// Creates an axis label.
        /// </summary>
        /// <returns>The new axis label.</returns>
        protected virtual ContentControl CreateAxisLabel()
        {
            return new AxisLabel();
        }

        /// <summary>
        /// Prepares an axis label to be plotted.
        /// </summary>
        /// <param name="label">The axis label to prepare.</param>
        /// <param name="dataContext">The data context to use for the axis 
        /// label.</param>
        protected virtual void PrepareAxisLabel(ContentControl label, object dataContext)
        {
            label.DataContext = dataContext;
            label.Style = AxisLabelStyle;
        }

        /// <summary>
        /// Creates and prepares an axis label.
        /// </summary>
        /// <param name="dataContext">The data context to assign to the axis
        /// label.</param>
        /// <returns>A new axis label.</returns>
        protected ContentControl CreateAndPrepareAxisLabel(object dataContext)
        {
            ContentControl label = CreateAxisLabel();
            PrepareAxisLabel(label, dataContext);
            return label;
        }

        /// <summary>
        /// Retrieves template parts and configures layout.
        /// </summary>
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();

            this.AxisGrid = GetTemplateChild(AxisGridName) as Grid;
            this.AxisTitle = GetTemplateChild(AxisTitleName) as Title;
            if (this.AxisTitle != null && this.AxisGrid.Children.Contains(this.AxisTitle))
            {
                this.AxisGrid.Children.Remove(this.AxisTitle);
                this.TitleLayoutTransformControl.Child = this.AxisTitle;
                this.AxisGrid.Children.Add(this.TitleLayoutTransformControl);
            }

            ArrangeAxisGrid();
        }

        /// <summary>
        /// When the size of the oriented panel changes invalidate the axis.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Information about the event.</param>
        private void OnOrientedPanelSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Arranges the grid when the location property is changed.
        /// </summary>
        /// <param name="oldValue">The old location.</param>
        /// <param name="newValue">The new location.</param>
        protected override void OnLocationPropertyChanged(AxisLocation oldValue, AxisLocation newValue)
        {
            ArrangeAxisGrid();
        }

        /// <summary>
        /// Arranges the elements in the axis grid.
        /// </summary>
        private void ArrangeAxisGrid()
        {
            if (this.AxisGrid != null)
            {
                this.AxisGrid.ColumnDefinitions.Clear();
                this.AxisGrid.RowDefinitions.Clear();
                IList<UIElement> children = this.AxisGrid.Children.ToList();
                children.Clear();

                if (this.Orientation == AxisOrientation.Vertical)
                {
                    this.TitleLayoutTransformControl.Transform = new RotateTransform { Angle = -90.0 };

                    this.OrientedPanel.Orientation = System.Windows.Controls.Orientation.Vertical;
                    this.OrientedPanel.IsInverted = !(Location == AxisLocation.Right);
                    this.OrientedPanel.IsReversed = true;
                    this.AxisGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    this.AxisGrid.RowDefinitions.Add(new RowDefinition());

                    int column = 0;
                    if (this.AxisTitle != null)
                    {
                        this.AxisGrid.ColumnDefinitions.Add(new ColumnDefinition());
                        Grid.SetRow(this.TitleLayoutTransformControl, 0);
                        Grid.SetColumn(this.TitleLayoutTransformControl, 0);
                        column++;
                    }
                    Grid.SetRow(this.OrientedPanel, 0);
                    Grid.SetColumn(this.OrientedPanel, column);
                }
                else if (this.Orientation == AxisOrientation.Horizontal)
                {
                    this.TitleLayoutTransformControl.Transform = new RotateTransform { Angle = 0 };

                    this.OrientedPanel.Orientation = System.Windows.Controls.Orientation.Horizontal;
                    this.OrientedPanel.IsInverted = (Location == AxisLocation.Top);
                    this.OrientedPanel.IsReversed = false;
                    this.AxisGrid.ColumnDefinitions.Add(new ColumnDefinition());
                    this.AxisGrid.RowDefinitions.Add(new RowDefinition());

                    if (this.AxisTitle != null)
                    {
                        this.AxisGrid.RowDefinitions.Add(new RowDefinition());
                        Grid.SetColumn(this.TitleLayoutTransformControl, 0);
                        Grid.SetRow(this.TitleLayoutTransformControl, 1);
                    }
                    Grid.SetColumn(this.OrientedPanel, 0);
                    Grid.SetRow(this.OrientedPanel, 0);
                }

                foreach (UIElement child in children)
                {
                    AxisGrid.Children.Add(child);
                }

                if (this.Location == AxisLocation.Top)
                {
                    AxisGrid.Mirror(System.Windows.Controls.Orientation.Horizontal);
                }
                else if (this.Location == AxisLocation.Right)
                {
                    AxisGrid.Mirror(System.Windows.Controls.Orientation.Vertical);
                    this.TitleLayoutTransformControl.Transform = new RotateTransform { Angle = 90 };
                }

                Invalidate();
            }
        }

        /// <summary>
        /// Reformulates the grid when the orientation is changed.  Grid is
        /// either separated into two columns or two rows.  The title is 
        /// inserted with the outermost section from the edge and an oriented
        /// panel is inserted into the innermost section.
        /// </summary>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected override void OnOrientationPropertyChanged(AxisOrientation oldValue, AxisOrientation newValue)
        {
            ArrangeAxisGrid();
            base.OnOrientationPropertyChanged(oldValue, newValue);
        }

        /// <summary>
        /// Updates the visual appearance of the axis when it is invalidated.
        /// </summary>
        /// <param name="args">Information for the invalidated event.</param>
        protected override void OnInvalidated(RoutedEventArgs args)
        {
            if (AxisGrid != null)
            {
                Render();
            }
            base.OnInvalidated(args);
        }

        /// <summary>
        /// Renders the axis labels, tick marks, and other visual elements.
        /// </summary>
        protected abstract void Render();

        /// <summary>
        /// Invalidates the axis.
        /// </summary>
        protected void Invalidate()
        {
            OnInvalidated(new RoutedEventArgs());
        }

        /// <summary>
        /// Gets the grid lines object used by the axis.
        /// </summary>
        UIElement IAxisGridLinesElementProvider.GridLinesElement
        {
            get { return this.GridLines; }
        }

        /// <summary>
        /// A field that tracks the listeners of the grid lines element property
        /// change event.
        /// </summary>
        private RoutedPropertyChangedEventHandler<UIElement> _gridLinesElementPropertyChanged;

        /// <summary>
        /// An event raised when the grid lines element property changes.
        /// </summary>
        event RoutedPropertyChangedEventHandler<UIElement> IAxisGridLinesElementProvider.GridLinesElementChanged
        {
            add { _gridLinesElementPropertyChanged += value; }
            remove { _gridLinesElementPropertyChanged -= value; }
        }
    }
}