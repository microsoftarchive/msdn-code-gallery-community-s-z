using DataGridViewExtensionMethods;
using System;
using System.Data;
using System.Windows.Forms;
using SharedFileOperations;
using WindowsFormsApplication1.Properties;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        private BindingSource bsCustomers = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }
        private void cmdAddNewRow_Click(object sender, EventArgs e)
        {

            if (!(string.IsNullOrWhiteSpace(txtCompanyName.Text)))
            {
                DataOperations DataOps = new DataOperations();
                int NewId = 0;
                if (DataOps.AddNewCustomer(txtCompanyName.Text, ref NewId))
                {
                    ((DataTable)bsCustomers.DataSource).Rows.Add(new object[] { NewId, txtCompanyName.Text });
                    bsCustomers.Position = bsCustomers.Find("Identifier", NewId);
                }
                else
                {
                    MessageBox.Show("Failed to add new company");
                }
            }
            else
            {
                MessageBox.Show("Enter data into the textbox to add a row");
                ActiveControl = txtCompanyName;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(FileOperations.DatabaseLocation(Settings.Default.ConnectionString)))
            {
                cmdAddNewRow.Enabled = false;
                MessageBox.Show("Database not located");
            }
            else
            {
                DataOperations DataOps = new DataOperations();
                bsCustomers.DataSource = DataOps.GetCustomers();
                DataGridView1.DataSource = bsCustomers;
                DataGridView1.ExpandColumns();
                bsCustomers.Sort = "CompanyName";
                ActiveControl = txtCompanyName;
            }
        }
    }
}