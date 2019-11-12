using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SkypeIntegration.Converters
{
    public class ProfileImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
           var fileInfo = new FileInfo(value.ToString());
           if (fileInfo.Length < 5)
               return new Uri(Directory.GetCurrentDirectory() + "\\Images\\NoAvatar.png");
           else
               return new Uri(value.ToString());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
