using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataOperations;

namespace WindowsApplication_cs
{
    public partial class CustomerForm : Form
    {
        private bool inAddMode;
        private List<StateItems> stateItems;
        private DataRow CustomerRow;
        //currentRow
        private List<TextBox> formTextBoxes = new List<TextBox>();
        public CustomerForm(bool AddMode, List<StateItems> stateInfo, ref DataRow currentRow)
        {
            InitializeComponent();
            inAddMode = AddMode;
            stateItems = stateInfo;
            CustomerRow = currentRow;
        }
        public CustomerForm(bool AddMode, List<StateItems> stateInfo)
        {
            InitializeComponent();
            inAddMode = AddMode;
            stateItems = stateInfo;
        }
        public CustomerForm()
        {
            InitializeComponent();
        }

        private void CustomerForm_Load(object sender, EventArgs e)
        {
            formTextBoxes.AddRange(Controls.OfType<TextBox>().ToArray());

            cboStates.DataSource = stateItems;
            cboStates.DisplayMember = "Name";

            if (inAddMode)
            {
                Text = "Adding new customer";
            }
            else
            {
                Text = "Editing current customer";

                txtFirstName.Text = CustomerRow.Field<string>("FirstName");
                txtLastName.Text = CustomerRow.Field<string>("LastName");
                txtAddress.Text = CustomerRow.Field<string>("Address");
                txtCity.Text = CustomerRow.Field<string>("City");
                txtZipCode.Text = CustomerRow.Field<string>("ZipCode");

                string currentState = CustomerRow.Field<string>("State");

                var customerState = stateItems
                    .Select((data, index) => new { Index = index, Name = data.Name })
                    .Where((data) => data.Name == CustomerRow.Field<string>("State"))
                    .FirstOrDefault();

                if (currentState != null)
                {
                    cboStates.SelectedIndex = customerState.Index;
                }
            }

        }

        private void cmdAccept_Click(object sender, EventArgs e)
        {
            if (formTextBoxes.Where((textBox) => string.IsNullOrWhiteSpace(textBox.Text)).Any() || cboStates.SelectedIndex == 0)
            {
                MessageBox.Show("To save a record all fields must have information along with selecting a state.");
                return;
            }
            else
            {
                if (!inAddMode)
                {
                    // remember we pass the data row by ref so these changes take affect to the UI but not the backend database table
                    // so we will handle this in the mainform.
                    CustomerRow.SetField<string>("FirstName", txtFirstName.Text);
                    CustomerRow.SetField<string>("LastName", txtLastName.Text);
                    CustomerRow.SetField<string>("Address", txtAddress.Text);
                    CustomerRow.SetField<string>("City", txtCity.Text);
                    CustomerRow.SetField<string>("State", cboStates.Text);
                    CustomerRow.SetField<string>("ZipCode", txtZipCode.Text);

                }

                DialogResult = DialogResult.OK;

            }

        }

        private void Button2_Click(object sender, EventArgs e)
        {
           
            if (CustomerRow != null)
            {
                CustomerRow.RejectChanges();
            }

            DialogResult = DialogResult.Cancel;
        }
    }
}
