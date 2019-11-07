using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

using TimelineLibrary;

namespace WPFTimelineToggleBands
{
	public partial class Window1
	{
		private TimelineTray _timeline;

		public Window1()
		{
			InitializeComponent();
			ResetTimeBands(this, new RoutedEventArgs());
		}

		private void ResetTimeBands(object sender, RoutedEventArgs e)
		{

			var timeline = new TimelineTray
											{
												CalendarType = "gregorian",
												HorizontalAlignment = HorizontalAlignment.Stretch
											};
			_timeline = timeline;
			Grid.SetRow(timeline, 2);
			//timeline.SetBinding(TimelineTray.MinDateTimeProperty, new Binding { ElementName = "MinTime", Path = new PropertyPath("Text"), Converter = new StringDateTimeValueConverter() });
			//timeline.SetBinding(TimelineTray.MaxDateTimeProperty, new Binding { ElementName = "MaxTime", Path = new PropertyPath("Text"), Converter = new StringDateTimeValueConverter() });
			DateTime min;
			var minOk = DateTime.TryParse(MinTime.Text, out min);
			DateTime max;
			var maxOk = DateTime.TryParse(MaxTime.Text, out max);
            DateTime cur;
            var curOk = DateTime.TryParse(CurrentDate.Text, out cur);

			if (minOk && maxOk && max > min && curOk)
			{
				timeline.MinDateTime = min;
				timeline.MaxDateTime = max;
                timeline.CurrentDateTime = cur;
			}

			bool main = true;
			int bandNr = 0;

			var toolBox = new TimelineToolbox();
			toolBox.Style = GetApplicationStyle("TimelineToolboxStyle");
			//_timeline.AddTimelineToolbox();
			//toolBox.Height = 30;
			Grid.SetRow(toolBox, bandNr++);
			timeline.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
			timeline.Children.Add(toolBox);


			if (milliseconds.IsChecked.Value) SetupBand("milliseconds", ref main, ref bandNr);
			if (milliseconds10.IsChecked.Value) SetupBand("milliseconds10", ref main, ref bandNr);
			if (milliseconds100.IsChecked.Value) SetupBand("milliseconds100", ref main, ref bandNr);
			if (seconds.IsChecked.Value) SetupBand("seconds", ref main, ref bandNr);
			if (minutes.IsChecked.Value) SetupBand("minutes", ref main, ref bandNr);
            if (minutes10.IsChecked.Value) SetupBand("minutes10", ref main, ref bandNr);
			if (hours.IsChecked.Value) SetupBand("hours", ref main, ref bandNr);
			if (days.IsChecked.Value) SetupBand("days", ref main, ref bandNr);
			if (months.IsChecked.Value) SetupBand("months", ref main, ref bandNr);
			if (years.IsChecked.Value) SetupBand("years", ref main, ref bandNr);
			if (decades.IsChecked.Value) SetupBand("decades", ref main, ref bandNr);


			if (_grdTimeLine.Children.Count > 1)
			{
				_grdTimeLine.Children.RemoveAt(_grdTimeLine.Children.Count - 1);
			}
			//timeline.TimelineReady += (x, y) => timeline.ResetEvents(Properties.Resources.Monet);
			timeline.Loaded += (x, y) => timeline.ResetEvents(Properties.Resources.Monet);

			_grdTimeLine.Children.Add(timeline);
		}


		private void SetupBand(string itemSourceType, ref bool main, ref int bandNr)
		{
			var band = CreateBand();
			band.IsMainBand = main;
			main = false;
			band.ItemSourceType = itemSourceType;
			Grid.SetRow(band, bandNr++);
			if (band.IsMainBand)
			{
				_timeline.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
				band.Style = (Style)FindResource("TimelineTemplateMainBand");
				band.DefaultEventTemplate = (DataTemplate)FindResource("TimelineEventStyle");
				band.DefaultItemTemplate = (DataTemplate)FindResource("ColumnTemplateStyle");
			}
			else
			{
				_timeline.RowDefinitions.Add(new RowDefinition { Height = new GridLength(30) });
				band.Style = (Style)FindResource("TimelineTemplateSecondaryBand");
				band.ShortEventTemplate = (DataTemplate)FindResource("ShortEventTemplateStyle");
				band.DefaultItemTemplate = (DataTemplate)FindResource("SecondaryColumnStyle");
			}
			_timeline.Children.Add(band);
		}

		private Style GetApplicationStyle(string styleName)
		{
			Style myStyle;

			try
			{
				myStyle = Resources[styleName] as Style;
			}
			catch (Exception)
			{
				return null;
			}
			return myStyle;
		}

		private static TimelineBand CreateBand()
		{
			return new TimelineBand
			{
				IsMainBand = true,
				HorizontalAlignment = HorizontalAlignment.Stretch,
				TimelineWindowSize = 20,
				MaxEventHeight = 100
			};
		}

		private void DateRangeChanged(object sender, TextChangedEventArgs e)
		{
			if (MinTime == null || MaxTime == null || _timeline == null) return;
			DateTime min;
			var minOk = DateTime.TryParse(MinTime.Text, out min);
			DateTime max;
			var maxOk = DateTime.TryParse(MaxTime.Text, out max);
			DateTime cur;
			var curOk = DateTime.TryParse(CurrentDate.Text, out cur);
			if (minOk && maxOk && max > min)
			{
				//_timeline.MinDateTime = min;
				//_timeline.MaxDateTime = max;
				ResetTimeBands(this, new RoutedEventArgs());
			}
		}
		private void CurrentDateChanged(object sender, TextChangedEventArgs e)
		{
			if (MinTime == null || MaxTime == null || _timeline == null) return;
			DateTime min;
			var minOk = DateTime.TryParse(MinTime.Text, out min);
			DateTime max;
			var maxOk = DateTime.TryParse(MaxTime.Text, out max);
			DateTime cur;
			var curOk = DateTime.TryParse(CurrentDate.Text, out cur);
			if (minOk && maxOk && max > min && curOk && cur >= min && cur <= max)
			{
				//_timeline.MinDateTime = min;
				//_timeline.MaxDateTime = max;
				//ResetTimeBands(this, new RoutedEventArgs());
				_timeline.CurrentDateTime = cur;
			}
		}

	}
}
