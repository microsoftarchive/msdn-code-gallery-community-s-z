using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Demo_cs
{
    public partial class Form1 : Form
    {
        private BindingSource bsCustomer = new BindingSource();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var ops = new Operations();
            if (ops.GetCustomers())
            {
                bsCustomer.DataSource = ops.CustomersTable;
                
                bindingNavigator1.BindingSource = bsCustomer;

                dataGridView1.DataSource = bsCustomer;

                dataGridView1.Columns["FirstName"].HeaderText = "First";
                dataGridView1.Columns["LastName"].HeaderText = "Last";
            }

        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            var Cust = new Customer();
            var f = new EditorForm(ref Cust);
            
            try
            {
                if (f.ShowDialog() == DialogResult.OK)
                {
                    var ops = new Operations();
                    if (ops.AddCustomer(ref Cust))
                    {
                        bsCustomer.DataTable().Rows.Add(new object[] {Cust.id, Cust.FirstName, Cust.LastName, Cust.CityIdentifier,Cust.StateIdentifer,Cust.City,Cust.State });
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
    }
}
