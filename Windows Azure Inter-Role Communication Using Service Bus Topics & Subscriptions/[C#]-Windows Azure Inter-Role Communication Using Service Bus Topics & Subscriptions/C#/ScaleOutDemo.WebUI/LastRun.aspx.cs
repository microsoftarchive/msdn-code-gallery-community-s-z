using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;

namespace ScaleOutDemo.WebUI
{
    public partial class LastRun : System.Web.UI.Page
    {
        private const string NumberFormat = "F0";

        protected void Page_Load(object sender, EventArgs e)
        {
            TestRunFinishEvent finishEvent = HttpRuntime.Cache[CommonConsts.SessionKeyTestRunFinishEvent] as TestRunFinishEvent;

            if (finishEvent != null)
            {
                this.textBoxTestRunID.Text = finishEvent.TestRunID.ToString();
                this.textBoxDuration.Text = finishEvent.Duration.ToString();
                this.textBoxThroughput.Text = finishEvent.Throughput.ToString(NumberFormat);
                this.textBoxMinMulticastLatency.Text = finishEvent.MinMulticastLatency.ToString(NumberFormat);
                this.textBoxAvgMulticastLatency.Text = finishEvent.AvgMulticastLatency.ToString(NumberFormat);
                this.textBoxMaxMulticastLatency.Text = finishEvent.MaxMulticastLatency.ToString(NumberFormat);
                this.textBoxMinUnicastLatency.Text = finishEvent.MinUnicastLatency.ToString(NumberFormat);
                this.textBoxAvgUnicastLatency.Text = finishEvent.AvgUnicastLatency.ToString(NumberFormat);
                this.textBoxMaxUnicastLatency.Text = finishEvent.MaxUnicastLatency.ToString(NumberFormat);

                this.detailsPanel.Visible = true;
            }
            else
            {
                this.infoPanel.Visible = true;
            }
        }
    }
}