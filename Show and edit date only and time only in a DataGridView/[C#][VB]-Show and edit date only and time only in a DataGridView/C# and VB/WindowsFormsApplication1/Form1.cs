using System;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        BindingSource bsData = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Read data from database table and setup for
        /// viewing data.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            DataOperations ops = new DataOperations();
            bsData.DataSource = ops.GetRows();

            DataGridView1.AutoGenerateColumns = false;
            DataGridView1.DataSource = bsData;
            Label1.DataBindings.Add("Text", bsData, "Identifier");
            DataGridView1.ExpandColumns();

            DataGridView1.CellEnter += DataGridView1_CellEnter;
        }
        /// <summary>
        /// Provides one click access to custom columns.
        /// This may or may not be something you want but wanted to 
        /// show how it can be done
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridView1_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            if (DataGridView1[e.ColumnIndex, e.RowIndex].EditType != null)
            {
                if (DataGridView1.IsCalendarCell(e) || DataGridView1.IsTimeCell(e))
                {
                    SendKeys.Send("{F2}");
                }
            }
        }
        /// <summary>
        /// Show field data for current row
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cmdShowRow_Click(object sender, EventArgs e)
        {
            MessageBox.Show(string.Join(Environment.NewLine, ((DataRowView)bsData.Current).Row.ItemArray));
        }

        private void cmdClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
