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
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace TimelineLibrary
{
    /// 
    /// <summary>
    /// Timeline (which is an instance of TimelineTray class) may have several TimelineBand
    /// objects in it. Each TimelineBand may represent years, months, and so on. Events 
    /// are displayed on each timelineband</summary>
    /// 
    [TemplatePart(Name = TimelineBand.TP_CANVAS_PART, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = TimelineBand.TP_NAVIGATE_LEFT_PART, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = TimelineBand.TP_NAVIGATE_LEFT_BUTTON_PART, Type = typeof(Button))]
    [TemplatePart(Name = TimelineBand.TP_NAVIGATE_RIGHT_PART, Type = typeof(FrameworkElement))]
    [TemplatePart(Name = TimelineBand.TP_NAVIGATE_RIGHT_BUTTON_PART, Type = typeof(Button))]
    [TemplatePart(Name = TimelineBand.TP_VISIBLE_DATES_PART, Type = typeof(Rectangle))]
    [TemplatePart(Name = TimelineBand.TP_MAIN_GRID_PART, Type = typeof(Grid))]
    public class TimelineBand: Control
    {
        #region Events

        public delegate void TimelineBandEvent(object sender, RoutedEventArgs e);
		public delegate void TimelineEventDelegate(FrameworkElement element, TimelineDisplayEvent de);
        
        public event Action<Point>                      OnCanvasDrag;
        public event Action<Point>                      OnCanvasBeginDrag;
        public event Action<Point>                      OnCanvasEndDrag;
        public event TimelineBandEvent                  OnCurrentDateChanged;
        
        #endregion

        #region Private Fields and Constants

        #region Types of Scale

        private const string                            TL_TYPE_DECADES = "decades";
        private const string                            TL_TYPE_YEARS = "years";
        private const string                            TL_TYPE_MONTHS = "months";
        private const string                            TL_TYPE_DAYS = "days";
        private const string                            TL_TYPE_HOURS = "hours";
        private const string                            TL_TYPE_MINUTES = "minutes";
        private const string                            TL_TYPE_MINUTES10 = "minutes10";
        private const string                            TL_TYPE_SECONDS = "seconds";
        private const string                            TL_TYPE_MILLISECONDS100 = "milliseconds100";
        private const string                            TL_TYPE_MILLISECONDS10 = "milliseconds10";
        private const string                            TL_TYPE_MILLISECONDS = "milliseconds";


        #endregion

        #region Control Part constants

        private const string                            TP_CANVAS_PART = "CanvasPart";
        private const string                            TP_NAVIGATE_LEFT_PART = "NavigateLeft";
        private const string                            TP_NAVIGATE_LEFT_BUTTON_PART = "NavigateLeftButton";
        private const string                            TP_NAVIGATE_RIGHT_PART = "NavigateRight";
        private const string                            TP_NAVIGATE_RIGHT_BUTTON_PART = "NavigateRightButton";
        private const string                            TP_MAIN_GRID_PART = "MainGrid";
        private const string                            TP_VISIBLE_DATES_PART = "VisibleDatesPart";

        #endregion

        private const string                            FMT_TRACE = "Name: {0}, Type:{1}, Size:{2},{3},{4},{5}";

        // canval where we draw column lines, column titles and events
        private Canvas                                  m_canvasPart;  

        // timeline columns clipping area
        private RectangleGeometry                       m_clipRect;

        private TimelineBuilder                         m_calc;

        // specifies if all columns already initialized
        private bool                                    m_calcInitialized;
        
        private string                                  m_sourceType = TL_TYPE_YEARS;
        private TimelineCalendarType                    m_timelineType;
        private string                                  m_calendarType;

        private ObservableCollection<TimelineDisplayEvent>
                                                        m_selection = new ObservableCollection<TimelineDisplayEvent>();
        private bool                                    m_timeFormat24 = false;

        private double                                  m_offset;

        public EventHandler                             OnSelectionChanged;
        
        public InertialTimelineScroll                   InertialScroll;
        private TimelineTray                            m_tray;


        #endregion

        #region Dependency Properties

        #region DefaultTextItemTemplate

        public static readonly DependencyProperty DefaultTextItemTemplateProperty =
            DependencyProperty.Register("DefaultTextItemTemplate", typeof(DataTemplate), 
            typeof(TimelineBand), new PropertyMetadata(DefaultTextItemTemplateChanged));


        public static void DefaultTextItemTemplateChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            TimelineBand                        band;
            band = (TimelineBand) d;

            if (band != null)
            {
                band.OnDefaultTextItemTemplateChanged(e); 
            }
        }

        protected virtual void OnDefaultTextItemTemplateChanged(
            DependencyPropertyChangedEventArgs          e
        )
        {
            DefaultTextItemTemplate = (DataTemplate) e.NewValue;
        }

        public DataTemplate DefaultTextItemTemplate
        {
            get
            {
                return (DataTemplate) GetValue(DefaultTextItemTemplateProperty);
            }
            set
            {
                SetValue(DefaultTextItemTemplateProperty, value);
            }
        }

        #endregion

        #region TextItemTemplate

        public static readonly DependencyProperty TextItemTemplateProperty =
            DependencyProperty.Register("TextItemTemplate", typeof(DataTemplate), 
            typeof(TimelineBand), new PropertyMetadata(TextItemTemplateChanged));


        public static void TextItemTemplateChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            TimelineBand                        band;
            band = (TimelineBand) d;

            if (band != null)
            {
                band.OnTextItemTemplateChanged(e); 
            }
        }

        protected virtual void OnTextItemTemplateChanged(
            DependencyPropertyChangedEventArgs          e
        )
        {
            TextItemTemplate = (DataTemplate) e.NewValue;
        }

        public DataTemplate TextItemTemplate
        {
            get
            {
                return (DataTemplate) GetValue(TextItemTemplateProperty);
            }
            set
            {
                SetValue(TextItemTemplateProperty, value);
            }
        }

        #endregion

        #region DefaultItemTemplate
        public static readonly DependencyProperty DefaultItemTemplateProperty =
            DependencyProperty.Register("DefaultItemTemplate", typeof(DataTemplate), 
            typeof(TimelineBand), new PropertyMetadata(DefaultItemTemplateChanged));


        public static void DefaultItemTemplateChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            TimelineBand                        band;
            band = (TimelineBand) d;

            if (band != null)
            {
                band.OnDefaultItemTemplateChanged(e); 
            }
        }

        protected virtual void OnDefaultItemTemplateChanged(
            DependencyPropertyChangedEventArgs          e
        )
        {
            DefaultItemTemplate = (DataTemplate) e.NewValue;
        }

        public DataTemplate DefaultItemTemplate
        {
            get
            {
                return (DataTemplate) GetValue(DefaultItemTemplateProperty);
            }
            set
            {
                SetValue(DefaultItemTemplateProperty, value);
            }
        }
        #endregion

        #region DefaultShortEventTemplate
        
        public static readonly DependencyProperty DefaultShortEventTemplateProperty =
            DependencyProperty.Register("DefaultShortEventTemplate", 
                typeof(DataTemplate), typeof(TimelineBand), 
                new PropertyMetadata(DefaultShortEventTemplateChanged));


        public static void DefaultShortEventTemplateChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            TimelineBand                        band;
            band = (TimelineBand) d;

            if (band != null)
            {
                band.OnDefaultShortEventTemplateChanged(e); 
            }
        }

        protected virtual void OnDefaultShortEventTemplateChanged(
            DependencyPropertyChangedEventArgs          e
        )
        {
            DefaultShortEventTemplate = (DataTemplate) e.NewValue;
        }
        
        public DataTemplate DefaultShortEventTemplate
        {
            get
            {
                return (DataTemplate) GetValue(DefaultShortEventTemplateProperty);
            }

            set
            {
                SetValue(DefaultShortEventTemplateProperty, value);
            }
        }
        #endregion

        #region DefaultEventTemplate
        
        public static readonly DependencyProperty DefaultEventTemplateProperty =
            DependencyProperty.Register("DefaultEventTemplate", 
                typeof(DataTemplate), 
                typeof(TimelineBand), 
                new PropertyMetadata(DefaultEventTemplateChanged));


        public static void DefaultEventTemplateChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            TimelineBand                        band;
            band = (TimelineBand) d;

            if (band != null)
            {
                band.OnDefaultEventTemplateChanged(e); 
            }
        }

        protected virtual void OnDefaultEventTemplateChanged(
            DependencyPropertyChangedEventArgs          e
        )
        {
            DefaultEventTemplate = (DataTemplate) e.NewValue;
        }

        public DataTemplate DefaultEventTemplate
        {
            get
            {
                return (DataTemplate)GetValue(DefaultEventTemplateProperty);
            }

            set
            {
                SetValue(DefaultEventTemplateProperty, value);
            }
        }
        #endregion

        #region EventTemplate

        public static readonly DependencyProperty EventTemplateProperty =
            DependencyProperty.Register("EventTemplate", 
                typeof(DataTemplate), 
                typeof(TimelineBand), 
                new PropertyMetadata(EventTemplateChanged));

        public static void EventTemplateChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            TimelineBand                        band;
            band = (TimelineBand) d;

            if (band != null)
            {
                band.OnEventTemplateChanged(e); 
            }
        }

        protected virtual void OnEventTemplateChanged(
            DependencyPropertyChangedEventArgs          e
        )
        {
            EventTemplate = (DataTemplate) e.NewValue;
        }

        public DataTemplate EventTemplate
        {
            get
            {
                return (DataTemplate) GetValue(EventTemplateProperty);
            }

            set
            {
                SetValue(EventTemplateProperty, value);
            }
        } 
        
        #endregion

        #region ItemTemplate

        public static readonly DependencyProperty ItemTemplateProperty =
            DependencyProperty.Register("ItemTemplate", 
                typeof(DataTemplate), 
                typeof(TimelineBand), 
                new PropertyMetadata(ItemTemplateChanged));

        public static void ItemTemplateChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            TimelineBand                        band;
            band = (TimelineBand) d;

            if (band != null)
            {
                band.OnItemTemplateChanged(e); 
            }
        }

        protected virtual void OnItemTemplateChanged(
            DependencyPropertyChangedEventArgs          e
        )
        {
            ItemTemplate = (DataTemplate) e.NewValue;
        }

        public DataTemplate ItemTemplate
        {
            get
            {
                return (DataTemplate)GetValue(ItemTemplateProperty);
            }

            set
            {
                SetValue(ItemTemplateProperty, value);
            }
        } 
        
        #endregion

        #region ShortEventTemplate

        public static readonly DependencyProperty ShortEventTemplateProperty =
            DependencyProperty.Register("ShortEventTemplate", 
                typeof(DataTemplate), 
                typeof(TimelineBand), 
                new PropertyMetadata(ShortEventTemplateChanged));

        public static void ShortEventTemplateChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            TimelineBand                        band;
            band = (TimelineBand) d;

            if (band != null)
            {
                band.OnShortEventTemplateChanged(e); 
            }
        }

        protected virtual void OnShortEventTemplateChanged(
            DependencyPropertyChangedEventArgs          e
        )
        {
            ShortEventTemplate = (DataTemplate) e.NewValue;
        }

        public DataTemplate ShortEventTemplate
        {
            get
            {
                return (DataTemplate)GetValue(ShortEventTemplateProperty);
            }

            set
            {
                SetValue(ShortEventTemplateProperty, value);
            }
        } 
        
        #endregion

        #region TimelineWindowSize

        public static readonly DependencyProperty TimelineWindowSizeProperty =
            DependencyProperty.Register("TimelineWindowSize", typeof(int), 
                typeof(TimelineBand), new PropertyMetadata(
                10, TimelineWindowSizeChanged));

        public static void TimelineWindowSizeChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            TimelineBand                        band;

            band = (TimelineBand) d;

            if (band != null)
            {
                band.OnTimelineWindowSizeChanged(e); 
            }
        }

        protected virtual void OnTimelineWindowSizeChanged(
            DependencyPropertyChangedEventArgs          e
        )
        {
            int                                         newVal;

            newVal = (int) e.NewValue;

            if (newVal < 2)
            {
                throw new ArgumentException("TimelineWindowSize should be greater then 2");
            }
            if (Calculator != null)
            {
                Calculator.ColumnCount = newVal;
            }

            UpdateControlSize();
        }

        public int TimelineWindowSize
        {
            get
            {
                return (int) GetValue(TimelineWindowSizeProperty);
            }
            set
            {
                SetValue(TimelineWindowSizeProperty, value);
            }
        }

        #endregion

        #region MaxEventHeight

        public static readonly DependencyProperty MaxEventHeightProperty =
            DependencyProperty.Register("MaxEventHeight", 
                typeof(double), typeof(TimelineBand), 
                new PropertyMetadata(50.0, MaxEventHeightChanged));

        public static void MaxEventHeightChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            ((TimelineBand) d).MaxEventHeight = (double) e.NewValue;
        }

        public double MaxEventHeight
        { 
            get
            {
                return (double) GetValue(MaxEventHeightProperty);
            }

            set
            {
                Debug.Assert(value > 1);
                SetValue(MaxEventHeightProperty, value);
            }
        }

        #endregion

        #region IsMainBand

        public static readonly DependencyProperty IsMainBandProperty =
            DependencyProperty.Register("IsMainBand", 
                typeof(bool), typeof(TimelineBand), 
                new PropertyMetadata(false, IsMainBandChanged));

        public static void IsMainBandChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            ((TimelineBand) d).IsMainBand = (bool) e.NewValue;
        }

        public bool IsMainBand
        { 
            get
            {
                return (bool) GetValue(IsMainBandProperty);
            }

            set
            {
                SetValue(IsMainBandProperty, value);
            }
        }

        #endregion

        #endregion

        #region Template Parts

        public Grid MainGridPart
        {
            get;
            set;
        }

        public Canvas CanvasPart
        {
            get
            {
                return m_canvasPart;
            }

            set
            {
                if (m_canvasPart != null)
                {
                    if (InertialScroll != null)
                    {
                        InertialScroll.OnDragStart -= OnCanvasMouseLeftButtonDown;
                        InertialScroll.OnDragStop  -= OnCanvasMouseLeftButtonUp;
                        InertialScroll.OnDragMove  -= OnCanvasMouseMove;
                        InertialScroll = null;
                    }

                    m_canvasPart.MouseWheel  -= OnCanvasMouseWheel;
                    m_canvasPart.SizeChanged -= OnSizeChanged;
                }

                m_canvasPart = value;

                if (value != null)
                {
                    InertialScroll = new InertialTimelineScroll(m_canvasPart);

                    InertialScroll.OnDragStart   += OnCanvasMouseLeftButtonDown;
                    InertialScroll.OnDragStop    += OnCanvasMouseLeftButtonUp;
                    InertialScroll.OnDragMove    += OnCanvasMouseMove;
                    InertialScroll.OnDoubleClick += OnCanvasDoubleClick;

                    m_canvasPart.MouseWheel  += OnCanvasMouseWheel;
                    m_canvasPart.SizeChanged += OnSizeChanged;

                    m_canvasPart.DataContext = this;
                }
            }
        }

        void OnCanvasDoubleClick(
            Point                                       point
        )
        {
            DateTime                                    date;

            date = CurrentDateTime + 
                m_calc.PixelsToTimeSpan(point.X - m_canvasPart.ActualWidth / 2);

            TimelineTray.FireTimelineDoubleClick(date, point);
        }

        void OnSizeChanged(
            object                                      sender, 
            SizeChangedEventArgs                        e
        )
        {
            this.ClipRect.Rect = new Rect(new Point(0, 0), 
                new Size(e.NewSize.Width, e.NewSize.Height));
        }

        void OnCanvasMouseWheel(
            object                                      sender, 
            MouseWheelEventArgs                         e
        )
        {
					if (Keyboard.Modifiers != ModifierKeys.Control)
					{
						TimeSpan span;

						if (m_calc != null)
						{
							span = m_calc.PixelsToTimeSpan(e.Delta / 5);
							SafeDateChange(span, true);
						}
					}
        }

        public FrameworkElement VisibleDatesPart
        {
            get;
            set;
        }

        #region NavigateLeft 
        
        private Button                                  m_navigateLeftButton;
        public Button NavigateLeftButton
        {
            get
            {
                return m_navigateLeftButton;
            }

            set
            {
                if (m_navigateLeftButton != null)
                {
                    m_navigateLeftButton.Click -= OnNavigateLeftClick;
                }

                m_navigateLeftButton = value;

                if (m_navigateLeftButton != null)
                {
                    m_navigateLeftButton.Click += OnNavigateLeftClick;
                }
            }
        }

        void OnNavigateLeftClick(object sender, RoutedEventArgs e)
        {
            SafeDateChange(m_calc.ColumnTimeWidth, true);
        }

        #endregion

        #region NavigateRight 
        
        private Button                                  m_navigateRightButton;
        public Button NavigateRightButton
        {
            get
            {
                return m_navigateRightButton;
            }

            set
            {
                if (m_navigateRightButton != null)
                {
                    m_navigateRightButton.Click -= OnNavigateRightClick;
                }

                m_navigateRightButton = value;

                if (m_navigateRightButton != null)
                {
                    m_navigateRightButton.Click += OnNavigateRightClick;
                }
            }
        }

        void OnNavigateRightClick(object sender, RoutedEventArgs e)
        {
            SafeDateChange(m_calc.ColumnTimeWidth, false);
        }

        #endregion

        #region Template Parts' Event Handlers

        private void OnCanvasMouseLeftButtonDown(
            Point                                       p
        )
        {
            if (TooltipServiceEx.LastTooltip != null)
            {
                TooltipServiceEx.LastTooltip.Hide();
                TooltipServiceEx.LastTooltip = null;
            }

            m_canvasPart.Cursor = Cursors.Hand;

            if (OnCanvasBeginDrag != null)
            {
                OnCanvasBeginDrag(p);
            }
        }

        private void OnCanvasMouseLeftButtonUp(
            Point                                       p
        )
        {
            StopDragging();
            if (TooltipServiceEx.LastTooltip != null)
            {
                TooltipServiceEx.LastTooltip.Hide();
                TooltipServiceEx.LastTooltip = null;
            }

            if (OnCanvasEndDrag != null)
            {
                OnCanvasEndDrag(p);
            }
        }

        public virtual double VerticalScrollableSize
        {
            get
            {
                if (m_calc != null && m_calc.VerticalViewSize > this.ActualHeight)
                {
                    return m_calc.VerticalViewSize;
                }
                else
                { 
                    return this.ActualHeight;
                }
            }
        }

        protected virtual void OnCanvasMouseMove(
            Point                                       pPrev,
            Point                                       pNew
        )
        {
            if (m_calc != null)
            {
                Dispatcher.BeginInvoke(new Action(() => 
                {
                    MoveScale(pPrev, pNew);

                    if (IsMainBand && OnCanvasDrag != null)
                    {
                        OnCanvasDrag(pNew);
                    }

                    if (TooltipServiceEx.LastTooltip != null)
                    {
                        TooltipServiceEx.LastTooltip.Hide();
                        TooltipServiceEx.LastTooltip = null;
                    }
                }));
            }
        }

        private void StopDragging(
        )
        {
            m_canvasPart.Cursor = Cursors.Arrow;
        }

        #endregion

        #endregion

        #region Public Properties

        public double CanvasScrollOffset
        {
            get
            {
                return m_offset;
            }
            set
            {
                //
                // we do not do display events here any more, it should be done manually
                //
                m_offset = value;
                OnScrollPositionChanged();
            }
        }

        public virtual void OnScrollPositionChanged(
        )
        {
        }

        public Canvas Canvas
        {
            get
            {
                return m_canvasPart;
            }
        }

        public bool TimeFormat24
        {
            get
            {
                return m_timeFormat24;
            }
            set
            {
                m_timeFormat24 = value;
                if (m_calc != null && m_calc.Calendar != null)
                {
                    m_calc.Calendar.TimeFormat24 = m_timeFormat24;
                }
            }
        }

        public TimelineTray TimelineTray
        {
            get
            {
                if (m_tray == null && Parent as TimelineTray != null)
                {
                    m_tray = Parent as TimelineTray;
                }
                return m_tray;
            }

            set
            {
                TimelineTray old = m_tray;
                m_tray = value;
                OnTimelineTrayChanged(old, m_tray);
            }
        }

        protected virtual void OnTimelineTrayChanged(
            TimelineTray                                old,
            TimelineTray                                newTray
        )
        {
        }

        public String CalendarType
        {
            get;
            set;
        }

        public string ItemSourceType
        {
            get
            {
                return m_sourceType;
            }

            set
            {
                string                                  itemsType;

                itemsType = value.ToLower();
                m_sourceType = value;

                switch (itemsType)
                {
                    case TL_TYPE_DECADES:
                        m_timelineType = TimelineCalendarType.Decades;
                        break;

                    case TL_TYPE_YEARS:
                        m_timelineType = TimelineCalendarType.Years;
                        break;

                    case TL_TYPE_MONTHS:
                        m_timelineType = TimelineCalendarType.Months;
                        break;

                    case TL_TYPE_DAYS:
                        m_timelineType = TimelineCalendarType.Days;
                        break;

                    case TL_TYPE_HOURS:
                        m_timelineType = TimelineCalendarType.Hours;
                        break;

                    case TL_TYPE_MINUTES10:
                        m_timelineType = TimelineCalendarType.Minutes10;
                        break;

                    case TL_TYPE_MINUTES:
                        m_timelineType = TimelineCalendarType.Minutes;
                        break;

                    case TL_TYPE_SECONDS:
                        m_timelineType = TimelineCalendarType.Seconds;
                        break;

                    case TL_TYPE_MILLISECONDS100:
                        m_timelineType = TimelineCalendarType.Milliseconds100;
                        break;

                    case TL_TYPE_MILLISECONDS10:
                        m_timelineType = TimelineCalendarType.Milliseconds10;
                        break;

                    case TL_TYPE_MILLISECONDS:
                        m_timelineType = TimelineCalendarType.Milliseconds;
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        /// 
        /// <summary>
        /// This sets/gets both dependency property and internal current datetime</summary>
        /// 
        internal DateTime CurrentDateTime
        {
            get
            {
                return m_calc == null ? new DateTime() : m_calc.CurrentDateTime;
            }
            set
            {
                if (m_calc != null && m_calc.CurrentDateTime != value)
                {
                    m_calc.TimeMove(m_calc.CurrentDateTime - value);
                    
                    if (OnCurrentDateChanged != null)
                    {
                        OnCurrentDateChanged(this, new RoutedEventArgs());
                    }
                }
            }
        }

        public string DisplayField
        { 
            get; 
            set;
        }

        public TimelineCalendar ItemsSource 
        { 
            get; 
            set; 
        }

        public TimelineEventStore EventStore
        {
            get
            {
                return m_calc.EventStore;
            }
            set
            {
                Debug.Assert(value != null);
                m_calc.EventStore = value;
            }
        }

        public double VisibleDatesAreaWidth
        {
            get
            {
                double                                  width;
                TimeSpan                                visTimeSpan;

                Debug.Assert(m_calc != null);

                if (IsMainBand)
                {
                    width = 0;
                }
                else 
                {
                    visTimeSpan = VisibleTimeSpan;

                    if (visTimeSpan.Ticks < 0)
                    {
                        visTimeSpan = new TimeSpan(0L);
                    }

                    width = m_calc.TimeSpanToPixels(visTimeSpan);
                }

                return width;
            }
        }

        public double VisibleDatesAreaHeight
        {
            get
            {
                return CanvasPart.ActualHeight - 1;
            }
        }

        public TimeSpan VisibleTimeSpan
        {
            get
            {
                return (m_calc == null ? new TimeSpan(0L) : m_calc.VisibleWindowSize);
            }

            internal set
            {
                Debug.Assert(m_calc != null);

                m_calc.VisibleWindowSize = value;
            }
        }

        public TimelineBuilder Calculator
        {
            get
            {
                return m_calc;
            }
        }

        #endregion 

        #region Public and Internal methods

        public ObservableCollection<TimelineDisplayEvent> Selection
        {
            get
            {
                return m_selection;
            }
        }

        public void OnMoreInfoClick(
            object                                      sender, 
            RoutedEventArgs                             args
        )
        {
            EventDetailsWindow                          details;
            FrameworkElement                            element;

            details = new EventDetailsWindow();
            details.DataContext = ((FrameworkElement) sender).DataContext;

            element = (FrameworkElement) sender;

            TooltipServiceEx.HideLastTooltip();

#if SILVERLIGHT
            details.Show();
#else
            details.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            details.ShowDialog();
#endif
            TooltipServiceEx.HideLastTooltip();
        }

        public override void OnApplyTemplate(
        )
        {
            Utilities.Trace(this);

            base.OnApplyTemplate();

            MainGridPart = (Grid) GetTemplateChild(TP_MAIN_GRID_PART);
            CanvasPart = (Canvas) GetTemplateChild(TP_CANVAS_PART);

            NavigateLeftButton = (Button) GetTemplateChild(TP_NAVIGATE_LEFT_BUTTON_PART);
            NavigateRightButton = (Button) GetTemplateChild(TP_NAVIGATE_RIGHT_BUTTON_PART);

            VisibleDatesPart = (FrameworkElement) GetTemplateChild(TP_VISIBLE_DATES_PART);

            if (VisibleDatesPart != null)
            {
                VisibleDatesPart.SetValue(Canvas.ZIndexProperty, TimelineBuilder.MIN_EVENT_ZINDEX - 1);
            }
        }

        static TimelineBand(
        )
        {
#if !SILVERLIGHT
            DefaultStyleKeyProperty.OverrideMetadata(typeof(TimelineBand), 
                new FrameworkPropertyMetadata(typeof(TimelineBand)));
#endif
        }

        public TimelineBand(
        )
        {
            Utilities.Trace(this);
#if SILVERLIGHT
            this.DefaultStyleKey = typeof(TimelineBand);
#endif
            this.Loaded += OnControlLoaded;
            this.SizeChanged += OnControlSizeChanged;
#if SILVERLIGHT
            Application.Current.Host.Content.FullScreenChanged += OnFullScreen;
#endif
        }

        void OnFullScreen(
            object                                      sender, 
            EventArgs                                   e
        )
        {
            Utilities.Trace(this);

            UpdateControlSize();
        }

        void OnControlSizeChanged(
            object                                      sender, 
            SizeChangedEventArgs                        e
        )
        {
            Utilities.Trace(this);

            UpdateControlSize(false, e.NewSize);
        }

        void UpdateControlSize(
            bool                                        animate = true,
            Size?                                       size = null                                          
        )
        {
            Utilities.Trace(this);

            if (size == null)
            {
                size = new Size(this.ActualWidth, this.ActualHeight);
            }

            if (m_calcInitialized)
            {
                m_calc.BuildColumns(animate, false, size);
                this.ResetVisibleDaysHighlight();
            }
        }

        
        void OnControlLoaded(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            Utilities.Trace(this);
        }

        public void CreateTimelineCalculator(
            string                                      calendarType,
            DateTime                                    currentDateTime,
            DateTime                                    minDateTime,
            DateTime                                    maxDateTime
        )
        {
            Debug.Assert(this.TimelineTray != null);

            ItemsSource = new TimelineCalendar(calendarType, m_timelineType,
                minDateTime, maxDateTime);

            ItemsSource.TimeFormat24 = TimeFormat24;

            m_calendarType = calendarType;

            if (ItemTemplate == null)
            {
                ItemTemplate = DefaultItemTemplate;
            }

            if (TextItemTemplate == null)
            {
                TextItemTemplate = DefaultTextItemTemplate;
            }
            
            if (ShortEventTemplate == null)
            {
                ShortEventTemplate = DefaultShortEventTemplate;
            }

            if (EventTemplate == null)
            {
                EventTemplate = DefaultEventTemplate;
            }

            if (m_calc != null)
            {
                m_calc.ClearEvents();
                m_calc.ClearColumns();
            }

            m_calc = new TimelineBuilder(
                this,
                CanvasPart, 
                ItemTemplate, 
                TextItemTemplate,
                TimelineWindowSize, 
                ItemsSource, 
                !IsMainBand ? ShortEventTemplate : EventTemplate,
                MaxEventHeight,
                IsMainBand,
                currentDateTime);

            m_calc.BuildColumns();
            m_calcInitialized = true;
        }

        public void CalculateEventRows(
        )
        {
            //
            // it only makes sence to calculate row positions for main band becuase
            // other bands should use rows from main band to look similar with main.
            //
            Debug.Assert(IsMainBand);
            Debug.Assert(m_calc != null);

            m_calc.CalculateEventRows();
        }

        /// 
        /// <summary>
        /// Calculates event positions (should be called after CalculateEventRows for main (see IsMainBand)
        /// timelineband)</summary>
        /// 
        public void CalculateEventPositions(
        )
        {
            Debug.Assert(m_calc != null);

            m_calc.CalculateEventPositions();
        }
        
        /// 
        /// <summary>
        /// Clear all events from timelineband screen</summary>
        /// 
        public void ClearEvents(
        )
        {
            if (m_calc != null)
            {
                m_calc.ClearEvents();
            }
        }

        /// 
        /// <summary>
        /// Display all events which should be visible in current timelineband window</summary>
        /// 
        public void DisplayEvents(
        )
        {
            Debug.Assert(m_calc != null);
            m_calc.DisplayEvents();
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetVisibleDaysHighlight(
        )
        {
            if (VisibleDatesPart != null)
            {
                if (VisibleTimeSpan.Ticks == 0 || IsMainBand)
                {
                    VisibleDatesPart.Visibility = Visibility.Collapsed;
                }
                else if (VisibleDatesAreaWidth != 0.0 && VisibleDatesAreaHeight != 0.0)
                {
                    VisibleDatesPart.Visibility = Visibility.Visible;
                    VisibleDatesPart.Width = VisibleDatesAreaWidth;
                    VisibleDatesPart.Height = VisibleDatesAreaHeight;

                    VisibleDatesPart.SetValue(Canvas.LeftProperty, 
                        (CanvasPart.ActualWidth - VisibleDatesAreaWidth) / 2 + 1);

                    VisibleDatesPart.SetValue(Canvas.ZIndexProperty, TimelineBuilder.MIN_EVENT_ZINDEX - 1);
                }
            }
        }

        public override string ToString(
            )
        {
            return String.Format(FMT_TRACE, Name, ItemSourceType, GetValue(Canvas.LeftProperty),
                GetValue(Canvas.TopProperty), ActualHeight, ActualWidth);
        }

        #endregion

		public event TimelineEventDelegate OnEventCreated;

		internal void FireEventCreated(
			FrameworkElement element,
			TimelineDisplayEvent de
		)
		{
			if (OnEventCreated != null)
			{
				OnEventCreated(element, de);
			}
		}

        #region Private Methods and Properties

        private RectangleGeometry ClipRect
        {
            get
            {
                if (m_clipRect == null)
                {
                    m_clipRect = (RectangleGeometry) GetTemplateChild("ClipRect");
                }
                return m_clipRect;
            }
        }

        private string GetDataContext(
            int                                         index
        )
        {
            return TimelineCalendar.ItemToString(ItemsSource, ItemsSource[index]);
        }

        /// 
        /// <summary>
        /// Moves timeline according to mouse move during drag-drop</summary>
        /// 
        private void MoveScale(
            Point                                       prevPos,
            Point                                       newPos
        )
        {
            TimeSpan                                    span;
            double                                      vertOffset;
            bool                                        display = false;

            Debug.Assert(m_calc != null);

            if (newPos.Y - prevPos.Y != 0 && IsMainBand)
            { 
                vertOffset = TimelineTray.EventCanvasOffset - (newPos.Y - prevPos.Y);

                if (vertOffset != 0 && vertOffset <= VerticalScrollableSize)
                {
                    if (vertOffset < 0)
                    {
                        vertOffset = 0;
                    }

                    vertOffset = Math.Min(
                        VerticalScrollableSize - this.ActualHeight, vertOffset);

                    TimelineTray.EventCanvasOffset = vertOffset;
                    display = true;
                }
            }

            if (newPos.X != prevPos.X)
            {
                span = m_calc.PixelsToTimeSpan(newPos.X - prevPos.X);

                SafeDateChange(span, true, newPos.X < prevPos.X);
            }
            else if (display)
            {
                DisplayEvents();
            }
        }

        protected virtual void OnMoveScale(
        )
        {
        }

        private void SafeDateChange(
            TimeSpan                                    span,
            bool                                        subtract
        )
        {
              SafeDateChange(span, subtract, false);
        }

        private void SafeDateChange(
            TimeSpan                                    span,
            bool                                        subtract,
            bool                                        fixAsMaxDate
        )
        {
            bool                                        fixDate;

            fixDate = true;

            try
            {
                if (subtract)
                {
                    if (CurrentDateTime - span > Calculator.Calendar.MinDateTime)  
                    {
                        TimelineTray.CurrentDateTime -= span;
                        fixDate = false;
                    }
                }
                else
                {
                    if (CurrentDateTime + span < Calculator.Calendar.MaxDateTime)  
                    {
                        TimelineTray.CurrentDateTime += span;
                        fixDate = false;
                    }
                }
            }
            catch(ArgumentOutOfRangeException)
            {
                fixDate = true;
            }
            
            if (fixDate)
            {
                if (!fixAsMaxDate)
                {
                    TimelineTray.CurrentDateTime = Calculator.Calendar.MinDateTime;
                }
                else
                {
                    TimelineTray.CurrentDateTime = Calculator.Calendar.MaxDateTime;
                }
            }
        }

        #endregion

    }
}
