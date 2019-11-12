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
    /// Represents a dynamic series that uses axes to display data points.
    /// </summary>
    /// <QualityBand>Preview</QualityBand>
    public abstract class DataPointSeriesWithAxes : DataPointSeries, ICategoryAxisInformationProvider, IRangeAxisInformationProvider
    {
        /// <summary>
        /// The amount of margin to factor in when returning a range for a range
        /// axis to plot.
        /// </summary>
        private const double RangeAxisMargin = 20;

        /// <summary>
        /// Creates the correct range axis based on the data.
        /// </summary>
        /// <param name="value">The value to evaluate to determine which type of
        /// axis to create.</param>
        /// <returns>The range axis appropriate that can plot the provided
        /// value.</returns>
        protected static IRangeAxis CreateRangeAxisFromData(object value)
        {
            double doubleValue;
            DateTime dateTime;
            if (ValueHelper.TryConvert(value, out doubleValue))
            {
                return new LinearAxis();
            }
            else if (ValueHelper.TryConvert(value, out dateTime))
            {
                return new DateTimeAxis();
            }
            else
            {
                throw new InvalidOperationException(Properties.Resources.DataPointSeriesWithAxes_ValueMustBeDateTimeOrNumeric);
            }
        }

        /// <summary>
        /// Creates an accessor function that retrieves the value appropriate
        /// from a data point for a given access.
        /// </summary>
        /// <typeparam name="T">The type of value returned by the accessor.
        /// </typeparam>
        /// <param name="axis">The axis to retrieve the value for.</param>
        /// <returns>A function that returns a value appropriate for the axis
        /// when provided a DataPoint.</returns>
        private Func<DataPoint, T> CreateAxisValueAccessor<T>(IAxis axis)
        {
            Func<DataPoint, T> selector = null;
            if (axis == InternalActualIndependentAxis)
            {
                selector = (dataPoint) => (T)dataPoint.ActualIndependentValue;
            }
            else if (axis == InternalActualDependentAxis)
            {
                selector = (dataPoint) => (T)dataPoint.ActualDependentValue;
            }
            return selector;
        }

        /// <summary>
        /// Gets or sets the actual dependent axis.
        /// </summary>
        protected IAxis InternalActualDependentAxis { get; set; }

        #region public Axis InternalDependentAxis

        /// <summary>
        /// Stores the internal dependent axis.
        /// </summary>
        private IAxis _internalDependentAxis;

        /// <summary>
        /// Gets or sets the value of the internal dependent axis.
        /// </summary>
        protected IAxis InternalDependentAxis
        {
            get { return _internalDependentAxis; }
            set 
            {
                if (_internalDependentAxis != value)
                {
                    IAxis oldValue = _internalDependentAxis;
                    _internalDependentAxis = value;
                    OnInternalDependentAxisPropertyChanged(oldValue, value);
                }
            }
        }

        /// <summary>
        /// DependentAxisProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>        
        protected virtual void OnInternalDependentAxisPropertyChanged(IAxis oldValue, IAxis newValue)
        {
            if (newValue != null 
                && InternalActualDependentAxis != null 
                && InternalActualDependentAxis != newValue 
                && InternalActualDependentAxis.IsObjectRegistered(this))
            {
                InternalActualDependentAxis.Invalidated -= OnAxisInvalidated;
                SeriesHost.UnregisterWithAxis(this, InternalActualDependentAxis);
                GetAxes();
            }
        }
        #endregion public Axis InternalDependentAxis

        /// <summary>
        /// Gets or sets the actual independent axis value.
        /// </summary>
        protected IAxis InternalActualIndependentAxis { get; set; }

        #region protected Axis InternalIndependentAxis

        /// <summary>
        /// The internal independent axis.
        /// </summary>
        private IAxis _internalIndependentAxis;

        /// <summary>
        /// Gets or sets the value of the internal independent axis.
        /// </summary>
        protected IAxis InternalIndependentAxis
        {
            get { return _internalIndependentAxis; }
            set 
            {
                if (value != _internalIndependentAxis)
                {
                    IAxis oldValue = _internalIndependentAxis;
                    _internalIndependentAxis = value;
                    OnInternalIndependentAxisPropertyChanged(oldValue, value);
                }
            }
        }

        /// <summary>
        /// IndependentAxisProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>        
        protected virtual void OnInternalIndependentAxisPropertyChanged(IAxis oldValue, IAxis newValue)
        {
            if (newValue != null
                && InternalActualIndependentAxis != null
                && InternalActualIndependentAxis != newValue
                && InternalActualIndependentAxis.IsObjectRegistered(this))
            {
                InternalActualIndependentAxis.Invalidated -= OnAxisInvalidated;
                SeriesHost.UnregisterWithAxis(this, InternalActualIndependentAxis);
                GetAxes();
            }
        }
        #endregion protected Axis IndependentAxis

        /// <summary>
        /// Updates the axes when a new data point is added.
        /// </summary>
        /// <param name="dataPoint">The data point to add.</param>
        protected override void AddDataPoint(DataPoint dataPoint)
        {
            base.AddDataPoint(dataPoint);

            if (!LoadingDataPoints)
            {
                UpdateAxes();
            }
        }

        /// <summary>
        /// Updates the dependent and independent axes when a data point is
        /// removed.
        /// </summary>
        /// <param name="dataPoint">The data point to remove.</param>
        protected override void RemoveDataPoint(DataPoint dataPoint)
        {
            base.RemoveDataPoint(dataPoint);

            if (!LoadingDataPoints)
            {
                UpdateAxes();
            }
        }

        /// <summary>
        /// Update the axes when the specified data point's ActualDependentValue property changes.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected override void OnDataPointActualDependentValueChanged(DataPoint dataPoint, object oldValue, object newValue)
        {
            UpdateActualDependentAxis();
            UpdateDataPoint(dataPoint);
            base.OnDataPointActualDependentValueChanged(dataPoint, oldValue, newValue);
        }

        /// <summary>
        /// Update the axes when the specified data point's DependentValue property changes.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected override void OnDataPointDependentValueChanged(DataPoint dataPoint, object oldValue, object newValue)
        {
            if ((null != InternalActualDependentAxis))
            {
                dataPoint.BeginAnimation(DataPoint.ActualDependentValueProperty, "ActualDependentValue", newValue, this.TransitionDuration);
            }
            else
            {
                dataPoint.ActualDependentValue = newValue;
            }
            base.OnDataPointDependentValueChanged(dataPoint, oldValue, newValue);
        }

        /// <summary>
        /// Update axes when the specified data point's effective dependent value changes.
        /// </summary>
        private void UpdateActualDependentAxis()
        {
            if (InternalActualDependentAxis != null)
            {
                ICategoryAxis categoryAxis = InternalActualDependentAxis as ICategoryAxis;
                if (categoryAxis != null)
                {
                    ICategoryAxisInformationProvider categoryInformationProvider = (ICategoryAxisInformationProvider)this;
                    categoryAxis.Update(categoryInformationProvider, categoryInformationProvider.GetCategories(categoryAxis));
                }
                IRangeAxis rangeAxis = InternalActualDependentAxis as IRangeAxis;
                if (rangeAxis != null)
                {
                    IRangeAxisInformationProvider rangeInformationProvider = (IRangeAxisInformationProvider)this;
                    rangeAxis.Update(rangeInformationProvider, rangeInformationProvider.GetActualRange(rangeAxis));
                }
            }
        }

        /// <summary>
        /// Update axes when the specified data point's actual independent value changes.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected override void OnDataPointActualIndependentValueChanged(DataPoint dataPoint, object oldValue, object newValue)
        {
            UpdateActualIndependentAxis();
            UpdateDataPoint(dataPoint);
            base.OnDataPointActualIndependentValueChanged(dataPoint, oldValue, newValue);
        }

        /// <summary>
        /// Update axes when the specified data point's independent value changes.
        /// </summary>
        /// <param name="dataPoint">The data point.</param>
        /// <param name="oldValue">The old value.</param>
        /// <param name="newValue">The new value.</param>
        protected override void OnDataPointIndependentValueChanged(DataPoint dataPoint, object oldValue, object newValue)
        {
            if (null != InternalActualIndependentAxis)
            {
                dataPoint.BeginAnimation(DataPoint.ActualIndependentValueProperty, "ActualIndependentValue", newValue, this.TransitionDuration);
            }
            else
            {
                dataPoint.ActualIndependentValue = newValue;
            }
            base.OnDataPointIndependentValueChanged(dataPoint, oldValue, newValue);
        }

        /// <summary>
        /// Update axes when a data point's effective independent value changes.
        /// </summary>
        private void UpdateActualIndependentAxis()
        {
            if (InternalActualIndependentAxis != null)
            {
                ICategoryAxis categoryAxis = InternalActualIndependentAxis as ICategoryAxis;
                if (categoryAxis != null)
                {
                    ICategoryAxisInformationProvider categoryInformationProvider = (ICategoryAxisInformationProvider)this;
                    categoryAxis.Update(categoryInformationProvider, categoryInformationProvider.GetCategories(categoryAxis));
                }
                IRangeAxis rangeAxis = InternalActualIndependentAxis as IRangeAxis;
                if (rangeAxis != null)
                {
                    IRangeAxisInformationProvider rangeInformationProvider = (IRangeAxisInformationProvider)this;
                    rangeAxis.Update(rangeInformationProvider, rangeInformationProvider.GetActualRange(rangeAxis));
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of the DynamicSeriesWithAxes class.
        /// </summary>
        internal DataPointSeriesWithAxes()
        {
        }

		protected Boolean axesHasBeenUpdated = false;

        /// <summary>
        /// Acquires axes after data points have loaded.
        /// </summary>
        protected override void OnDataPointsLoaded()
        {
			axesHasBeenUpdated = false;

            GetAxes();

            UpdateAxes();

            base.OnDataPointsLoaded();
        }

        /// <summary>
        /// This method updates both axes and invalidates if necessary.
        /// </summary>
        private void UpdateAxes()
        {
            if (InternalActualDependentAxis != null && InternalActualIndependentAxis != null)
            {
                InternalActualDependentAxis.Invalidated -= OnAxisInvalidated;
                InternalActualIndependentAxis.Invalidated -= OnAxisInvalidated;

                bool hasInvalidated = false;

                RoutedEventHandler handler = (obj, e) => hasInvalidated = true;
                InternalActualDependentAxis.Invalidated += handler;
                InternalActualIndependentAxis.Invalidated += handler;

                try
                {
                    UpdateActualIndependentAxis();
                    UpdateActualDependentAxis();

					axesHasBeenUpdated = true;

                    if (hasInvalidated)
                    {
                        UpdateAllDataPoints();
                    }
                }
                finally
                {
                    InternalActualDependentAxis.Invalidated -= handler;
                    InternalActualIndependentAxis.Invalidated -= handler;

                    InternalActualDependentAxis.Invalidated += OnAxisInvalidated;
                    InternalActualIndependentAxis.Invalidated += OnAxisInvalidated;
                }
            }
        }

        /// <summary>
        /// Only updates all data points if series has axes.
        /// </summary>
        protected override void UpdateAllDataPoints()
        {
            if (InternalActualIndependentAxis != null && InternalActualDependentAxis != null)
            {
                base.UpdateAllDataPoints();
            }
        }

        /// <summary>
        /// Method called to get series to acquire the axes it needs.  Acquires
        /// no axes by default.
        /// </summary>
        private void GetAxes()
        {
            if (SeriesHost != null)
            {
                DataPoint firstDataPoint = ActiveDataPoints.FirstOrDefault();
                if (firstDataPoint == null)
                {
                    return;
                }

                double dependentValue;
                if (!ValueHelper.TryConvert(firstDataPoint.DependentValue, out dependentValue))
                {
                    throw new InvalidOperationException(Properties.Resources.DataPointSeriesWithAxes_DependentValueMustBeNumeric);
                }

                GetAxes(firstDataPoint);
            }
        }

        /// <summary>
        /// Method called to get series to acquire the axes it needs.  Acquires
        /// no axes by default.
        /// </summary>
        /// <param name="firstDataPoint">The first data point.</param>
        protected abstract void GetAxes(DataPoint firstDataPoint);

        /// <summary>
        /// Acquires a category axis.
        /// </summary>
        /// <param name="assignedAxis">The axis assigned to the exposed
        /// axis property.</param>
        /// <param name="firstDataPoint">A data point used to determine
        /// where a date or numeric axis is required.</param>
        /// <param name="orientation">The desired orientation of the axis.
        /// </param>
        /// <param name="axisInitializationAction">A function that initializes 
        /// a newly created axis.</param>
        /// <param name="axisPropertyAccessor">A function that returns the 
        /// current value of the property used to store the axis.</param>
        /// <param name="axisPropertySetter">A function that accepts an axis
        /// value and assigns it to the property intended to store a reference
        /// to it.</param>
        /// <param name="dataPointAxisValueGetter">A function that retrieves
        /// the value to plot on the axis from the data point.</param>
        protected void GetCategoryAxis(
                    IAxis assignedAxis,
                    DataPoint firstDataPoint,
                    AxisOrientation orientation,
                    Func<ICategoryAxis> axisInitializationAction,
                    Func<ICategoryAxis> axisPropertyAccessor,
                    Action<ICategoryAxis> axisPropertySetter,
                    Func<DataPoint, object> dataPointAxisValueGetter)
        {
            object firstCategoryValue = dataPointAxisValueGetter(firstDataPoint);
            if (assignedAxis != null)
            {
                if (assignedAxis.Orientation == orientation)
                {
                    ICategoryAxis assignedCategoryAxis = assignedAxis as CategoryAxis;
                    if (assignedCategoryAxis != null)
                    {
                        if (assignedCategoryAxis.CanPlot(firstCategoryValue))
                        {
                            axisPropertySetter(assignedCategoryAxis);
                            if (!assignedAxis.IsObjectRegistered(this))
                            {
                                assignedCategoryAxis.Invalidated += OnAxisInvalidated;
                                this.SeriesHost.RegisterWithAxis(this, (IAxis)assignedCategoryAxis);
                            }
                            return;
                        }
                        else
                        {
                            throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Properties.Resources.DataPointSeriesWithAxes_AxisCannotPlotValue, firstCategoryValue));
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException(Properties.Resources.DataPointSeriesWithAxes_ExpectedAxesOfTypeICategoryAxis);
                    }
                }
                else
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Properties.Resources.DataPointSeriesWithAxes_AxisIsIncorrectOrientation, orientation));
                }
            }

            IAxis actualIndependentAxis = axisPropertyAccessor() as IAxis;

            // Only acquire new independent axis if necessary
            if (actualIndependentAxis == null
                || actualIndependentAxis.Orientation != orientation)
            {
                ICategoryAxis categoryAxis =
                    SeriesHost
                        .Axes.Where(currentAxis => currentAxis.Orientation == orientation)
                        .OfType<ICategoryAxis>()
                        .Where(
                            currentCategoryAxis => 
                                currentCategoryAxis.CanPlot(firstCategoryValue)
                                && currentCategoryAxis.CanRegister(this))
                        .FirstOrDefault();

                if (categoryAxis == null)
                {
                    categoryAxis = axisInitializationAction();
                    categoryAxis.Orientation = orientation;
                }

                // Unregister with current axis if it has one.
                if (axisPropertyAccessor() != null)
                {
                    axisPropertyAccessor().Invalidated -= OnAxisInvalidated;
                    ICategoryAxis oldCategoryAxis = axisPropertyAccessor() as ICategoryAxis;
                    this.SeriesHost.UnregisterWithAxis(this, (IAxis)oldCategoryAxis);
                }

                // Set axis to be its independent axis
                axisPropertySetter(categoryAxis);

                if (!categoryAxis.IsObjectRegistered(this))
                {
                    categoryAxis.Invalidated += OnAxisInvalidated;

                    // Register new axis with series host
                    this.SeriesHost.RegisterWithAxis(this, (IAxis)categoryAxis);
                }
            }
        }

        /// <summary>
        /// Acquires a range axis.
        /// </summary>
        /// <param name="assignedAxis">The axis assigned to the exposed
        /// axis property.</param>
        /// <param name="firstDataPoint">A data point used to determine
        /// where a date or numeric axis is required.</param>
        /// <param name="orientation">The desired orientation of the axis.
        /// </param>
        /// <param name="axisInitializationAction">A function that initializes 
        /// a newly created axis.</param>
        /// <param name="axisPropertyAccessor">A function that returns the 
        /// current value of the property used to store the axis.</param>
        /// <param name="axisPropertySetter">A function that accepts an axis
        /// value and assigns it to the property intended to store a reference
        /// to it.</param>
        /// <param name="dataPointAxisValueGetter">A function that accepts a
        /// Control and returns the value that will be plot on the axis.
        /// </param>
        protected void GetRangeAxis(
                    IAxis assignedAxis,
                    DataPoint firstDataPoint,
                    AxisOrientation orientation,
                    Func<IRangeAxis> axisInitializationAction,
                    Func<IRangeAxis> axisPropertyAccessor,
                    Action<IRangeAxis> axisPropertySetter,
                    Func<DataPoint, object> dataPointAxisValueGetter)
        {
            if (assignedAxis != null)
            {
                if (assignedAxis.Orientation == orientation)
                {
                    IRangeAxis assignedRangeAxis = assignedAxis as IRangeAxis;
                    if (assignedRangeAxis != null)
                    {
                        object value = dataPointAxisValueGetter(firstDataPoint);
                        if (assignedRangeAxis.CanPlot(value))
                        {
                            axisPropertySetter(assignedRangeAxis);
                            if (!assignedAxis.IsObjectRegistered(this))
                            {
                                assignedRangeAxis.Invalidated += OnAxisInvalidated;
                                this.SeriesHost.RegisterWithAxis(this, (IAxis)assignedRangeAxis);
                            }
                            return;
                        }
                        else
                        {
                            throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Properties.Resources.DataPointSeriesWithAxes_AxisCannotPlotValue, value));
                        }
                    }
                    else
                    {
                        throw new InvalidOperationException(Properties.Resources.DataPointSeriesWithAxes_ExpectedAxesOfTypeICategoryAxis);
                    }
                }
                else
                {
                    throw new InvalidOperationException(string.Format(CultureInfo.CurrentCulture, Properties.Resources.DataPointSeriesWithAxes_AxisIsIncorrectOrientation, orientation));
                }
            }

            // If current axis is not suitable...
            if (axisPropertyAccessor() == null || !axisPropertyAccessor().CanPlot(dataPointAxisValueGetter(firstDataPoint)))
            {
                // Attempt to find suitable axis
                IRangeAxis axis =
                        SeriesHost.Axes
                            .Cast<IAxis>()
                            .Where(currentAxis => currentAxis.Orientation == orientation
                                && currentAxis.CanPlot(dataPointAxisValueGetter(firstDataPoint))
                                && currentAxis.CanRegister(this))
                            .OfType<IRangeAxis>()
                            .FirstOrDefault();

                if (axis == null)
                {
                    axis = axisInitializationAction();
                    axis.Orientation = orientation;
                }

                IAxis baseAxis = (IAxis)axis;
                // Unregister with current axis if it has one.
                if (axisPropertyAccessor() != null)
                {
                    axisPropertyAccessor().Invalidated -= OnAxisInvalidated;
                    SeriesHost.UnregisterWithAxis(this, baseAxis);
                }

                axisPropertySetter(axis);

                if (!axis.IsObjectRegistered(this))
                {
                    axis.Invalidated += OnAxisInvalidated;
                    SeriesHost.RegisterWithAxis(this, baseAxis);
                }
            }
        }

        /// <summary>
        /// Updates data points when the axis is invalidated.
        /// </summary>
        /// <param name="sender">The axis that was invalidated.</param>
        /// <param name="e">The event data.</param>
        private void OnAxisInvalidated(object sender, EventArgs e)
        {
            if (InternalActualDependentAxis != null && InternalActualIndependentAxis != null && PlotArea != null)
            {
                UpdateAllDataPoints();
            }
        }

        /// <summary>
        /// Overrides the range requested from the axis.  The default range is
        /// the range of values on to be plotted on the axis.
        /// </summary>
        /// <param name="rangeAxis">The axis to retrieve the range for.</param>
        /// <param name="range">The range of values that are plotted on the 
        /// axis.</param>
        /// <returns>A new range.</returns>
        protected virtual Range<IComparable> OverrideRequestedAxisRange(IRangeAxis rangeAxis, Range<IComparable> range)
        {
            if (range.HasData)
            {
                double minimumCoordinate = rangeAxis.GetPlotAreaCoordinate(range.Minimum);
                double maximumCoordinate = rangeAxis.GetPlotAreaCoordinate(range.Maximum);

                if (ValueHelper.CanGraph(minimumCoordinate) && ValueHelper.CanGraph(maximumCoordinate))
                {
                    minimumCoordinate -= RangeAxisMargin;
                    maximumCoordinate += RangeAxisMargin;

                    Range<IComparable> minimumOffsetRange = rangeAxis.GetPlotAreaCoordinateValueRange(minimumCoordinate);
                    Range<IComparable> maximumOffsetRange = rangeAxis.GetPlotAreaCoordinateValueRange(maximumCoordinate);

                    if (minimumOffsetRange.HasData && maximumOffsetRange.HasData)
                    {
                        return new Range<IComparable>(
                            minimumOffsetRange.Minimum,
                            maximumOffsetRange.Maximum);
                    }
                }
            }
            return range;
        }

        /// <summary>
        /// Returns a list of categories used by the series.
        /// </summary>
        /// <param name="categoryAxis">The axis for which to retrieve the categories.
        /// </param>
        /// <returns>A list of categories used by the series.</returns>
        IEnumerable<object> ICategoryAxisInformationProvider.GetCategories(ICategoryAxis categoryAxis)
        {
            IAxis axis = (IAxis)categoryAxis;
            if (axis == null)
            {
                throw new ArgumentNullException("categoryAxis");
            }

            Func<DataPoint, object> selector = null;
            if (axis == InternalActualIndependentAxis)
            {
                if (IndependentValueBinding == null)
                {
                    return Enumerable.Range(1, ActiveDataPointCount).Cast<object>();
                }
                selector = (dataPoint) => dataPoint.IndependentValue ?? dataPoint.DependentValue;
            }
            else if (axis == InternalActualDependentAxis)
            {
                selector = (dataPoint) => dataPoint.DependentValue;
            }

            return ActiveDataPoints.Select(selector).Distinct();
        }

        /// <summary>
        /// Called when the value of the SeriesHost property changes.
        /// </summary>
        /// <param name="oldValue">The value to be replaced.</param>
        /// <param name="newValue">The new series host value.</param>
        protected override void OnSeriesHostPropertyChanged(ISeriesHost oldValue, ISeriesHost newValue)
        {
            if (oldValue != null)
            {
                if (InternalActualIndependentAxis != null)
                {
                    oldValue.UnregisterWithAxis(this, InternalActualIndependentAxis);
                    InternalActualIndependentAxis.Invalidated -= OnAxisInvalidated;
                    InternalActualIndependentAxis = null;
                }
                if (InternalActualDependentAxis != null)
                {
                    oldValue.UnregisterWithAxis(this, InternalActualDependentAxis);
                    InternalActualDependentAxis.Invalidated -= OnAxisInvalidated;
                    InternalActualDependentAxis = null;
                }
            }

            base.OnSeriesHostPropertyChanged(oldValue, newValue);
        }

        /// <summary>
        /// Returns the range of values for the axis to include.
        /// </summary>
        /// <param name="rangeAxis">The axis corresponding to the range.</param>
        /// <returns>The range for the axis to include.</returns>
        Range<IComparable> IRangeAxisInformationProvider.GetActualRange(IRangeAxis rangeAxis)
        {
            if (rangeAxis == null)
            {
                throw new ArgumentNullException("rangeAxis");
            }

            Func<DataPoint, IComparable> selector = CreateAxisValueAccessor<IComparable>((IAxis)rangeAxis);
            return (null != selector) ? ActiveDataPoints.Select(selector).GetRange() : new Range<IComparable>();
        }

        /// <summary>
        /// Returns the range of values for the axis to include.
        /// </summary>
        /// <param name="rangeAxis">The axis corresponding to the range.</param>
        /// <returns>The range for the axis to include.</returns>
        Range<IComparable> IRangeAxisInformationProvider.GetDesiredRange(IRangeAxis rangeAxis)
        {
            return OverrideRequestedAxisRange(rangeAxis, (this as IRangeAxisInformationProvider).GetActualRange(rangeAxis));
        }
    }
}
