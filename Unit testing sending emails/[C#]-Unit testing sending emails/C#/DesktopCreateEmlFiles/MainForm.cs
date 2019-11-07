using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopCreateEmlFiles
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            var dataOps = new DataOperations();

            // get email addresses
            var adresses1 = dataOps.GetEmailAddresses();
            var adresses2 = adresses1.DeepClone();

            foreach (CheckListBoxItem item in adresses2)
            {
                checkedListBox2.Items.Add(item);
            }
            foreach (CheckListBoxItem item in adresses1)
            {
                checkedListBox1.Items.Add(item);
            }

            // get templates from SQL-Server
            cboBodies.DataSource = dataOps.GetEmailBodies();
            cboBodies.DisplayMember = "Text";

            checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
            checkedListBox2.ItemCheck += CheckedListBox2_ItemCheck;
        }

        private void CheckedListBox2_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                ((CheckListBoxItem)checkedListBox2.Items[e.Index]).Checked = true;
            }
            else
            {
                ((CheckListBoxItem)checkedListBox2.Items[e.Index]).Checked = false;
            }
        }
        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            if (e.NewValue == CheckState.Checked)
            {
                ((CheckListBoxItem)checkedListBox1.Items[e.Index]).Checked = true;
            }
            else
            {
                ((CheckListBoxItem)checkedListBox1.Items[e.Index]).Checked = false;
            }

        }
        private void cboBodies_SelectedIndexChanged(object sender, EventArgs e)
        {
            webBrowser1.DocumentText = ((EmailBody)cboBodies.SelectedItem).Body;
        }
        private List<string> GetToAddresses()
        {
            var ToAddresses = new List<string>();
            for (int index = 0; index < checkedListBox1.Items.Count; index++)
            {
                var item = ((CheckListBoxItem)checkedListBox1.Items[index]);
                if (item.Checked)
                {
                    ToAddresses.Add(item.EmailAddress);
                }
            }

            return ToAddresses;
        }
        private List<string> GetCcAddresses()
        {
            var ccAddresses = new List<string>();
            for (int index = 0; index < checkedListBox2.Items.Count; index++)
            {
                var item = ((CheckListBoxItem)checkedListBox2.Items[index]);
                if (item.Checked)
                {
                    ccAddresses.Add(item.EmailAddress);
                }
            }

            return ccAddresses;
        }
        private void sendButton_Click(object sender, EventArgs e)
        {
            var ToAddresses = GetToAddresses();
            var ccAddresses = GetCcAddresses();

            if (ToAddresses.Count >0  && !string.IsNullOrWhiteSpace(txtSubject.Text) && !string.IsNullOrWhiteSpace(txtFromAddress.Text) && !(webBrowser1.DocumentText == "<HTML></HTML>"))
            {
                MailOperations mo = new MailOperations();
                mo.CleanEml();
                mo.ToList = ToAddresses;
                if (ccAddresses.Count() >0)
                {
                    mo.ccList = ccAddresses;
                }
                mo.Subject = txtSubject.Text;
                mo.Body = webBrowser1.DocumentText;
                Task.Run(() => mo.Send()).Wait();
            }
            else
            {
                MessageBox.Show("Missing stuff");
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Process.Start(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"MailDrop"));
        }
    }
}
/*
 * Console.WriteLine($"{checkedListBox1.Items.Cast<CheckListBoxItem>().Where(item => item.Checked).Count()}");
 * Console.WriteLine($"{checkedListBox2.Items.Cast<CheckListBoxItem>().Where(item => item.Checked).Count()}");
 */
