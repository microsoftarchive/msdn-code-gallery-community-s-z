using System.Windows;
using Microsoft.Practices.Prism.Regions;

namespace Illusion.Shell
{
    /// <summary>
    /// Interaction logic for Shell.xaml
    /// </summary>
    public partial class Shell : Window
    {
        public Shell(ShellViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
