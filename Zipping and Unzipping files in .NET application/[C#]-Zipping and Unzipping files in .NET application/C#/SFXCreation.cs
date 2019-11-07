using System;
using System.Windows.Forms;

namespace ArchiveManager
{
    public partial class SFXCreation : Form
    {
        public SFXCreation(string stubFileName, string sfxOutputFileName)
        {
            InitializeComponent();

            txtName.Text = stubFileName;
            txtSfx.Text = sfxOutputFileName;
        }

        /// <summary>
        /// Gets the desired Stub file name.
        /// </summary>
        public string StubFileName
        {
            get
            {
                return txtName.Text;
            }
            set
            {
                txtName.Text = value;
            }
        }

        /// <summary>
        /// Gets the desired SFX file name.
        /// </summary>
        public string SfxFileName
        {
            get
            {
                return txtSfx.Text;
            }
            set
            {
                txtSfx.Text = value;
            }
        }

        /// <summary>
        /// Handles the OK button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOk_Click(object sender, EventArgs e)
        {
#if false
            // Check for invalid characters.
            if (StubFileName.Contains("/") || StubFileName.Contains("\\"))
            {
                MessageBox.Show(Messages.InvalidCharacters, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            if (SfxFileName.Contains("/") || SfxFileName.Contains("\\"))
            {
                MessageBox.Show(Messages.InvalidCharacters, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
#endif

            this.DialogResult = DialogResult.OK;
        }

        private void btnStubFile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select an SFX stub file";
                dlg.FileName = txtName.Text;
                dlg.Filter = "All files|*.*";
                dlg.FilterIndex = 1;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtName.Text = dlg.FileName;
                }
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        private void btnBrowseSfx_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog dlg = new OpenFileDialog();
                dlg.Title = "Select an SFX file";
                dlg.FileName = txtSfx.Text;
                dlg.Filter = "All files|*.*";
                dlg.FilterIndex = 1;
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtSfx.Text = dlg.FileName;
                }
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }
    }
}