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

namespace SampleWpfApp
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow() {
			InitializeComponent();

			this.home = new Pages.HomePage() { MainWindow = this, Items = this.items };
			this.edit = new Pages.EditPage() { MainWindow = this };
		}

		private Pages.HomePage home;
		private Pages.EditPage edit;

		private List<Models.SampleItem> items = new List<SampleItem>();

		private void Window_Loaded( object sender, RoutedEventArgs e ) {
			this.mainFrame.Navigate( this.home );
		}

		public void GoHome() {
			this.home.Items = this.items;
			this.mainFrame.Navigate( this.home );
		} // end sub

		public void GoToEdit(SampleItem item = null) {

			bool isNew = false;
			if (item == null) {
				item = new SampleItem();
				isNew = true;
			}// end if

			this.edit.Item = item;
			this.edit.IsNew = isNew;

			this.mainFrame.Navigate( this.edit );
		} // end sub

		public void AddItem( SampleItem newItem ) {
			if (newItem == null) throw new ArgumentNullException( "newItem" );
			this.items.Add( newItem );
		}
		
	}
}
