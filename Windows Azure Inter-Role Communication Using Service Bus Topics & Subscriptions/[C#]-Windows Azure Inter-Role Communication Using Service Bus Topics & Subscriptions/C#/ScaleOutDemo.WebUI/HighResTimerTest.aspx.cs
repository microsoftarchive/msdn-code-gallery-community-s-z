using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;
using System.Threading;

using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;

namespace ScaleOutDemo.WebUI
{
    public partial class HighResTimerTest : System.Web.UI.Page
    {
        private const int delayMs = 5000;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.hiResTimerSupported.Text = HighResolutionTimer.IsHighResolution.ToString();
            this.hiResTimerFrequency.Text = HighResolutionTimer.Frequency.ToString();
            this.stopwatchFrequency.Text = Stopwatch.Frequency.ToString();
            this.currentTickCount.Text = HighResolutionTimer.CurrentTickCount.ToString();
            this.currentDateTimeTickCount.Text = DateTime.UtcNow.Ticks.ToString();

            Stopwatch timer = Stopwatch.StartNew();
            Thread.Sleep(delayMs);
            
            delayWithStopwatch.Text = timer.ElapsedMilliseconds.ToString();
            
            timer.Stop();
            
            long start = HighResolutionTimer.CurrentTickCount;
            Thread.Sleep(delayMs);

            delayWithHiResTimer.Text = HighResolutionTimer.Current.GetElapsedMilliseconds(start).ToString();
        }
    }
}