using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using SKYPE4COMLib;

namespace SkypeIntegration.Converters
{
    public class GenderConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var gender = (TUserSex)value;
            switch (gender)
            {
                case TUserSex.usexMale: return "Male";
                case TUserSex.usexFemale: return "Female";
                default: return "Unknown";
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
