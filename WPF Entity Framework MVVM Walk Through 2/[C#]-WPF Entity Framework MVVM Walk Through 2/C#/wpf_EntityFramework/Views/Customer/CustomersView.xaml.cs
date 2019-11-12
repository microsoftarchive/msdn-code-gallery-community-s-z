using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace wpf_EntityFramework
{
    /// <summary>
    /// Interaction logic for CustomersView.xaml
    /// </summary>
    public partial class CustomersView : UserControl
    {
        public CustomersView()
        {
            InitializeComponent();
            this.DataContext = new CustomersViewModel();
        }
        private void DatabindingError(object sender, ValidationErrorEventArgs e)
        {
            Debug.WriteLine("ErrorContent " + e.Error.ErrorContent);
            Debug.WriteLine("ResolvedSourcePropertyName " + ((System.Windows.Data.BindingExpression)(e.Error.BindingInError)).ResolvedSourcePropertyName);
        }

        private void Binding_SourceUpdated(object sender, DataTransferEventArgs e)
        {
            string propertyName;
            BindingExpression binding = null;
            Type type = e.TargetObject.GetType();
            if (type == typeof(TextBox))
            {
                binding = ((TextBox)e.TargetObject).GetBindingExpression(TextBox.TextProperty);
            }
            else if (type == typeof(ComboBox))
            {
                binding = ((ComboBox)e.TargetObject).GetBindingExpression(ComboBox.SelectedValueProperty);

            }
            else if (type == typeof(DatePicker))
            {
                binding = ((DatePicker)e.TargetObject).GetBindingExpression(DatePicker.SelectedDateProperty);

            }
            propertyName = binding.ResolvedSourcePropertyName;

        }  

    }
}
