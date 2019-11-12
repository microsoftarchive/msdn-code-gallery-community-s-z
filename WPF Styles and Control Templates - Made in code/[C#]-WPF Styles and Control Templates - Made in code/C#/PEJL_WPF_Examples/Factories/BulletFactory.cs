using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace PEJL_WPF_Examples.Factories
{
    class BulletFactory
    {
        public static UIElement MakeBulletChrome(object obj)
        {
            var bchrome = new Microsoft.Windows.Themes.BulletChrome();
            bchrome.SetBinding(Microsoft.Windows.Themes.BulletChrome.BorderBrushProperty, new Binding("TemplatedParent.BorderBrush") { Source = obj });
            bchrome.SetBinding(Microsoft.Windows.Themes.BulletChrome.BackgroundProperty, new Binding("TemplatedParent.Background") { Source = obj });
            bchrome.SetBinding(Microsoft.Windows.Themes.BulletChrome.RenderMouseOverProperty, new Binding("TemplatedParent.IsMouseOver") { Source = obj });
            bchrome.SetBinding(Microsoft.Windows.Themes.BulletChrome.RenderPressedProperty, new Binding("TemplatedParent.IsPressed") { Source = obj });
            bchrome.SetBinding(Microsoft.Windows.Themes.BulletChrome.IsCheckedProperty, new Binding("TemplatedParent.IsChecked") { Source = obj });
            return bchrome;
        }

        public static UIElement MakeBulletImage(object obj, string path)
        {
            var grid = new Grid();

            var border = new Border { BorderThickness = new Thickness(1), MinHeight=12, MinWidth=12 };
            BindingOperations.SetBinding(border, Border.BorderBrushProperty, new Binding("TemplatedParent.BorderBrush") { Source = obj });
            BindingOperations.SetBinding(border, Border.BackgroundProperty, new Binding("TemplatedParent.Background") { Source = obj });

            var bImage = new Image { Height=20, Width=20, Margin=new Thickness(-8), Source = new BitmapImage(new Uri(path, UriKind.RelativeOrAbsolute)), Opacity=0.8 }; 
            BindingOperations.SetBinding(bImage, Control.VisibilityProperty, new Binding("TemplatedParent.IsChecked") { Source = obj, Converter=new BooleanToVisibilityConverter() });

            grid.Children.Add(border);
            grid.Children.Add(bImage);
            return grid;
        }
    }
}
