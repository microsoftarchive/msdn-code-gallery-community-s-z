using System;
using System.Linq;
using System.Windows.Forms;


namespace ChatApp1._2.Forms
{
    public partial class FrmLogin : Form
    {
        public bool IsRegistered = false;
       public string Password { get; set; }
        public string EmailAddress { get; set; }

        public FrmLogin()
        {
            InitializeComponent();
        }

        private void LlRegisterLinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FrmRegister register = new FrmRegister();
            DialogResult dr = new DialogResult();
            dr = register.ShowDialog();

            if (dr == System.Windows.Forms.DialogResult.OK)
            {
                EmailAddress = register.RegisteredUserEmail;
                Password = register.RegisteredUserPassword;
                IsRegistered = true;
                this.Close();
            }
        }

        private void BtnLoginClick(object sender, EventArgs e)
        {
           if (!string.IsNullOrEmpty(tbEmailAddress.Text) || !string.IsNullOrWhiteSpace(tbEmailAddress.Text))
            {
                if (!string.IsNullOrEmpty(tbPassword.Text) || !string.IsNullOrWhiteSpace(tbPassword.Text))
                {
                    EmailAddress = tbEmailAddress.Text;
                    Password = tbPassword.Text;
                    
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Password is invalid");
                }
            }
            else
            {
                MessageBox.Show("Email Address is in valid");
            }
        }

        private void BtnCancelClick(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
