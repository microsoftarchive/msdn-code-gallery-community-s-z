using System;
using System.Windows.Data;
using System.Windows.Media;
using System.Windows;
using System.Diagnostics;

namespace Tasks.Show.Helpers
{
    public class BrushToAlphaBrushConverter : IValueConverter
    {
		#region Properties 

        private byte Alpha
        {
            get
            {
                return (byte)(255.0 * this.Opacity);
            }
        }

        public double Opacity { get; set; }

		#endregion Properties 

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            SolidColorBrush brush = value as SolidColorBrush;
            if (value != null)
            {
                SolidColorBrush alphaBrush = new SolidColorBrush(Color.FromArgb(this.Alpha, brush.Color.R, brush.Color.G, brush.Color.B));
                return alphaBrush;
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // not implemented
            return null;
        }

        #endregion
    }

    public class BoolToDoubleConverter : IValueConverter
    {
		#region Fields 

        private double _FalseValue = 0.5;
        private double _TrueValue = 1.0;

		#endregion Fields 

		#region Properties 

        public double FalseValue
        {
            get { return _FalseValue; }
            set { _FalseValue = value; }
        }

        public double TrueValue
        {
            get { return _TrueValue; }
            set { _TrueValue = value; }
        }

		#endregion Properties 

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value) return TrueValue; else return FalseValue;
            }
            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            // not implemented
            return null;
        }

        #endregion
    }

    public class ReverseBooleanToVisibilityConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is bool)
            {
                if ((bool)value)
                {
                    return Visibility.Collapsed;
                }
                else
                {
                    return Visibility.Visible;
                }
            }
            return Visibility.Visible;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }

    public class DateTimeToStringConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string format = parameter.ToString();
            
            if (value is DateTime)
            {
                // there is no support for a single letter representation of the day of the 
                // week so we invent our own
                if (format.EasyEquals("w"))
                {
                    return ((DateTime)value).ToString("ddd").Substring(0, 1);
                }
                else return ((DateTime)value).ToString(format);
            }

            return null;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }

    public class DebugConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            Debug.WriteLine(string.Format("TargetType: {0} / Value: {1}", targetType, value));
            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return value;
        }

        #endregion
    }

    public class ColorToBrushConverterWithFallback : IValueConverter
    {
		#region Properties 

        public Brush FallbackBrush { get; set; }

		#endregion Properties 

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Color && ((Color)value).A > 0)
            {
                return new SolidColorBrush((Color)value);
            }
            return FallbackBrush;
        }

        public object  ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }

    public class ColorToColorConverterWithFallback : IValueConverter
    {
        #region Properties

        public Color FallbackColor { get; set; }

        #endregion Properties

        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is Color && ((Color)value).A > 0)
            {
                return (Color)value;
            }
            return FallbackColor;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return null;
        }

        #endregion
    }

    public class FallbackWhenNullConverter : IValueConverter
    {
        #region IValueConverter Members

        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            string fallback = parameter.ToString();

            if (string.IsNullOrEmpty(value.ToString()))
            {
                return fallback;
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        #endregion
    }

}
