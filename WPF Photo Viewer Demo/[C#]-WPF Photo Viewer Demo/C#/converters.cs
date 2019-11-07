using System;
using System.Globalization;
using System.Windows.Data;

namespace SDKSamples.ImageSample
{
    /// <summary>
    /// Converts an exposure time from a decimal (e.g. 0.0125) into a string (e.g. 1/80)
    /// </summary>
    public class ExposureTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)

        {
            try
            {
                decimal exposure = (decimal)value;

                exposure = Decimal.Round(1 / exposure);
                return String.Format("1/{0}", exposure.ToString());
            }
            catch (NullReferenceException)
            {
                return null;
            }
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            string exposure = ((string) value).Substring(2);
            return (1 / Decimal.Parse(exposure));
        }
    }

    /// <summary>
    /// Converts an exposure mode from an enum into a human-readable string (e.g. AperturePriority
    /// becomes "Aperture Priority")
    /// </summary>
    public class ExposureModeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            ExposureMode exposureMode = (ExposureMode)value;

            switch (exposureMode)
            {
                case ExposureMode.AperturePriority:
                    return "Aperture Priority";
                    
                case ExposureMode.HighSpeedMode:
                    return "High Speed Mode";

                case ExposureMode.LandscapeMode:
                    return "Landscape Mode";

                case ExposureMode.LowSpeedMode:
                    return "Low Speed Mode";

                case ExposureMode.Manual:
                    return "Manual";

                case ExposureMode.NormalProgram:
                    return "Normal";

                case ExposureMode.PortraitMode:
                    return "Portrait";

                case ExposureMode.ShutterPriority:
                    return "Shutter Priority";

                default:
                    return "Unknown";
            }
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    /// <summary>
    /// Converts a lens aperture from a decimal into a human-preferred string (e.g. 1.8 becomes F1.8)
    /// </summary>
    public class LensApertureConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return String.Format("F{0:##.0}", value);
            }
            else
            {
                return String.Empty;
            }
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            if (!String.IsNullOrEmpty((string)value))
            {
                return Decimal.Parse(((string)value).Substring(1));
            }
            else
            {
                return null;
            }
        }
    }

    /// <summary>
    /// Converts a focal length from a decimal into a human-preferred string (e.g. 85 becomes 85mm)
    /// </summary>
    public class FocalLengthConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value != null)
            {
                return String.Format("{0}mm", value);
            }
            else
            {
                return String.Empty;
            }
        }

        public object ConvertBack(object value, Type targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }

    /// <summary>
    /// Converts an x,y size pair into a string value (e.g. 1600x1200)
    /// </summary>
    public class PhotoSizeConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if ((values[0] == null) || (values[1] == null))
            {
                return String.Empty;
            }
            else
            {
                return String.Format("{0}x{1}", values[0], values[1]);
            }
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            if ((string) value == String.Empty)
            {
                return new object[2];
            }
            else
            {
                string[] sSize = new string[2];
                sSize = ((string)value).Split('x');
                
                object[] size = new object[2];
                size[0] = UInt32.Parse(sSize[0]);
                size[1] = UInt32.Parse(sSize[1]);
                return size;
            }
        }
    }
}
