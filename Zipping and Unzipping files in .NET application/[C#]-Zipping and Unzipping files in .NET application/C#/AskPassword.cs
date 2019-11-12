using System;
using System.Windows.Forms;

namespace ArchiveManager
{
    public partial class AskPassword : Form
    {
        public AskPassword()
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
            }
        }

        bool _skip;
        public bool Skip
        {
            get { return _skip; }
            set { _skip = value; }
        }

        /// <summary>
        /// Gets a boolean value indicating whether to use the password for the entire archive.
        /// </summary>
        public bool UpdateArchivePassword
        {
            get
            {
                return chkUpdateArchivePassword.Checked;
            }
        }

        /// <summary>
        /// Gets or sets the archive file name.
        /// </summary>
        public string FileName
        {
            get { return lblFile.Text; }
            set { lblFile.Text = value; }
        }

        private void btnSkip_Click(object sender, EventArgs e)
        {
            _skip = true;
            DialogResult = DialogResult.OK;
        }
    }
}