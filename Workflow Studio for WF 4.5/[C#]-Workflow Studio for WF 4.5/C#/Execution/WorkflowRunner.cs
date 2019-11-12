//-----------------------------------------------------------------------
// <copyright file="WorkflowRunner.cs" company="Microsoft Corporation">
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
    using System.Activities.XamlIntegration;
    using System.IO;
    using System.Text;
    using Microsoft.Consulting.WorkflowStudio.Properties;
    using Microsoft.Consulting.WorkflowStudio.Utilities;
    using Microsoft.Consulting.WorkflowStudio.ViewModel;

    public class WorkflowRunner : IWorkflowRunner
    {
        private TextWriter output;
        private WorkflowApplication workflowApplication;
        private bool running;
        private WorkflowDesigner workflowDesigner;

        private string workflowName;

        public WorkflowRunner(TextWriter output, string workflowName, WorkflowDesigner workflowDesigner)
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
            if (this.running && this.workflowApplication != null)
            {
                StatusViewModel.SetStatusText(Resources.AbortingStatus, this.workflowName);
                this.workflowApplication.Abort();
            }
        }

        public void Run()
        {
            this.workflowDesigner.Flush();
            MemoryStream ms = new MemoryStream(ASCIIEncoding.Default.GetBytes(this.workflowDesigner.Text));

            DynamicActivity activityToRun = ActivityXamlServices.Load(ms) as DynamicActivity;

            this.workflowApplication = new WorkflowApplication(activityToRun);

            this.workflowApplication.Extensions.Add(this.output);
            this.workflowApplication.Completed = this.WorkflowCompleted;
            this.workflowApplication.Aborted = this.WorkflowAborted;
            this.workflowApplication.OnUnhandledException = this.WorkflowUnhandledException;
            StatusViewModel.SetStatusText(Resources.RunningStatus, this.workflowName);

            try
            {
                this.running = true;
                this.workflowApplication.Run();
            }
            catch (Exception e)
            {
                this.output.WriteLine(ExceptionHelper.FormatStackTrace(e));
                StatusViewModel.SetStatusText(Resources.ExceptionStatus, this.workflowName);
                this.running = false;
            }
        }

        private void WorkflowCompleted(WorkflowApplicationCompletedEventArgs e)
        {
            this.running = false;
            StatusViewModel.SetStatusText(string.Format(Resources.CompletedStatus, e.CompletionState.ToString()), this.workflowName);
        }

        private void WorkflowAborted(WorkflowApplicationAbortedEventArgs e)
        {
            this.running = false;
            StatusViewModel.SetStatusText(Resources.AbortedStatus, this.workflowName);
        }

        private UnhandledExceptionAction WorkflowUnhandledException(WorkflowApplicationUnhandledExceptionEventArgs e)
        {
            Console.WriteLine(ExceptionHelper.FormatStackTrace(e.UnhandledException));
            return UnhandledExceptionAction.Terminate;
        }
    }
}
