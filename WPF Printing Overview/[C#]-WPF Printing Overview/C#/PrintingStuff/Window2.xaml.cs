using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace PrintingStuff
{
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
        }

        private void Print_Click(object sender, RoutedEventArgs e)
        {
            //If you reduce the size of the view area of the window, so the text does not all fit into one page, it will print separate pages
            PrintDialog printDialog = new PrintDialog();
            if (printDialog.ShowDialog() == true)
                printDialog.PrintDocument(((IDocumentPaginatorSource)flowDocument).DocumentPaginator, "This is a Flow Document");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var win = new Window3();
            win.Show();
            this.Close();
        }
    }
}
