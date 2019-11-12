using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_cs
{
    public static class Extensions
    {
        /// <summary>
        /// Indicates that a selection has not been made in one of the combo boxes in the editor form
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool IsSelectOne(this ComboBox sender)
        {
            return sender.Text == "Select one";
        }
        public static int StateIdentifier(this ComboBox sender)
        {
            return ((State)sender.SelectedItem).StateIdentifier;
        }

        public static int CityIdentifier(this ComboBox sender)
        {
            if (sender.SelectedItem == null)
            {
                return -1;
            }
            else
            {
                return ((City)sender.SelectedItem).CityIdentifier;
            }            
        }

        public static string FirstName(this BindingSource sender)
        {
            return ((DataRowView)sender.Current).Row.Field<string>("FirstName");
        }

        public static int CityIdentifier(this BindingSource sender)
        {
            return ((DataRowView)sender.Current).Row.Field<int>("CityIdentifier"); 
        }
        public static int StateIdentifier(this BindingSource sender)
        {
            return ((DataRowView)sender.Current).Row.Field<int>("StateIdentifier");
        }

        public static bool CurrentIsValid(this BindingSource sender)
        {
            return sender.Current != null;
        }
        public static DataTable DataTable(this BindingSource sender)
        {
            return (DataTable)sender.DataSource;
        }
        public static DataView DataView(this BindingSource sender)
        {
            return sender.DataTable().DefaultView;
        }
    }
}
