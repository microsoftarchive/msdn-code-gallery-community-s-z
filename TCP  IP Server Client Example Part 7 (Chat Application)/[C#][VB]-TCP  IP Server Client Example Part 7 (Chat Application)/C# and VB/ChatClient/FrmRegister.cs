using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChatClient
{
    public partial class FrmRegister : Form
    {
        public string RegisteredUserEmail { get; set; }
        public string RegisteredUserPassword { get; set; } // We have hard coded all passwords to pass to speed up debugging

        public FrmRegister()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Allow user to Register and Login Simultaneously
        /// Add your own Error Validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Allow user to Register and Login Simultaneously
        /// Add your own Error Validation
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (this.tbEmailAddress.Text.Length > 0 && this.tbPassword.Text.Length > 0 && this.tbPassword.Text == this.tbConfirmPassword.Text)
            {
                this.RegisteredUserEmail = this.tbEmailAddress.Text;
                this.RegisteredUserPassword = this.tbPassword.Text.Replace(",", ""); // Remove ',' (commas) from passwords as it could invalidate with our messages
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show("Registration Details are not Valid");
            }
        }
    }
}
