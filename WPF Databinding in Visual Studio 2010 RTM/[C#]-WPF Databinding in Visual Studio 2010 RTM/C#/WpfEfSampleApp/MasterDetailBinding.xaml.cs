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
    //  This sample demonstrates Master-Detail data binding to CollectionViewSources and how
    //   work with master-detail entity collections. See the WpfEfDAL.Order and WpfEfDAL.OrderDetail 
    //   partial classes and the OrdersCollection to see one way to manage this.
    //  1. - Declare the CollectionViewSources in XAML Window.Resources section
    //  2. - Query the Orders and specify the Include("OrderDetails") to pull down the order details
    //  3. - Set the Source property of the CollectionViewSource
    /// </summary>
    public partial class MasterDetailBinding : Window
    {
        private OMSEntities db = new OMSEntities(); // EF ObjectContext connects to database and tracks changes
        private OrdersCollection OrderData;         // inherits from ObservableCollection

        private CollectionViewSource MasterViewSource;
        private CollectionViewSource DetailViewSource;

        //  Provides currency to controls (position & movement in the collections)
        private ListCollectionView MasterView;  //WithEvents 
        private BindingListCollectionView DetailsView;

        public MasterDetailBinding()
        {
            InitializeComponent();
        }

        private void MasterDetailBindingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IQueryable<Order> query = from o in db.Orders.Include("OrderDetails")
                                      //where o.OrderDate >= System.Convert.ToDateTime("1/1/2009")
                                      orderby o.OrderDate descending, o.Customer.LastName
                                      select o;

            this.OrderData = new OrdersCollection(query, db);

            // Make sure the lookup lists are pulled from the same ObjectContext 
            //  (OMSEntities) that the order query uses above.
            // Also have to make sure you return a list of whole entites and not a 
            //  projection of just a few fields otherwise the binding won// t work.
            IQueryable<Customer> customerList = from c in db.Customers
                                                where c.Orders.Count > 0
                                                orderby c.LastName, c.FirstName
                                                select c;

            IQueryable<Product> productList = from p in db.Products
                                              orderby p.Name
                                              select p;

            this.MasterViewSource = (CollectionViewSource)this.FindResource("MasterViewSource");
            this.DetailViewSource = (CollectionViewSource)this.FindResource("DetailsViewSource");
            this.MasterViewSource.Source = this.OrderData;

            CollectionViewSource customerSource = (CollectionViewSource)this.FindResource("CustomerLookup");
            customerSource.Source = customerList.ToList();  // A simple list is OK here since we are not editing Customers
            CollectionViewSource productSource = (CollectionViewSource)this.FindResource("ProductLookup");
            productSource.Source = productList.ToList();    // A simple list is OK here since we are not editing Products

            this.MasterView = (ListCollectionView)this.MasterViewSource.View;
            MasterView.CurrentChanged += new EventHandler(MasterView_CurrentChanged);

            this.DetailsView = (BindingListCollectionView)this.DetailViewSource.View;
        }

        private void MasterView_CurrentChanged(object sender, System.EventArgs e)   // MasterView.CurrentChanged
        {
            //  We need to grab the new child view when the master's position changes
            this.DetailsView = (BindingListCollectionView)this.DetailViewSource.View;
        }

        private void btnSave_Click(object sender, System.Windows.RoutedEventArgs e) // btnSave.Click
        {
            try
            {
                db.SaveChanges();
                MessageBox.Show("Order data saved.", this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)   // btnDelete.Click
        {
            if (this.MasterView.CurrentPosition > -1)
                this.MasterView.RemoveAt(this.MasterView.CurrentPosition);
        }

        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)  // btnAdd.Click
        {
            this.MasterView.AddNew();
            this.MasterView.CommitNew();
        }

        private void btnPrevious_Click(object sender, System.Windows.RoutedEventArgs e) // btnPrevious.Click
        {
            if (this.MasterView.CurrentPosition > 0)
                this.MasterView.MoveCurrentToPrevious();
        }

        private void btnNext_Click(object sender, System.Windows.RoutedEventArgs e) // btnNext.Click
        {
            if (this.MasterView.CurrentPosition < this.MasterView.Count - 1)
                this.MasterView.MoveCurrentToNext();
        }

        private void btnAddDetail_Click(object sender, System.Windows.RoutedEventArgs e)    // btnAddDetail.Click
        {
            this.DetailsView.AddNew();
            this.DetailsView.CommitNew();
        }

        private void btnDeleteDetail_Click(object sender, System.Windows.RoutedEventArgs e) // btnDeleteDetail.Click
        {
            if (this.DetailsView.CurrentPosition > -1)
                this.DetailsView.RemoveAt(this.DetailsView.CurrentPosition);
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
