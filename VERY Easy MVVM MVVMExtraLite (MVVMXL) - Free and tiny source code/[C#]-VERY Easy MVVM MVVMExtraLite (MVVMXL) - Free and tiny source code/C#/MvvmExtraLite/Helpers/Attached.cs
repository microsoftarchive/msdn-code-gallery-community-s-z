using System.Windows;

namespace MvvmExtraLite.Helpers
{
    class Attached
    {
        public static bool? GetCloseDialogFlag(DependencyObject obj)
        {
            return (bool?)obj.GetValue(CloseDialogFlagProperty);
        }

        public static void SetCloseDialogFlag(DependencyObject obj, bool? value)
        {
            obj.SetValue(CloseDialogFlagProperty, value);
        }

        public static readonly DependencyProperty CloseDialogFlagProperty =
            DependencyProperty.RegisterAttached("CloseDialogFlag", typeof(bool?), typeof(Attached), new UIPropertyMetadata(null, CloseDialogFlagChanged));

        static void CloseDialogFlagChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            var window = sender as Window;
            if (window != null && e.NewValue != null)
                window.Close();
        }
    }
}
