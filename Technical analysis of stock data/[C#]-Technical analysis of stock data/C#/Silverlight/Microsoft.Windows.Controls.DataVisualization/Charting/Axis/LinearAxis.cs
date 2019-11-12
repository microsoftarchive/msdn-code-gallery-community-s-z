// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// An axis that displays numeric values.
    /// </summary>
    [StyleTypedProperty(Property = "GridLineStyle", StyleTargetType = typeof(Line))]
    [StyleTypedProperty(Property = "MajorTickMarkStyle", StyleTargetType = typeof(Line))]
    [StyleTypedProperty(Property = "MinorTickMarkStyle", StyleTargetType = typeof(Line))]
    [StyleTypedProperty(Property = "AxisLabelStyle", StyleTargetType = typeof(NumericAxisLabel))]
    [StyleTypedProperty(Property = "TitleStyle", StyleTargetType = typeof(Title))]
    [TemplatePart(Name = AxisGridName, Type = typeof(Grid))]
    [TemplatePart(Name = AxisTitleName, Type = typeof(Title))]
    public sealed class LinearAxis : NumericAxis
    {
        #region public double? Interval
        /// <summary>
        /// Gets or sets the axis interval.
        /// </summary>
        [TypeConverter(typeof(NullableConverter<double>))]
        public double? Interval
        {
            get { return (double?)GetValue(IntervalProperty); }
            set { SetValue(IntervalProperty, value); }
        }

        /// <summary>
        /// Identifies the Interval dependency property.
        /// </summary>
        public static readonly DependencyProperty IntervalProperty =
            DependencyProperty.Register(
                "Interval",
                typeof(double?),
                typeof(LinearAxis),
                new PropertyMetadata(null, OnIntervalPropertyChanged));

        /// <summary>
        /// IntervalProperty property changed handler.
        /// </summary>
        /// <param name="d">LinearAxis that changed its Interval.</param>
        /// <param name="e">Event arguments.</param>
        private static void OnIntervalPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            LinearAxis source = (LinearAxis)d;
            source.OnIntervalPropertyChanged();
        }

        /// <summary>
        /// IntervalProperty property changed handler.
        /// </summary>
        private void OnIntervalPropertyChanged()
        {
            OnInvalidated(new RoutedEventArgs());
        }
        #endregion public double? Interval

        #region public double ActualInterval
        /// <summary>
        /// Gets the actual interval of the axis.
        /// </summary>
        public double ActualInterval
        {
            get { return (double)GetValue(ActualIntervalProperty); }
            private set { SetValue(ActualIntervalProperty, value); }
        }

        /// <summary>
        /// Identifies the ActualInterval dependency property.
        /// </summary>
        public static readonly DependencyProperty ActualIntervalProperty =
            DependencyProperty.Register(
                "ActualInterval",
                typeof(double),
                typeof(LinearAxis),
                new PropertyMetadata(double.NaN));
        #endregion public double ActualInterval

        /// <summary>
        /// Instantiates a new instance of the LinearAxis class.
        /// </summary>
        public LinearAxis()
        {
            this.ActualRange = new Range<IComparable>(0.0, 1.0);
        }

		protected override void Render()
		{
			base.Render();
		}

        /// <summary>
        /// Returns the plot area coordinate of a value.
        /// </summary>
        /// <param name="value">The value to plot.</param>
        /// <returns>The plot area coordinate of a value.</returns>
        protected override double GetPlotAreaCoordinate(IComparable value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            if (ActualRange.HasData)
            {
                double doubleValue = ValueHelper.ToDouble(value);
                Range<double> actualDoubleRange = ToDoubleRange(ActualRange);

                double pixelLength = Math.Max(((Orientation == AxisOrientation.Horizontal) ? this.ActualWidth : this.ActualHeight) - 1, 0);
                double rangelength = actualDoubleRange.Maximum - actualDoubleRange.Minimum;

                return (doubleValue - actualDoubleRange.Minimum) * (pixelLength / rangelength);
            }

            return double.NaN;
        }

        /// <summary>
        /// Returns the actual interval to use to determine which values are 
        /// displayed in the axis.
        /// </summary>
        /// <returns>Actual interval to use to determine which values are 
        /// displayed in the axis.
        /// </returns>
        private double CalculateActualInterval()
        {
            if (Interval != null)
            {
                return Interval.Value;
            }

            Range<double> doubleActualRange = ToDoubleRange(ActualRange);

            // helper functions
            Func<double, double> Exponent = x => Math.Ceiling(Math.Log(x, 10));
            Func<double, double> Mantissa = x => x / Math.Pow(10, Exponent(x) - 1);

            // reduce intervals for horizontal axis.
            double maxIntervals = Orientation == AxisOrientation.Horizontal ? MaximumAxisIntervalsPer200Pixels * 0.8 : MaximumAxisIntervalsPer200Pixels;
            // real maximum interval count
            double maxIntervalCount = ActualLength / 200 * maxIntervals;

            double range = Math.Abs(doubleActualRange.Minimum - doubleActualRange.Maximum);
            double interval = Math.Pow(10, Exponent(range));
            double tempInterval = interval;

            // decrease interval until interval count becomes less than maxIntervalCount
            while (true)
            {
                int mantissa = (int)Mantissa(tempInterval);
                if (mantissa == 5)
                {
                    // reduce 5 to 2
                    tempInterval = ValueHelper.RemoveNoiseFromDoubleMath(tempInterval / 2.5);
                }
                else if (mantissa == 2 || mantissa == 1 || mantissa == 10)
                {
                    // reduce 2 to 1,10 to 5,1 to 0.5
                    tempInterval = ValueHelper.RemoveNoiseFromDoubleMath(tempInterval / 2.0);
                }

                if (range / tempInterval > maxIntervalCount)
                {
                    break;
                }

                interval = tempInterval;
            }
            return interval;
        }

        /// <summary>
        /// Returns a sequence of values to create major tick marks for.
        /// </summary>
        /// <returns>A sequence of values to create major tick marks for.
        /// </returns>
        protected override IEnumerable<IComparable> GetMajorTickMarkValues()
        {
            return GetMajorValues().Cast<IComparable>();
        }

        /// <summary>
        /// Returns a sequence of major axis values.
        /// </summary>
        /// <returns>A sequence of major axis values.
        /// </returns>
        private IEnumerable<double> GetMajorValues()
        {
            if (!ActualRange.HasData || ValueHelper.Compare(ActualRange.Minimum, ActualRange.Maximum) == 0 || ActualLength == 0.0)
            {
                yield break;
            }
            Range<double> typedActualRange = ToDoubleRange(ActualRange);
            this.ActualInterval = CalculateActualInterval();
            double startValue = AlignToInterval(typedActualRange.Minimum, this.ActualInterval);
            if (startValue < typedActualRange.Minimum)
            {
                startValue = AlignToInterval(typedActualRange.Minimum + this.ActualInterval, this.ActualInterval);
            }
            double nextValue = startValue;
            for (int counter = 1; nextValue <= typedActualRange.Maximum; counter++)
            {
                yield return nextValue;
                nextValue = startValue + (counter * this.ActualInterval);
            }
        }

        /// <summary>
        /// Returns a sequence of values to plot on the axis.
        /// </summary>
        /// <returns>A sequence of values to plot on the axis.</returns>
        protected override IEnumerable<IComparable> GetLabelValues()
        {
            return GetMajorValues().Cast<IComparable>();
        }

        /// <summary>
        /// Aligns a value to the provided interval value.  The aligned value
        /// should always be smaller than or equal to than the provided value.
        /// </summary>
        /// <param name="value">The value to align to the interval.</param>
        /// <param name="interval">The interval to align to.</param>
        /// <returns>The aligned value.</returns>
        private static double AlignToInterval(double value, double interval)
        {
            double typedInterval = (double)interval;
            double typedValue = (double)value;
            return ValueHelper.RemoveNoiseFromDoubleMath(ValueHelper.RemoveNoiseFromDoubleMath(Math.Floor(typedValue / typedInterval)) * typedInterval);
        }

        /// <summary>
        /// Returns the value range given a plot area coordinate.
        /// </summary>
        /// <param name="value">The plot area coordinate.</param>
        /// <returns>A range of values at that plot area coordinate.</returns>
        protected override Range<IComparable> GetValueRangeAtPlotAreaCoordinate(double value)
        {
            if (ActualRange.HasData && ActualLength != 0.0)
            {
                Range<double> actualDoubleRange = ToDoubleRange(ActualRange);

                double rangelength = actualDoubleRange.Maximum - actualDoubleRange.Minimum;
                double output = ((value * (rangelength / ActualLength)) + actualDoubleRange.Minimum);

                return new Range<IComparable>(output, output);
            }

            return new Range<IComparable>();
        }

        /// <summary>
        /// Overrides the actual range to ensure that it is never set to an
        /// empty range.
        /// </summary>
        /// <param name="range">The range to override.</param>
        /// <returns>Returns the overridden range.</returns>
        protected override Range<IComparable> OverrideActualRange(Range<IComparable> range)
        {
            Range<IComparable> overriddenActualRange = base.OverrideActualRange(range);
            if (!overriddenActualRange.HasData)
            {
                return new Range<IComparable>(0.0, 1.0);
            }
            else if (ValueHelper.Compare(overriddenActualRange.Minimum, overriddenActualRange.Maximum) == 0)
            {
                return new Range<IComparable>(((double)overriddenActualRange.Minimum) - 1, ((double)overriddenActualRange.Maximum) + 1);
            }

            return overriddenActualRange;
        }
    }
}