using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

// MessageBox wrappers
using MessageDialogs;
using WindowsFormsApplication1.ExtensionMethods;
using System.Drawing;

namespace WindowsFormsApplication1
{

    public partial class Form1 : Form
    {
        /// <summary>
        /// Store a list of contact titles we use
        /// in the editor form.
        /// </summary>
        private List<string> contactTitles;
        private Dictionary<int, string> standings;

        public Form1()
        {
            InitializeComponent();
            customersDataGridView.KeyDown += CustomersDataGridView_KeyDown;
        }

        /// <summary>
        /// Here when the user presses ENTER we display a modal form with
        /// the current row data. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomersDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            /*
             * We are on a new row, nothing to edit.
             * If you wanted this could be a starting point to add a new row
             * yet there are better ways, for starters using the add button in
             * the BindingNavigator.
             */
            if (customersDataGridView.CurrentRow.IsNewRow)
            {
                return;
            }

            if (e.KeyData == Keys.Enter)
            {
                e.Handled = true;

                var id = ((DataRowView)customersBindingSource.Current).Row.Field<int>("CustomerIdentifier");


                NorthWindDataSet.CustomersRow cust = northWindDataSet.Customers.FirstOrDefault(c => c.CustomerIdentifier == id);

                var f = new CustomerEditForm(cust, contactTitles);
                try
                {
                    if (f.ShowDialog() != DialogResult.OK)
                    {
                        northWindDataSet.Customers.FirstOrDefault(c => c.CustomerIdentifier == id).RejectChanges();
                    }
                    else
                    {
                        // nothing required here. If you were thinking validation should be done here, nope
                        // validation should be in the edit form, see my comments in the save button for the
                        // edit form.
                    }
                }
                finally
                {
                    f.Dispose();
                }

            }
        }
        /// <summary>
        /// Override the default behavior of the delete button on the Customer's BindingNavigator
        /// - Select the delete button in the property window of the BindingNavigator, a ComboBox 
        ///   is displayed, select none. Next double click on the delete button which created the
        ///   event below. If you don't follow the steps above then the default action (delete)
        ///   will happen then your code in the click event below
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (KarenDialogs.Question("Do you really want to remove the current customer?"))
            {
                customersBindingSource.RemoveCurrent();
            }
        }

        private void customersBindingNavigatorSaveItem_Click_1(object sender, EventArgs e)
        {
            if (northWindDataSet.HasChanges())
            {
                if (KarenDialogs.Question("Save changes back to database?"))
                {
                    this.Validate();
                    this.customersBindingSource.EndEdit();

                    /*
                     * Manually added
                     */
                    this.ordersBindingSource.EndEdit();

                    this.tableAdapterManager.UpdateAll( this.northWindDataSet);
                }
            }
            else
            {
                MessageBox.Show("There are no changes");
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             * Since our Microsoft database does not have a reference table
             * for contact titles we build one outside of our typed data classes
             * generated in NorthWindDataSet.xsd and do it with SqlClient data
             * provider. In a well structured database design we would of had
             * a reference table for contact titles
             */
            var ops = new DataOperations();
            contactTitles = ops.ContactTitles();
            standings = ops.Standings();

            this.ordersTableAdapter.Fill(this.northWindDataSet.Orders);
            this.customersTableAdapter.Fill(this.northWindDataSet.Customers);

            /*
             * Manually added, next two lines so we have the master and details
             * working together.
             */
            this.ordersBindingSource.DataSource = customersBindingSource;
            ordersBindingSource.DataMember = northWindDataSet.Relations[0].RelationName;

            /*
             * DataGridViewColumns to hide in the master DataGridView
             */
            var columns = new DataGridViewColumn[] 
            {
                orderIDDataGridViewTextBoxColumn,
                customerIdentifierDataGridViewTextBoxColumn
            };

            foreach (var col in columns)
            {
                col.Visible = false;
            }

            /*
             * Split Header text by upper-case characters in the master DataGridView
             */
            foreach (DataGridViewColumn col in customersDataGridView.Columns)
            {
                col.HeaderText = System.Text.RegularExpressions.Regex.Replace(col.HeaderText, "([a-z])([A-Z])", "$1 $2");
            }

            /*
             * Standard resize columns in master DataGridView
             */
            customersDataGridView.AutoResizeColumns();

            /*
             * The company column is an odd one that does not comply so set the header width manually
             */
            companyNameColumn.Width = companyNameColumn.Width + 20;

            /*
             * Repeat what we just did for the master DataGridView
             */
            foreach (DataGridViewColumn col  in ordersDataGridView.Columns)
            {
                col.HeaderText = System.Text.RegularExpressions.Regex.Replace(col.HeaderText, "([a-z])([A-Z])", "$1 $2");
            }
            


            /*
             * The postal code column is an odd one that does not comply so set the header width manually
             */
            shipPostalCodeDataGridViewTextBoxColumn.Width = shipPostalCodeDataGridViewTextBoxColumn.Width + 15;

            /*
             * The user is here to browse data so set the master DataGridView as the active control.
             */
            ActiveControl = customersDataGridView;


            /*
             * Yes we can do a find and position when found!!!
             */
            var postion = customersBindingSource.Find("CompanyName", "Around the Horn");
            if (postion > -1)
            {
                customersBindingSource.Position = postion;
            }

        }
        /// <summary>
        /// Shows how to view fields of the master (customer) current row in the DataGridView
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void currentCustomerButton_Click(object sender, EventArgs e)
        {

            if (customersBindingSource.Current != null)
            {
                var row = ((DataRowView)customersBindingSource.Current).Row;
                MessageBox.Show(row.Field<string>("CompanyName"));
            }
        }
        /// <summary>
        /// Do a super simple filter. For more on filtering see my code sample
        /// https://code.msdn.microsoft.com/BindingSource-Find-and-08e48b45
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchByCompanyName_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(companyNameSearchToolStripTextBox1.Text))
            {
                customersBindingSource.Filter = $"CompanyName LIKE '{companyNameSearchToolStripTextBox1.Text.Replace("'","''")}%'";
            }
            else
            {
                customersBindingSource.Filter = "";
            }
            
        }
        /// <summary>
        /// If you need to check for errors prior to saving. This method is
        /// currently incomplete in that all it does is check for errors for
        /// each row in the data set. Note the commented lines, they provide
        /// access to the errors so you can decide how to handle them.
        /// </summary>
        private bool FindErrors()
        {
            int errorCount = 0;
            if (northWindDataSet.HasErrors)
            {
                foreach (DataTable table in northWindDataSet.Tables)
                {
                    if (table.HasErrors)
                    {
                        foreach (DataRow row in table.Rows)
                        {
                            if (row.HasErrors)
                            {
                                // Process error here.
                                //row.RowError
                                //row.GetColumnError
                                //row.GetColumnsInError                                

                                errorCount += 1;
                            }
                        }
                    }
                }
            }

            return errorCount > 0;
        }
    }
}
