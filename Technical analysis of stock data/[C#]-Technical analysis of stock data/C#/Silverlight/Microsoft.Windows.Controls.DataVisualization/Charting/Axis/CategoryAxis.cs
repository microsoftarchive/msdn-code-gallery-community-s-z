// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// An axis that displays categories.
    /// </summary>
    [StyleTypedProperty(Property = "GridLineStyle", StyleTargetType = typeof(Line))]
    [StyleTypedProperty(Property = "MajorTickMarkStyle", StyleTargetType = typeof(Line))]
    [StyleTypedProperty(Property = "AxisLabelStyle", StyleTargetType = typeof(AxisLabel))]
    [StyleTypedProperty(Property = "TitleStyle", StyleTargetType = typeof(Title))]
    [TemplatePart(Name = AxisGridName, Type = typeof(Grid))]
    [TemplatePart(Name = AxisTitleName, Type = typeof(Title))]
    public sealed class CategoryAxis : HybridAxis, ICategoryAxis
    {
        #region public CategorySortOrder SortOrder
        /// <summary>
        /// Gets or sets the sort order used for the categories.
        /// </summary>
        public CategorySortOrder SortOrder
        {
            get { return (CategorySortOrder)GetValue(SortOrderProperty); }
            set { SetValue(SortOrderProperty, value); }
        }

        /// <summary>
        /// Identifies the SortOrder dependency property.
        /// </summary>
        public static readonly DependencyProperty SortOrderProperty =
            DependencyProperty.Register(
                "SortOrder",
                typeof(CategorySortOrder),
                typeof(CategoryAxis),
                new PropertyMetadata(CategorySortOrder.None, OnSortOrderPropertyChanged));

        /// <summary>
        /// SortOrderProperty property changed handler.
        /// </summary>
        /// <param name="d">CategoryAxis that changed its SortOrder.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnSortOrderPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            CategoryAxis source = (CategoryAxis)d;
            source.OnSortOrderPropertyChanged();
        }

        /// <summary>
        /// SortOrderProperty property changed handler.
        /// </summary>
        private void OnSortOrderPropertyChanged()
        {
            Invalidate();
        }
        #endregion public CategorySortOrder SortOrder

		private int _interval = 1;
		public int Interval
		{
			get { return _interval; }
			set { _interval = value; }
		}

		private bool _displayShortDate = false;
		public bool DisplayShortDate
		{
			get { return _displayShortDate; }
			set { _displayShortDate = value; }
		}

        /// <summary>
        /// Gets or sets a list of categories to display.
        /// </summary>
        private IList<object> Categories { get; set; }

        /// <summary>
        /// Gets or sets the grid line coordinates to display.
        /// </summary>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLine", Justification = "This is the expected capitalization.")]
        private IList<double> GridLineCoordinatesToDisplay { get; set; }

        /// <summary>
        /// Instantiates a new instance of the CategoryAxis class.
        /// </summary>
        public CategoryAxis()
        {
            this.Categories = new List<object>();
            this.GridLineCoordinatesToDisplay = new List<double>();
        }

        /// <summary>
        /// Updates categories when a series is registered.
        /// </summary>
        /// <param name="series">The series to be registered.</param>
        protected override void OnObjectRegistered(object series)
        {
            base.OnObjectRegistered(series);
            UpdateCategories();
        }

        /// <summary>
        /// Updates categories when a series is unregistered.
        /// </summary>
        /// <param name="series">The series to be unregistered.</param>
        protected override void OnObjectUnregistered(object series)
        {
            base.OnObjectUnregistered(series);
            UpdateCategories();
        }

        /// <summary>
        /// Returns range of coordinates for a given category.
        /// </summary>
        /// <param name="category">The category to return the range for.</param>
        /// <returns>The range of coordinates corresponding to the category.
        /// </returns>
        public Range<double> GetPlotAreaCoordinateRange(object category)
        {
            if (category == null)
            {
                throw new ArgumentNullException("category");
            }
            int index = Categories.IndexOf(category);
            if (index == -1)
            {
                return new Range<double>();
            }

            double maximumLength = Math.Max(ActualLength - 1, 0);
            double lower = (index * maximumLength) / Categories.Count;
            double upper = ((index + 1) * maximumLength) / Categories.Count;

            if (Orientation == AxisOrientation.Horizontal)
            {
                return new Range<double>(lower, upper);
            }
            else
            {
                return new Range<double>(maximumLength - upper, maximumLength - lower);
            }
        }

        /// <summary>
        /// Returns the category at a given coordinate.
        /// </summary>
        /// <param name="coordinate">The plot are coordinate.</param>
        /// <returns>The category at the given plot area coordinate.</returns>
        public object GetCategoryAtPlotAreaCoordinate(double coordinate)
        {
            if (this.ActualLength == 0.0 || this.Categories.Count == 0)
            {
                return null;
            }
            int index = (int) Math.Floor(coordinate / (this.ActualLength / this.Categories.Count));
            if (index >= 0 && index < this.Categories.Count)
            {
                if (Orientation == AxisOrientation.Horizontal)
                {
                    return this.Categories[index];
                }
                else
                {
                    return this.Categories[(this.Categories.Count - 1) - index];
                }
            }

            return null;
        }

        /// <summary>
        /// Updates the categories in response to an update from a registered
        /// category axis information provider.
        /// </summary>
        /// <param name="usesCategoryAxis">The category axis information
        /// provider.</param>
        /// <param name="categories">A sequence of categories.</param>
        public void Update(ICategoryAxisInformationProvider usesCategoryAxis, IEnumerable<object> categories)
        {
            UpdateCategories();
        }

        /// <summary>
        /// Updates the list of categories.
        /// </summary>
        private void UpdateCategories()
        {
            IEnumerable<object> categories =
                this.RegisteredObjects
                .OfType<ICategoryAxisInformationProvider>()
                .SelectMany(infoProvider => infoProvider.GetCategories(this))
                .Distinct();

            if (SortOrder == CategorySortOrder.Ascending)
            {
                categories = categories.OrderBy(category => category);
            }
            else if (SortOrder == CategorySortOrder.Descending)
            {
                categories = categories.OrderByDescending(category => category);
            }

            this.Categories = categories.ToList();

            Invalidate();
        }

        /// <summary>
        /// Returns the major axis grid line coordinates.
        /// </summary>
        /// <returns>A sequence of the major grid line coordinates.</returns>
        protected override IEnumerable<double> GetMajorGridLineCoordinates()
        {
            return GridLineCoordinatesToDisplay;
        }

        /// <summary>
        /// Renders the axis labels, tick marks, and other visual elements.
        /// </summary>
        protected override void Render()
        {
            OrientedPanel.Children.Clear();
            this.GridLineCoordinatesToDisplay.Clear();

            if (this.Categories.Count > 0)
            {
                double maximumLength = Math.Max(ActualLength - 1, 0);

                Action<double> placeTickMarkAt =
                    (pos) =>
                    {
                        Line tickMark = CreateMajorTickMark();
                        OrientedPanel.SetCenterCoordinate(tickMark, pos);
                        OrientedPanel.SetPriority(tickMark, 0);
                        this.GridLineCoordinatesToDisplay.Add(pos);
                        OrientedPanel.Children.Add(tickMark);
                    };

				

                int index = 0;
                int priority = 0;
                foreach (object category in Categories)
                {
                    ContentControl axisLabel = CreateAndPrepareAxisLabel(category);
					if (DisplayShortDate)
					{
						DateTime dt = DateTime.Now;
						if (DateTime.TryParse(category.ToString(), out dt))
						{
							axisLabel = CreateAndPrepareAxisLabel((object)dt.ToShortDateString());
						}
					}

                    double lower = ((index * maximumLength) / Categories.Count) + 0.5;
                    double upper = (((index + 1) * maximumLength) / Categories.Count) + 0.5;
                    placeTickMarkAt(lower);
                    OrientedPanel.SetCenterCoordinate(axisLabel, (lower + upper) / 2);
                    OrientedPanel.SetPriority(axisLabel, priority + 1);

					if (index % Interval == 0)
						OrientedPanel.Children.Add(axisLabel);

                    index++;
                    priority = (priority + 1) % 2;
                }

                placeTickMarkAt(maximumLength + 0.5);
            }
        }

        /// <summary>
        /// Returns a value indicating whether a value can be plotted on the
        /// axis.
        /// </summary>
        /// <param name="value">A value which may or may not be able to be
        /// plotted.</param>
        /// <returns>A value indicating whether a value can be plotted on the
        /// axis.</returns>
        public override bool CanPlot(object value)
        {
            return true;
        }
    }
}