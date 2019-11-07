using System.Windows;

namespace Tasks.Show.Helpers
{
    public class Attached : DependencyObject
    {
        #region IsSelected

        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.RegisterAttached("IsSelected", typeof(bool), typeof(Attached),
                new FrameworkPropertyMetadata((bool)false));

        public static bool GetIsSelected(DependencyObject d)
        {
            return (bool)d.GetValue(IsSelectedProperty);
        }

        public static void SetIsSelected(DependencyObject d, bool value)
        {
            d.SetValue(IsSelectedProperty, value);
        }

        #endregion

        #region InformationText

        public static readonly DependencyProperty InformationTextProperty =
            DependencyProperty.RegisterAttached("InformationText", typeof(string), typeof(Attached),
                new FrameworkPropertyMetadata((string)null));

        public static string GetInformationText(DependencyObject d)
        {
            return (string)d.GetValue(InformationTextProperty);
        }

        public static void SetInformationText(DependencyObject d, string value)
        {
            d.SetValue(InformationTextProperty, value);
        }

        #endregion
    }
}
