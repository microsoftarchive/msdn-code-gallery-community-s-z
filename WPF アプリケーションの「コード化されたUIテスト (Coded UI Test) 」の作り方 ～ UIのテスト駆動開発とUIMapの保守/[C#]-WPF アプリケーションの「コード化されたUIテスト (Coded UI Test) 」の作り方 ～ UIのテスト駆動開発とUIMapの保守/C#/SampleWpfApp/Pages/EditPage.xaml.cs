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
using SampleWpfApp.Models;

namespace SampleWpfApp.Pages
{
	/// <summary>
	/// Interaction logic for EditPage.xaml
	/// </summary>
	public partial class EditPage : Page
	{
		public EditPage() {
			InitializeComponent();
		}
		public MainWindow MainWindow { get; set; }


		/// <summary>
		/// Backing field of SampleItem property.
		/// </summary>
		private SampleItem valueOfItem;

		/// <summary>
		/// Gets or sets the value of something.
		/// </summary>
		public SampleItem Item {
			get {
				return this.valueOfItem;
			} // end get
			set {
				this.valueOfItem = value;
				this.DataContext = null;
				this.DataContext = this.valueOfItem;
			} // end set
		} // end property


		/// Backing field of IsNew property.
		/// </summary>
		private bool valueOfIsNew;

		/// <summary>
		/// Gets or sets the value of something.
		/// </summary>
		public bool IsNew {
			get {
				return this.valueOfIsNew;
			} // end get
			set {
				this.valueOfIsNew = value;
				if (this.valueOfIsNew) {
					this.pageTitle.Text = "ADD NEW ITEM";
				}
				else {
					this.pageTitle.Text = "EDIT ITEM";
				} // end if
			} // end set
		} // end property

		private void OKButton_Click( object sender, RoutedEventArgs e ) {

			if (this.IsNew) {
				this.MainWindow.AddItem( this.Item );
				this.IsNew = false;
			} // end if

			this.MainWindow.GoHome();
		}

		private void CancelButton_Click( object sender, RoutedEventArgs e ) {
			this.MainWindow.GoHome();
		}

	}
}
