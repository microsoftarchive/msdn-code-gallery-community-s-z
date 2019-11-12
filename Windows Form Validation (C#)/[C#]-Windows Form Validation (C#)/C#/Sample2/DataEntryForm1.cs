using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Noogen.Validation;

namespace Sample2
{
    public partial class dataEntryForm1 : Form
    {
        public Person Person { get; set; }
        public dataEntryForm1()
        {
            InitializeComponent();
            Shown += DataEntryForm_Shown;

            DataTable dtStates = new DataTable();
            var ops = new States();
            statesComboBox.DataSource = ops.Read();
            statesComboBox.DisplayMember = "Abbr";
            statesComboBox.ValueMember = "Id";

            // Code Project custom validator
            ValidationRule vr = new ValidationRule();
            vr.CustomValidationMethod += vr_CustomValidationMethod;
            validationProvider1.SetValidationRule(statesComboBox, vr);

        }
        /// <summary>
        /// State ComboBox I've manually setup the validation rule while all other
        /// controls I setup validation directly in the control property window.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void vr_CustomValidationMethod(object sender, CustomValidationEventArgs e)
        {
            e.IsValid = !e.Value.ToString().Equals("Select");
            e.ErrorMessage = "Needs a valid state";         
        }
        private void DataEntryForm_Shown(object sender, EventArgs e)
        {
            Controls.OfType<TextBox>()
                .ToList()
                .ForEach(ctr =>  ctr.KeyDown += Control_KeyDown
           );
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
        private void SaveButton_Click(object sender, EventArgs e)
        {
            // if there are validation rules not met results will have them, otherwise results is an empty string.
            var results  = this.validationProvider1.ValidationMessages(!this.validationProvider1.Validate());
            if (results.IsNullOrWhiteSpace())
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
        }
    }
}
