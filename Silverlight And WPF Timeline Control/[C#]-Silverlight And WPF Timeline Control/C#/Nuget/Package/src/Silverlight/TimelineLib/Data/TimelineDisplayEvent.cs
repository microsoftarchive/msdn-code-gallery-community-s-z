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
using System.Reflection;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Controls;
using System.Windows;

namespace TimelineLibrary
{
    /// 
    /// <summary>
    /// we need this so that every timeline band can have it's own instance and 
    /// therefore different brush and event top coordinates and width</summary>
    /// 
    public class TimelineDisplayEvent: ContentControl, INotifyPropertyChanged
    {
        public static string                            MoreLinkText;
        public static int                               TeaserSize;
    	public static string                            SelectedEventImageUrl;

        private Brush                                   m_rectBrush;
        private TimelineEvent                           m_timelineEvent;
        private bool                                    m_selected;
        
        public event PropertyChangedEventHandler        PropertyChanged;
        private double                                  m_eventDescriptionWidth;
        private double                                  m_eventDescriptionHeight;

        private double                                  m_eventTop = -1;
        private double                                  m_eventPixWidth = -1;
        private string                                  m_teaser;
    	private object                                  m_visualInfo;

        public TimelineDisplayEvent(
            TimelineEvent                               e,
            TimelineTray                                tray,
            TimelineBuilder                             builder
            )
        {
            if (e.Link == null)
            {
                e.Link = String.Empty;
            }

            if (e.Description == null)
            {
                e.Description = String.Empty;
            }

            m_timelineEvent = e;
        	m_selected = e.Selected;
            m_timelineEvent.PropertyChanged += OnEventPropertyChanged;

            if (e.HeightOverride == -1.0)
            {
                m_eventDescriptionHeight = tray.MainBand.MaxEventHeight;
            }
            else
            {
                m_eventDescriptionHeight = e.HeightOverride;
            }

            if (e.WidthOverride == -1.0)
            {
                m_eventDescriptionWidth = tray.DescriptionWidth;
            }
            else
            {
                m_eventDescriptionWidth = e.WidthOverride;
            }

            if (e.TopOverride != -1)
            {
                SetCalculatedTop(e.TopOverride);
            }

            TimelineBuilder = builder;
            TimelineTray = tray;

            UpdateDisplayEvent();
        }

        public string Id
        {
            get
            {
                return m_timelineEvent.Id;
            }
        }
       
        public string EventTime
        {
            get
            {
                string                                  res;

                if (Event.IsDuration)
                {
                    if (Event.StartDate.ToShortDateString() == Event.EndDate.ToShortDateString())
                    {
                        res = Event.StartDate.ToShortDateString() + " " +
                              Event.StartDate.ToShortTimeString() + ".." +
                              Event.EndDate.ToShortTimeString();
                    }
                    else
                    {
                        res = Event.StartDate.ToShortDateString() + " " +
                              Event.StartDate.ToShortTimeString() + ".." +
                              Event.EndDate.ToShortDateString() + " " +
                              Event.EndDate.ToShortTimeString();

                    }

                }
                else
                {
                    res = Event.StartDate.ToShortDateString() + " " +
                              Event.StartDate.ToShortTimeString();
                }

                return res;
            }
        }

        public TimelineTray TimelineTray
        {
            get;
            set;
        }

        public TimelineBuilder TimelineBuilder
        {
            get;
            set;
        }

        /// 
        /// <summary>
        /// Default width of description for main timeline band events</summary>
        /// 
        public double DescriptionWidth
        {
            get
            {
                return m_eventDescriptionWidth;
            }

            set
            {
                m_eventDescriptionWidth = value;
                m_timelineEvent.WidthOverride = value;
                FirePropertyChanged("DescriptionWidth");
            }
        }

        /// 
        /// <summary>
        /// Default height of description for main timeline band events</summary>
        /// 
        public double DescriptionHeight
        {
            get
            {
                return m_eventDescriptionHeight;
            }

            set
            {
                m_eventDescriptionHeight = value;
                m_timelineEvent.HeightOverride = value;
                FirePropertyChanged("DescriptionHeight");
            }
        }

        public TimelineEvent Event
        {
            get
            {
                return m_timelineEvent;
            }
        }

        public Brush EventColorBrush
        {
            get
            {
                Type                                    colorType;
                object                                  o;

                if (m_rectBrush == null)
                {
                    m_rectBrush = new SolidColorBrush(Colors.Gray);

                    if (!String.IsNullOrEmpty(Event.EventColor))
                    {
                        colorType = typeof(System.Windows.Media.Colors); 

                        if (colorType.GetProperty(Event.EventColor) != null)
                        {
                            o = colorType.InvokeMember(Event.EventColor, BindingFlags.GetProperty, null, null, null);
                            if (o != null)
                            {
                                m_rectBrush = new SolidColorBrush((Color) o);
                            }
                        }
                    }
                }

                return m_rectBrush;
            }
            set
            {
                m_rectBrush = value;
            }
        }

        public string Teaser
        {
            get
            {
                return m_teaser;
            }
            set
            {
                m_teaser = value;
                FirePropertyChanged("Teaser");
            }
        }

        public System.Windows.Visibility MoreLinkVisibility
        {
            get
            {
                return String.IsNullOrEmpty(LinkText) ?
                    System.Windows.Visibility.Collapsed: System.Windows.Visibility.Visible;
            }
        }

        public System.Windows.Visibility LinkVisibility
        {
            get
            {
                return String.IsNullOrEmpty(Event.Link) ?
                    System.Windows.Visibility.Collapsed: System.Windows.Visibility.Visible;
            }
        }

        public string LinkText
        {
            get;
            set;
        }

        public double Top
        {
            get
            {
                return m_eventTop;
            }
            set
            {
                m_eventTop = value;

                if (!TimelineBuilder.LockTopOverrideUpdate)
                {
                    m_timelineEvent.TopOverride = m_eventTop;
                }
                FirePropertyChanged("Top");
            }
        }

        public double TopWithoutOffset
        {
            get;
            set;
        }

        public void SetCalculatedTop(double value)
        {
            m_eventTop = value;
            TopWithoutOffset = value;
            FirePropertyChanged("Top");
        }

        public double EventPixelWidth
        {
            get
            {
                return m_eventPixWidth;
            }
            set
            {
                m_eventPixWidth = value;

                ActualEventPixelWidth = TimelineBuilder.TimeSpanToPixels(Event.EndDate - Event.StartDate); 
                ActualEventPixelWidth = Math.Max(3.0, ActualEventPixelWidth);

                FirePropertyChanged("EventPixelWidth");
                FirePropertyChanged("ActualEventPixelWidth");
            }
        }

        public double ActualEventPixelWidth
        {
            get;
            set;
        }

        public Thickness SelectionBorder
        {
            get
            {
                return Selected ? new Thickness(3) : new Thickness(1);
            }
        }

        public Visibility BorderVisibility
        {
            get
            {
                return (String.IsNullOrEmpty(this.Event.Title) && 
                        String.IsNullOrEmpty(this.Event.Description) ? Visibility.Collapsed : Visibility.Visible);

            }
        }

        public bool Selected
        {
            get
            {
                return m_selected;
            }
            set
            {
                m_selected = value;
            	m_timelineEvent.Selected = m_selected;
                FirePropertyChanged(String.Empty);
            }
        }

        public bool IsEventMouseOver
        {
            get;
            set;
        }

        public string StartEndDateTime
        {
            get
            {
                string                                  ret;

                if (Event.IsDuration)
                {
                    ret = String.Format("{0}-{1}", Event.StartDate, Event.EndDate);
                }
                else
                {
                    ret = Event.StartDate.ToString();
                }

                return ret;
            }
        }



    	public object VisualInfo
    	{
			get { return m_visualInfo; }
			set { m_visualInfo = value; }
    	}

    	public string FixDescription(
            string                                      d
            )
        {
            return d.Replace('\n', ' ').Replace('\r', ' ').Replace("  ", " ").Trim();
        }

        private void OnEventPropertyChanged(
            object                                      sender, 
            PropertyChangedEventArgs                    e
            )
        {
            if (e.PropertyName.Length == 0)
            {
                FirePropertyChanged(String.Empty);
            }
            else if (e.PropertyName == "EventColor")
            {
                FirePropertyChanged("EventColorBrush");
            }
            else if (e.PropertyName == "Description")
            {
                UpdateDisplayEvent();
            }
            else if (e.PropertyName == "StartDate" || e.PropertyName == "EndDate")
            {
                FirePropertyChanged("EventTime");
                //FirePropertyChanged("");
            }
            else if (e.PropertyName == "Link")
            {
                UpdateDisplayEvent();
            }
        }

        private void UpdateDisplayEvent(
            )
        {
            if (TeaserSize > 0 && Event.Description.Length > TeaserSize)
            {
                Teaser = Event.Description.Substring(0, TeaserSize) + "...";
                LinkText = MoreLinkText;
            }
            else
            {
                Teaser = Event.Description;
                if (Event.Link.Length == 0)
                {
                    LinkText = String.Empty;
                }
                else
                {
                    LinkText = MoreLinkText;
                }
            }
        }

        private void FirePropertyChanged(
            string                                      name
            )
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}