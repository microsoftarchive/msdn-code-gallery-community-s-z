using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WPFAutoCompleteTextbox
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
            textBox1.AddItem(new AutoCompleteEntry("Toyota Camry", "Toyota Camry", "camry", "car", "sedan"));
            textBox1.AddItem(new AutoCompleteEntry("Toyota Corolla", "Toyota Corolla", "corolla", "car", "compact"));
            textBox1.AddItem(new AutoCompleteEntry("Toyota Tundra", "Toyota Tundra", "tundra", "truck"));
            textBox1.AddItem(new AutoCompleteEntry("Chevy Impala", null));  // null matching string will default with just the name
            textBox1.AddItem(new AutoCompleteEntry("Chevy Tahoe", "Chevy Tahoe", "tahoe", "truck", "SUV"));
            textBox1.AddItem(new AutoCompleteEntry("Chevrolet Malibu", "Chevrolet Malibu", "malibu", "car", "sedan"));
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            textBox1.Text = string.Empty;
        }
    }
}
