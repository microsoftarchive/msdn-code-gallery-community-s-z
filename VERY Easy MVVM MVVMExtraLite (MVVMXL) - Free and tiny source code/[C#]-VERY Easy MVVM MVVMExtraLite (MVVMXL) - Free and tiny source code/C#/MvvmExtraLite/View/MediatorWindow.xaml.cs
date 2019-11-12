using System.Windows;
using MvvmExtraLite.ViewModel;

namespace MvvmExtraLite.View
{
    public partial class MediatorWindow : Window
    {
        public MediatorWindow()
        {
            InitializeComponent();
            DataContext = new ViewModelMediator();
        }
    }
}
