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

namespace SampleWpfApp.Pages
{
	/// <summary>
	/// Interaction logic for HomePage.xaml
	/// </summary>
	public partial class HomePage : Page
	{
		public HomePage() {
			InitializeComponent();
		}

		public MainWindow MainWindow { get; set; }

		/// <summary>
		/// Backing field of Items property.
		/// </summary>
		private IEnumerable<SampleWpfApp.Models.SampleItem> valueOfItems;

		/// <summary>
		/// Gets or sets the value of something.
		/// </summary>
		public IEnumerable<SampleWpfApp.Models.SampleItem> Items {
			get {
				return this.valueOfItems;
			} // end get
			set {
				this.valueOfItems = value;
				this.DataContext = null;
				this.DataContext = this.valueOfItems;
				
			} // end set
		} // end property

		private void appBarAddButton_Click( object sender, RoutedEventArgs e ) {

			if (this.MainWindow != null) {
				this.MainWindow.GoToEdit();
			} // end if
		} // end sub
	}
}
