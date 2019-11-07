using System.Collections.Generic;
using System.Windows;
using WpfApplication66.Model;

namespace WpfApplication66
{
    public partial class MainWindow : Window
    {
        public List<Person> MyCollection { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            MyCollection = new List<Person>
            {
                new Person { FirstName = "Fred", LastName="Smith" },
                new Person { FirstName = "Tom", LastName="Jones" }
            };
            DataContext = this;
        }
    }
}
