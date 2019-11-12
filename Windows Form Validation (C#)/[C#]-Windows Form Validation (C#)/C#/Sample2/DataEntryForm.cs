using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace Sample2
{

    /// <summary>
    /// This is a very basic example for performing validation to 
    /// create a new person. In a real application we would may
    /// very well have more rules.
    /// 
    /// I set each TextBox Tag with information to use in the Validating
    /// process. 
    /// </summary>
    public partial class dataEntryForm : Form
    {

        public Person Person { get; set; }

        public dataEntryForm()
        {
            InitializeComponent();

            Shown += DataEntryForm_Shown;

            DataTable dtStates = new DataTable();
            var ops = new States();
            statesComboBox.DataSource = ops.Read();
            statesComboBox.DisplayMember = "Abbr";
            statesComboBox.ValueMember = "Id";

        }
        /// <summary>
        /// Setup key event for moving when user presses ENTER in any of the TextBoxes
        /// and subscribe to Validating event for all TextBoxes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataEntryForm_Shown(object sender, EventArgs e)
        {

            Controls.OfType<TextBox>()
                .ToList()
                .ForEach(ctr =>
                    {
                        ctr.KeyDown += Control_KeyDown;
                        ctr.Validating += TextBox_Validating;
                    }
           );

        }
        /// <summary>
        /// CauseValidation is set to true via the property window
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Click(object sender, EventArgs e)
        {
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                Person = new Person(
                    firstNameTextBox.Text,
                    lastNameTextBox.Text,
                    streetTextBox.Text,
                    cityTextBox.Text,
                    statesComboBox.Text,
                    postalCodeTextBox.Text);

                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Can not save without all required fields");
            }

        }
        /// <summary>
        /// Move to next control on ENTER key, prevent bell
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Control_KeyDown(object sender, KeyEventArgs e)
        {            
            if ((e.KeyCode == Keys.Enter) || (e.KeyCode == Keys.Return))
            {
                e.SuppressKeyPress = true;
                SelectNextControl((Control)sender, true, true, true, true);                
            }
        }
        /// <summary>
        /// Ensure the TextBox is not empty. There could be more rules for
        /// validation yet I wanted to keep this simple
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBox_Validating(object sender, CancelEventArgs e)
        {
            var tb = (TextBox)sender;
            
            if (tb.IsNullOrWhiteSpace())
            {
                //e.Cancel = true;
                //tb.Focus();
                errorProvider1.SetError(tb, $"{tb.Tag} is required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(tb, "");
            }
        }
        /// <summary>
        /// We loaded from a text file all states while the first record
        /// was tossed in for showing "Select". If the states came from
        /// a database table we would do something like (thinking SQL-Server)
        /// 
        /// dt.Rows.Add(new object[] { 0, "", "Select" });
        /// dt.Load(cmd.ExecuteReader())
        /// 
        /// or insert a row after the ExecuteRead and specify the original 
        /// row.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void statesComboBox_Validating(object sender, CancelEventArgs e)
        {
            if (statesComboBox.Text == "Select")
            {
                e.Cancel = true;
                statesComboBox.Focus();
                errorProvider1.SetError(statesComboBox, "State section required");
            }
            else
            {
                e.Cancel = false;
                errorProvider1.SetError(statesComboBox, "");
            }
        }
    }
}
