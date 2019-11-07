using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Support
{
    public class EditRow : ContentControl
    {
        public string LabelFor
        {
            get { return (string)GetValue(LabelForProperty); }
            set { SetValue(LabelForProperty, value); }
        }
        public static readonly DependencyProperty LabelForProperty = DependencyProperty.RegisterAttached(
                          "LabelFor",
                          typeof(string),
                          typeof(EditRow));
        public string LabelWidth
        {
            get { return (string)GetValue(LabelWidthProperty); }
            set { SetValue(LabelWidthProperty, value); }
        }
        public static readonly DependencyProperty LabelWidthProperty = DependencyProperty.RegisterAttached(
                          "LabelWidth",
                          typeof(string),
                          typeof(EditRow)
                          );
        public string PropertyWidth
        {
            get { return (string)GetValue(PropertyWidthProperty); }
            set { SetValue(PropertyWidthProperty, value); }
        }
        public static readonly DependencyProperty PropertyWidthProperty = DependencyProperty.RegisterAttached(
                          "PropertyWidth",
                          typeof(string),
                          typeof(EditRow)
                         );
        public EditRow()
        {
            this.IsTabStop = false;
        }

    }
}
