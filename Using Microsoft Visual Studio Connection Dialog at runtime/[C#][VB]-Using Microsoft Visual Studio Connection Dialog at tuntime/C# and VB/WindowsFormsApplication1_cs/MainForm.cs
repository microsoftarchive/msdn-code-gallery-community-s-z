using Microsoft.Data.ConnectionUI;
using System.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Windows.Forms;
using static System.Windows.Forms.CheckedListBox;

namespace WindowsFormsApplication1_cs
{
    /// <summary>
    /// Pleases note the buttons being enabled as we move forward
    /// is to ensure the operator of this demo does not go into
    /// an event and crash. For production usage you would need
    /// to control things as you see fit.
    /// </summary>
    public partial class MainForm : Form
    {
        public string ServerName { get; set; }
        public string InitialCatalog { get; set; }
        public MainForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Create connection string and show tables
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            button2.Enabled = false;
            button3.Enabled = false;


            var ops = new Operations();
            var dataSource = "";
            if (ops.GetConnection(ref dataSource ))
            {
                listBox1.DataSource = ops.TableNames;
                ServerName = ops.ServerName;
                InitialCatalog = ops.InitialCatalog;
                button2.Enabled = true;
            }
        }
        /// <summary>
        /// Show column names for selected table
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button2_Click(object sender, EventArgs e)
        {
            SetTableColumns();
        }
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            SetTableColumns();
        }
        private void SetTableColumns()
        {
            checkedListBox1.Items.Clear();
            var ops = new Operations();
            var columnInformation = ops.ColumnNameSelection(ServerName, InitialCatalog, listBox1.Text);
            foreach (var item in columnInformation)
            {
                checkedListBox1.Items.Add(item);
            }

            button3.Enabled = true;
            button4.Enabled = true;
        }
        /// <summary>
        /// Create a SELECT statement.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button3_Click(object sender, EventArgs e)
        {
            var columnInformation = new List<ColumnInformation>();
            for (int index = 0; index < checkedListBox1.Items.Count; index++)
            {
                if (checkedListBox1.GetItemChecked(index))
                {
                    columnInformation.Add(((ColumnInformation)checkedListBox1.Items[index]));
                }
            }

            var f = new SelectStatementForm();
            f.Statement = columnInformation.SelectStatement(listBox1.Text);
            try
            {
                f.ShowDialog();
            }
            finally
            {
                f.Dispose();
            }

        }
        private void closeButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {

            var columnInformation = GetColumnInformation();
            saveFileDialog1.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var ops = new Exporter();
                ops.ToCsv(ServerName, InitialCatalog, columnInformation.SelectStatement(listBox1.Text), saveFileDialog1.FileName);
            }
        }

        private List<ColumnInformation> GetColumnInformation()
        {
            var columnInformation = new List<ColumnInformation>();

            for (int index = 0; index < checkedListBox1.Items.Count; index++)
            {
                if (checkedListBox1.GetItemChecked(index))
                {
                    columnInformation.Add(((ColumnInformation)checkedListBox1.Items[index]));
                }
            }
            return columnInformation;
        }


    }
}
