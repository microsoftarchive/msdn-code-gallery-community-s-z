//-----------------------------------------------------------------------
// <copyright file="WorkflowServiceHostDebugger.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio.Execution
{
    using System;
    using System.Activities;
    using System.Activities.Presentation;
    using System.IO;
    using System.ServiceModel.Activities;
    using System.Text;
    using System.Xaml;
    using Microsoft.Consulting.WorkflowStudio.Properties;
    using Microsoft.Consulting.WorkflowStudio.Utilities;
    using Microsoft.Consulting.WorkflowStudio.ViewModel;

    public class WorkflowServiceHostDebugger : WorkflowDebuggerBase
    {
        private WorkflowServiceHost workflowServiceHost;

        public WorkflowServiceHostDebugger(TextWriter output, string workflowName, WorkflowDesigner workflowDesigner, bool disableDebugViewOutput)
            : base(output, workflowName, workflowDesigner, disableDebugViewOutput)
        {
        }

        public override void Abort()
        {
            if (this.running && this.workflowServiceHost != null)
            {
                StatusViewModel.SetStatusText(Resources.AbortingInDebugStatus, this.workflowName);
                this.workflowServiceHost.Abort();
            }
        }

        protected override void LoadAndExecute()
        {
            MemoryStream ms = new MemoryStream(ASCIIEncoding.Default.GetBytes(this.workflowDesigner.Text));
            WorkflowService workflowToRun = XamlServices.Load(ms) as WorkflowService;

            this.workflowServiceHost = new WorkflowServiceHost(workflowToRun);
            this.workflowServiceHost.WorkflowExtensions.Add(this.output);
            this.workflowServiceHost.WorkflowExtensions.Add(this.InitialiseVisualTrackingParticipant(workflowToRun.GetWorkflowRoot()));
            this.AddHandlers();

            try
            {
                this.running = true;
                this.workflowServiceHost.Open();
            }
            catch (Exception e)
            {
                this.output.WriteLine(ExceptionHelper.FormatStackTrace(e));
                StatusViewModel.SetStatusText(Resources.ExceptionInDebugStatus, this.workflowName);
            }
        }

        protected override Activity GetRootRuntimeWorkflowElement(Activity root)
        {
            WorkflowInspectionServices.CacheMetadata(root);
            return root;
        }

        private void WorkflowServiceHost_Closed(object sender, EventArgs e)
        {
            this.running = false;
            this.RemoverHandlers();
            StatusViewModel.SetStatusText(Resources.ClosedServiceHostInDebugStatus, this.workflowName);
        }

        private void WorkflowServiceHost_Opened(object sender, EventArgs e)
        {
            StatusViewModel.SetStatusText(Resources.OpenServiceHostInDebugStatus, this.workflowName);
        }

        private void WorkflowServiceHost_Faulted(object sender, EventArgs e)
        {
            this.running = false;
            this.RemoverHandlers();
            StatusViewModel.SetStatusText(Resources.FaultedServiceHostInDebugStatus, this.workflowName);
        }

        private void AddHandlers()
        {
            this.workflowServiceHost.Closed += new EventHandler(this.WorkflowServiceHost_Closed);
            this.workflowServiceHost.Opened += new EventHandler(this.WorkflowServiceHost_Opened);
            this.workflowServiceHost.Faulted += new EventHandler(this.WorkflowServiceHost_Faulted);
        }

        private void RemoverHandlers()
        {
            this.workflowServiceHost.Closed += new EventHandler(this.WorkflowServiceHost_Closed);
            this.workflowServiceHost.Opened += new EventHandler(this.WorkflowServiceHost_Opened);
            this.workflowServiceHost.Faulted += new EventHandler(this.WorkflowServiceHost_Faulted);
        }
    }
}
