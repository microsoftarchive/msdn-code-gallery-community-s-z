/* 
 * Copyright (c) 2010, Andriy Syrov
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without modification, are permitted provided 
 * that the following conditions are met:
 * 
 * Redistributions of source code must retain the above copyright notice, this list of conditions and the 
 * following disclaimer.
 * 
 * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and 
 * the following disclaimer in the documentation and/or other materials provided with the distribution.
 *
 * Neither the name of Andriy Syrov nor the names of his contributors may be used to endorse or promote 
 * products derived from this software without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED 
 * WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A 
 * PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR ANY 
 * DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED 
 * TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS 
 * INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, 
 * OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN 
 * IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
 *   
 */
using System;
using System.Linq;
using System.Net;
using System.Collections;
using System.Diagnostics;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Threading;
using System.Reflection;
using System.Windows.Threading;
using System.Windows.Media.Animation;

namespace TimelineLibrary
{
    /// 
    /// <summary>
    /// This class provides mapping between screen coordinates/sizes and time and 
    /// timeline event placement</summary>
    /// 
    public class TimelineBuilder
    {
        // max number of events that we display on the screen at the same time
        // (just need some resonable limit to avoid perf issues)
        public const int                                MAX_EVENTS = 10000; 

        public const int                                MIN_EVENT_ZINDEX = 250;
        public const int                                MAX_EVENT_ZINDEX = 100000;

        private const int                               FOCUS_ZINDEX_INC = 50000;

        public const int                                ANIMATION_DURATION = 300;

        #region Private Fields

        private const double                            TOP_MARGIN = 5;

        // we need this margin so that events do not run over date/time column titles
        private const double                            BOTTOM_MARGIN = 5; 

        // colums which are not visible, but used for smothing of scroll
        private const int                               EXTRA_COLUMNS = 4; 

        private SingleDelayedInvoke                     m_delayInvoke = new SingleDelayedInvoke(SingleDelayedInvoke.MEDIUM_UI_DELAY);
        private SingleDelayedInvoke                     m_delayComplete = new SingleDelayedInvoke(SingleDelayedInvoke.MAX_UI_DELAY);

        private const int                               EVENT_POOL_SIZE = 200;
        private const int                               INITIAL_EVENT_POOL_SIZE = EVENT_POOL_SIZE / 10;

        private TimelineBand                            m_parent;
        private TimelineCalendar                        m_timeline;
        private DateTime                                m_currDate;

        private const long                              INVALID_COLUMN_IDX = -99999999;
        private long                                    m_startIndex = INVALID_COLUMN_IDX;
        private FrameworkElement[]                      m_columns;
        private FrameworkElement[]                      m_columnMarkers;
        private int                                     m_columnCount;

        private TimelineEventStore                      m_events;
        private Dictionary<TimelineEvent, object>       m_visibleEvents;
        private double                                  m_maxEventHeight;

        private Dictionary<TimelineEvent, TimelineDisplayEvent>
                                                        m_dispEvents;

        private bool                                    m_assignRows;

        private Canvas                                  m_canvas;            

        private DataTemplate                            m_template;
        private DataTemplate                            m_markerTemplate;
        private DataTemplate                            m_eventTemplate;

        private TimeSpan                                m_maxDescriptionWidth = new TimeSpan();
        private Stack<UIElement>                        m_elementPool = new Stack<UIElement>();

        private long                                    m_displayExecTime = 0;
        private double                                  m_viewSize;

        private Storyboard                              m_columnStoryboard;
        private Storyboard                              m_eventStoryboard;

        #endregion

        public TimelineBuilder(
            TimelineBand                                band,
            Canvas                                      canvas,
            DataTemplate                                template,
            DataTemplate                                textTemplate,
            int                                         columnCount,
            TimelineCalendar                            timeline,
            DataTemplate                                eventTemplate,
            double                                      maxEventHeight, 
            bool                                        assignRows,
            DateTime                                    currDateTime
        )
        {
            SingleDelayedInvoke                         poolBuilder;

            Debug.Assert(template != null);
            Debug.Assert(canvas != null);
            Debug.Assert(eventTemplate != null);
            Debug.Assert(band != null);
            Debug.Assert(columnCount > 0);
            Debug.Assert(timeline != null);
            Debug.Assert(maxEventHeight > 0);

            m_parent = band;
            m_eventTemplate = eventTemplate;
            m_canvas = canvas;
            m_template = template;;
            m_columnCount = columnCount;
            m_timeline = timeline;
            m_assignRows = assignRows;
            m_markerTemplate = textTemplate;
            
            m_visibleEvents = new Dictionary<TimelineEvent, object>();
            m_dispEvents = new Dictionary<TimelineEvent, TimelineDisplayEvent>();
            m_maxEventHeight = maxEventHeight;

            CurrentDateTime = currDateTime;

            //
            // precreate some elements, so that we can later take them from pool
            //
            poolBuilder = new SingleDelayedInvoke();

            for (int i = 0; i < INITIAL_EVENT_POOL_SIZE; ++i)
            {
                m_elementPool.Push((UIElement) CreateEventElement());
            }

            Utilities.Trace(this);
        }

        public List<TimelineEvent> AllEvents
        {
            get
            {
                return m_events == null ? null : m_events.All;
            }
        }

        public TimelineCalendar Calendar
        {
            get
            {
                return m_timeline;
            }
        }

        public TimeSpan VisibleWindowSize
        {
            get;
            set;
        }

        /// 
        /// <summary>
        /// This method used by Utilities.Trace</summary>
        /// 
        public override string ToString(
        )
        {
            return (m_timeline == null ? String.Empty : m_timeline.LineType.ToString());
        }

        public int ColumnCount
        {
            get
            {
                return m_columnCount;
            }
            set
            {
                m_columnCount = value;
            }
        }

        /// 
        /// <summary>
        /// This calculates row for each of event (makes sense only for main band).
        /// We try to place evens so that the do not overlap on the screen.</summary>
        /// 
        public void CalculateEventRows(
        )
        {
            int                                         count;
            int                                         rowCount;
            int                                         minIndex;
            DateTime[]                                  dates;
            DateTime                                    minDate;
            TimelineEvent                               e;
            int                                         overrideRowCount;

            Debug.Assert(m_assignRows);
            Debug.Assert(AllEvents != null);

            Utilities.Trace(this);

            rowCount = (int) ((PixelHeight - TOP_MARGIN - BOTTOM_MARGIN) / m_maxEventHeight);

            if (AllEvents.Count > 0)
            {
                overrideRowCount = AllEvents.Max((s) => { return s.RowOverride; }) + 1;
                rowCount = Math.Max(rowCount, overrideRowCount);
            }

            if (rowCount == 0)
            {
                for (int i = 0; i < AllEvents.Count; ++i)
                {
                    e = AllEvents[i];
                    e.Row = 0;
                }
            }
            else 
            {
                dates = new DateTime[rowCount];

                for (int i = 0; i < rowCount; ++i)
                {
                    dates[i] = new DateTime();
                }

                count = AllEvents.Count;

                for (int i = 0; i < count; ++i)
                {
                    minDate = dates[0];    
                    minIndex = 0;
                    e = AllEvents[i];

                    if (e.RowOverride == -1)
                    {
                        for (int k = 0; k < rowCount; ++k)
                        {
                            if (minDate > dates[k])
                            {
                                minIndex = k;
                                minDate = dates[k];
                            }
                        }

                        dates[minIndex] = e.EndDate;
                        e.Row = minIndex;
                    }
                    else
                    {
                        e.Row = e.RowOverride;
                        dates[e.Row] = e.EndDate;
                    }
                }
            }
        }


        /// 
        /// <summary>
        /// Calculate top position and width of each event</summary>
        /// 
        public void CalculateEventPositions(
        )
        {
            TimelineDisplayEvent                        pos;
            double                                      maxWidth = 0;

            Debug.Assert(AllEvents != null);
            
            if (m_dispEvents == null)
            {
                return;
            }

            Utilities.Trace(this);
            
            foreach (TimelineEvent e in AllEvents)
            {
                if (!m_dispEvents.ContainsKey(e))
                {
                    pos = new TimelineDisplayEvent(e, m_parent.TimelineTray, this);
                    m_dispEvents.Add(e, pos);
                }
                else
                {
                    pos = m_dispEvents[e];
                }

                Debug.Assert(e.Row >= 0, "Need first call CalculateEventRows for main band");

                if (pos.Top == -1 || pos.TimelineTray.RecalculateEventTopPosition)
                {
                    pos.SetCalculatedTop(e.Row * m_maxEventHeight + TOP_MARGIN);
                }

                pos.ActualEventPixelWidth = TimeSpanToPixels(e.EndDate - e.StartDate); 
                pos.ActualEventPixelWidth = Math.Max(3.0, pos.ActualEventPixelWidth);

                pos.EventPixelWidth = Math.Min(PixelWidth * 2, pos.ActualEventPixelWidth);

                maxWidth = Math.Max(maxWidth, pos.DescriptionWidth);
            }

            m_maxDescriptionWidth = PixelsToTimeSpan(maxWidth);
        }

        public void DisplayEvents(
            bool                                        animate = false
        )
        {
            if (m_parent.TimelineTray.ImmediateDisplay || 
                m_displayExecTime <= SingleDelayedInvoke.MINIMAL_UI_DELAY)
            {
                m_displayExecTime = DisplayEventsImpl(false, animate);
            }
            else
            { 
                m_delayInvoke.Invoke(() => 
                {
                    DisplayEventsImpl(true, false);

                    m_delayComplete.Invoke(() => 
                    {
                        m_displayExecTime = DisplayEventsImpl(false, false);
                    });
                });
            }
        }

        private bool CompleteColumnAnimation(
        )
        {
            if (m_columnStoryboard != null)
            {
                m_columnStoryboard.SkipToFill();
                m_columnStoryboard.Stop();
                m_columnStoryboard = null;
                return true;
            }

            return false;
        }

        private bool CompleteEventAnimation(
        )
        {
            if (m_eventStoryboard != null)
            {
                m_eventStoryboard.SkipToFill();
                m_eventStoryboard.Stop();
                m_eventStoryboard = null;
                return true;
            }
            return false;
        }

        /// 
        /// <summary>
        /// Display all visible events and remove all invisible for current visible time window
        /// In quick mode we only reposition events which are already displayed.</summary>
        /// 
        public long DisplayEventsImpl(
            bool                                        refreshVisibleOnly = false,
            bool                                        animate = false
        )
        {
            DateTime                                    begin;
            DateTime                                    end;
            double                                      distance;
            double                                      left;
            TimelineDisplayEvent                        pos;
            double                                      viewSize = 0;
            bool                                        isNew = false;
            IEnumerable<TimelineEvent>                  events;
            Dictionary<TimelineEvent, object>           newVisibleEvents;
            object                                      visual;
            long                                        start;
            double                                      oldViewSize;
            int                                         i = 0;

            CompleteEventAnimation();

            if (animate)
            {
                m_eventStoryboard = new Storyboard();
            }

            start = DateTime.Now.Millisecond;
            oldViewSize = m_viewSize;

            if (m_timeline.IsValidIndex(m_startIndex))
            {
                begin = m_timeline.GetFloorTime(m_timeline[m_startIndex]);
            }
            else
            {
                begin = DateTime.MinValue;
            }

            if (m_timeline.IsValidIndex(m_startIndex + m_columnCount + EXTRA_COLUMNS))
            {
                end = m_timeline.GetCeilingTime(m_timeline[m_startIndex + m_columnCount + EXTRA_COLUMNS]);
            }
            else
            {
                end = DateTime.MaxValue;
            }

            begin = DateTime.MinValue + m_maxDescriptionWidth > begin ? DateTime.MinValue : begin - m_maxDescriptionWidth;

            if (AllEvents != null)
            {
                //
                // remove events which are not visible any more
                //
                m_visibleEvents.Keys.NotInRange(begin, end).ForEach
                (
                    (te) => RemoveEvent(m_visibleEvents[te])
                );

                if (!refreshVisibleOnly)
                {
                    events = m_events.QuickSearch(begin, end, true);
                }
                else
                {
                    events = m_visibleEvents.Keys.InRange(begin, end);
                }

                newVisibleEvents = new Dictionary<TimelineEvent, object>();

                foreach (TimelineEvent e in events)
                {
                    if (++i > MAX_EVENTS)
                    {
                        break;
                    }
                    pos = m_dispEvents[e];
                        
                    distance = TimeSpanToPixels(CurrentDateTime - e.StartDate);
                    left = PixelWidth / 2 - distance;

                    Debug.Assert(e.InRange(begin, end));

                    if (pos.EventPixelWidth != pos.ActualEventPixelWidth)
                    {
                        if (left + pos.ActualEventPixelWidth < PixelWidth)
                        {
                            left = left + pos.ActualEventPixelWidth - PixelWidth * 2;
                        }
                        else if (left < -PixelWidth && left + pos.ActualEventPixelWidth > PixelWidth)
                        {
                            left = Math.Max(-PixelWidth, left);
                        }
                    }

                    if (!m_visibleEvents.ContainsKey(e))
                    {
                        visual = CreateEvent(e, m_dispEvents[e]);
                        isNew = true;
                    }
                    else
                    {
                        visual = m_visibleEvents[e];
                        isNew = false;
                    }
                        
                    newVisibleEvents.Add(e, visual);
                    viewSize = Math.Max(viewSize, MoveEvent(visual, 
                                                            m_dispEvents[e].TopWithoutOffset, 
                                                            left, 
                                                            pos.EventPixelWidth,
                                                            isNew,
                                                            animate));
                }

                m_visibleEvents = newVisibleEvents;
            }          
      
            m_viewSize = viewSize;
            if (m_parent.IsMainBand)
            {
                if (oldViewSize != viewSize)
                {
                    m_parent.OnScrollPositionChanged();
                }
                m_parent.TimelineTray.FireScrollViewChanged(viewSize);
            }

            if (m_eventStoryboard != null)
            {
                m_eventStoryboard.Begin();
            }

            return DateTime.Now.Millisecond - start;
        }

        public double VerticalViewSize
        {
            get
            {
                return m_viewSize + BOTTOM_MARGIN + TOP_MARGIN;
            }
        }


        /// 
        /// <summary>
        /// Removes all columns from timelineband screen</summary>
        /// 
        public void ClearColumns(
        )
        {
            if (Columns != null)
            {
                Columns.ForEach((e) => RemoveColumn(e));
            }

            if (ColumnMarkers != null)
            {
                ColumnMarkers.ForEach((e) => RemoveColumnText(e));
            }

            m_columns = null;
            m_columnMarkers = null;
        }

        /// 
        /// <summary>
        /// Remove all events from timeline screen</summary>
        /// 
        public void ClearEvents(
        )
        {
            if (m_visibleEvents != null)
            {
                foreach (object e in m_visibleEvents.Values)
                {
                    RemoveEvent(e);
                }
            }

            m_visibleEvents = new Dictionary<TimelineEvent, object>();
            m_dispEvents = new Dictionary<TimelineEvent, TimelineDisplayEvent>();

            m_events = new TimelineEventStore(new List<TimelineEvent>());
        }

        #region Properties

        public double PixelWidth
        {
            get
            {
                return m_canvas.ActualWidth;
            }
        }

        public double PixelHeight
        {
            get
            {
                return m_canvas.ActualHeight;
            }
        }

        public DateTime CurrentDateTime
        {
            get
            {
                return m_currDate;
            }
            set
            {
                if (m_currDate != value &&  m_columnStoryboard != null)
                {
                    CompleteColumnAnimation();
                }

                if (value < m_timeline.MinDateTime)
                {
                    m_currDate = m_timeline.MinDateTime;
                }
                else if (value > m_timeline.MaxDateTime)
                {
                    m_currDate = m_timeline.MaxDateTime;
                }
                else
                {
                    m_currDate = value;
                }
            }
        }

        public double ColumnPixelWidth
        {
            get
            {
                if (m_columns == null)
                {
                    return 0;
                }
                return PixelWidth / m_columnCount;
            }
        }

        public TimeSpan ColumnTimeWidth
        {
            get
            {
                DateTime                                begin;
                DateTime                                end;
                DateTime                                date;
                TimeSpan                                tick;

                date = CurrentDateTime;
                tick = new TimeSpan(1L);

                if (date == m_timeline.MaxDateTime)
                {
                    date = m_timeline.GetFloorTime(date) - tick;
                }
                else if (date == m_timeline.MinDateTime)
                {
                    date = m_timeline.GetCeilingTime(date) + tick;
                }

                end = m_timeline.GetFloorTime(date);
                begin = m_timeline.GetCeilingTime(date);

                return begin - end;
            }
        }

        public FrameworkElement[] Columns
        {
            get
            {
                return m_columns;
            }
        }

        public FrameworkElement[] ColumnMarkers
        {
            get
            {
                return m_columnMarkers;
            }
        }

        public TimelineEventStore EventStore
        {
            get
            {
                return m_events;
            }
            set
            {
                Debug.Assert(value != null);
                m_events = value;
            }
        }

        #endregion

        private FrameworkElement PositionColumn(
            FrameworkElement                            el,
            double                                      left, 
            double                                      top, 
            double                                      width, 
            double                                      height, 
            int                                         index = 0,
            string                                      content = null,
            Storyboard                                  sb = null
        )
        {
            double                                      currLeft;

            Debug.Assert(top > -1);

            if (content != null && ((string) el.DataContext) != content)
            {
                el.DataContext = content;
            }

            el.SetValue(Canvas.TopProperty, 0.0);
            el.SetValue(Canvas.ZIndexProperty, index);
            el.Height = height;

            currLeft = (double) el.GetValue(Canvas.LeftProperty);

            if (sb != null && 
                Math.Abs(left - currLeft) < width * 1.5)
            {
                sb.AddDouble(ANIMATION_DURATION, el, new PropertyPath(Canvas.LeftProperty), currLeft, left)
                  .AddDouble(ANIMATION_DURATION, el, new PropertyPath(FrameworkElement.WidthProperty), el.Width, width);
            }
            else
            { 
                el.SetValue(Canvas.LeftProperty, left);
                el.Width = width;
            }

            return el;
        }

        private FrameworkElement PositionColumnMarker(
            FrameworkElement                            el,
            double                                      left, 
            double                                      width, 
            double                                      height, 
            int                                         index = 0,
            string                                      content = null,
            Storyboard                                  sb = null
        )
        {
            double                                      currentLeft;

            if (el != null)
            { 
                if (content != null && ((string) el.DataContext) != content)
                {
                    el.DataContext = content;
                }

                el.SetValue(Canvas.TopProperty, height - Math.Max(el.ActualHeight, el.Height));
                el.SetValue(Canvas.ZIndexProperty, MAX_EVENT_ZINDEX + index);
                el.Width = width;

                currentLeft = (double) el.GetValue(Canvas.LeftProperty);

                if (sb != null && 
                    Math.Abs(left - currentLeft) < width * 1.5)
                {
                    sb.AddDouble(ANIMATION_DURATION, el, new PropertyPath(Canvas.LeftProperty), currentLeft, left)
                      .AddDouble(ANIMATION_DURATION, el, new PropertyPath(FrameworkElement.WidthProperty), el.Width, width);
                }
                else
                { 
                    el.Width = width;
                    el.SetValue(Canvas.LeftProperty, left);
                }
            }
            return el;
        }

        public object CreateEventElement(
        )
        {
            FrameworkElement                            element;
            DependencyObject                            obj;
            Hyperlink                                   link;

            obj = m_eventTemplate.LoadContent();
            element = (FrameworkElement) obj;
            element.MouseEnter += OnMouseEnter;
            element.MouseLeave += OnMouseLeave;

            if (m_parent.IsMainBand)
            {
                element.MouseLeftButtonDown += OnLeftButtonDown;
            }

            link = (Hyperlink) element.FindName("EventLinkTextBlock");

            if (link != null)
            {
                link.Click += m_parent.OnMoreInfoClick;
            }

            return element;
        }

        public object CreateEvent(
            TimelineEvent                               e,
            TimelineDisplayEvent                        de
        )
        {
            FrameworkElement                            element;

            Debug.Assert(e != null);

            if (m_elementPool.Count == 0)
            {
                element = CreateEventElement() as FrameworkElement;
            }
            else
            {
                element = m_elementPool.Pop() as FrameworkElement;
            }

            element.DataContext = de;
            element.SetValue(Canvas.ZIndexProperty, (e.Row + 1) * MIN_EVENT_ZINDEX);
            m_canvas.Children.Add(element);

            if (m_parent.IsMainBand)
            {
                m_parent.TimelineTray.FireEventCreated(element, de);
                m_parent.FireEventCreated(element,de);
            }

            return element;
        }

        void OnLeftButtonDown(
            object                                      sender, 
            System.Windows.Input.MouseButtonEventArgs   e
        )
        {
            FrameworkElement                            fe;
            TimelineDisplayEvent                        de;

            fe = (sender as FrameworkElement);

            if (Keyboard.Modifiers != ModifierKeys.Control)
            {
                foreach (TimelineDisplayEvent ev in m_parent.Selection)
                {
                    ev.Selected = false;
                }
                m_parent.Selection.Clear();
            }

            de = fe.DataContext as TimelineDisplayEvent;
            de.Selected = !de.Selected;

            if (de.Selected)
            {
                m_parent.Selection.Add(de);
            }
            else
            {
                m_parent.Selection.Remove(de);
            }

            if (m_parent.OnSelectionChanged != null)
            {
                m_parent.OnSelectionChanged(this, EventArgs.Empty);
            }
        }

        void OnMouseLeave(
            object                                      sender, 
            System.Windows.Input.MouseEventArgs         e
        )
        {
            FrameworkElement                            el;
            int                                         index;

            el = (FrameworkElement) sender;

            if (!InertialTimelineScroll.Moving)
            {
                if ((el.DataContext as TimelineDisplayEvent).IsEventMouseOver)
                {
                    (el.DataContext as TimelineDisplayEvent).IsEventMouseOver = false;

                    index = (int) el.GetValue(Canvas.ZIndexProperty) - FOCUS_ZINDEX_INC;
                    if (index > MIN_EVENT_ZINDEX - 1)
                    {
                        el.SetValue(Canvas.ZIndexProperty, index);
                    }
                }
            }
        }

        private void OnMouseEnter(
            object                                      sender, 
            System.Windows.Input.MouseEventArgs         e
        )
        {
            FrameworkElement                            el;
            int                                         index;

            el = (FrameworkElement) sender;

            if (!InertialTimelineScroll.Moving)
            {
                if (!(el.DataContext as TimelineDisplayEvent).IsEventMouseOver)
                {
                    index = (int) el.GetValue(Canvas.ZIndexProperty);
                    if (index < MIN_EVENT_ZINDEX + FOCUS_ZINDEX_INC)
                    {
                        index += FOCUS_ZINDEX_INC;
                        (el.DataContext as TimelineDisplayEvent).IsEventMouseOver = true;
                        el.SetValue(Canvas.ZIndexProperty, index);
                    }
                }
            }
        }

        public double MoveEvent(
            object                                      eo,
            double                                      top,
            double                                      left,
            double                                      width,
            bool                                        enew = true,
            bool                                        animate = false
        )
        {
            FrameworkElement                            el;
            TimelineDisplayEvent                        de;
            double                                      currentLeft;

            el = eo as FrameworkElement;
            Debug.Assert(el != null);
            
            de = el.DataContext as TimelineDisplayEvent;

            if (left > -el.ActualWidth + 1 && left < m_canvas.ActualWidth + el.ActualWidth - 1)
            {
                if (m_parent.IsMainBand)
                {
                    m_parent.TimelineTray.FireOnEventVisible(el, (el.DataContext as TimelineDisplayEvent));
                }
            }

            SetTopWithScrollOffset(el, top, true, animate);

            currentLeft = (double) el.GetValue(Canvas.LeftProperty);

            if (m_eventStoryboard != null && 
                animate && 
                currentLeft != left && 
                Math.Abs(currentLeft - left) < el.ActualWidth)
            {
                m_eventStoryboard.AddDouble(ANIMATION_DURATION, 
                                            el, 
                                            new PropertyPath(Canvas.LeftProperty), 
                                            currentLeft, 
                                            left);
            }
            else
            {
                el.SetValue(Canvas.LeftProperty, left);
            }

            return de.TopWithoutOffset + de.DescriptionHeight;
        }

        public void SetTopWithScrollOffset(
            FrameworkElement                            el, 
            double                                      top,
            bool                                        lockOverride,
            bool                                        animate = false
        )
        {
            TimelineDisplayEvent                        de;
            double                                      currentLeft;

            if (lockOverride)
            {
                LockTopOverrideUpdate = true;
            }

            try
            {
                if (m_parent.IsMainBand)
                {
                    top = top - m_parent.CanvasScrollOffset;
                }
                else
                {
                    el.SetValue(Canvas.TopProperty, top);
                }

                currentLeft = (double) el.GetValue(Canvas.TopProperty);

                if (m_eventStoryboard != null && 
                    animate && 
                    currentLeft != top && 
                    Math.Abs(currentLeft - top) < el.ActualHeight)
                {
                    m_eventStoryboard.AddDouble(ANIMATION_DURATION, 
                                                el, 
                                                new PropertyPath(Canvas.TopProperty), 
                                                (double) el.GetValue(Canvas.TopProperty), 
                                                top);
                }
                else
                {
                    el.SetValue(Canvas.TopProperty, top);
                }
            }
            finally
            {
                if (lockOverride)
                {
                    LockTopOverrideUpdate = false;
                }
            }

            de = el.DataContext as TimelineDisplayEvent;
            m_viewSize = Math.Max(m_viewSize, de.TopWithoutOffset + de.DescriptionHeight);
        }

        public bool LockTopOverrideUpdate
        {
            get;
            set;
        }

        public void RemoveEvent(
            object                                      e
        )
        {
            UIElement                                   element;
            Hyperlink                                   link;

            element = e as UIElement;

            Debug.Assert(element != null);

            m_canvas.Children.Remove(e as UIElement);

            if (m_elementPool.Count < EVENT_POOL_SIZE)
            {
                (element as FrameworkElement).DataContext = null;
                m_elementPool.Push(element);
            }
            else
            {
                element.MouseEnter -= OnMouseEnter;
                element.MouseLeave -= OnMouseLeave;

                link = (Hyperlink) (element as FrameworkElement).FindName("EventLinkTextBlock");

                if (link != null)
                {
                    link.Click -= m_parent.OnMoreInfoClick;
                }
            }

            if (m_parent.IsMainBand)
            {
                m_parent.TimelineTray.FireEventDeleted(element as FrameworkElement, 
                    (element as FrameworkElement).DataContext as TimelineDisplayEvent);
            }
        }

        public void RemoveColumn(
            object                                      e
        )
        {
            m_canvas.Children.Remove(e as UIElement);
        }

        public void RemoveColumnText(
            object                                      e
        )
        {
            m_canvas.Children.Remove(e as UIElement);
        }

        private string GetDataContext(
            long                                        index
        )
        {
            if (m_timeline.IsValidIndex(index))
            {
                return TimelineCalendar.ItemToString(m_timeline, m_timeline[index]);
            }
            else
            {
                return string.Empty;
            }
        }

        /// 
        /// <summary>
        /// Build columns (one for each years, dates, etc.)</summary>
        /// 
        public void BuildColumns(
            bool                                        animate = false,
            bool                                        displayEvents = false,
            Size?                                       newSize = null
        )
        {
            double                                      step;
            double                                      width;
            double                                      height;
            double                                      left;

            FrameworkElement[]                          columns;
            FrameworkElement[]                          markers;
            int                                         i;

            Utilities.Trace(this);

            if (newSize == null)
            {
                width = PixelWidth;
                height = PixelHeight;
            }
            else
            {
                width = newSize.Value.Width;
                height = newSize.Value.Height;
            }

            step = ColumnPixelWidth;

            CompleteColumnAnimation();

            if (m_columns == null || m_columns.Length != m_columnCount + EXTRA_COLUMNS)
            {
                columns = new FrameworkElement[m_columnCount + EXTRA_COLUMNS];
                markers = new FrameworkElement[m_columnCount + EXTRA_COLUMNS];

                if (m_columns != null)
                {
                    Array.Copy(m_columns, columns, Math.Min(columns.Length, m_columns.Length));

                    for (i = columns.Length; i < m_columns.Length; ++i)
                    {
                        m_canvas.Children.Remove(m_columns[i]);
                    }
                }

                if (m_columnMarkers != null)
                {
                    Array.Copy(m_columnMarkers, markers, Math.Min(markers.Length, m_columnMarkers.Length));

                    for (i = markers.Length; i < m_columnMarkers.Length; ++i)
                    {
                        m_canvas.Children.Remove(m_columnMarkers[i]);
                    }
                }
                m_columns = columns;
                m_columnMarkers = markers;
            }

            for (i = 0; i < m_columnCount + EXTRA_COLUMNS; ++i)
            {
                left = ColumnPixelWidth * (i - 1);

                if (m_columns[i] == null)
                {
                    m_columns[i] = m_template.LoadContent() as FrameworkElement;
                    m_columns[i].DataContext = null;
                    m_canvas.Children.Add(m_columns[i]);
                }

                if (m_markerTemplate != null && m_columnMarkers[i] == null)
                { 
                    m_columnMarkers[i] = m_markerTemplate.LoadContent() as FrameworkElement;
                    m_columnMarkers[i].DataContext = null;
                    m_canvas.Children.Add(m_columnMarkers[i]);
                }
            }

            FixPositions(displayEvents, animate);
        }

        /// 
        /// <summary>
        /// Convert pixels to TimeSpan according to current timeline band type</summary>
        /// 
        public TimeSpan PixelsToTimeSpan(
            double                                      pixels
        )
        {
            long                                        val;
            TimeSpan                                    span;
            double                                      dval;

            dval = (pixels * ColumnTimeWidth.TotalMilliseconds) / ColumnPixelWidth;
            dval = dval * TimeSpan.TicksPerMillisecond;

            val = (long) Math.Round(dval, 0);
            span = new TimeSpan(val);

            return span;
        }

        /// 
        /// <summary>
        /// Convert TimeSpan to pixels according to current timeline band type</summary>
        /// 
        public double TimeSpanToPixels(
            TimeSpan                                    span
            )
        {
            TimeSpan                                    totalVisible;

            switch (m_timeline.LineType)
            {
                case TimelineCalendarType.Decades:
                    totalVisible = new TimeSpan(365 * 10 * m_columnCount, 0, 0, 0);
                    break;

                case TimelineCalendarType.Years:
                    totalVisible = new TimeSpan(365 * m_columnCount, 0, 0, 0);
                    break;

                case TimelineCalendarType.Months:
                    totalVisible = new TimeSpan(31 * m_columnCount, 0, 0, 0);
                    break;

                case TimelineCalendarType.Days:
                    totalVisible = new TimeSpan(m_columnCount, 0, 0, 0);
                    break;

                case TimelineCalendarType.Hours:
                    totalVisible = new TimeSpan(0, m_columnCount, 0, 0, 0);
                    break;

                case TimelineCalendarType.Minutes10:
                    totalVisible = new TimeSpan(0, 0, m_columnCount * 10, 0, 0);
                    break;
                
                case TimelineCalendarType.Minutes:
                    totalVisible = new TimeSpan(0, 0, m_columnCount, 0, 0);
                    break;

                case TimelineCalendarType.Seconds:
                    totalVisible = new TimeSpan(0, 0, 0, m_columnCount, 0);
                    break;

                case TimelineCalendarType.Milliseconds100:
                    totalVisible = new TimeSpan(0, 0, 0, 0, m_columnCount * 100);
                    break;                

                case TimelineCalendarType.Milliseconds10:
                    totalVisible = new TimeSpan(0, 0, 0, 0, m_columnCount * 10);
                    break;

                default: // TimelineCalendarType.Milliseconds:
                    totalVisible = new TimeSpan(0, 0, 0, 0, m_columnCount);
                    break;
            }

            return (PixelWidth * span.TotalMilliseconds) / totalVisible.TotalMilliseconds;
        }

        /// 
        /// <summary>
        /// Moves current timeline band for the passed timespan</summary>
        /// 
        public void TimeMove(
            TimeSpan                                    span
            )
        {
            CurrentDateTime -= span;
            FixPositions(true);
        }

        /// 
        /// <summary>
        /// After current data is changed this function fixes positions of all columns 
        /// and all events</summary>
        /// 
        private void FixPositions(
            bool                                        displayEvents,
            bool                                        animate = false
        )
        {
            double                                      startLeft;
            double                                      posOffset;

            int                                         colcount;
            long                                        newStart;
            long                                        idxOffset;

            if (CompleteColumnAnimation())
            {
                animate = false;
            }

            if (animate)
            {
                m_columnStoryboard = new Storyboard();
            }

            colcount = (m_columnCount  + EXTRA_COLUMNS);
            posOffset = TimeSpanToPixels(CurrentDateTime - m_timeline.GetFloorTime(CurrentDateTime));

            newStart = m_timeline.IndexOf(CurrentDateTime) - colcount / 2;
            startLeft = (PixelWidth / 2 - ColumnPixelWidth * (colcount / 2)) - posOffset;

            if (m_startIndex == INVALID_COLUMN_IDX || newStart > m_startIndex + colcount || newStart + colcount < m_startIndex)
            {
                //
                // this is case when we draw columns for the first time, or there are no columns which data contexts 
                // may be reused
                //
                PositionColumnAndMarker(newStart, startLeft, 0, true, m_columnStoryboard);
            }
            else if (m_startIndex == newStart)
            {
                //
                // this is the case when we reuse existing column context (date string)
                //
                PositionColumnAndMarker(newStart, startLeft, 0, false, m_columnStoryboard);
            }
            else 
            {
                idxOffset = m_startIndex - newStart;

                ShiftArray(m_columns, idxOffset, out m_columns);
                ShiftArray(m_columnMarkers, idxOffset, out m_columnMarkers);

                PositionColumnAndMarker(newStart, startLeft, 0, false, m_columnStoryboard);

                if (idxOffset > 0)
                {
                    for (int i = 0; i < idxOffset; ++i)
                    {
                        SetColumnDataContext(newStart + i, i);
                    }
                }
                else
                {
                    for (int i = colcount + (int) idxOffset; i < colcount; ++i)
                    {
                        SetColumnDataContext(newStart + i, i);
                    } 
                }
            }
            m_startIndex = Math.Max(0, newStart);

            if (displayEvents)
            { 
                DisplayEvents(animate);
            }

            if (m_columnStoryboard != null)
            {
                m_columnStoryboard.Begin();
            }
        }

        private void SetColumnDataContext(
            long                                        dataIndex,
            int                                         i
        )
        {
            string context = GetDataContext(dataIndex);

            m_columns[i].DataContext = context;
            if (m_columnMarkers[i] != null)
            {
                m_columnMarkers[i].DataContext = context;
            }
        }

        private static void ShiftArray<T>(
            T[]                                         arr, 
            long                                        shift, 
            out T[]                                     res
        )
        {
            long                                        len;
            if (arr != null && shift != 0)
            {
                len = arr.Length;
                res = new T[len];

                if (shift < 0)
                {
                    shift = -shift + len;
                    for (long i = 0; i < len; ++i)
                    {
                        res[i] = arr[(i + shift) % len];
                    }
                }
                else
                { 
                    for (long i = 0; i < len; ++i)
                    {
                        res[(i + shift) % len] = arr[i];
                    }
                }
            }
            else
            {
                res = null;
            }
        }

        private void PositionColumnAndMarker(
            long                                        startIndex,
            double                                      startLeft,
            double                                      top,
            bool                                        resetContext = true,
            Storyboard                                  sb = null
        )
        {
            string                                      context = null;
            object                                      dc;

            for (int idx = 0; idx < m_columnCount  + EXTRA_COLUMNS; ++idx)
            {
                dc = m_columns[idx].DataContext;

                if (resetContext || dc == null)
                {
                    context = GetDataContext(startIndex + idx);
                }
                else
                {
                    context = null;
                }

                PositionColumn(m_columns[idx], startLeft, 0.0, ColumnPixelWidth + 1, PixelHeight, idx, context, sb);
                PositionColumnMarker(m_columnMarkers[idx], startLeft, ColumnPixelWidth + 1, PixelHeight, idx, context, sb);
                startLeft += ColumnPixelWidth;
            }
        }

        public List<TimelineEvent> VisibleTimelineEvents
        {
            get
            {
                if (m_visibleEvents != null)
                {
                    return (from visibles in m_visibleEvents 
                                select visibles.Key as TimelineEvent).ToList();
                }
                return null;
            }
        }

        public long MinVisibleIndex
        {
            get
            {
                return m_startIndex + EXTRA_COLUMNS / 2;
            }
        }

        public DateTime MinVisibleDateTime
        {
            get
            {
                return (DateTime) m_timeline[MinVisibleIndex];
            }
        }

        public long MaxVisibleIndex
        {
            get
            {
                return m_startIndex + m_columnCount + EXTRA_COLUMNS / 2;
            }
        }

        public DateTime MaxVisibleDateTime
        {
            get
            {
                return (DateTime) m_timeline[MaxVisibleIndex];
            }
        }
    }
}