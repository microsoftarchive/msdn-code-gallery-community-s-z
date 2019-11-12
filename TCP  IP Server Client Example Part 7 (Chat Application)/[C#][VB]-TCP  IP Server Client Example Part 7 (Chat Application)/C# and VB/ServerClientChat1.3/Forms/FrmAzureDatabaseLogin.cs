using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ServerClientChat1._3.Forms
{
    public partial class FrmAzureDatabaseLogin : Form
    {

        public string ServerName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }

        public FrmAzureDatabaseLogin()
        {
            InitializeComponent();
            ProcessCheckedState();

#if DEBUG   // Only show the buttons we need depending upon the running mode.
            btnLoad.Enabled = true;
            btnLoad.Visible = true;
            btnCancel.Enabled = false;
            btnCancel.Visible = false;
            btnConnect.Visible = false;
            btnConnect.Enabled = false;

#else
            btnLoad.Enabled = true;
            btnLoad.Visible = true;
            btnCancel.Enabled = true;
            btnCancel.Visible = true;
            btnConnect.Visible = true;
            btnConnect.Enabled = true;
#endif
        }

        /// <summary>
        /// Validate the Server name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbServername_Validating(object sender, CancelEventArgs e)
        {
            ServerName = tbServername.Text.Replace("tcp:", "").Trim(); // Remove the tcp: if there and any extra spaces
#if DEBUG
            // Get Results from the Load Button
            // If we do not use the Compile Time constants the ErrorProvider stops us from using the Load Button.
#else
             if (string.IsNullOrWhiteSpace(ServerName))
            {
                errorProvider1.SetError(tbServername, "Server name cannot be empty");
                e.Cancel = true; // Don't move to next control
            }
            else
            {
                if (!ServerName.Contains(','))
                {
                    errorProvider1.SetError(tbServername, "Add , then the port to be used."); // We should check that the name does not end in , but I will leave that to you to work out how to validate that.
                    e.Cancel = true; // Don't move to next control
                }
                else
                {
                    errorProvider1.Clear(); // We don't need to show the Error icon now if it is showing
                    e.Cancel = false; // move to next control
                }
            }
#endif
        }

        /// <summary>
        /// Validate the User name
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbUsername_Validating(object sender, CancelEventArgs e)
        {
#if DEBUG
            // Get values from Load Button
#else
             if (string.IsNullOrWhiteSpace(tbUsername.Text))
            {
                errorProvider1.SetError(tbUsername, "User name cannot be empty");
                e.Cancel = true; // Don't move to next control
            }
            else
            {
                UserName = tbUsername.Text.Trim(); // Make sure there are no extra spaces.
                errorProvider1.Clear(); // We don't need to show the Error icon now if it is showing
                e.Cancel = false; // move to next control
            }
#endif
        }

        /// <summary>
        /// Validate the User's Password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tbPassword_Validating(object sender, CancelEventArgs e)
        {
#if DEBUG
            // Get Values from Load button.
#else
            if (string.IsNullOrWhiteSpace(tbPassword.Text))
            {
                errorProvider1.SetError(tbPassword, "Password name cannot be empty");
                e.Cancel = true; // Don't move to next textbox
            }
            else
            {
                Password = tbPassword.Text.Trim(); // Make sure there are no extra spaces.
                errorProvider1.Clear(); // We don't need to show the Error icon now if it is showing
                e.Cancel = false; // move to next control
            }
#endif
        }

        /// <summary>
        /// User canceled connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Make the Connection
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnect_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.OK;
            this.Close();
        }

        private void cbRememberForThisSession_CheckedChanged(object sender, EventArgs e)
        {
            ProcessCheckedState();
        }

        private void ProcessCheckedState()
        {
            if (cbRememberForThisSession.Checked)
            {
                tbServername.Text = ServerName;
                tbUsername.Text = UserName;
                tbPassword.Text = Password;
            }
        }

        /// <summary>
        /// Loads the User Connection Details from a File called ChatAzureDB.txt located in My Documents
        /// The file contains three lines
        /// Line 1 Server Details: xxxxxxxxxx.database.windows.net,1433
        /// Line 2 User Name     : YourUserName@xxxxxxxxxx
        /// Line 3 Plain text Password: xxxxxxxxxxxxxxxxxx
        /// 
        /// This is only to aid us in Debugging and SHOULD NOT BE USED IN PRODUCTION
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLoad_Click(object sender, EventArgs e)
        {
            try
            {
                string path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path = Path.Combine(path, "ChatAzureDB.txt");

                FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                StreamReader sr = new StreamReader(fs);

                ServerName = sr.ReadLine();
                UserName = sr.ReadLine();
                Password = sr.ReadLine();

                sr.Close();
                fs.Close();
                DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load Configuration File: " + ex.Message);
            }

        }
    }
}
