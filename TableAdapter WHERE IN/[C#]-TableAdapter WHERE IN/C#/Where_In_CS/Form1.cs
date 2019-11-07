using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Where_In_CS
{
    public partial class Form1 : Form
    {
        string customerPrimaryKeyName = "CustomerIdentifier";
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Add/Edit/Delete operations are not part of this code sample
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void customersBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("CRUD operations not implemented for this code sample");
        }
        /// <summary>
        /// In short this is the default code injected by the data wizards, I simply
        /// removed the comments.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            this.customersTableAdapter.Fill(this.dataSet1.Customers);
            this.customersNamesTableAdapter.Fill(this.dataSet1.CustomersNames);
        }
        /// <summary>
        /// Normal fill, clear selections in listbox
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearForCustomerIdentifierQueryButton_Click(object sender, EventArgs e)
        {
            ClearItemsForCustomerIdentifier();
        }
        /// <summary>
        /// If there are selected items in the ListBox, cast each item to a DataRowView to
        /// access the primary key at the DataRow level to pass into our customer fill method
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void selectByCustomerIdentifierButton_Click(object sender, EventArgs e)
        {
            var items = listBox1.SelectedItems;
            if (items != null)
            {
                // create an array of primary keys to send to our custom select
                var customeridentifiers = items.Cast<DataRowView>().ToList()
                    .Select(view => view.Row.Field<int>(customerPrimaryKeyName)).ToArray();

                // this is our overrridden query which is modified in DataSet.cs 
                // which you can view by right clicking on FillByInByCustomerIdentifier and
                // select go to definition
                customersTableAdapter
                    .FillByInByCustomerIdentifier(dataSet1.Customers, customeridentifiers);
            }
            else
            {
                ClearItemsForCustomerIdentifier();
            }
        }
        /// <summary>
        /// reset after a filter was applied for customer id query
        /// </summary>
        void ClearItemsForCustomerIdentifier()
        {

            listBox1.SelectedItems.Clear();

            if (customersBindingSource.Current != null)
            {
                var id = ((DataRowView)customersBindingSource.Current).Row.Field<int>(customerPrimaryKeyName);
                var colIndex = customersDataGridView.CurrentCellAddress.X;
                
                customersTableAdapter.Fill(this.dataSet1.Customers);

                if (chkRemember.Checked)
                {
                    var index = customersBindingSource.Find(customerPrimaryKeyName, id);
                    if (index != -1)
                    {
                        customersBindingSource.Position = index;
                        customersDataGridView.CurrentCell = customersDataGridView.Rows[index].Cells[colIndex];
                    }
                }
            }
        }
        /// <summary>
        /// Hide/show panel for focus on the DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TogglePanelButton_Click(object sender, EventArgs e)
        {
            panel1.Visible = !panel1.Visible;
        }
    }
}
