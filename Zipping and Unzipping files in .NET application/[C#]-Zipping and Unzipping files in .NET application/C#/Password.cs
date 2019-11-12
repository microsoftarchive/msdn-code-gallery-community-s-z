using System;
using System.Windows.Forms;
using ComponentPro.Compression;

namespace ArchiveManager
{
    public partial class Password : Form
    {
        public Password()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Gets or sets the archive's password.
        /// </summary>
        public string Pass
        {
            get
            {
                return txtPassword.Text;
            }
            set
            {
                txtPassword.Text = value;
                txtReenter.Text = value;
            }
        }        

        /// <summary>
        /// Gets or sets the encryption algorithm.
        /// </summary>
        public EncryptionAlgorithm EncryptionAlgorithm
        {
            get 
            {
                if (txtPassword.Text.Length == 0)
                    return EncryptionAlgorithm.None;

                switch (cboEncryption.SelectedIndex)
                {
                    case 0:
                        return EncryptionAlgorithm.PkzipClassic;

                    case 1:
                        return EncryptionAlgorithm.Aes128;

                    case 2:
                        return EncryptionAlgorithm.Aes192;

                    default:
                        return EncryptionAlgorithm.Aes256;
                }
            }
            set
            {
                switch (value)
                {
                    case EncryptionAlgorithm.None:
                    case EncryptionAlgorithm.PkzipClassic:
                        cboEncryption.SelectedIndex = 0; break;

                    case EncryptionAlgorithm.Aes128:
                        cboEncryption.SelectedIndex = 1; break;

                    case EncryptionAlgorithm.Aes192:
                        cboEncryption.SelectedIndex = 2; break;

                    case EncryptionAlgorithm.Aes256:
                        cboEncryption.SelectedIndex = 3; break;
                }                
            }
        }

        /// <summary>
        /// Handles the OK button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Check passwords.
            if (txtReenter.Text != txtPassword.Text)
            {
                MessageBox.Show("Reentered password does not match with password!", "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult = DialogResult.OK;
        }
    }
}