namespace TransitionTest
{
    using System.Windows.Data;

    class Negative : IValueConverter
    {
        /// <summary>
        /// インスタンスの取得
        /// </summary>
        public static Negative Instance
        {
            get { return new Negative(); }
        }

        #region IValueConverter のメンバ
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            if (value is double)
                return -1.0 * (double)value;

            else
                throw new System.ArgumentException();
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.Exception("The method or operation is not implemented.");
        }
        #endregion
    }
}
