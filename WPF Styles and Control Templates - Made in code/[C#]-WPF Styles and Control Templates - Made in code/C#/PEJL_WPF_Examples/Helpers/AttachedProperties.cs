using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace PEJL_WPF_Examples
{
    public class AttachedProperties
    {
        public static bool GetIsHighlighted(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsHighlightedProperty);
        }

        public static void SetIsHighlighted(DependencyObject obj, bool value)
        {
            obj.SetValue(IsHighlightedProperty, value);
        }

        // Using a DependencyProperty as the backing store for IsHighlighted.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsHighlightedProperty =
            DependencyProperty.RegisterAttached("IsHighlighted", typeof(bool), typeof(AttachedProperties), new UIPropertyMetadata(false));
    }
}
