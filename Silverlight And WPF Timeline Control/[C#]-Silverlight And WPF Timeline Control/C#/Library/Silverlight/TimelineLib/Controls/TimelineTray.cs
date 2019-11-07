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
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Xml.Linq;
using System.Collections.ObjectModel;
using System.Windows.Media;
using System.Windows.Media.Effects;
#if !SILVERLIGHT
    using System.IO;
#else
    using System.Windows.Browser;
#endif

namespace TimelineLibrary
{
    public delegate void TimelineEventDelegate(FrameworkElement element, TimelineDisplayEvent de);
    public delegate void ScrollViewpointChanged(object sender, double value);
    public delegate void DoubleClick(DateTime date, Point point);

    /// 
    /// <summary>
    /// Main container class for TimelineBands. It is inherited from Grid, so that timeline band 
    /// can be places one under another and main band can be maximized.</summary>
    /// 
    /// Timeline tray is the main screen control.  Timeline bands are rows within the timeline grid
    /// 
    public class TimelineTray: Grid, ITimelineToolboxTarget, INotifyPropertyChanged
    {
        #region Constants

        // Used for tracing in debug version
        private const string                            FMT_TRACE = "Name: {0}, Size:{1},{2}";
        
        // Default 'more' link text displayed in events of main band
        private const string                            MORE_LINK_TEXT = " More...";

        // Default teaser length of events in main band
        private const int                               DEFAULT_TEASER_SIZE = 80;

        // These default constants are used for scripting
        private const int                               DEFAULT_MAIN_EVENT_SIZE = 70;
        private const int                               DEFAULT_SECONDARY_EVENT_SIZE = 4;
        
        // Default description width        
        private const double                            DEFAULT_DESCRIPTION_WIDTH = 226;

        #endregion

        #region Private Fields

        private List<TimelineBand>                      m_bands;
        private TimelineBand                            m_mainBand;

        private TimelineEventStore                      m_eventStore;
        private TimelineUrlCollection                   m_dataUrls;
        private bool                                    m_changingDate;

        private DataControlNotifier                     m_notifier;   
        private string                                  m_cultureId = TimelineLibrary.DateTimeConverter.DEFAULT_CULTUREID;

        // We recognize 2 modes in which control is working: silverlight and javascript.
        // In javascript mode bands are created from javascript, so sequence of control 
        // load events is different from silverlight mode. If no timeline bands defined 
        // in xaml we assume javascript mode otherwize assume silverlight mode.
        private bool                                    m_isJavascriptMode;     
        private DateTime                                m_currentDateTime;
        private bool                                    m_initialized;
        private bool                                    m_loaded;
        private ObservableCollection<TimelineEvent>     m_selection = new ObservableCollection<TimelineEvent>();
		private string                                  m_selectedEventImageUrl;

        private double                                  m_descriptionWidth = DEFAULT_DESCRIPTION_WIDTH;
        private bool                                    m_recalcOnResize = true;

        private double                                  m_offset = 0;

        #endregion

		/// <summary>
		/// Fires when the timeline control becomes ready.  This event is perfect for using 
        /// the <see cref="ResetEvents" /> method to load events into the timeline.
		/// </summary>
        public event EventHandler                       TimelineReady;
        public event EventHandler                       TimelineUpdated;
		public event EventHandler                       CurrentDateChanged;
        public event EventHandler                       SelectionChanged;
        public event DoubleClick                        TimelineDoubleClick;
        public event ScrollViewpointChanged             ScrollViewChanged;

        public event EventHandler                       EventsRefreshed;

        //
        // This event fires every time visual element is created for TimelineEvent becuase
        // it is inside visible area of timeline or about to be.
        //
        public event TimelineEventDelegate              OnEventCreated;

        //
        // This event fires every time visual element is deleted for TimelineEvent 
        // because it is outside visible area of timeline
        //
        public event TimelineEventDelegate              OnEventDeleted;

        //
        // This event fires when event is in visible area of the timeline screen 
        //
        public event TimelineEventDelegate              OnEventVisible;

        #region Ctor

        public TimelineTray(
        )
        {
            m_dataUrls = new TimelineUrlCollection();
            m_bands = new List<TimelineBand>();

            m_eventStore = new TimelineEventStore(new List<TimelineEvent>());

            MoreLinkText = MORE_LINK_TEXT;

            this.Loaded += OnControlLoaded;
            this.SizeChanged += OnSizeChanged;
			this.MouseWheel += OnMouseWheel;
           
#if SILVERLIGHT
            Application.Current.Host.Content.FullScreenChanged += OnFullScreenChanged;
#endif
        }

        #endregion

        #region Dependency Properties

        #region CurrentDateTime dependency property


        /// 
        /// <summary>
        /// Gets or sets current date of all timeline bands. Current date is in the middle of 
        /// each timeline band. This property can be changed from code behind to programmatically 
        /// move timelines back and forth</summary>
        /// 
        public static readonly DependencyProperty CurrentDateTimeProperty =
            DependencyProperty.Register("CurrentDateTime", typeof(DateTime), 
            typeof(TimelineTray), new PropertyMetadata(DateTime.Now, OnCurrentDateTimeChanged));

        [TypeConverter(typeof(DateTimeConverter))]
        public DateTime CurrentDateTime
        {
            get
            {
                return (DateTime) GetValue(CurrentDateTimeProperty);
            }
            set
            {
                SetValue(CurrentDateTimeProperty, value);
            }
        }

        public static void OnCurrentDateTimeChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            TimelineTray                                t;

            t = d as TimelineTray;

            if (t != null && e.NewValue != e.OldValue)
            {
                if ((DateTime) e.NewValue < t.MinDateTime)
                {
                    t.SetValue(CurrentDateTimeProperty, t.MinDateTime);
                }
                else if ((DateTime) e.NewValue > t.MaxDateTime)
                {
                    t.SetValue(CurrentDateTimeProperty, t.MaxDateTime);
                }
                else 
                {
                    t.m_currentDateTime = (DateTime) e.NewValue;
                    if (t.m_mainBand != null)
                    {
                        t.m_mainBand.CurrentDateTime = t.m_currentDateTime;
                        t.m_currentDateTime = t.m_mainBand.CurrentDateTime;
                    }
                    
                }
            }
        }

        #endregion

        #region MinDateTime

        public static readonly DependencyProperty MinDateTimeProperty =
            DependencyProperty.Register("MinDateTime", typeof(DateTime), 
            typeof(TimelineTray), new PropertyMetadata(DateTime.MinValue, 
                OnMinDateTimeChanged));

        [TypeConverter(typeof(DateTimeConverter))]
        public DateTime MinDateTime
        {
            get
            {
                return (DateTime) GetValue(MinDateTimeProperty);
            }
            set
            {
                SetValue(MinDateTimeProperty, value);
            }
        }

        public static void OnMinDateTimeChanged(
            DependencyObject                            d, 
            DependencyPropertyChangedEventArgs          e
        )
        {
            TimelineTray                                t;

            t = d as TimelineTray;

            if (t != null && e.NewValue != e.OldValue)
            {
                if ((DateTime) e.NewValue >= t.MaxDateTime)
                {
                    throw new ArgumentOutOfRangeException("MinDateTime cannot be more then MaxDateTime");
                }
                else if (t.CurrentDateTime < (DateTime) e.NewValue)
                {
                    t.SetValue(CurrentDateTimeProperty, e.NewValue);
                }

                foreach (TimelineBand b in t.m_bands)
                {
                    if (b.Calculator != null && b.Calculator.Calendar != null)
                    {
                        b.Calculator.Calendar.MinDateTime = ((DateTime) e.NewValue);
                    }
                }
            }
        }


        #endregion

        #region MaxDateTime

        public static readonly DependencyProperty MaxDateTimeProperty =
            DependencyProperty.Register("MaxDateTime", typeof(DateTime), 
            typeof(TimelineTray), new PropertyMetadata(DateTime.MaxValue, OnMaxDateTimeChanged));

        [TypeConverter(typeof(DateTimeConverter))]
        public DateTime MaxDateTime
        {
            get
            {
                return (DateTime) GetValue(MaxDateTimeProperty);
            }
            set
            {
                SetValue(MaxDateTimeProperty, value);
            }
        }

        public static void OnMaxDateTimeChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            TimelineTray                                t;

            t = d as TimelineTray;

            if (t != null && e.NewValue != e.OldValue)
            {
                if ((DateTime) e.NewValue < t.MinDateTime)
                {
                    throw new ArgumentOutOfRangeException("MaxDateTime cannot be less then MinDateTime");
                }
                else if (t.CurrentDateTime >= (DateTime) e.NewValue)
                {
                    t.SetValue(CurrentDateTimeProperty, e.NewValue);
                }

                foreach (TimelineBand b in t.m_bands)
                {
                    if (b.Calculator != null && b.Calculator.Calendar != null)
                    {
                        b.Calculator.Calendar.MaxDateTime = ((DateTime) e.NewValue);
                    }
                }
            }
        }

        #endregion

        #region TeaserSize

        public static readonly DependencyProperty TeaserSizeProperty =
            DependencyProperty.Register("TeaserSize", typeof(int), 
            typeof(TimelineTray), new PropertyMetadata(DEFAULT_TEASER_SIZE));

        public int TeaserSize
        {
            get
            {
                return (int) GetValue(TeaserSizeProperty);
            }
            set
            {
                SetValue(TeaserSizeProperty, value);
            }
        }

        #endregion

        #region ImmediateDisplay

        public static readonly DependencyProperty ImmediateDisplayProperty =
            DependencyProperty.Register("ImmediateDisplay", typeof(bool), 
            typeof(TimelineTray), new PropertyMetadata(true));

        public bool ImmediateDisplay
        {
            get
            {
                return (bool) GetValue(ImmediateDisplayProperty);
            }
            set
            {
                SetValue(ImmediateDisplayProperty, value);
            }
        }

        #endregion

        #endregion

        #region Public Methods and Properties

        public double EventCanvasOffset
        {
            get
            {
                return m_offset;
            }

            set
            {
                MainBand.CanvasScrollOffset = value;
                m_offset = value;
            }
        }

        /// 
        /// <summary>
        /// Specifies if vertical event positions should be recalculated when 
        /// timeline is resized. If false event positions calculated only once when
        /// timeline tray is displayed</summary>
        /// 
        public bool RecalculateEventTopPosition
        {
            get
            {
                return m_recalcOnResize;
            }
            set
            {
                m_recalcOnResize = value;
            }
        }

        public TimelineBand MainBand
        {
            get
            {
                return m_mainBand;
            }
        }

        /// 
        /// <summary>
        /// Return list of loaded timeline events</summary>
        /// 
        public List<TimelineEvent> TimelineEvents
        {
            get
            {
                return m_eventStore.All;
            }
        }

        ///
        /// <summary>
        /// Default width of of description element of main timeline band</summary>
        /// 
        public double DescriptionWidth
        {
            get
            {
                return m_descriptionWidth;
            }
            set
            {
                m_descriptionWidth = value;
            }
        }

        /// 
        /// <summary>
        /// ResetEvents method adds events specified in xml to all timeline bands.
        /// If you need to refresh events call ClearEvents and then ResetEvents, this 
        /// will removed all events from the screen and then draw up-to-date events.
		/// </summary>
		/// <param name="xml">The XML data that contains the data for the timeline events.</param>
        public void ResetEvents(
            string                                      xml
        )
        {
            ResetEvents(XDocument.Parse(xml));
        }

		/// <summary>
		/// Resets the UI with the XML provided in the XML document.
		/// </summary>
		/// <param name="doc">The XML document that contains the data for the timeline events.</param>
        public void ResetEvents(
            XDocument                                   doc
        )
        {
            m_eventStore = new TimelineEventStore(LoadEventDocument(doc));
            ClearSelection();
            RefreshEvents();
        }

		/// <summary>
		/// Resets the timeline using a list of events to provide to the UI.
		/// </summary>
		/// <param name="events">The events to reset the UI with.</param>
        public void ResetEvents(
            List<TimelineEvent>                         events,
            bool                                        fixDates = true
        )
        {
            //
            // fix event dates
            //
            if (fixDates)
            { 
                foreach (TimelineEvent e in events)
                {
                    if (!e.IsDuration)
                    {
                        e.EndDate = e.StartDate;
                    }
                }
            }

            m_eventStore = new TimelineEventStore(events);
            ClearSelection();
            RefreshEvents();
        }

        private void ClearSelection()
        {
            if (MainBand != null && MainBand.Selection != null)
            {
                MainBand.Selection.Clear();
                m_selection.Clear();

                PropertyChanged(this, new PropertyChangedEventArgs("SelectedTimelineEvents"));
                if (SelectionChanged != null) 
                {
                    SelectionChanged(this, EventArgs.Empty);
                }
            }
        }

        /// 
        /// <summary>
        /// Removes all events from all timeline bands</summary>
        /// 
        public void ClearEvents(
        )
        {
            m_eventStore = new TimelineEventStore(new List<TimelineEvent>());
            RefreshEvents();
        }

        /// 
        /// <summary>
        /// This link text is displayed if description on the event is more then specified by
        /// TeaserSize property</summary>
        /// 
        public string MoreLinkText
        {
            get;
            set;
        }

		/// <summary>
		/// This image that is displayed when an event is selected
		/// </summary>
		public void SetTeaserEventImageForSelectedEvents(string imageUrl)
		{
            Debug.Assert(false);

			m_selectedEventImageUrl = imageUrl;
			foreach (var timelineEvent in m_eventStore.All)
			{
				if (timelineEvent.Selected)
				{
					timelineEvent.TeaserEventImage = m_selectedEventImageUrl;
				}
			}
            TimelineDisplayEvent.SelectedEventImageUrl = imageUrl;
        }

        /// 
        /// <summary>
        /// Refresh (delete and recreate and redisplay) all events on all timeline bands.</summary>
        /// 
        public void RefreshEvents(
        )
        {
            RefreshEvents(true);
        }

        public void RefreshEvents(
            bool                                        checkInit
        )
        {
            if (m_initialized || !checkInit)
            {
                Utilities.Trace(this);

                foreach (TimelineBand b in m_bands)
                {
                    Debug.Assert(b.Calculator != null);

                    b.ClearEvents();
                    b.EventStore = m_eventStore;
                }

                m_mainBand.CalculateEventRows();
            
                foreach (TimelineBand b in m_bands)
                {
                    b.CalculateEventPositions();
                }

                foreach (TimelineBand b in m_bands)
                {
                    b.DisplayEvents();
                }

                if (TimelineUpdated != null)
                {
                    TimelineUpdated(this, EventArgs.Empty);
                }
            }

            if (EventsRefreshed != null)
            {
                EventsRefreshed(this, EventArgs.Empty);
            }
        }

        /// 
        /// <summary>
        /// This method is used for debugging (from Utilities.Trace)</summary>
        /// 
        public override string ToString(
        )
        {
            return String.Format(FMT_TRACE, Name, ActualHeight, ActualWidth);
        }

        /// 
        /// <summary>
        /// Specifies that control is initialized, which means that all bands are provided,
        /// all controls resized and xml data are read. Some of the properties and methods
        /// cannot be executed once control is initialized.</summary>
        /// 
        public bool IsTimelineInitialized
        {
            get
            {
                return m_initialized;
            }
        }

        /// 
        /// <summary>
        /// Calendar type (see TimelineCalendar.CalendarFromString property for the list of 
        /// values). This value cannot be changed after control is initialized.</summary>
        /// 
        public string CalendarType
        {
            get
            {
                return DateTimeConverter.CalendarName;
            }
            set
            {
                DateTimeConverter.CalendarName = value;
            }
        }

        /// 
        /// <summary>
        /// Culture ID specified what Date format is used, by default we use 'en-US'</summary>
        /// 
        public string CultureID
        {
            get
            {
                return m_cultureId;
            }
            set
            {
                Debug.Assert(value != null && value.Length > 0);
                
                m_cultureId = value;
                DateTimeConverter.CultureId = m_cultureId;
            }
        }

        /// 
        /// <summary>
        /// This property is used for DateTime calculations and is based on CultureID</summary>
        /// 
        public CultureInfo CultureInfo
        {
            get
            {
                return DateTimeConverter.CultureInfo;
            }
        }

        /// <summary>   		 
	    /// Returns the currently visible TimelineEvents   		 
	    /// </summary>   		 
        public IEnumerable<TimelineEvent> VisibleTimeEvents   		 
        {   		 
            get   		 
            {   		 
    			if (MainBand != null)
                {
		    		return MainBand.Calculator != null ? MainBand.Calculator.VisibleTimelineEvents : null;
                }   		 
                return null;   		 
            }   		 
        }

        /// <summary>   		 
        /// Returns the currently selected TimelineEvents   		 
        /// </summary>   		 
        public ObservableCollection<TimelineEvent> SelectedTimelineEvents
        {
            get
            {
                return m_selection;
            }
        }  


        /// 
        /// <summary>
        /// Zooms in/out all timeline bands by one column</summary>
        /// 
        public void Zoom(
            bool                                         zoomIn
        )
        {
			Zoom(zoomIn, 1);
		}

		/// <summary>
		/// Zoom in/out all timeline bands by the number of columns defined by zoomValue
		/// </summary>
		/// <param name="zoomIn">true to zoom in, false to zoom out</param>
		/// <param name="zoomValue">the number of columns to zoom</param>
		private void Zoom(
            bool                                         zoomIn, 
            int                                          zoomValue
        )
		{
            int                                          inc;
            TimeSpan                                     visibleWindow;

            inc = zoomIn ? -1 : 1;
			inc *= zoomValue;

			if (this.m_initialized)
            {
				foreach (TimelineBand band in this.m_bands)
                {
                    if (band.TimelineWindowSize + inc >= 2)
                    {
                        band.TimelineWindowSize += inc;
                    }
                    band.Calculator.DisplayEvents(true);
                }

				visibleWindow = this.m_mainBand.Calculator.MaxVisibleDateTime -
				                this.m_mainBand.Calculator.MinVisibleDateTime;

				foreach (TimelineBand band in this.m_bands)
                {
                    band.VisibleTimeSpan = visibleWindow;
                    band.ResetVisibleDaysHighlight();
                }
            }
        }

        /// 
        /// <summary>
        /// Collection of data file locations to load events from</summary>
        /// 
        public TimelineUrlCollection Urls
        {
            get
            {
                return m_dataUrls;
            }
        }

        #endregion

        #region Methods and Properties for Scripting from HTML

        /// 
        /// <summary>
        /// Loads data and displays them in the control</summary>
        /// 
        public void Run(
        )
        {
            Utilities.Trace(this);

            if (!m_isJavascriptMode)
            {
                Reload();
            }
            else
            {
                m_notifier.AddUrls(m_dataUrls);

                m_notifier.Start();
                m_notifier.CheckCompleted();
            }
        }

        /// 
        /// <summary>
        /// Add new timeline band</summary>
        /// 
        public void AddTimelineBand(
            int                                         height,
            bool                                        isMain, 
            string                                      srcType, 
            int                                         columnsCount
        )
        {
            AddTimelineBand(height, isMain, srcType, columnsCount, 
                isMain ? DEFAULT_MAIN_EVENT_SIZE : DEFAULT_SECONDARY_EVENT_SIZE);
        }

        public void AddTimelineToolbox(
        )
        {
            TimelineToolbox                             toolbox;
            RowDefinition                               rd;

            toolbox = new TimelineToolbox();
            toolbox.SetSite(this as ITimelineToolboxTarget);

            rd = new RowDefinition();

            if (toolbox.DesiredSize.Height > 0)
            {
                rd.Height = new GridLength(toolbox.DesiredSize.Height);
            }
            else
            {
                rd.Height = new GridLength(0, GridUnitType.Auto);
            }

            this.RowDefinitions.Add(rd);
            toolbox.SetValue(Grid.RowProperty, this.RowDefinitions.Count() - 1);

            this.Children.Add(toolbox);

        }

        public void AddTimelineBand(
            int                                         height,
            bool                                        isMain, 
            string                                      srcType, 
            int                                         columnsCount, 
            int                                         eventSize
        )
        {
            TimelineBand                                band;
            RowDefinition                               rd;

            band = new TimelineBand();

            if (m_notifier != null)
            {
                m_notifier.AddElement(band);
            }

            band.IsMainBand = isMain;
            band.ItemSourceType = srcType;

            rd = new RowDefinition();
            
            if (height > 0)
            {
                rd.Height = new GridLength((double) height);
                band.Height = height;
            }
            else
            {
                rd.Height = new GridLength(1.0, GridUnitType.Star);
            }

            this.RowDefinitions.Add(rd);

            band.SetValue(Grid.RowProperty, this.RowDefinitions.Count() - 1);
            band.Margin = new Thickness(0.0);
            band.TimelineWindowSize = columnsCount;
            band.MaxEventHeight = eventSize;
            band.TimelineTray = this;

            if (band.IsMainBand)
            {
                m_mainBand = band;
            }

            m_bands.Add(band);
            this.Children.Add(band);
        }

        #endregion

        #region Protected and Private methods

        private void OnFullScreenChanged(
            object                                      sender, 
            EventArgs                                   e
        )
        {
            Utilities.Trace(this);

            if (m_initialized)
            {
                RefreshEvents();
            }
        }

        private void OnSizeChanged(
            object                                      sender, 
            SizeChangedEventArgs                        e
        )
        {
            Utilities.Trace(this);

            if (m_initialized)
            {
                RefreshEvents();
            }
        }

		private void OnMouseWheel(
				object sender,
				MouseWheelEventArgs e
		)
		{
			if (Keyboard.Modifiers == ModifierKeys.Control)
			{
				Zoom(e.Delta > 0, Math.Abs(e.Delta / 120));
			}
		}

        /// 
        /// <summary>
        /// The user moved current datetime on one of the timeline bands, so we 
        /// sync all other bands with it.</summary>
        /// 
        private void OnCurrentDateChanged(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            TimelineBand                                band;

            if (!m_changingDate)
            {
                try
                {
                    m_changingDate = true;

                    band = (TimelineBand) sender;
                    m_currentDateTime = band.CurrentDateTime;

                    m_bands.ForEach(b => 
                    {
                        if (sender != b) 
                        { 
                            b.CurrentDateTime = band.CurrentDateTime; 
                        }
                    });

			        if (CurrentDateChanged != null)
			        {
				        CurrentDateChanged(this, EventArgs.Empty);
			        }
                }
                finally
                {
                    m_changingDate = false;
                }
            }
        }

        public virtual TimelineEvent CreateEvent(
        )
        {
            return new TimelineEvent();
        }

        public virtual TimelineEvent ReadEvent(
            XElement                                    row
        )
        {
            TimelineEvent                               e;
            string                                      start;
            string                                      end;
            string                                      isDuration;
            string                                      rowOverride;
            string                                      widthOverride;
            string                                      heightOverride;
            string                                      topOverride;

            rowOverride = GetAttribute(row.Attribute("rowOverride"));
            widthOverride = GetAttribute(row.Attribute("WidthOverride"));
            heightOverride = GetAttribute(row.Attribute("HeightOverride"));
            topOverride = GetAttribute(row.Attribute("TopOverride"));

            e = CreateEvent();

            e.Id = GetAttribute(row.Attribute("id"));
            e.Title = GetAttribute(row.Attribute("title"));
            e.EventColor = GetAttribute(row.Attribute("color"));
            e.Link = GetAttribute(row.Attribute("link"));
            e.EventImage = GetAttribute(row.Attribute("image"));
            e.TeaserEventImage = GetAttribute(row.Attribute("teaserimage"));
            e.Description = GetContent(row);

            start = GetAttribute(row.Attribute("start"));
            end = GetAttribute(row.Attribute("end"));
            isDuration = GetAttribute(row.Attribute("isDuration"));

            e.RowOverride = rowOverride.Length == 0 ? -1 : int.Parse(rowOverride);
            e.WidthOverride = widthOverride.Length == 0 ? -1.0 : double.Parse(widthOverride);
            e.HeightOverride = heightOverride.Length == 0 ? -1.0 : double.Parse(heightOverride);
            e.TopOverride = topOverride.Length == 0 ? -1.0 : double.Parse(topOverride);

            if (start.Length == 4)
            {
                e.StartDate = new DateTime(int.Parse(start), 1, 1);            
            }
            else
            {
                e.StartDate = DateTime.Parse(start, DateTimeConverter.CultureInfo);
            }

            if (String.Compare(isDuration, "true", StringComparison.InvariantCultureIgnoreCase) == 0)
            {
                e.IsDuration = true;
                if (end.Length == 4)
                {
                    e.EndDate = new DateTime(int.Parse(end), 1, 1);
                }
                else if (end.Length < 4)
                {
                    e.EndDate = e.StartDate;
                }
                else
                {
                    e.EndDate = DateTime.Parse(end, DateTimeConverter.CultureInfo);
                }
            }
            else
            {
                e.IsDuration = false;
                e.EndDate = e.StartDate;
            }

            return e;
        }

        /// <summary>
        /// Adds events located in parsed document to list of all events</summary>
        /// 
        private List<TimelineEvent> LoadEventDocument(
            XDocument                                   doc
        )
        {
            List<TimelineEvent>                         timelineEvents;


            timelineEvents = new List<TimelineEvent>();

            Debug.Assert(doc != null);
            Utilities.Trace(this);

            foreach (XElement el in doc.Descendants("data").Descendants("event"))
            {
                timelineEvents.Add(ReadEvent(el));
            }

            return timelineEvents;
        }

        public void Reload(
        )
        {
            if (m_bands.Count > 0 && m_mainBand != null)
            {
                m_isJavascriptMode = false;

                m_notifier = new DataControlNotifier(m_dataUrls, m_bands);
                m_notifier.LoadComplete += OnControlAndDataComlete;
                m_notifier.Start();
                m_notifier.CheckCompleted();
            }
        }

        private void OnControlLoaded(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {

            Utilities.Trace(this);
            
            if (!m_loaded) 
            {
                HookChildElements(this.Children);
        
                if (m_bands.Count > 0 && m_mainBand != null)
                {
                    // we are in silverlight mode, so all bands and urls are specified in 
                    // xaml and we can start data load immediately
                    m_isJavascriptMode = false;

                    m_notifier = new DataControlNotifier(m_dataUrls, m_bands);
                    m_notifier.LoadComplete += OnControlAndDataComlete; 
                    m_notifier.Start();
                    m_notifier.CheckCompleted();
                }
                else
                {
                    // we will need to wait till Run method is called from javascript
                    m_isJavascriptMode = true;
                    m_notifier = new DataControlNotifier();
                    m_notifier.LoadComplete += OnControlAndDataComlete; 
                }
                m_loaded = true;
            }

            // Do not remove copyright notice
            AddCopyrightElement();
        }

        /// 
        /// <summary>
        /// Do not remove copyright notice.</summary>
        /// 
        private void AddCopyrightElement(
        )
        {
            TextBlock                                   tb;
            byte                                        defTransparancy = 185;
            byte                                        noTransparancy = 255;

            tb = new TextBlock();

            tb.FontFamily = new FontFamily("Trebuchet MS");
            tb.SetValue(TextOptions.TextHintingModeProperty, TextHintingMode.Animated);

            tb.Margin = new Thickness(2, 1, 1, 1);
            tb.SetValue(Canvas.ZIndexProperty, 300000);

            tb.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
            tb.VerticalAlignment = System.Windows.VerticalAlignment.Top;

            tb.Text = "(c) timeline.codeplex.com";
            tb.Foreground = new SolidColorBrush(new Color() { A = defTransparancy });

            tb.Height = 14;
            tb.Width = 148;

            tb.Cursor = Cursors.Hand;
            tb.FontWeight = FontWeights.Bold;

            tb.Effect = new DropShadowEffect()
            {
                 Direction = 0.0,
                 ShadowDepth = 0.0,
                 Color = Colors.White
            };

            tb.MouseLeftButtonDown += (s, e) => 
            {
#if SILVERLIGHT
                HtmlPage.Window.Navigate(new Uri("http://timeline.codeplex.com/license"), "_blank");
#else
                Process.Start("http://timeline.codeplex.com/license");
#endif
            };

            tb.MouseEnter += (s, e) => 
            {
                tb.Foreground = new SolidColorBrush(new Color() { A = noTransparancy });
            };

            tb.MouseLeave += (s, e) => 
            {
                tb.Foreground = new SolidColorBrush(new Color() { A = defTransparancy });
            };

            this.Children.Add(tb);
        }

        protected void HookChildElements(
            UIElementCollection                         col
        )
        {
            TimelineBand                                b;

            foreach (UIElement  el in col)
            {
                if (el as TimelineBand != null)
                {
                    b = (TimelineBand) el;
                    b.TimelineTray = this;

                    if (b.IsMainBand)
                    {
                        m_mainBand = b;
                    }

                    m_bands.Add(b);
                }
                else if (el as TimelineToolbox != null)
                {
                    ((TimelineToolbox) el).SetSite(this);
                }
                else if (el as Panel != null)
                {
                    HookChildElements(((el) as Panel).Children);
                }
            }        

        }

        /// 
        /// <summary>
        /// This happens when we have all data and all timeline band controls have 
        /// completed resizing, so we ready to show content</summary>
        /// 
        private void OnControlAndDataComlete(
            object                                      sender, 
            EventArgs                                   e
        )
        {
            TimeSpan                                    visibleWindow;
            List<TimelineEvent>                         events = new List<TimelineEvent>();

            TimelineDisplayEvent.MoreLinkText = MoreLinkText;
            TimelineDisplayEvent.TeaserSize = TeaserSize;

            m_currentDateTime = CurrentDateTime;
#if SILVERLIGHT
            if (m_notifier != null)
            {
                m_notifier.StreamList.ForEach(s => events.AddRange(LoadEventDocument(XDocument.Load(s, LoadOptions.None))));
            }
#else
            if (m_notifier != null)
            {
                foreach (Stream s in m_notifier.StreamList)
                {
                    System.Xml.XmlTextReader                        reader;
                    reader = new System.Xml.XmlTextReader(s);

                    events.AddRange(LoadEventDocument(XDocument.Load(reader, LoadOptions.None)));

                }
            }
#endif

            if (m_notifier != null && m_notifier.StreamList.Count > 0)
            {
                m_eventStore = new TimelineEventStore(events);
            }

            if (m_mainBand == null)
            {
                throw new Exception("At least one main timeline band should be specified");
            }

            m_mainBand.CreateTimelineCalculator(
                CalendarType, 
                CurrentDateTime, 
                MinDateTime, 
                MaxDateTime
            );

            m_bands.ForEach(b => b.CreateTimelineCalculator(CalendarType, CurrentDateTime, MinDateTime, MaxDateTime));

            //
            // now we need to calculate visible timeline window and 
            // assign it to all timelineband controls
            //
            visibleWindow = m_mainBand.Calculator.MaxVisibleDateTime - m_mainBand.Calculator.MinVisibleDateTime;

            foreach (TimelineBand band in m_bands)
            {
                band.VisibleTimeSpan = visibleWindow;
                band.ResetVisibleDaysHighlight();

                band.Calculator.BuildColumns();

                band.OnCurrentDateChanged += OnCurrentDateChanged;

                if (band.IsMainBand)
                {
                    band.OnSelectionChanged += OnSelectionChanged;
                }
            }

            m_notifier = null;
            m_initialized = true;

            RefreshEvents(false);

            if (TimelineReady != null)
            {
                TimelineReady(this, new EventArgs());
            }
        }

        protected virtual void Initialized(
        )
        {
        }

        /// 
        /// <summary>
        /// Attribute value reader helper.</summary>
        /// 
        protected static string GetAttribute(
            XAttribute                                  a
        )
        {
            return a == null ? String.Empty : a.Value;
        }

        ///
        /// <summary>
        /// Returns content of element as xml</summary>
        ///
        protected static string GetContent(
            XElement                                    e
        )
        {
            return (e.FirstNode == null ? String.Empty : e.FirstNode.ToString());
        }

        /// 
        /// <summary>
        /// Sort function for events by startdate</summary>
        /// 
        private static int CompareEvents(
            TimelineEvent                               a,
            TimelineEvent                               b
        )
        {
            int                                         ret;

            Debug.Assert(a != null);
            Debug.Assert(b != null);

            if (a.StartDate == b.StartDate)
            {
                ret = 0;
            }
            else if (a.StartDate < b.StartDate)
            {
                ret = -1;
            }
            else
            {
                ret = 1;
            }

            return ret;
        }
        #endregion 
    
        #region ITimelineToolboxTarget Members

        void ITimelineToolboxTarget.FindMinDate(
        )
        {
            this.CurrentDateTime = this.MinDateTime;
        }

        void ITimelineToolboxTarget.FindMaxDate(
        )
        {
            this.CurrentDateTime = this.MaxDateTime;
        }

        void ITimelineToolboxTarget.FindDate(
            DateTime                                    date
        )
        {
            this.CurrentDateTime = date;
        }

        void ITimelineToolboxTarget.MoveLeft(
        )
        {
            try
            {
                this.CurrentDateTime -= m_mainBand.Calculator.ColumnTimeWidth;
            }
            catch (ArgumentOutOfRangeException)
            {
                this.CurrentDateTime = this.MinDateTime;
            }
        }

        void ITimelineToolboxTarget.MoveRight(
        )
        {
            try
            {
                this.CurrentDateTime += m_mainBand.Calculator.ColumnTimeWidth;
            }
            catch (ArgumentOutOfRangeException)
            {
                this.CurrentDateTime = this.MaxDateTime;
            }
        }

        void ITimelineToolboxTarget.ZoomIn(
        )
        {
            this.Zoom(true);
        }

        void ITimelineToolboxTarget.ZoomOut(
        )
        {
            this.Zoom(false);
        }

        #endregion

        private void OnSelectionChanged(
            object                                      sender, 
            EventArgs                                   e
        )
        {
            m_selection.Clear();
            if (MainBand != null)
            {
                MainBand.Selection.ToList().ForEach((ev) => m_selection.Add(ev.Event));
            }

            PropertyChanged(this,new PropertyChangedEventArgs("SelectedTimelineEvents"));
            if (SelectionChanged != null)
            {
                SelectionChanged(this, EventArgs.Empty);
            }
        }

        internal void FireEventCreated(
            FrameworkElement                            element,
            TimelineDisplayEvent                        de
        )
        {
            if (OnEventCreated != null)
            {
                OnEventCreated(element, de);
            }
        }

        internal void FireEventDeleted(
            FrameworkElement                            element,
            TimelineDisplayEvent                        de
        )
        {
            if (OnEventDeleted != null)
            {
                OnEventDeleted(element, de);
            }
        }

        internal void FireOnEventVisible(
            FrameworkElement                            element,
            TimelineDisplayEvent                        de
        )
        {
            if (OnEventVisible != null)
            {
                OnEventVisible(element, de);
            }
        }

        internal void FireScrollViewChanged(
            double                                      height
        )
        {
            if (ScrollViewChanged != null)
            {
                ScrollViewChanged(this, height);
            }
        }

        internal void FireTimelineDoubleClick(
            DateTime                                    date,
            Point                                       point
        )
        {
            if (TimelineDoubleClick != null)
            {
                TimelineDoubleClick(date, point);
            }
        }

    
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler  PropertyChanged = delegate {};

        #endregion
    }
}
