using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MasaSam.Samples.RatingControl
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void rtFive_RatingChanged(object sender, Controls.RatingChangedEventArgs e)
        {
            CalculateAverage();
        }

        private void rtTen_RatingChanged(object sender, Controls.RatingChangedEventArgs e)
        {
            CalculateAverage();
        }

        private void rtFifteen_RatingChanged(object sender, Controls.RatingChangedEventArgs e)
        {
            CalculateAverage();
        }

        private void CalculateAverage()
        {
            this.tbAverage.Text = "Average: " + (new int[] { rtFive.Value, rtTen.Value, rtFifteen.Value }).Average().ToString();
        }
    }
}
