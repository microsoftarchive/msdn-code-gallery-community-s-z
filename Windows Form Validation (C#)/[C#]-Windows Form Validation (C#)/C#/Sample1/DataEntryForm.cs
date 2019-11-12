using System;
using System.Linq;
using System.Windows.Forms;

namespace Sample1
{
    /// <summary>
    /// DialogResult is set for the cancel button in the property window for
    /// the cancel button.
    /// </summary>
    public partial class dataEntryForm : Form
    {
        public Person Person { get; set; }
        public dataEntryForm()
        {
            InitializeComponent();
            Shown += DataEntryForm_Shown;
        }
        /// <summary>
        /// Setup key event for moving when user presses ENTER in any of the TextBoxes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataEntryForm_Shown(object sender, EventArgs e)
        {
            Controls.OfType<TextBox>()
                .ToList()
                .ForEach(ctr => ctr.KeyDown += Control_KeyDown);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            // We only see if each TextBox are not empty. For some this may be okay while
            // in other cases not so, especially when dealing with some required and some
            // not required or perhaps when we have other type of controls e.g. ComboBox etc.
            if (Controls.OfType<TextBox>().Any(tb => string.IsNullOrWhiteSpace(tb.Text)))
            {
                MessageBox.Show("All fields are required");
                return;
            }

            Person = new Person(
                firstNameTextBox.Text, 
                lastNameTextBox.Text, 
                streetTextBox.Text, 
                cityTextBox.Text, 
                stateTextBox.Text, 
                postalCode.Text);

            DialogResult = DialogResult.OK;

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
    }
}
