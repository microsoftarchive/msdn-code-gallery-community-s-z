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
using Illusion.Navigation.ViewModel;

namespace Illusion.Navigation.View
{
    /// <summary>
    /// Interaction logic for HeaderView.xaml
    /// </summary>
    public partial class HeaderView : UserControl
    {
        public HeaderView(HeaderViewModel model)
        {
            InitializeComponent();
            DataContext = model;
        }
    }
}
