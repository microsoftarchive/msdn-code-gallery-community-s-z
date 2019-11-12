namespace WPFGroupingSample
{
    using System;
    using System.Windows;
    using System.Windows.Data;

    /// <summary>
    /// 整数から1の位を省いた値に変換します。
    /// </summary>
    public class AgeToGenerationConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            int? age = value as int?;
            if (!age.HasValue)
            {
                return DependencyProperty.UnsetValue;
            }

            return age.Value / 10;
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
