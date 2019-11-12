using MVVMChildWindow.Common;
using System.Windows;

namespace MVVMChildWindow
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();  
            childWindow.DataContext = ChildWindowManager.Instance;
            this.DataContext = new MainViewModel();     
        }
    }
}
