using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.ComponentModel;
using System.Windows.Controls.Primitives;
using System.Windows.Documents;

namespace PEJL_WPF_Examples
{
    public partial class MainWindow : Window
    {
        class Person
        {
            public string Name { get; set; }
        }

        public MainWindow()
        {
            InitializeComponent();
        }
    }
}
