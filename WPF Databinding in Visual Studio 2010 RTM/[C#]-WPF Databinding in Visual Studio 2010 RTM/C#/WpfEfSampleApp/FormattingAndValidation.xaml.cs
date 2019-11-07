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


/// <summary>
//  This sample demonstrates the use of value converters for formatting values and
//  for restricting user input to valid types as well as validation. 
//  This form will not allow non-dates in date fields or non-numerics in numeric fields
//   by using a simple ValueConverter (see the SimpleConverter class and the XAML bindings).
/// </summary>
/// <remarks></remarks>
namespace WpfEfSampleApp
{
    /// <summary>
    /// Interaction logic for FormattingAndValidation.xaml
    /// </summary>
    public partial class FormattingAndValidation : Window
    {
        private OMSEntities db = new OMSEntities(); // EF ObjectContext connects to database and tracks changes
        private OrdersCollection OrderData;         // inherits from ObservableCollection

        private CollectionViewSource MasterViewSource;
        private CollectionViewSource DetailViewSource;

        // provides currency to controls (position & movement in the collections)
        private ListCollectionView MasterView;
        private BindingListCollectionView DetailsView;

        public FormattingAndValidation()
        {
            InitializeComponent();
        }

        private void Window1_Loaded(object sender, RoutedEventArgs e)
        {
            IQueryable<Order> query = from o in db.Orders.Include("OrderDetails")
                                        //where o.OrderDate >= System.Convert.ToDateTime("1/1/2009")
                                        orderby o.OrderDate descending, o.Customer.LastName
                                        select o;

            this.OrderData = new OrdersCollection(query, db);

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
            customerSource.Source = customerList.ToList();  //  A simple list is OK here since we are not editing Customers

            CollectionViewSource productSource = (CollectionViewSource)this.FindResource("ProductLookup");
            productSource.Source = productList.ToList();    //  A simple list is OK here since we are not editing Products

            this.MasterView = (ListCollectionView)this.MasterViewSource.View;
            MasterView.CurrentChanged += new EventHandler(MasterView_CurrentChanged);

            this.DetailsView = (BindingListCollectionView)this.DetailViewSource.View;
        }

        private void MasterView_CurrentChanged(object sender, System.EventArgs e)
        {
            // We need to grab the new child view when the master's position changes
            this.DetailsView = (BindingListCollectionView)this.DetailViewSource.View;
        }

        private void btnSave_Click(System.Object sender, System.Windows.RoutedEventArgs e) // btnSave.Click
        {
            try {
                db.SaveChanges();
                MessageBox.Show("Order data saved.", this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnDelete_Click(System.Object sender, System.Windows.RoutedEventArgs e) // btnDelete.Click
        {
            if (this.MasterView.CurrentPosition > -1)
                this.MasterView.RemoveAt(this.MasterView.CurrentPosition);
        }

        private void btnAdd_Click(System.Object sender, System.Windows.RoutedEventArgs e)   //btnAdd.Click
        {
            this.MasterView.AddNew();
            this.MasterView.CommitNew();
        }

        private void btnPrevious_Click(System.Object sender, System.Windows.RoutedEventArgs e)  // btnPrevious.Click
        {
            if (this.MasterView.CurrentPosition > 0)
                this.MasterView.MoveCurrentToPrevious();
        }

        private void btnNext_Click(System.Object sender, System.Windows.RoutedEventArgs e)  // btnNext.Click
        {
            if (this.MasterView.CurrentPosition < this.MasterView.Count - 1)
                this.MasterView.MoveCurrentToNext();
        }

        private void btnAddDetail_Click(System.Object sender, System.Windows.RoutedEventArgs e) //  btnAddDetail.Click
        {
            this.DetailsView.AddNew();
            this.DetailsView.CommitNew();
        }

        private void btnDeleteDetail_Click(System.Object sender, System.Windows.RoutedEventArgs e)  // btnDeleteDetail.Click
        {
            if (this.DetailsView.CurrentPosition > -1)
                this.DetailsView.RemoveAt(this.DetailsView.CurrentPosition);
        }

        private void Item_GotFocus(System.Object sender, System.Windows.RoutedEventArgs e)
        {
            // This will keep the View position in sync with the selected 
            // row even when a control is being edited in the ListViewItem
            ListViewItem item = (ListViewItem)sender;
            this.ListView1.SelectedItem = item.DataContext;
        }
    }
}
