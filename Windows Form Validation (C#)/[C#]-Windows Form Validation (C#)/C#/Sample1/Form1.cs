using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sample1
{
    public partial class Form1 : Form
    {

        BindingSource bsPeople = new BindingSource();

        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Setup DataGridView, done so that there
        /// is no inline editing as we want all (in this case adding)
        /// operations done by pressing a button to invoke
        /// a form to make changes as this is the focus of the code
        /// sample.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
        /// <summary>
        /// Invoke our child form to add a new person
        /// </summary>
        private void addNewPerson()
        {
            var f = new dataEntryForm();
            if (f.ShowDialog() == DialogResult.OK)
            {
                bsPeople.Add(f.Person);
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
