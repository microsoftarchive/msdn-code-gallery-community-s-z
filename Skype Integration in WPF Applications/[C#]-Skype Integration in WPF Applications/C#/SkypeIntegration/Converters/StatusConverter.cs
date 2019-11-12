using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SKYPE4COMLib;
namespace SkypeIntegration.Converters
{
    public class StatusConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is TOnlineStatus)
            {
                var status = (TOnlineStatus)value;
                switch (status)
                {
                    case TOnlineStatus.olsAway:
                        return new Uri(Directory.GetCurrentDirectory() + "\\Images\\Away.png");
                    case TOnlineStatus.olsDoNotDisturb:
                        return new Uri(Directory.GetCurrentDirectory() + "\\Images\\DoNotDisturb.png");
                    case TOnlineStatus.olsOnline:
                        return new Uri(Directory.GetCurrentDirectory() + "\\Images\\Online.png");
                    default:
                        return new Uri(Directory.GetCurrentDirectory() + "\\Images\\Offline.png");
                }
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
