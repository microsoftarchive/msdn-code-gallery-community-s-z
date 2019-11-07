using System;
using System.Windows.Forms;

namespace Example_cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string databaseFileNameMdb = "..\\..\\..\\Databases\\Database1.mdb";
            string databaseFileNameAccdb = "..\\..\\..\\Databases\\Database1.accdb";

            DataOperations demo = new DataOperations(databaseFileNameMdb);
            demo.LoadCustomers();

            ListBox1.DisplayMember = "CompanyName";
            ListBox1.DataSource = demo.CustomerTable;

            demo = new DataOperations(databaseFileNameAccdb);
            demo.LoadCustomers();

            ListBox2.DisplayMember = "CompanyName";
            ListBox2.DataSource = demo.CustomerTable;
        }
    }
}
