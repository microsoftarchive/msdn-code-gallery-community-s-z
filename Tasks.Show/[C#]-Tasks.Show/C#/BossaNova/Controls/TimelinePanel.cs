using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Collections.Generic;
using System.ComponentModel;

namespace Tasks.Show.Controls
{

    public class TimelinePanel : Panel
    {
		#region Fields 

        private List<Rect> _IntersectingRects = new List<Rect>();
        private List<DateElement> _VisibleElements = new List<DateElement>();

		#endregion Fields 

		#region Public Methods 

        public void ShiftDateByUnits(double offset)
        {
            long TickOffset = OffsetToTicks(offset);

            BeginDate = new DateTime(BeginDate.Ticks + TickOffset);
            EndDate = new DateTime(EndDate.Ticks + TickOffset);
        }

		#endregion Public Methods 

		#region Protected Methods 

        protected override Size ArrangeOverride(Size finalSize)
        {
            // populate the _VisibleElements collection with items that
            // are visible and within the current date range

            _VisibleElements.Clear();

            foreach (UIElement child in InternalChildren)
            {
                DateTime Date = (DateTime)child.GetValue(DateProperty);
                DateTime RangeEndDate = (DateTime)child.GetValue(RangeEndDateProperty);

                if (child.Visibility != Visibility.Collapsed && (Date >= BeginDate || RangeEndDate >= BeginDate))
                {
                    _VisibleElements.Add(new DateElement(child, Date, RangeEndDate));
                }
                else
                {
                    //ArrangeHelper(child, new Rect(-1*child.DesiredSize.Width, 0, child.DesiredSize.Width, child.DesiredSize.Height ));
                }
            }

            // sort the _VisibleElements collection

            _VisibleElements.Sort();

            foreach (DateElement child in _VisibleElements)
            {
                double x, y, width;

                x = CalculateTimelineOffset(child.Date, finalSize.Width);
                Rect r = new Rect(x, 0, child.Element.DesiredSize.Width, child.Element.DesiredSize.Height);
                child.PlacementRectangle = r;

                y = CalculateVerticalOffset(child);

                r = new Rect(x, y, child.Element.DesiredSize.Width, child.Element.DesiredSize.Height);
                child.PlacementRectangle = r;

                if (child.Date != DateTime.MinValue && child.EndRangeDate != DateTime.MinValue)
                {
                    width = CalculateTimelineOffset(child.EndRangeDate, finalSize.Width) - CalculateTimelineOffset(child.Date, finalSize.Width);

                    child.Element.Arrange(new Rect(new Point(x, y), new Size(width, child.Element.DesiredSize.Height)));
                }
                else
                {
                    child.Element.Arrange(new Rect(new Point(x, y), child.Element.DesiredSize));
                }
            }

            return finalSize;
        }

        protected override Size MeasureOverride(Size availableSize)
        {
            Size childSize = availableSize;
            foreach (UIElement child in InternalChildren)
            {
                if (child == null) { continue; }
                child.Measure(childSize);
            }
            return new Size();
        }

		#endregion Protected Methods 

		#region Private Methods 

        private double CalculateTimelineOffset(DateTime d, double finalWidth)
        {
            long TickRange = EndDate.Ticks - BeginDate.Ticks;
            long TickOffset = d.Ticks - BeginDate.Ticks;

            return ((double)TickOffset / (double)TickRange) * finalWidth;
        }

        private double CalculateVerticalOffset(DateElement curr)
        {
            if (!IsStackingEnabled)
            {
                return 0;
            }

            // create and sort a list of rectangles that intersect with current item

            _IntersectingRects.Clear();

            foreach (DateElement child in _VisibleElements)
            {
                Rect ChildRect = child.PlacementRectangle;
                Rect n = curr.PlacementRectangle;

                //if (ChildRect == n) break;
                if (child == curr) break;

                if (n.Left >= ChildRect.Left && n.Left <= ChildRect.Right) _IntersectingRects.Add(ChildRect);
            }

            _IntersectingRects.Sort(CompareRectanglesByTop);

            // find the first gap that is big enough to accomodate the current item

            double verticalOffset = 0;

            for (int i = 0; i < _IntersectingRects.Count; i++)
            {
                Rect r = _IntersectingRects[i];

                if (i == 0)
                {
                    if (r.Top >= curr.PlacementRectangle.Height)
                    {
                        verticalOffset = 0;
                        break;
                    }
                }

                if (i == _IntersectingRects.Count - 1)
                {
                    verticalOffset = r.Bottom;
                    break;
                }
                else
                {
                    Rect n = _IntersectingRects[i + 1];
                    if ((n.Top - r.Bottom) >= curr.PlacementRectangle.Height)
                    {
                        verticalOffset = r.Bottom;
                        break;
                    }
                }
            }

            return verticalOffset;

        }

        private static int CompareRectanglesByTop(Rect a, Rect b)
        {
            return a.Top.CompareTo(b.Top);
        }

        private long OffsetToTicks(double offset)
        {
            if (this.ActualWidth == 0)
                return 0;
            else
            {
                double TicksPerUnit = (EndDate.Ticks - BeginDate.Ticks) / this.ActualWidth;
                long TickOffset = (long)(offset * TicksPerUnit);
                return TickOffset;
            }
        }

		#endregion Private Methods 

		#region Nested Classes 


        private class DateElement : IComparable<DateElement>
        {
		#region Fields 

            public DateTime Date;
            public UIElement Element;
            public DateTime EndRangeDate;
            public Rect PlacementRectangle;

		#endregion Fields 

		#region Constructors 

            public DateElement(UIElement element, DateTime date, DateTime endRangeDate)
            {
                Element = element;
                Date = date;
                EndRangeDate = endRangeDate;
            }

		#endregion Constructors 

		#region Public Methods 

            public int CompareTo(DateElement d)
            {
                return this.Date.CompareTo(d.Date);
            }

		#endregion Public Methods 
        }
		#endregion Nested Classes 

        #region Attached Properties

        /// <summary>
        /// Date (Attached)
        /// </summary>

        public static DateTime GetDate(DependencyObject obj)
        {
            return (DateTime)obj.GetValue(DateProperty);
        }

        public static void SetDate(DependencyObject obj, DateTime value)
        {
            obj.SetValue(DateProperty, value);
        }

        public static readonly DependencyProperty DateProperty =
            DependencyProperty.RegisterAttached("Date", typeof(DateTime), typeof(TimelinePanel),
            new FrameworkPropertyMetadata(DateTime.MinValue, FrameworkPropertyMetadataOptions.AffectsParentArrange));

        /// <summary>
        /// RangeEndDate(Attached)
        /// </summary>

        public static DateTime GetRangeEndDate(DependencyObject obj)
        {
            return (DateTime)obj.GetValue(RangeEndDateProperty);
        }

        public static void SetRangeEndDate(DependencyObject obj, DateTime value)
        {
            obj.SetValue(RangeEndDateProperty, value);
        }

        public static readonly DependencyProperty RangeEndDateProperty =
            DependencyProperty.RegisterAttached("RangeEndDate", typeof(DateTime), typeof(TimelinePanel),
            new FrameworkPropertyMetadata(DateTime.MinValue, FrameworkPropertyMetadataOptions.AffectsParentArrange));

        #endregion

        #region Dependency Properties


        #region StackDirection

        public static readonly DependencyProperty StackDirectionProperty =
            DependencyProperty.Register("StackDirection", typeof(StackDirection), typeof(TimelinePanel),
                new FrameworkPropertyMetadata((StackDirection)StackDirection.TopToBottom));

        public StackDirection StackDirection
        {
            get { return (StackDirection)GetValue(StackDirectionProperty); }
            set { SetValue(StackDirectionProperty, value); }
        }

        #endregion
        /// <summary>
        /// BeginDate
        /// The first date that appears in the timeline.
        /// </summary>
        public DateTime BeginDate
        {
            get { return (DateTime)GetValue(BeginDateProperty); }
            set { SetValue(BeginDateProperty, value); }
        }
        public static readonly DependencyProperty BeginDateProperty =
            DependencyProperty.Register("BeginDate", typeof(DateTime), typeof(TimelinePanel),
            new FrameworkPropertyMetadata(DateTime.MinValue, FrameworkPropertyMetadataOptions.AffectsArrange));
        /// <summary>
        /// EndDate
        /// The last date that appears in the timeline.
        /// </summary>
        public DateTime EndDate
        {
            get { return (DateTime)GetValue(EndDateProperty); }
            set { SetValue(EndDateProperty, value); }
        }
        public static readonly DependencyProperty EndDateProperty =
            DependencyProperty.Register("EndDate", typeof(DateTime), typeof(TimelinePanel),
            new FrameworkPropertyMetadata(DateTime.MinValue, FrameworkPropertyMetadataOptions.AffectsArrange));
        /// <summary>
        /// IsStackingEnabled
        /// </summary>
        public bool IsStackingEnabled
        {
            get { return (bool)GetValue(IsStackingEnabledProperty); }
            set { SetValue(IsStackingEnabledProperty, value); }
        }
        public static readonly DependencyProperty IsStackingEnabledProperty =
            DependencyProperty.Register("IsStackingEnabled", typeof(bool), typeof(TimelinePanel),
            new FrameworkPropertyMetadata(true, FrameworkPropertyMetadataOptions.AffectsArrange));
        #endregion
    }

    public enum StackDirection
    {
        TopToBottom,
        BottomToTop
    }


}
