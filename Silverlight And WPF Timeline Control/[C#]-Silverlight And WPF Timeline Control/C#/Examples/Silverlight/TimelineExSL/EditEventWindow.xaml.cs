using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using TimelineLibrary;
using System.ComponentModel;
using TimelineExLib;

namespace TimelineEx
{
    public partial class EditEventWindow : ChildWindow, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler        PropertyChanged;

        public EditEventWindow()
        {
            InitializeComponent();
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

        protected override void OnOpened(
        )
        {
            base.OnOpened();

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

            this.DialogResult = true;
        }

        private void DeleteClick(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            Tray.TimelineEvents.Remove(Event);
            Tray.RefreshEvents();
            this.DialogResult = true;
        }


        private void CancelClick(
            object                                      sender, 
            RoutedEventArgs                             e
        )
        {
            this.DialogResult = false;
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
        }
    }
}

