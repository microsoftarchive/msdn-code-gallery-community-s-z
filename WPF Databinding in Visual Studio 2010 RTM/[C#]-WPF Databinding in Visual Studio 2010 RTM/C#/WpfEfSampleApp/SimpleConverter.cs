using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Data;

namespace WpfEfSampleApp
{
    class SimpleConverter : IValueConverter
    {
        public object Convert(  object value,
                                System.Type targetType,
                                object parameter,
                                System.Globalization.CultureInfo culture)
        {
            if (parameter != null)
                return String.Format(culture, parameter.ToString(), value);

            return value;
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if ((targetType == typeof(DateTime)) || (targetType == typeof(Nullable<DateTime>)))
            {
                return System.Convert.ToDateTime(value);
            }

            else if ((targetType == typeof(int)) || (targetType == typeof(Nullable<int>)))
            {
                return System.Convert.ToInt32(value);
            }

            else if ((targetType == typeof(Decimal)) || (targetType == typeof(Nullable<Decimal>)))
            {
                return System.Convert.ToDecimal(value);
            }

            return value;
        }
    }
}
