using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ChatClient.Properties;

namespace ChatClient
{
    public partial class FrmAddFriend : Form
    {

        public string FriendsEmailAddress { get; set; }
        public string MyEmailAddress { get; set; }
        public FrmAddFriend()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Get's the friends email address
        /// No Validation here, it needs to be added for production
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(tbFriendsEmailAddress.Text))
            {
                MessageBox.Show(Resources.YouMustEnterTheValidEmailAddressOfYourFriend);
            }
            else
            {
                FriendsEmailAddress = tbFriendsEmailAddress.Text;
                if (FriendsEmailAddress != MyEmailAddress)
                {
                    DialogResult = System.Windows.Forms.DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Resources.YouCanTAddYourselfAsAFriend);
                }
            }
        }

        /// <summary>
        /// The EU has changed their mind - or they don't have any friends!
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.Close();
        }
    }
}
