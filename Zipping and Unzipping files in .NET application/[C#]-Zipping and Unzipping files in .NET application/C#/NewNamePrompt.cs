using System;
using System.Windows.Forms;

namespace ArchiveManager
{
    public partial class NewNamePrompt : Form
    {
        public NewNamePrompt(string oldName)
        {
            InitializeComponent();

            txtNewName.Text = oldName;
        }

        /// <summary>
        /// Gets the desired new name.
        /// </summary>
        public string NewName
        {
            get
            {
                return txtNewName.Text;
            }
            set
            {
                txtNewName.Text = value;
            }
        }

        /// <summary>
        /// Gets the desired new name caption.
        /// </summary>
        public string NewNameCaption
        {
            get
            {
                return lbl.Text;
            }
            set
            {
                lbl.Text = value;
            }
        }

        bool _rename = true;
        /// <summary>
        /// Gets the desired new name caption.
        /// </summary>
        public bool Rename
        {
            get
            {
                return _rename;
            }
            set
            {
                _rename = value;
            }
        }

        /// <summary>
        /// Handles the OK button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            if (_rename)
            {
                // Check for invalid characters.
                if (NewName.Contains("/") || NewName.Contains("\\"))
                {
                    MessageBox.Show(Messages.InvalidCharacters, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return;
                }
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}