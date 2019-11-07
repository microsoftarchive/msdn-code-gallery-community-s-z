using System.Windows;
using System.Windows.Controls.Primitives;
using PEJL_WPF_Examples.Factories;
using System.Windows.Data;
using System;
using System.Windows.Media.Imaging;

namespace PEJL_WPF_Examples.Helpers
{
    class BulletDecoratorByCode : BulletDecorator
    {
        public object ActualBullet
        {
            get { return (object)GetValue(ActualBulletProperty); }
            set { SetValue(ActualBulletProperty, value); }
        }

        public static readonly DependencyProperty ActualBulletProperty =
            DependencyProperty.Register("ActualBullet", typeof(object), typeof(BulletDecoratorByCode), new UIPropertyMetadata(null, ActualBulletChanged));

        static void ActualBulletChanged(object obj, DependencyPropertyChangedEventArgs e)
        {
            var bdec = obj as BulletDecoratorByCode;

            if ((string)e.NewValue == "Microsoft.Windows.Themes.BulletChrome")
                bdec.Bullet = BulletFactory.MakeBulletChrome(obj);
            else
                bdec.Bullet = BulletFactory.MakeBulletImage(obj, (string)e.NewValue);
        }

        
    }

    public class ImageConverter : IValueConverter
    {
        public object Convert(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return new BitmapImage(new Uri((string)value, UriKind.RelativeOrAbsolute));
        }

        public object ConvertBack(object value, System.Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new System.NotImplementedException();
        }
    }

}
