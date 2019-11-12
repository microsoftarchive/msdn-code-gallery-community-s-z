using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using Tasks.Show.Helpers;
using Tasks.Show.Models;
using Tasks.Show.Utils;

namespace Tasks.Show.UserControls
{
    /// <summary>
    /// Interaction logic for DateDropDown.xaml
    /// </summary>
    public partial class DateDropDown : UserControl
    {
        #region Fields

        private DateTime? _openDate;
        private ObservableCollection<LabeledDateTime> Dates;
        private DateTime lastRefresh = DateTime.MinValue;

        #endregion Fields D:\Projects\Tasks.Show\Code\trunk\BossaNova\Controls\PopupToggle.cs

        #region Constructors

        public DateDropDown()
        {
            InitializeComponent();
            LayoutRoot.DataContext = this;
            Dates = new ObservableCollection<LabeledDateTime>();
            DatesList.ItemsSource = Dates;

            this.PreviewKeyDown += UserControl_KeyDown;
            NewDateTextBox.PreviewKeyUp += UserControl_KeyDown;
        }

        #endregion Constructors

        #region Event Handlers

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            LabeledDateTime d = (sender as Button).DataContext as LabeledDateTime;
            this.Date = d.Date;
            Close();
        }

        private void NewDateTextBox_GotFocus(object sender, RoutedEventArgs e)
        {

        }

        private void NewDateTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            ConfirmImage.Visibility = Visibility.Collapsed;
            QuestionImage.Visibility = Visibility.Collapsed;
        }

        private void NewDateTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(NewDateTextBox.Text))
            {
                ConfirmImage.Visibility = Visibility.Collapsed;
                QuestionImage.Visibility = Visibility.Collapsed;
                return;
            }

            DateTime? d = DateParser.ParseDate(NewDateTextBox.Text);
            if (d != null)
            {
                ConfirmImage.Visibility = Visibility.Visible;
                QuestionImage.Visibility = Visibility.Collapsed;
                this.Date = d;
            }
            else
            {
                ConfirmImage.Visibility = Visibility.Collapsed;
                QuestionImage.Visibility = Visibility.Visible;
                this.Date = _openDate;
            }
        }

        private void Popup_Opened(object sender, EventArgs e)
        {
            // need to refresh the dates on each open to handle day changes
            RefreshDates();

            NewDateTextBox.Focus();
            _openDate = this.Date;

            if (NewDateTextBox.Text != null)
            {
                NewDateTextBox.SelectAll();
            }

            NewDateTextBox.Text = null;
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
                    if (_openDate != null)
                    {
                        this.Date = _openDate;
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

        private void RefreshDates()
        {
            if (lastRefresh.Date != DateTime.Today)
            {
                Dates.Clear();
                Dates.Add(new LabeledDateTime("No Due Date", null));
                Dates.Add(new LabeledDateTime("Today", DateTime.Today));
                Dates.Add(new LabeledDateTime("Tomorrow", DateTime.Today.AddDays(1)));
                Dates.Add(new LabeledDateTime("This Week", DateTime.Today.Next(DayOfWeek.Friday)));
                Dates.Add(new LabeledDateTime("One Week from Today", DateTime.Today.AddDays(7)));
                Dates.Add(new LabeledDateTime("Someday", DateTime.MaxValue.Date));
                lastRefresh = DateTime.Today;
            }
        }

        #endregion Private Methods

        #region Date

        public static readonly DependencyProperty DateProperty =
            DependencyProperty.Register("Date", typeof(DateTime?), typeof(DateDropDown),
                new FrameworkPropertyMetadata((DateTime?)null,
                    new PropertyChangedCallback(OnDateChanged)));


        public DateTime? Date
        {
            get { return (DateTime?)GetValue(DateProperty); }
            set { SetValue(DateProperty, value); }
        }

        private static void OnDateChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DateDropDown)d).OnDateChanged(e);
        }

        protected virtual void OnDateChanged(DependencyPropertyChangedEventArgs e)
        {
            if (this.ShowOverdue)
            {
                DateTime? d = e.NewValue as DateTime?;
                if (d != null)
                {
                    if (d.Value < DateTime.Today)
                    {
                        OverdueIcon.Opacity = 1.0;
                        return;
                    }
                }

                OverdueIcon.Opacity = 0.0;
            }
        }

        #endregion

        #region ShowOverdue

        public static readonly DependencyProperty ShowOverdueProperty =
            DependencyProperty.Register("ShowOverdue", typeof(bool), typeof(DateDropDown),
                new FrameworkPropertyMetadata((bool)false,
                    new PropertyChangedCallback(OnShowOverdueChanged)));

        public bool ShowOverdue
        {
            get { return (bool)GetValue(ShowOverdueProperty); }
            set { SetValue(ShowOverdueProperty, value); }
        }

        private static void OnShowOverdueChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((DateDropDown)d).OnShowOverdueChanged(e);
        }

        protected virtual void OnShowOverdueChanged(DependencyPropertyChangedEventArgs e)
        {
            PrettyDateConverter converter = this.Resources["PrettyDateConverter"] as PrettyDateConverter;
            if (converter != null)
            {
                converter.ShowOverdue = (bool)e.NewValue;
            }

            if (!(bool)e.NewValue)
            {
                OverdueIcon.Visibility = Visibility.Collapsed;
            }
            else
            {
                OverdueIcon.Visibility = Visibility.Visible;
            }
        }

        #endregion

        private class LabeledDateTime
        {
            #region Constructors

            public LabeledDateTime(string label, DateTime? date) { Label = label; Date = date; }

            #endregion Constructors

            #region Properties

            public DateTime? Date { get; set; }

            public string Label { get; set; }

            #endregion Properties
        }
    }
}
