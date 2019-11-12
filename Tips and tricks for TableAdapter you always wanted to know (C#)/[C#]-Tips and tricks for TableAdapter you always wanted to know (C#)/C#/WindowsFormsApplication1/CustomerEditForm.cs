using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class CustomerEditForm : Form
    {
        NorthWindDataSet.CustomersRow customerRow;
        public CustomerEditForm()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Here we pass in a strong typed class which represents the current row in the master
        /// DataGridView and also a list of valid contact titles.
        /// </summary>
        /// <param name="pCustomerRow"></param>
        /// <param name="pTitles"></param>
        public CustomerEditForm(NorthWindDataSet.CustomersRow pCustomerRow, List<string> pTitles)
        {
            InitializeComponent();

            customerRow = pCustomerRow;

            companyNameTextBox.Text = customerRow.CompanyName;
            contactNameTextBox.Text = customerRow.ContactName;
            titleComboBox.DataSource = pTitles;
            titleComboBox.SelectedIndex = titleComboBox.FindString(customerRow.ContactTitle);
        }
        /// <summary>
        /// DialogResult = Ok, set in the property window of the button
        /// There is no validation here e.g. to see if company name, contact name or title are empty
        /// which we could easily implement.
        /// 
        /// For ideas on doing assertion/validation see my MSDN code sample
        /// https://code.msdn.microsoft.com/Windows-Form-Validation-C-7d7e6045
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void saveButton1_Click(object sender, EventArgs e)
        {
            customerRow.CompanyName = companyNameTextBox.Text;
            customerRow.ContactName = contactNameTextBox.Text;
            customerRow.ContactTitle = titleComboBox.Text;
        }
    }
}
