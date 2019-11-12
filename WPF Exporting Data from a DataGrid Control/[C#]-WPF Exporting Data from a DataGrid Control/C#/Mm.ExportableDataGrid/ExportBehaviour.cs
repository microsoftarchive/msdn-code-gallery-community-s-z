using System.Windows;
using System.Windows.Controls;

namespace Mm.ExportableDataGrid
{
    public class ExportBehaviour
    {
        public static readonly DependencyProperty ExportStringProperty =
            DependencyProperty.RegisterAttached("ExportString", //name of attached property
            typeof(string), //type of attached property
            typeof(ExportBehaviour), //type of this owner class
            new PropertyMetadata(string.Empty)); //the default value of the attached property

        public static string GetExportString(DataGridColumn column)
        {
            return (string)column.GetValue(ExportStringProperty);
        }

        public static void SetExportString(DataGridColumn column, string value)
        {
            column.SetValue(ExportStringProperty, value);
        }
    }
}
