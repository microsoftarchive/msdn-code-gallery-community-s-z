using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ThreadSleepTaskDelayDemo
{
    public partial class Form1 : Form
    {
        CancellationTokenSource tokenSource = new CancellationTokenSource();

        public Form1()
        {
            InitializeComponent();
        }

        private void btnThreadSleep_Click(object sender, EventArgs e)
        {
            PutThreadSleep();
            MessageBox.Show("I am back");
        }

        private async void btnTaskDelay_Click(object sender, EventArgs e)
        {
            await PutTaskDelay();
            MessageBox.Show("I am back");
        }

        void PutThreadSleep()
        {
            Thread.Sleep(5000);
        }

        async Task PutTaskDelay()
        { 
            try
            {
                await Task.Delay(5000, tokenSource.Token);
            }
            catch (TaskCanceledException ex)
            {
                
            }
            catch (Exception ex)
            { 
            
            }
        }

        private void btnCancelTaskDelay_Click(object sender, EventArgs e)
        {
            tokenSource.Cancel();
        }
    }
}
