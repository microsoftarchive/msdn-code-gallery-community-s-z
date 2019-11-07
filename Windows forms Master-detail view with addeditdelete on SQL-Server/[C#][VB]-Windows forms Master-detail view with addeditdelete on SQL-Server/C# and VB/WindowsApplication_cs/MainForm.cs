using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataOperations;
using MessageDialogs;

namespace WindowsApplication_cs
{
    public partial class MainForm : Form
    {
        /// <summary>
        /// Containers for our customer and orders data
        /// which are setup in Operations class.
        /// </summary>
        BindingSource bsMaster = new BindingSource();
        BindingSource bsDetails = new BindingSource();
        BindingSource bsOrderDetails = new BindingSource();

        List<StateItems> StateInformation;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Operations ops = new Operations();

            ops.LoadData();

            if (!ops.HasErrors)
            {

                StateInformation = ops.StateInformation;

                bsMaster = ops.Master;
                bsDetails = ops.Details;

                MasterDataGridView.DataSource = bsMaster;
                DetailsDataGridView.AutoGenerateColumns = false;

                DetailsDataGridView.DataSource = bsDetails;
                OrderDateColumn.ReadOnly = false;
                UpdateButtonColumn.UseColumnTextForButtonValue = true;

                MasterBindingNavigator.BindingSource = bsMaster;

                bsOrderDetails = ops.OrderDetails;
                OrderDetailsDataGridView.DataSource = bsOrderDetails;
                OrderDetailsDataGridView.Columns["id"].Visible = false;
                OrderDetailsDataGridView.Columns["OrderId"].Visible = false;
                DetailBindingNavigator.BindingSource = bsDetails;

                OrderDetailsDataGridView.Columns["ProductName"].HeaderText = "Product";
                OrderDetailsDataGridView.Columns["UnitPrice"].HeaderText = "Unit price";

            }
            else
            {
                MessageBox.Show(ops.ExceptionMessage);
            }
        }



        /// <summary>
        /// Point of entry for editing current customer from either
        /// a button on the BindingNavigator or pressing the enter key
        /// on the master DataGridView
        /// </summary>
        private void EditCurrentCustomer()
        {
            DataRow CustomerRow = ((DataRowView)bsMaster.Current).Row;
            CustomerForm f = new CustomerForm(false, StateInformation, ref CustomerRow);

            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    Operations ops = new Operations();
                    if (!(ops.UpdateCustomer(CustomerRow)))
                    {
                        MessageBox.Show($"Failed to update: {ops.ExceptionMessage}");
                    }
                }
            }
            finally
            {
                f.Dispose();
            }
        }

        private void MasterDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                e.Handled = true;
                EditCurrentCustomer();
            }
        }

        private void MasterBindingNavigatorEditCustomer_Click(object sender, EventArgs e)
        {
            EditCurrentCustomer();
        }

        private void MasterBindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            CustomerForm f = new CustomerForm(true, StateInformation);

            try
            {

                if (f.ShowDialog() == DialogResult.OK)
                {

                    Operations ops = new Operations();
                    int NewId = 0;

                    if (ops.AddCustomer(f.txtFirstName.Text, f.txtLastName.Text, f.txtAddress.Text, f.txtCity.Text, f.cboStates.Text, f.txtZipCode.Text,ref NewId))
                    {
                        var dt = ((DataSet)bsMaster.DataSource).Tables["Customer"];
                        dt.Rows.Add(new object[] { NewId, f.txtFirstName.Text, f.txtLastName.Text, f.txtAddress.Text, f.txtCity.Text, f.cboStates.Text, f.txtZipCode.Text });
                    }
                    else
                    {
                        MessageBox.Show($"Failed to add new row: {ops.ExceptionMessage}");
                    }
                }

            }
            finally
            {
                f.Dispose();
            }
        }
        /// <summary>
        /// Remove current customer and all orders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MasterBindingNavigatorDeleteCustomer_Click(object sender, EventArgs e)
        {
            if (KarenDialogs.Question("Do you really want to remove this customer and all their orders?"))
            {
                Operations ops = new Operations();
                int CustomerId = ((DataRowView)bsMaster.Current).Row.Field<int>("id");
                if (ops.RemoveCustomerAndOrders(CustomerId))
                {
                    bsMaster.RemoveCurrent();
                }
                else
                {
                    MessageBox.Show($"Failed to remove data{Environment.NewLine}{ops.ExceptionMessage}");
                }
            }
        }
        /// <summary>
        /// Update the order date for current row. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <remarks>
        /// It's possible that there are no changes but for this code sample there is no check.
        /// If you wanted to implement this refer to DataTable events to peek at the current and
        /// proposed value for, in this case the data column.
        /// See my code sample on this
        /// https://code.msdn.microsoft.com/Working-with-DataTable-2ff5f158
        /// </remarks>
        private void DetailsDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            var senderGrid = (DataGridView)sender;

            if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex >= 0)
            {
                if (bsDetails.Current != null)
                {

                    DateTime OrderDate = ((DataRowView)bsDetails.Current).Row.Field<DateTime>("OrderDate");
                    int OrderId = ((DataRowView)bsDetails.Current).Row.Field<int>("id");

                    Operations ops = new Operations();

                    if (!(ops.UpdateOrder(OrderId, OrderDate)))
                    {
                        MessageBox.Show($"Failed to update: {ops.ExceptionMessage}");
                    }

                }
            }
        }

        private void DetailsDataGridView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyData == Keys.Enter)
            {

                e.Handled = true;

                if (bsDetails.Current != null)
                {
                    OrderForm f = new OrderForm();
                    try
                    {
                        DateTime OrderDate = ((DataRowView)bsDetails.Current).Row.Field<DateTime>("OrderDate");
                        f.DateTimePicker1.Value = OrderDate;

                        if (f.ShowDialog() == DialogResult.OK)
                        {

                            OrderDate = f.DateTimePicker1.Value;

                            int OrderId = ((DataRowView)bsDetails.Current).Row.Field<int>("id");
                            Operations ops = new Operations();

                            if (!(ops.UpdateOrder(OrderId, OrderDate)))
                            {
                                MessageBox.Show($"Failed to update: {ops.ExceptionMessage}");
                            }
                            else
                            {
                                ((DataRowView)bsDetails.Current).Row.SetField<DateTime>("OrderDate", OrderDate);
                            }
                        }

                    }
                    finally
                    {
                        f.Dispose();
                    }

                }
            }
        }

        private void DetailsBindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            OrderForm f = new OrderForm();

            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    int id = 0;
                    int CurrentCustomerId = ((DataRowView)bsMaster.Current).Row.Field<int>("id");
                    string InvoiceValue = "";
                    Operations ops = new Operations();

                    ops.AddOrder(CurrentCustomerId, f.DateTimePicker1.Value,ref InvoiceValue,ref id);

                    if (!ops.HasErrors)
                    {
                        DataTable detailTable = ((DataSet)(((BindingSource)bsDetails.DataSource).DataSource)).Tables["Orders"];
                        detailTable.Rows.Add(new object[] { id, CurrentCustomerId, DateTime.Now, InvoiceValue });
                    }
                    else
                    {
                        MessageBox.Show(ops.ExceptionMessage);
                    }

                }
            }
            finally
            {
                f.Dispose();
            }
        }

        private void DetailsBindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (KarenDialogs.Question("Remove this order?"))
            {

                int OrderId = ((DataRowView)bsDetails.Current).Row.Field<int>("id");

                Operations ops = new Operations();

                if (!(ops.RemoveSingleOrder(OrderId)))
                {
                    MessageBox.Show($"Failed to update: {ops.ExceptionMessage}");
                }
                else
                {
                    bsDetails.RemoveCurrent();
                }

            }
        }


    }
    static class DataGridViewExtensionMethods
    {
        public static string[] RowsArray(this DataGridView sender)
        {
            return
                (
                    from row in sender.Rows.Cast<DataGridViewRow>()
                    where !row.IsNewRow
                    let RowItem = string.Join(",", Array.ConvertAll(row.Cells.Cast<DataGridViewCell>().ToArray(),
                    (DataGridViewCell c) => ((c.Value == null) ? "" : c.Value.ToString())))
                    select RowItem
                 ).ToArray();
        }


    }

}
