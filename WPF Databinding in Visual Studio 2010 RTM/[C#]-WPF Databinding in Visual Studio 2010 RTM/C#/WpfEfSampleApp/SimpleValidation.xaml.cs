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

//  <summary>
//  This form demonstrates simple data validation error display.
//  - 1. XAML data bindings specify ValidatesOnDataErrors=True
//  - 2. WpfEfDAL.Customer implements IDataErrorInfo and specifies a validation rule on the LastName property
//  - 3. Application.xaml defines an ErrorTemplate for displaying validation errors
//  </summary>

namespace WpfEfSampleApp
{
    public partial class SimpleValidation : Window
    {
        private OMSEntities db = new OMSEntities(); // EF ObjectContext connects to database and tracks changes
        private CustomerCollection CustomerData;    // inherits from ObservableCollection
        private ListCollectionView View;            // provides currency to controls (position & movement in the collection)

        public SimpleValidation()
        {
            InitializeComponent();
        }

        private void SimpleValidationWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IQueryable<Customer> query = from c in db.Customers
                                         where c.City == "Seatttle"
                                         orderby c.LastName, c.FirstName
                                         select c;

            this.CustomerData = new CustomerCollection(query, db);

            CollectionViewSource customerSource = (CollectionViewSource)this.FindResource("CustomerSource");
            customerSource.Source = this.CustomerData;

            this.View = (ListCollectionView)customerSource.View;
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
                if (!this.CustomerData.HasErrors)
                {
                    db.SaveChanges();
                    MessageBox.Show("Customer data saved.", this.Title, MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Please correct the errors on this form before saving.", this.Title, MessageBoxButton.OK, MessageBoxImage.Stop);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
