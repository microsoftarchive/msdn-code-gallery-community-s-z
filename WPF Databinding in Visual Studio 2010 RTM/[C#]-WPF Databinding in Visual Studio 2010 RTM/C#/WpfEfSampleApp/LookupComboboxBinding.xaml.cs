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
// This example shows how to properly bind entity references to lookup comboboxes
//  as well as how to notify the UI when the entity reference changes. 
// 1. - Handle the CustomerReference.AssociationChanged Event on the Order (See WpfEfDAL.Order partial class)
// 2. - XAML for Combobox binds the SelectedItem property to the Customer entity
// 3. - The lookup list of customers is pulled from the same ObjectContext (OMSEntities) that the order query uses 
// 4. - The lookup list of customers are entire Customer entites and not a projection of just a few fields
/// </summary>
/// <remarks></remarks>

namespace WpfEfSampleApp
{
    /// <summary>
    /// Interaction logic for LookupComboboxBinding.xaml
    /// </summary>
    public partial class LookupComboboxBinding : Window
    {
        private OMSEntities db = new OMSEntities();   //  EF ObjectContext connects to database and tracks changes
        private OrdersCollection OrderData;         //  inherits from ObservableCollection
        private ListCollectionView View;            //  provides currency to controls (position & movement in the collection)

        public LookupComboboxBinding()
        {
            InitializeComponent();
        }

        private void LookupComboboxBindingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IQueryable<Order> query = from o in db.Orders
                                      //where o.OrderDate >= System.Convert.ToDateTime("1/1/2009")
                                      orderby o.OrderDate descending, o.Customer.LastName
                                      select o;

            this.OrderData = new OrdersCollection(query, db);

            //  Make sure the lookup list is pulled from the same ObjectContext 
            //  (OMSEntities) that the order query uses above.
            //  Also have to make sure you return a list of Customer entites and not a 
            //  projection of just a few fields otherwise the binding won't work).
            IQueryable<Customer> customerList = from c in db.Customers
                                                where c.Orders.Count > 0
                                                orderby c.LastName, c.FirstName
                                                select c;

            CollectionViewSource orderSource = (CollectionViewSource)this.FindResource("OrdersSource");
            orderSource.Source = this.OrderData;

            CollectionViewSource customerSource = (CollectionViewSource)this.FindResource("CustomerLookup");
            customerSource.Source = customerList;   //.ToArray(); //.ToList();  // A simple list is OK here since we are not editing Customers

            this.View = (ListCollectionView)orderSource.View;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (this.View.CurrentPosition > -1)
                this.View.RemoveAt(this.View.CurrentPosition);
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            this.View.AddNew();
            this.View.CommitNew();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try {
                db.SaveChanges();
                MessageBox.Show("Order data saved.", this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
