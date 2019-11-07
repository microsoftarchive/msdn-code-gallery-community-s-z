using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Xml.Linq;
namespace WpfListViewContextMenu
{
    
    public partial class MainWindow : Window
    {
        private Nutrition nutritionObj;
        private List<Nutrition> nutritions; 
        public MainWindow()
        {
            InitializeComponent();
            LoadListView();
        }

        private void LoadListView()
        {
          
            XDocument nutritionsDoc = XDocument.Load( "Nutritions.xml" ); // temp data

            nutritions = ( from nutrition in nutritionsDoc.Descendants( "Nutrition" )
                                     select new Nutrition
                                     {
                                         Group = nutrition.Attribute( "Group" ).Value,
                                         Name = nutrition.Attribute( "Name" ).Value,
                                         Quantity = nutrition.Attribute( "Quantity" ).Value
                                     } ).ToList();

         

            foreach (Nutrition nutrition in nutritions)
            {
                nutritionlistView.Items.Add(nutrition);
            }
        }

        private void RemoveNutritionContextMenu_OnClick(object sender, RoutedEventArgs e)
        {
            nutritionlistView.Items.Remove(nutritionlistView.SelectedItem);  // remove the selected Item
        }

        private void EditNutritionContextMenu_OnClick(object sender, RoutedEventArgs e)
        {
            if (nutritionlistView.SelectedIndex>-1)
            {
                nutritionObj = new Nutrition();
                nutritionObj = (Nutrition) nutritionlistView.SelectedItem; // casting the list view
                MessageBox.Show("You are in edit for Name:"+nutritionObj.Name, "Nutrition", MessageBoxButton.OK, MessageBoxImage.Information);

            }

        }

        private void closeButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
