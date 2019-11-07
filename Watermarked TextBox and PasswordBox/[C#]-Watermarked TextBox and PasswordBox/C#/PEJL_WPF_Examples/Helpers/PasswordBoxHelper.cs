using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace PEJL_WPF_Examples
{
    public class PasswordBoxHelper
    {
        static bool isInistialised = false;

        public static string GetWatermark(DependencyObject obj)
        {
            return (string)obj.GetValue(WatermarkProperty);
        }

        public static void SetWatermark(DependencyObject obj, string value)
        {
            obj.SetValue(WatermarkProperty, value);
        }

        public static readonly DependencyProperty WatermarkProperty =
            DependencyProperty.RegisterAttached("Watermark", typeof(string), typeof(PasswordBoxHelper), new UIPropertyMetadata(null, WatermarkChanged));



        public static bool GetShowWatermark(DependencyObject obj)
        {
            return (bool)obj.GetValue(ShowWatermarkProperty);
        }

        public static void SetShowWatermark(DependencyObject obj, bool value)
        {
            obj.SetValue(ShowWatermarkProperty, value);
        }

        public static readonly DependencyProperty ShowWatermarkProperty =
            DependencyProperty.RegisterAttached("ShowWatermark", typeof(bool), typeof(PasswordBoxHelper), new UIPropertyMetadata(false));



        static void WatermarkChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            var pwd = obj as PasswordBox;

            CheckShowWatermark(pwd);

            if (!isInistialised)
            {
                pwd.PasswordChanged += new RoutedEventHandler(pwd_PasswordChanged);
                pwd.Unloaded += new RoutedEventHandler(pwd_Unloaded);
                isInistialised = true;
            }
        }

        private static void CheckShowWatermark(PasswordBox pwd)
        {
            pwd.SetValue(PasswordBoxHelper.ShowWatermarkProperty, pwd.Password == string.Empty);
        }

        static void pwd_PasswordChanged(object sender, RoutedEventArgs e)
        {
            var pwd = sender as PasswordBox;
            CheckShowWatermark(pwd);
        }

        static void pwd_Unloaded(object sender, RoutedEventArgs e)
        {
            var pwd = sender as PasswordBox;
            pwd.PasswordChanged -= new RoutedEventHandler(pwd_PasswordChanged);
        }

    }
}
