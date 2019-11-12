//=======================================================================================
// Microsoft Windows Azure Customer Advisory Team (CAT) Best Practices Series
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://windowsazurecat.com/. 
//
//=======================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
namespace ScaleOutDemo.WebUI
{
    #region Using references
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Microsoft.WindowsAzure.ServiceRuntime;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Contracts.Data;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;
    #endregion

    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Configure default values.
                this.messageCountTextBox.Text = "0";
                this.publishAsyncCheckbox.Checked = true;
                this.enableAsyncDispatchCheckbox.Checked = true;
                this.requireTopicCleanupCheckbox.Checked = false;
                this.purgeTraceLogTableCheckbox.Checked = false;
            }
        }

        protected void generateTestRunID_Click(object sender, EventArgs e)
        {
            this.testRunIDTextBox.Text = Guid.NewGuid().ToString();
            this.panelInfo.Visible = false;
            this.panelException.Visible = false;
        }

        protected void startTestButton_Click(object sender, EventArgs e)
        {
            TraceManager.WebRoleComponent.TraceIn();

            try
            {
                TestRunStartEvent startEvent = new TestRunStartEvent()
                {
                    TestRunID = Guid.Parse(this.testRunIDTextBox.Text),
                    MessageCount = Convert.ToInt32(this.messageCountTextBox.Text),
                    MessageSize = Convert.ToInt32(this.messageSizeDropDown.Text),
                    EnableAsyncPublish = this.publishAsyncCheckbox.Checked,
                    EnableAsyncDispatch = this.enableAsyncDispatchCheckbox.Checked,
                    RequireTopicCleanup = this.requireTopicCleanupCheckbox.Checked,
                    PurgeTraceLogTable = this.purgeTraceLogTableCheckbox.Checked
                };

                var targetInstance = RoleEnvironment.Roles.Where(r => { return r.Value != RoleEnvironment.CurrentRoleInstance.Role; }).
                            SelectMany(i => i.Value.Instances).OrderBy(inst => { return CommonFuncs.GetRoleInstanceIndex(inst.Id); }).Take(1).
                            FirstOrDefault();

                TraceManager.WebRoleComponent.TraceInfo("Sending an unicast IRC event to role instance ID {0}", targetInstance.Id);

                var ircEvent = new InterRoleCommunicationEvent(startEvent, roleInstanceID: targetInstance.Id);
                Global.InterRoleCommunicator.Publish(ircEvent);

                this.panelInfo.Visible = true;
            }
            catch (Exception ex)
            {
                this.labelExceptionDetails.Text = ExceptionTextFormatter.Format(ex);
                this.panelException.Visible = true;
            }
        }
    }
}
