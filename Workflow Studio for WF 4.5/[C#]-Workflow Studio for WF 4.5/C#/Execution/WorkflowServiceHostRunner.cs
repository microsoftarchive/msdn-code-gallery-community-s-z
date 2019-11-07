//-----------------------------------------------------------------------
// <copyright file="WorkflowServiceHostRunner.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio.Execution
{
    using System;
    using System.Activities.Presentation;
    using System.IO;
    using System.ServiceModel.Activities;
    using System.Text;
    using System.Xaml;
    using Microsoft.Consulting.WorkflowStudio.Properties;
    using Microsoft.Consulting.WorkflowStudio.Utilities;
    using Microsoft.Consulting.WorkflowStudio.ViewModel;

    public class WorkflowServiceHostRunner : IWorkflowRunner
    {
        private TextWriter output;
        private WorkflowServiceHost workflowServiceHost;
        private bool running;
        private WorkflowDesigner workflowDesigner;
        private string workflowName;

        public WorkflowServiceHostRunner(TextWriter output, string workflowName, WorkflowDesigner workflowDesigner)
        {
            this.output = output;
            this.workflowName = workflowName;
            this.workflowDesigner = workflowDesigner;
        }

        public bool IsRunning
        {
            get
            {
                return this.running;
            }
        }

        public void Abort()
        {
            if (this.running && this.workflowServiceHost != null)
            {
                StatusViewModel.SetStatusText(Resources.AbortingServiceHostStatus, this.workflowName);
                this.workflowServiceHost.Abort();
            }
        }

        public void Run()
        {
            this.workflowDesigner.Flush();
            MemoryStream ms = new MemoryStream(ASCIIEncoding.Default.GetBytes(this.workflowDesigner.Text));

            WorkflowService workflowToRun = XamlServices.Load(ms) as WorkflowService;

            this.workflowServiceHost = new WorkflowServiceHost(workflowToRun);

            this.workflowServiceHost.WorkflowExtensions.Add(this.output);
            try
            {
                this.AddHandlers();
                this.running = true;
                this.workflowServiceHost.Open();
            }
            catch (Exception e)
            {
                this.output.WriteLine(ExceptionHelper.FormatStackTrace(e));
                StatusViewModel.SetStatusText(Resources.ExceptionServiceHostStatus, this.workflowName);
                this.running = false;
            }
        }

        private void WorkflowServiceHost_Closed(object sender, EventArgs e)
        {
            this.running = false;
            this.RemoverHandlers();
            StatusViewModel.SetStatusText(Resources.ClosedServiceHostStatus, this.workflowName);
        }

        private void WorkflowServiceHost_Opened(object sender, EventArgs e)
        {
            StatusViewModel.SetStatusText(Resources.OpenServiceHostStatus, this.workflowName);
        }

        private void WorkflowServiceHost_Faulted(object sender, EventArgs e)
        {
            this.running = false;
            this.RemoverHandlers();
            StatusViewModel.SetStatusText(Resources.FaultedServiceHostStatus, this.workflowName);
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
