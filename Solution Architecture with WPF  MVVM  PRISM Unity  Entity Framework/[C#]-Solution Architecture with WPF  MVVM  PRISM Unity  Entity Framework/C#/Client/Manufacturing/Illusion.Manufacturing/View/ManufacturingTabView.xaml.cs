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
using Illusion.Manufacturing.ViewModel;

namespace Illusion.Manufacturing.View
{
    /// <summary>
    /// Interaction logic for TabView.xaml
    /// </summary>
    public partial class ManufacturingTabView : UserControl
    {
        public ManufacturingTabView(ManufacturingTabViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
