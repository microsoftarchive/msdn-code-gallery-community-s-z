using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Operations_cs;

namespace WindowsFormsApplication1_cs
{
    public partial class Form1 : Form
    {
        List<string> Statuses;
        SortableBindingList<TestTable> blCustomers = new SortableBindingList<TestTable>();
        BindingSource bsItem = new BindingSource();

        public Form1()
        {
            InitializeComponent();
            bsItem.PositionChanged += bsItem_PositionChanged;
        }
        /// <summary>
        /// Upate status for current row. If not located which 
        /// is possible if you stick by the 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bsItem_PositionChanged(object sender, EventArgs e)
        {
            if (bsItem.CurrentRowIsValid())
            {
                statusComboBox.SelectedIndex = statusComboBox.FindString(bsItem.Status());
            }
        }

        /// <summary>
        /// Load data into DataGridView, in a real app we would had used a DataGridViewComboBox
        /// for the status but that is outside the scope of this code sample. If interested I 
        /// have one here https://code.msdn.microsoft.com/DataGridView-ComboBox-with-b62fe359 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            var ops = new Operations();

            Statuses = ops.StatusList();
            statusComboBox.DataSource = Statuses;

            // Setup for sorting
            blCustomers = new SortableBindingList<TestTable>(ops.Read());

            // Bind to the BindingList
            bsItem.DataSource = blCustomers;

            dataGridView1.AutoGenerateColumns = false;
            // Set DataGridView DataSource
            dataGridView1.DataSource = bsItem;
            // Expand columns
            dataGridView1.ExpandColumns();

        }
        /// <summary>
        /// Update current row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void updateCurrentButton_Click(object sender, EventArgs e)
        {

            var currentRow = ((TestTable)bsItem.Current);

            currentRow.OrderStatus = statusComboBox.Text;

            // update database table
            var ops = new Operations();
            await ops.UpdateItem(currentRow);
            // update DataGridView cell
            dataGridView1.CurrentRow.Cells["OrderApprovalDateTimeColumn"].Value = ops.GetApprovalDate(currentRow);

        }
        /// <summary>
        /// Prepare for update
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void changeStatusButton_Click(object sender, EventArgs e)
        {
            dataGridView1.CurrentRow.Cells["OrderStatusColumn"].Value = statusComboBox.Text;
            dataGridView1.CurrentRow.Cells["OrderApprovalDateTimeColumn"].Value = null;
        }
        /// <summary>
        /// Get grouped OrderStatus
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1StatusGrouped_Click(object sender, EventArgs e)
        {
            var ops = new Operations();
            MessageBox.Show(ops.GroupedStatus());
        }
    }
}
