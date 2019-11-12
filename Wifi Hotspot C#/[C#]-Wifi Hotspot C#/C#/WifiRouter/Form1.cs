using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using System.Security.Principal;

namespace WifiRouter
{
    public partial class Form1 : Form
    {
        bool connect = false;
        public Form1()
        {
            
            InitializeComponent();
        }

        public static bool IsAdmin()
        {
            WindowsIdentity id = WindowsIdentity.GetCurrent();
            WindowsPrincipal p = new WindowsPrincipal(id);
            return p.IsInRole(WindowsBuiltInRole.Administrator);
        }
        public void RestartElevated()
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.CreateNoWindow = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = System.Windows.Forms.Application.ExecutablePath;
            startInfo.Verb = "runas";
            try
            {
                Process p = Process.Start(startInfo);
            }
            catch
            {

            }

            System.Windows.Forms.Application.Exit();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string ssid = textBox1.Text, key = textBox2.Text;
            if (!connect)
            {
                if (String.IsNullOrEmpty(textBox1.Text))
                {
                    MessageBox.Show("SSID cannot be left blank !",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    if (textBox2.Text == null || textBox2.Text == "")
                    {
                        MessageBox.Show("Key value cannot be left blank !",
                        "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        if (key.Length >= 6)
                        {
                            Hotspot(ssid, key, true);
                            textBox1.Enabled = false;
                            textBox2.Enabled = false;
                            button1.Text = "Stop";
                            connect = true;
                        }
                        else
                        {
                            MessageBox.Show("Key should be more then or Equal to 6 Characters !",
                            "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                }
            }
            else
            {
                Hotspot(null, null, false);
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                button1.Text = "Start";
                connect = false;
            }
        }
        private void Hotspot(string ssid, string key,bool status)
        {
            ProcessStartInfo processStartInfo = new ProcessStartInfo("cmd.exe");
            processStartInfo.RedirectStandardInput = true;
            processStartInfo.RedirectStandardOutput = true;
            processStartInfo.CreateNoWindow = true;
            processStartInfo.UseShellExecute = false;
            Process process = Process.Start(processStartInfo);

            if (process != null)
            {
                if (status)
                {
                    process.StandardInput.WriteLine("netsh wlan set hostednetwork mode=allow ssid=" + ssid + " key=" + key);
                    process.StandardInput.WriteLine("netsh wlan start hosted network");
                    process.StandardInput.Close();
                }
                else
                {
                    process.StandardInput.WriteLine("netsh wlan stop hostednetwork");
                    process.StandardInput.Close();
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!IsAdmin())
            {
                RestartElevated();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hotspot(null, null, false);
            Application.Exit();
        }
    }
}
