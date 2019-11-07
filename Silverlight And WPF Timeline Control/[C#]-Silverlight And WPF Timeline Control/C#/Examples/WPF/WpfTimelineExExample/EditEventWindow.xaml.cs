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
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.ComponentModel;
using TimelineEx;
using TimelineLibrary;

namespace WpfTimelineExExample
{
    /// <summary>
    /// Interaction logic for EditEventWindow.xaml
    /// </summary>
    public partial class EditEventWindow : Window
    {
        public event PropertyChangedEventHandler        PropertyChanged;

        public EditEventWindow()
        {
            InitializeComponent();

            this.Activated += OnOpened;
        }

        public TimelineEventEx Event
        {
            get;
            set;
        }

        public TimelineEventEx EditEvent
        {
            get;
            set;
        }

        public bool AddNew
        {
            get;
            set;
        }

        public TimelineTray Tray
        {
            get;
            set;
        }

        public void FirePropertyChanged(
            string                                      name
        )
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }

        public void OnOpened(
            object                                      sender, 
            EventArgs                                   e
        )
        {
            if (AddNew)
            {
                if (EditEvent == null)
                {
                    EditEvent = new TimelineEventEx();

                    EditEvent.Title = String.Empty;
                    EditEvent.Description = String.Empty;
                    EditEvent.IsDuration = false;
                    EditEvent.StartDate = DateTime.Now;
                    EditEvent.EndDate = DateTime.Now;
                    EditEvent.EventImage = String.Empty;
                    EditEvent.TeaserEventImage = string.Empty;
                    EditEvent.Video = String.Empty;
                    EditEvent.Row = 0;
                }
            }
            else
            {
                EditEvent = new TimelineEventEx();
                CopyEvent(Event, EditEvent);
            }
            this.DataContext = this;
        }

        private void CopyEvent(
            TimelineEventEx                             src,
            TimelineEventEx                             dest
        )
        {
            dest.Title = src.Title;
            dest.Description = src.Description;
            dest.IsDuration = src.IsDuration;
            dest.StartDate = src.StartDate;
            dest.EndDate = src.EndDate;
            dest.EventImage = src.EventImage;
            dest.TeaserEventImage = src.TeaserEventImage;
            dest.Video = src.Video;
        }

        private void SaveClick(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            if (!AddNew)
            {
                CopyEvent(EditEvent, Event);
            }
            else
            {
                Event = EditEvent;
                Tray.TimelineEvents.Add(Event);
            }
            
            if (!Event.IsDuration)
            {
                Event.EndDate = Event.StartDate; 
            }

            Tray.RefreshEvents();
            this.Close();
        }

        private void DeleteClick(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            Tray.TimelineEvents.Remove(Event);
            Tray.RefreshEvents();
            this.Close();
        }


        private void CancelClick(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            this.Close();
        }

        public DateTime StartTime
        {
            get
            {
                if (EditEvent.StartDate != null)
                {
                    return DateTime.Parse(EditEvent.StartDate.TimeOfDay.ToString());
                }

                return default(DateTime);
            }
            set
            {
                EditEvent.StartDate = new DateTime(
                    EditEvent.StartDate.Year, EditEvent.StartDate.Month, EditEvent.StartDate.Day, 
                    value.Hour, value.Minute, value.Second);

                FirePropertyChanged("StartTime");
            }
        }

        public DateTime StartDate
        {
            get 
            { 
                return EditEvent.StartDate; 
            }
            set
            {
                EditEvent.StartDate = value;
                FirePropertyChanged("StartDate");
            }
        }

        public DateTime EndTime
        {
            get
            {
                if (EditEvent.EndDate != null)
                {
                    return DateTime.Parse(EditEvent.EndDate.TimeOfDay.ToString());
                }

                return default(DateTime);
            }
            set
            {
                EditEvent.EndDate = new DateTime(
                    EditEvent.EndDate.Year, EditEvent.EndDate.Month, EditEvent.EndDate.Day, 
                    value.Hour, value.Minute, value.Second);

                FirePropertyChanged("EndTime");
            }
        }

        public DateTime EndDate
        {
            get 
            { 
                return EditEvent.EndDate; 
            }
            set
            {
                EditEvent.EndDate = value;
                FirePropertyChanged("EndDate");
            }
        }    }
}
