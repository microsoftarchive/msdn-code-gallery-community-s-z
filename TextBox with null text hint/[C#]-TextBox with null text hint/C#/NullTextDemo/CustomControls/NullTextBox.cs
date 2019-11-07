using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace NullTextDemo.CustomControls
{
    public class NullTextBox : TextBox
    {
        static NullTextBox()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NullTextBox),
                new FrameworkPropertyMetadata(typeof(NullTextBox)));
        }


        public static readonly DependencyProperty NullTextProperty =
             DependencyProperty.Register("NullText", typeof(String),
             typeof(NullTextBox), new FrameworkPropertyMetadata("Zadať"));

        public String NullText
        {
            get { return (String)GetValue(NullTextProperty); }
            set { SetValue(NullTextProperty, value); }
        }
    }
}
