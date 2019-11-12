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
    /// Interaction logic for ListBoxBinding.xaml
    /// </summary>
    public partial class ListBoxBinding : Window
    {
        private OMSEntities db = new OMSEntities();

        public ListBoxBinding()
        {
            InitializeComponent();
        }

        private void ListBoxBindingWindow_Loaded(object sender, RoutedEventArgs e)
        {
            IQueryable<Customer> result = from c in db.Customers
                                          where c.City == "Seattle"
                                          orderby c.LastName, c.FirstName
                                          select c;

            CollectionViewSource custViewSource = (CollectionViewSource)this.Resources["CustomerSource"];
            custViewSource.Source = result.ToList();
        }
    }
}
