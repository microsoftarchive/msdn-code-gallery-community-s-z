using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample2
{
    public partial class Form1 : Form
    {
        BindingSource bsPeople = new BindingSource();
        DataTable dtStates = new DataTable();
        public Form1()
        {
            InitializeComponent();
            var ops = new States();
            dtStates = ops.Read();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // columns have been defined in the IDE 
            dgvPeople.AutoGenerateColumns = false;

            // we are starting w/o any data
            bsPeople.DataSource = new List<Person>();

            bindingNavigator1.BindingSource = bsPeople;
            dgvPeople.DataSource = bsPeople;
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            addNewPerson();
        }
        private void addNewPerson()
        {
            // use custom provider
            if (useExtendedProviderCheckBox.Checked)
            {
                var f = new dataEntryForm1();
                if (f.ShowDialog() == DialogResult.OK)
                { 
                    bsPeople.Add(f.Person);
                }
            }
            else
            {
                // use in form validation
                var f = new dataEntryForm();
                if (f.ShowDialog() == DialogResult.OK)
                {
                    bsPeople.Add(f.Person);
                }
            }

        }
        private void addButton_Click(object sender, EventArgs e)
        {
            addNewPerson();
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We are not interested in delete for this sampple");
        }
    }
}
