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
using System.Windows.Shapes;
using WpfEfDAL;


namespace WpfEfSampleApp
{
    /// <summary>
    //  This example shows one way to build a simple data grid using a ListView in WPF.
    /// </summary>
    public partial class SimpleDataGrid : Window
    {
        private OMSEntities db = new OMSEntities();  // EF ObjectContext connects to database and tracks changes
        private CustomerCollection CustomerData;    // inherits from ObservableCollection
        private ListCollectionView View;            // provides currency to controls (position & movement in the collection)

        public SimpleDataGrid()
        {
            InitializeComponent();
        }

        private void SimpleDataGridWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IQueryable<Customer> query = from c in db.Customers
                                         where c.City == "Seattle"
                                         orderby c.LastName, c.FirstName
                                         select c;

            this.CustomerData = new CustomerCollection(query, db);

            CollectionViewSource customerSource = (CollectionViewSource)this.FindResource("CustomerSource");
            customerSource.Source = this.CustomerData;

            this.View = (ListCollectionView)customerSource.View;
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.View.CurrentPosition > -1)
                this.View.RemoveAt(this.View.CurrentPosition);
        }

        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            Customer cust = (Customer)this.View.AddNew();

            this.View.CommitNew();
            this.ListView1.ScrollIntoView(cust);
            this.ListView1.Focus();
        }

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            try
            {
                db.SaveChanges();
                MessageBox.Show("Customer data saved.", this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void Item_GotFocus(object sender, System.Windows.RoutedEventArgs e)
        {
            // This will keep the View position in sync with the selected 
            // row even when a control is being edited in the ListViewItem
            ListViewItem item = (ListViewItem)sender;
            this.ListView1.SelectedItem = item.DataContext;
        }
    }
}
