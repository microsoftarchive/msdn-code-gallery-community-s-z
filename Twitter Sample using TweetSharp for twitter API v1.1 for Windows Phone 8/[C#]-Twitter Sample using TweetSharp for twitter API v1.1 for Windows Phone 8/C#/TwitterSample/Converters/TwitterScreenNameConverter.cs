using System;
using System.Windows.Data;

namespace TwitterSample.Converters
{
    public class TwitterScreenNameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string input = (String)value;
            if (!string.IsNullOrEmpty(input))
            {
                return "@" + input;
            }
            else
            {
                return "";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
