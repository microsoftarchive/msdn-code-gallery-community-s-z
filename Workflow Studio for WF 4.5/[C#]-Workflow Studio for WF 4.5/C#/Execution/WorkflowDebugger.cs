//-----------------------------------------------------------------------
// <copyright file="WorkflowDebugger.cs" company="Microsoft Corporation">
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
    using System.Collections.Generic;
    using System.IO;
    using System.Text;
    using Microsoft.Consulting.WorkflowStudio.Properties;
    using Microsoft.Consulting.WorkflowStudio.Utilities;
    using Microsoft.Consulting.WorkflowStudio.ViewModel;

    public class WorkflowDebugger : WorkflowDebuggerBase
    {
        private WorkflowApplication workflowApplication;

        public WorkflowDebugger(TextWriter output, string workflowName, WorkflowDesigner workflowDesigner, bool disableDebugViewOutput)
            : base(output, workflowName, workflowDesigner, disableDebugViewOutput)
        {
        }

        public override void Abort()
        {
            if (this.running && this.workflowApplication != null)
            {
                StatusViewModel.SetStatusText(Resources.AbortingInDebugStatus, this.workflowName);
                this.workflowApplication.Abort();
            }
        }

        protected override void LoadAndExecute()
        {
            MemoryStream ms = new MemoryStream(ASCIIEncoding.Default.GetBytes(this.workflowDesigner.Text));
            DynamicActivity workflowToRun = ActivityXamlServices.Load(ms) as DynamicActivity;

            WorkflowInspectionServices.CacheMetadata(workflowToRun);

            this.workflowApplication = new WorkflowApplication(workflowToRun);

            this.workflowApplication.Extensions.Add(this.output);

            this.workflowApplication.Completed = this.WorkflowCompleted;
            this.workflowApplication.OnUnhandledException = this.WorkflowUnhandledException;
            this.workflowApplication.Aborted = this.WorkflowAborted;

            this.workflowApplication.Extensions.Add(this.InitialiseVisualTrackingParticipant(workflowToRun));

            try
            {
                this.running = true;
                this.workflowApplication.Run();
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

            IEnumerator<Activity> enumerator1 = WorkflowInspectionServices.GetActivities(root).GetEnumerator();

            // Get the first child
            enumerator1.MoveNext();
            root = enumerator1.Current;
            return root;
        }

        private void WorkflowCompleted(WorkflowApplicationCompletedEventArgs e)
        {
            this.running = false;
            StatusViewModel.SetStatusText(string.Format(Resources.CompletedInDebugStatus, e.CompletionState.ToString()), this.workflowName);
        }

        private void WorkflowAborted(WorkflowApplicationAbortedEventArgs e)
        {
            this.running = false;
            StatusViewModel.SetStatusText(Resources.AbortedInDebugStatus, this.workflowName);
        }

        private UnhandledExceptionAction WorkflowUnhandledException(WorkflowApplicationUnhandledExceptionEventArgs e)
        {
            Console.WriteLine(ExceptionHelper.FormatStackTrace(e.UnhandledException));
            return UnhandledExceptionAction.Terminate;
        }
    }
}
