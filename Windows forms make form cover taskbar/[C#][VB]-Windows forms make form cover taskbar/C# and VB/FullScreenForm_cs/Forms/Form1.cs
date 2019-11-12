using System;
using System.Windows.Forms;
using WinFormMaxLibrary;

namespace FullScreenForm_cs
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            StyleChanged += Form1_StyleChanged;
            FormClosing += Form1_FormClosing;
        }
        private void cmdChange_Click(object sender, EventArgs e)
        {

            if (cmdChange.Text == "Full")
            {

                cmdChange.Text = "Normal";

                this.FullScreen(chkTaskbar.Checked);

                if (chkTaskbar.Checked)
                {
                    this.FullScreen(true);
                }
            }
            else
            {
                cmdChange.Text = "Full";
                this.NormalMode();
            }
        }
        private void cmdShowChildForm_Click(object sender, EventArgs e)
        {
            childForm f = new childForm();
            bool TopMostSetting = this.TopMost;

            try
            {
                TopMost = false;
                f.ShowDialog();
            }
            finally
            {
                f.Dispose();
                TopMost = TopMostSetting;
            }
        }
        private void cmdDetect_Click(object sender, EventArgs e)
        {
            MessageBox.Show(WindowState.ToString());
        }
        private void Form1_StyleChanged(object sender, EventArgs e)
        {
            ListBox1.Items.Add(WindowState.ToString());
            ListBox1.SelectedIndex = ListBox1.Items.Count - 1;
        }
        private void cmdCloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.MainFormFullScreen == true)
            {
                this.FullScreen(true);
                cmdChange.Text = "Normal";
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
