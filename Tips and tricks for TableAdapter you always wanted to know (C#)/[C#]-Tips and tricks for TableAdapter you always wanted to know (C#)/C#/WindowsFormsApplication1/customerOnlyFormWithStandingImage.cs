using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApplication1.ExtensionMethods;

namespace WindowsFormsApplication1
{
    public partial class customerOnlyFormWithStandingImage : Form
    {
        public customerOnlyFormWithStandingImage()
        {
            InitializeComponent();
            customerWithStandingDataGridView.SelectionChanged += CustomerWithStandingDataGridView_SelectionChanged;
        }
        /// <summary>
        /// This event is for disallowing the selection for the image cells.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CustomerWithStandingDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (customerWithStandingDataGridView.Columns[customerWithStandingDataGridView.CurrentCell.ColumnIndex].Name == "standingsImageColumn")
                customerWithStandingDataGridView.CurrentCell.Selected = false;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.customerWithStandingTableAdapter.Fill(this.northWindDataSet.CustomerWithStanding);
            customerWithStandingDataGridView.ExpandColumns();
        }

        private void customerWithStandingBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not enabled for this code sample!");
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not enabled for this code sample!");
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not enabled for this code sample!");
        }
    }
}
