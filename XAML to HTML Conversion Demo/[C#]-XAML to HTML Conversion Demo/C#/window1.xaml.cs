using System;
using System.Collections;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Controls.Primitives;
using System.IO;
using System.Text;

namespace HTMLConverter
{

    public partial class Window1 : Window
    {

        public void convertContent(object sender, RoutedEventArgs e)
        {
            myTextBox.Text = HtmlToXamlConverter.ConvertHtmlToXaml(myTextBox.Text, true);
            MessageBox.Show("Content Conversion Complete!");
        }
        public void copyXAML(object sender, RoutedEventArgs e)
        {
            myTextBox.SelectAll();
            myTextBox.Copy();
        }

        public void convertContent2(object sender, RoutedEventArgs e)
        {
            myTextBox2.Text = HtmlFromXamlConverter.ConvertXamlToHtml(myTextBox2.Text);
            MessageBox.Show("Content Conversion Complete!");
        }
        public void copyHTML(object sender, RoutedEventArgs e)
        {
            myTextBox2.SelectAll();
            myTextBox2.Copy();
        }
    }
}