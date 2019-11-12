using System;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Markup;
using System.Windows.Data;
using System.Collections.Generic;

namespace Finance.Silverlight.Common.Converters
{
	public class DoubleToStringConverter : MarkupExtension, IValueConverter
	{
		public static List<DateTime> _datesArray;
		public static List<DateTime> DatesArray
		{
			get
			{
				return _datesArray;
			}
			set
			{
				_datesArray = value;
			}
		}

		public DoubleToStringConverter()
		{
		}

		public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			double indexDouble = System.Convert.ToDouble(value);
			int index = (int)indexDouble;
			string result = string.Empty;

			if (DatesArray != null && index > -1 && index < DatesArray.Count)
			{
				result = DatesArray[index].ToShortDateString();
			}

			return result;
		}

		public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
		{
			return null;
		}

		public override object ProvideValue(IServiceProvider serviceProvider)
		{
			return this;
		}
	}
}
