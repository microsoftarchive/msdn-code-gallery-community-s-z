using System.Windows;
using System.Windows.Controls;
using MediatorExample.Helpers;

namespace MediatorExample
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Mediator.NotifyColleagues("Try1", "Hello World");
        }
    }
}
