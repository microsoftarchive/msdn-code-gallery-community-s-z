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
    public abstract class RangeAxis : HybridAxis, IRangeAxis
    {
        #region public Style MinorTickMarkStyle
        /// <summary>
        /// Gets or sets the minor tick mark style.
        /// </summary>
        public Style MinorTickMarkStyle
        {
            get { return GetValue(MinorTickMarkStyleProperty) as Style; }
            set { SetValue(MinorTickMarkStyleProperty, value); }
        }

        /// <summary>
        /// Identifies the MinorTickMarkStyle dependency property.
        /// </summary>
        public static readonly DependencyProperty MinorTickMarkStyleProperty =
            DependencyProperty.Register(
                "MinorTickMarkStyle",
                typeof(Style),
                typeof(RangeAxis),
                new PropertyMetadata(null));

        #endregion public Style MinorTickMarkStyle

        /// <summary>
        /// The actual range of values.
        /// </summary>
        private Range<IComparable> _actualRange;

        /// <summary>
        /// Gets or sets the actual range of values.
        /// </summary>
        protected Range<IComparable> ActualRange
        {
            get
            {
                return _actualRange;
            }
            set
            {
                Range<IComparable> oldValue = _actualRange;
                Range<IComparable> overriddenValue = OverrideActualRange(value);
                if (!oldValue.Equals(overriddenValue))
                {
                    _actualRange = overriddenValue;
                    OnActualRangeChanged(overriddenValue);
                }
            }
        }

        /// <summary>
        /// Overrides the actual range.
        /// </summary>
        /// <param name="range">The range to potentially override.</param>
        /// <returns>The overridden range.</returns>
        protected virtual Range<IComparable> OverrideActualRange(Range<IComparable> range)
        {
            if (range.HasData)
            {
                IComparable minimum = ProtectedMinimum ?? range.Minimum;
                IComparable maximum = ProtectedMaximum ?? range.Maximum;

                if (ValueHelper.Compare(minimum, maximum) > 0)
                {
                    IComparable temp = maximum;
                    maximum = minimum;
                    minimum = temp;
                }

                return new Range<IComparable>(minimum, maximum);
            }
            else
            {
                IComparable minimum = ProtectedMinimum;
                IComparable maximum = ProtectedMaximum;
                if (ProtectedMinimum != null && ProtectedMaximum == null)
                {
                    maximum = minimum;
                }
                else if (ProtectedMaximum != null && ProtectedMinimum == null)
                {
                    minimum = maximum;
                }
                else
                {
                    return range;
                }
                return new Range<IComparable>(minimum, maximum);
            }
        }

        /// <summary>
        /// The maximum value displayed in the range axis.
        /// </summary>
        private IComparable _protectedMaximum;

        /// <summary>
        /// Gets or sets the maximum value displayed in the range axis.
        /// </summary>
        protected IComparable ProtectedMaximum
        {
            get
            {
                return _protectedMaximum;
            }
            set
            {
                if (value != null && ProtectedMinimum != null && ValueHelper.Compare(ProtectedMinimum, value) > 0)
                {
                    throw new InvalidOperationException(Properties.Resources.RangeAxis_MaximumValueMustBeLargerThanOrEqualToMinimumValue);
                }
                if (!object.ReferenceEquals(_protectedMaximum, value) && !object.Equals(_protectedMaximum, value))
                {
                    _protectedMaximum = value;
                    UpdateActualRange();
                }
            }
        }

        /// <summary>
        /// The minimum value displayed in the range axis.
        /// </summary>
        private IComparable _protectedMinimum;

        /// <summary>
        /// Gets or sets the minimum value displayed in the range axis.
        /// </summary>
        protected IComparable ProtectedMinimum
        {
            get
            {
                return _protectedMinimum;
            }
            set
            {
                if (value != null && ProtectedMaximum != null && ValueHelper.Compare(ProtectedMinimum, ProtectedMaximum) > 0)
                {
                    throw new InvalidOperationException(Properties.Resources.RangeAxis_MinimumValueMustBeLargerThanOrEqualToMaximumValue);
                }
                if (!object.ReferenceEquals(_protectedMinimum, value) && !object.Equals(_protectedMinimum, value))
                {
                    _protectedMinimum = value;
                    UpdateActualRange();
                }
            }
        }

        /// <summary>
        /// Instantiates a new instance of the RangeAxis class.
        /// </summary>
        internal RangeAxis()
        {
            this.DefaultStyleKey = typeof(RangeAxis);
            this.SizeChanged += (source, args) => UpdateActualRange();
        }

        /// <summary>
        /// Creates a minor axis tick mark.
        /// </summary>
        /// <returns>A line to used to render a tick mark.</returns>
        protected Line CreateMinorTickMark()
        {
            return CreateTickMark(MinorTickMarkStyle);
        }

        /// <summary>
        /// Updates range when a new series is registered.
        /// </summary>
        /// <param name="series">The newly registered series.</param>
        protected override void OnObjectRegistered(object series)
        {
            UpdateActualRange();
            base.OnObjectRegistered(series);
        }

        /// <summary>
        /// Updates range when a new series is registered.
        /// </summary>
        /// <param name="series">The unregistered series.</param>
        protected override void OnObjectUnregistered(object series)
        {
            UpdateActualRange();
            base.OnObjectUnregistered(series);
        }

        /// <summary>
        /// Invalidates axis when the actual range changes.
        /// </summary>
        /// <param name="range">The new actual range.</param>
        protected virtual void OnActualRangeChanged(Range<IComparable> range)
        {
            Invalidate();
        }

        /// <summary>
        /// Updates the actual range displayed on the axis.
        /// </summary>
        private void UpdateActualRange()
        {
            Range<IComparable> actualRange;
            if (ProtectedMaximum == null || ProtectedMinimum == null)
            {
                actualRange =
                    this.RegisteredObjects
                        .OfType<IRangeAxisInformationProvider>()
                        .Select(rangeProvider => rangeProvider.GetActualRange(this))
                        .Sum();

                this.ActualRange = actualRange;
                if (ActualLength != 0.0)
                {
                    Range<IComparable> desiredRange =
                        this.RegisteredObjects
                            .OfType<IRangeAxisInformationProvider>()
                            .Select(rangeProvider => rangeProvider.GetDesiredRange(this))
                            .Sum();

                    if (!desiredRange.HasData)
                    {
                        this.ActualRange = desiredRange;
                    }
                    else
                    {
                        this.ActualRange = new Range<IComparable>(ProtectedMinimum ?? desiredRange.Minimum, ProtectedMaximum ?? desiredRange.Maximum);
                    }
                }
            }
            else
            {
                this.ActualRange = new Range<IComparable>(ProtectedMinimum, ProtectedMaximum);
            }
        }

        /// <summary>
        /// Renders the axis labels, tick marks, and other visual elements.
        /// </summary>
        protected override void Render()
        {
            OrientedPanel.Children.Clear();

            if (ActualRange.HasData && !Object.Equals(ActualRange.Minimum, ActualRange.Maximum))
            {
                foreach (IComparable axisValue in GetMajorTickMarkValues())
                {
                    Line line = CreateMajorTickMark();
                    double coordinate = GetPlotAreaCoordinate(axisValue);
                    OrientedPanel.SetCenterCoordinate(line, coordinate);
                    OrientedPanel.SetPriority(line, 0);
                    OrientedPanel.Children.Add(line);
                }

                foreach (IComparable axisValue in GetMinorTickMarkValues())
                {
                    Line line = CreateMinorTickMark();
                    double coordinate = GetPlotAreaCoordinate(axisValue);
                    OrientedPanel.SetCenterCoordinate(line, coordinate);
                    OrientedPanel.SetPriority(line, 0);
                    OrientedPanel.Children.Add(line);
                }

                int count = 0;
                foreach (IComparable axisValue in GetLabelValues())
                {
                    ContentControl axisLabel = CreateAndPrepareAxisLabel(axisValue);
                    double coordinate = GetPlotAreaCoordinate(axisValue);
                    OrientedPanel.SetCenterCoordinate(axisLabel, coordinate);
                    OrientedPanel.SetPriority(axisLabel, count + 1);
                    OrientedPanel.Children.Add(axisLabel);
                    count = (count + 1) % 2;
                }
            }
        }

        /// <summary>
        /// Returns a sequence of the major grid line coordinates.
        /// </summary>
        /// <returns>A sequence of the major grid line coordinates.</returns>
        protected override IEnumerable<double> GetMajorGridLineCoordinates()
        {
            return GetMajorTickMarkValues().Select(value => GetPlotAreaCoordinate(value));
        }

        /// <summary>
        /// Returns a sequence of the values at which to plot major grid lines.
        /// </summary>
        /// <returns>A sequence of the values at which to plot major grid lines.
        /// </returns>
        [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLine", Justification = "This is the expected capitalization.")]
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "This method may do a lot of work and is therefore not a suitable candidate for a property.")]
        protected virtual IEnumerable<IComparable> GetMajorGridLineValues()
        {
            return GetMajorTickMarkValues();
        }

        /// <summary>
        /// Returns a sequence of values to plot on the axis.
        /// </summary>
        /// <returns>A sequence of values to plot on the axis.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "This method may do a lot of work and is therefore not a suitable candidate for a property.")]
        protected abstract IEnumerable<IComparable> GetMajorTickMarkValues();

        /// <summary>
        /// Returns a sequence of values to plot on the axis.
        /// </summary>
        /// <returns>A sequence of values to plot on the axis.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "This method may do a lot of work and is therefore not a suitable candidate for a property.")]
        protected virtual IEnumerable<IComparable> GetMinorTickMarkValues()
        {
            yield break;
        }

        /// <summary>
        /// Returns a sequence of values to plot on the axis.
        /// </summary>
        /// <returns>A sequence of values to plot on the axis.</returns>
        [SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "This method may do a lot of work and is therefore not a suitable candidate for a property.")]
        protected abstract IEnumerable<IComparable> GetLabelValues();

        /// <summary>
        /// Returns the plot area coordinate for a given value.
        /// </summary>
        /// <param name="value">The value to plot.</param>
        /// <returns>The plot area coordinate.</returns>
        protected abstract double GetPlotAreaCoordinate(IComparable value);

        /// <summary>
        /// Returns the value range given a plot area coordinate.
        /// </summary>
        /// <param name="value">The plot area coordinate.</param>
        /// <returns>A range of values at that plot area coordinate.</returns>
        protected abstract Range<IComparable> GetValueRangeAtPlotAreaCoordinate(double value);
        
        /// <summary>
        /// Gets the actual maximum value.
        /// </summary>
        Range<IComparable> IRangeAxis.Range
        {
            get { return ActualRange; }
        }
    
        /// <summary>
        /// The plot area coordinate of a value.
        /// </summary>
        /// <param name="value">The value for which to retrieve the plot area 
        /// coordinate.</param>
        /// <returns>The plot area coordinate.</returns>
        double IRangeAxis.GetPlotAreaCoordinate(IComparable value)
        {
            return GetPlotAreaCoordinate(value);
        }

        /// <summary>
        /// Returns the value range given a plot area coordinate.
        /// </summary>
        /// <param name="coordinate">The plot area coordinate.</param>
        /// <returns>A range of values at that plot area coordinate.</returns>
        Range<IComparable> IRangeAxis.GetPlotAreaCoordinateValueRange(double coordinate)
        {
            return GetValueRangeAtPlotAreaCoordinate(coordinate);
        }

        /// <summary>
        /// Updates the axis with information about a provider's data range.
        /// </summary>
        /// <param name="usesRangeAxis">The information provider.</param>
        /// <param name="range">The range of data in the information provider.
        /// </param>
        void IRangeAxis.Update(IRangeAxisInformationProvider usesRangeAxis, Range<IComparable> range)
        {
            UpdateActualRange();
        }
    }
}