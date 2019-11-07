using System;
using System.Linq;
using System.Windows.Forms;

namespace ChatApp1._2.Forms
{
    public partial class FrmRegister : Form
    {
        public string RegisteredUserEmail { get; set; }
        public string RegisteredUserPassword { get; set; }

        public FrmRegister()
        {
            InitializeComponent();
        }

        private void FrmRegister_Load(object sender, EventArgs e)
        {

        }

        // Validate Input
        private void BtnLoginClick(object sender, EventArgs e)
        {
            if (tbEmailAddress.Text.Length > 0)
            {
                if (tbPassword.Text.Length > 0 && tbPassword.Text == tbConfirmPassword.Text)
                {
                    RegisteredUserEmail = tbEmailAddress.Text;
                    RegisteredUserPassword = tbPassword.Text.Replace(",", "");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Passwords are invalid or do not match");
                }
            }
            else
            {
                MessageBox.Show("Email Address is not Valid");
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
