using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Tasks.Show.UserControls
{
    public partial class TimeSpanDropDown : UserControl
    {
        #region Fields

        private TimeSpan? _openDuration;

        #endregion Fields

        #region Constructors

        public TimeSpanDropDown()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;

            var timeSpans = new List<LabeledTimeSpan>();
            timeSpans.Add(new LabeledTimeSpan("No Estimate", null));
            timeSpans.Add(new LabeledTimeSpan("5 Minutes or Less", TimeSpan.FromMinutes(5)));
            timeSpans.Add(new LabeledTimeSpan("15 Minutes", TimeSpan.FromMinutes(15)));
            timeSpans.Add(new LabeledTimeSpan("30 Minutes", TimeSpan.FromMinutes(30)));
            timeSpans.Add(new LabeledTimeSpan("One Hour", TimeSpan.FromHours(1)));
            timeSpans.Add(new LabeledTimeSpan("Two Hours", TimeSpan.FromHours(2)));
            timeSpans.Add(new LabeledTimeSpan("Three Hours", TimeSpan.FromHours(3)));
            timeSpans.Add(new LabeledTimeSpan("Half Day", TimeSpan.FromHours(4)));
            timeSpans.Add(new LabeledTimeSpan("Full Day or More", TimeSpan.FromHours(8)));
            TimesList.ItemsSource = timeSpans.ToArray();

            this.PreviewKeyDown += UserControl_KeyDown;
        }

        #endregion Constructors

        #region Event Handlers

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LabeledTimeSpan d = (sender as Button).DataContext as LabeledTimeSpan;
            this.Duration = d.Duration;
            Close();
        }

        private void Popup_Opened(object sender, EventArgs e)
        {
            _openDuration = this.Duration;
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Popup.IsOpen)
            {
                if (e.Key == Key.Enter || e.Key == Key.Return)
                {
                    Close();
                }
                else if (e.Key == Key.Escape)
                {
                    if (_openDuration != null)
                    {
                        this.Duration = _openDuration;
                    }
                    Close();
                }
            }
        }

        #endregion Event Handlers

        #region Private Methods

        private void Close()
        {
            this.Popup.IsOpen = false;
        }

        #endregion Private Methods

        #region Duration

        public static readonly DependencyProperty DurationProperty =
            DependencyProperty.Register("Duration", typeof(TimeSpan?), typeof(TimeSpanDropDown),
                new FrameworkPropertyMetadata((TimeSpan?)null));

        public TimeSpan? Duration
        {
            get { return (TimeSpan?)GetValue(DurationProperty); }
            set { SetValue(DurationProperty, value); }
        }

        #endregion

        private class LabeledTimeSpan
        {
            #region Constructors

            public LabeledTimeSpan(string label, TimeSpan? duration) { Label = label; Duration = duration; }

            #endregion Constructors

            #region Properties

            public TimeSpan? Duration { get; set; }

            public string Label { get; set; }

            #endregion Properties
        }
    }

}
