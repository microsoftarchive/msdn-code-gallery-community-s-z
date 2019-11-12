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
    //  This sample demonstrates how to set up data binding in XAML to a collection 
    //   of customers that are queried from an Entity Data Model (EDM).
    /// </summary>
    public partial class SimpleDataEntry : Window
    {
        private OMSEntities db = new OMSEntities(); // EF ObjectContext connects to database and tracks changes
        private CustomerCollection CustomerData;    // inherits from ObservableCollection
        private ListCollectionView View;            // provides currency to controls (position & movement in the collection)

        public SimpleDataEntry()
        {
            InitializeComponent();
        }

        private void SimpleDataEntryWindow_Loaded(object sender, RoutedEventArgs e)
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

        private void btnPrevious_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.View.CurrentPosition > 0)
                this.View.MoveCurrentToPrevious();
        }

        private void btnNext_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.View.CurrentPosition < this.View.Count - 1)
                this.View.MoveCurrentToNext();
        }

        private void btnFirst_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.View.MoveCurrentToFirst();
        }

        private void btnLast_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.View.MoveCurrentToLast();
        }

        private void btnDelete_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (this.View.CurrentPosition > -1)
                this.View.RemoveAt(this.View.CurrentPosition);
        }

        private void btnAdd_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            this.View.AddNew();
            this.View.CommitNew();
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
    }
}
