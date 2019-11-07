using System;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Place a valid email address here to send a message to them
        /// </summary>
        private string RecipientAddress = "";

        public Form1()
        {
            InitializeComponent();
        }

        private async void sendHtmlMessageButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(RecipientAddress))
            {
                DemoSendMessage demo = new DemoSendMessage();
                await demo.SendMessage(
                    RecipientAddress,
                    "Test",
                    "Hello world\n\n<p>This is a test to send an <strong>email</strong> via app.config settings.",
                    chkSendToPickupFolder.Checked,
                    true);
            }
            else
            {
                MessageBox.Show("Requires an email address to sent a messag to.");
            }
        }

        private async void sendPlainTextMessageButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(RecipientAddress))
            {
                DemoSendMessage demo = new DemoSendMessage();
                await demo.SendMessage(
                    RecipientAddress,
                    "Test",
                    "Hello world\n\nThis is a test to send an email via app.config settings.",
                    chkSendToPickupFolder.Checked,
                    false);
            }
            else
            {
                MessageBox.Show("Requires an email address to sent a messag to.");
            }
        }

        /// <summary>
        /// Used to clean up pickup folder.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pickupFolderCleaner_Click(object sender, EventArgs e)
        {
            DemoSendMessage demo = new DemoSendMessage();
            demo.CleanPickupFolder();
        }
    }
}