using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SkypeIntegration.Model;

namespace SkypeIntegration.Converters
{
    public class NameConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value != null)
            {
                var friend = value as Friend;

                if (!string.IsNullOrEmpty(friend.DisplayName))
                    return friend.DisplayName;
                else if (!string.IsNullOrEmpty(friend.FullName))
                    return friend.FullName;
                else
                    return friend.Handle;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
