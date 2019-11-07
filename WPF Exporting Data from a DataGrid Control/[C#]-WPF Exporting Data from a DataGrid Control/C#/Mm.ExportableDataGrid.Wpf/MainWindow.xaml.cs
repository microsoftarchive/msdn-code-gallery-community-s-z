using System.Collections.Generic;
using System.Windows;

namespace Mm.ExportableDataGrid.Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;

            /* initialize categories */
            this.Categories = new List<Category>();
            this.Categories.Add(new Category() { Id = 1, Name = "Category A" });
            this.Categories.Add(new Category() { Id = 2, Name = "Category B" });

            /* initialize products */
            this.Products = new List<Product>();
            for (int i = 0; i < 100; ++i)
            {
                Product item = new Product();
                item.Id = i;
                item.Name = string.Format("Item {0}", i);

                bool b = (i % 2).Equals(0);
                item.IsAvailable = b;
                item.Category = b ? this.Categories[0] : this.Categories[1];
                this.Products.Add(item);
            }
        }

        public IList<Category> Categories
        {
            get;
            private set;
        }

        public IList<Product> Products
        {
            get;
            private set;
        }

        private void Export_Click(object sender, RoutedEventArgs e)
        {
            const string path = "test.csv";
            IExporter csvExporter = new CsvExporter(';');
            dataGrid.ExportUsingRefection(csvExporter, path);
        }
    }
}
