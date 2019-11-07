// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;

namespace Microsoft.Windows.Controls.DataVisualization.Charting
{
    /// <summary>
    /// This control draws gridlines with the help of an axis.
    /// </summary>
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLine", Justification = "This is the expected capitalization.")]
    [SuppressMessage("Microsoft.Naming", "CA1702:CompoundWordsShouldBeCasedCorrectly", MessageId = "GridLines", Justification = "This is the expected capitalization.")]
    internal class GridLines : Canvas
    {
        #region public HybridAxis Axis

        /// <summary>
        /// The field that stores the axis that the grid lines are connected to.
        /// </summary>
        private HybridAxis _axis;

        /// <summary>
        /// Gets the axis that the grid lines are connected to.
        /// </summary>
        public HybridAxis Axis
        {
            get { return _axis; }
            private set
            {
                if (_axis != value)
                {
                    HybridAxis oldValue = _axis;
                    _axis = value;
                    if (oldValue != _axis)
                    {
                        OnAxisPropertyChanged(oldValue, value);
                    }
                }
            }
        }

        /// <summary>
        /// AxisProperty property changed handler.
        /// </summary>
        /// <param name="oldValue">Old value.</param>
        /// <param name="newValue">New value.</param>
        private void OnAxisPropertyChanged(HybridAxis oldValue, HybridAxis newValue)
        {
            Debug.Assert(newValue != null, "Don't set the axis property to null.");

            if (newValue != null)
            {
                newValue.Invalidated += OnAxisInvalidated;
            }

            if (oldValue != null)
            {
                oldValue.Invalidated -= OnAxisInvalidated;
            }
        }
        #endregion public HybridAxis Axis

        /// <summary>
        /// Instantiates a new instance of the GridLines class.
        /// </summary>
        /// <param name="axis">The axis used by the GridLines.</param>
        public GridLines(HybridAxis axis)
        {
            this.Axis = axis;
            this.SizeChanged += new SizeChangedEventHandler(OnSizeChanged);
        }

        /// <summary>
        /// Redraws grid lines when the size of the control changes.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Information about the event.</param>
        private void OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Redraws grid lines when the axis is invalidated.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">Information about the event.</param>
        private void OnAxisInvalidated(object sender, RoutedEventArgs e)
        {
            Invalidate();
        }

        /// <summary>
        /// Draws the grid lines.
        /// </summary>
        internal void Invalidate()
        {
            IList<double> intervals = Axis.InternalGetMajorGridLineCoordinates().ToList();
            IList<Line> lines = Children.OfType<Line>().ToList();

            while (lines.Count > intervals.Count)
            {
                Children.Remove(lines[lines.Count - 1]);
                lines.RemoveAt(lines.Count - 1);
            }

            while (lines.Count < intervals.Count)
            {
                lines.Add(new Line() { Style = Axis.GridLineStyle });
                Children.Add(lines[lines.Count - 1]);
            }

            double maximumHeight = Math.Max(Math.Round(ActualHeight - 1), 0);
            double maximumWidth = Math.Max(Math.Round(ActualWidth - 1), 0);
            for (int i = 0; i < intervals.Count; i++)
            {
                double currentValue = intervals[i];

                double position = currentValue;
                if (!double.IsNaN(position))
                {
                    Line line = lines[i];
                    if (Axis.Orientation == AxisOrientation.Vertical)
                    {
                        line.Y1 = line.Y2 = maximumHeight - Math.Round(position - (line.StrokeThickness / 2));
                        line.X1 = 0.0;
                        line.X2 = maximumWidth;
                    }
                    else if (Axis.Orientation == AxisOrientation.Horizontal)
                    {
                        line.X1 = line.X2 = Math.Round(position - (line.StrokeThickness / 2));
                        line.Y1 = 0.0;
                        line.Y2 = maximumHeight;
                    }
                    // workaround for '1px line thickness issue'
                    if (line.StrokeThickness % 2 > 0)
                    {
                        line.SetValue(Canvas.LeftProperty, 0.5);
                        line.SetValue(Canvas.TopProperty, 0.5);
                    }
                }
            }
        }
    }
}