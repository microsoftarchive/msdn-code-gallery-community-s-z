using System.Windows;
using MvvmExtraLite.ViewModel;

namespace MvvmExtraLite.View
{
    public partial class ClosableWindow : Window
    {
        public ClosableWindow()
        {
            InitializeComponent();
            DataContext = new ViewModelMain();
        }
    }
}
