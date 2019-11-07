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
    public partial class FrmLogin : Form
    {
        public bool IsRegistered { get; set; }
        public string Password { get; set; }
        public string EmailAddress { get; set; }

        public FrmLogin()
        {
            InitializeComponent();
            this.IsRegistered = false; // This is changed if the EU clicks the Register link and successfully registers
        }

        /// <summary>
        /// Cancel the login process
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Add your own validation just as it was done in the AzureDB Login Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(this.tbEmailAddress.Text) && !string.IsNullOrWhiteSpace(this.tbPassword.Text))
            {

                this.EmailAddress = tbEmailAddress.Text;
                this.Password = tbPassword.Text.Replace(",", "");

                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();

            }
            else
            {
                MessageBox.Show("Login details are in valid");
            }
        }

        /// <summary>
        /// Let the EU Register from here.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void llRegister_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegister register = new FrmRegister();
            DialogResult dr = new DialogResult();
            dr = register.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                this.EmailAddress = register.RegisteredUserEmail;
                this.Password = register.RegisteredUserPassword.Replace(",", "");
                this.IsRegistered = true;
                this.Close();
            }
            else
            {
                this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.Close();
            }
        }
    }
}
