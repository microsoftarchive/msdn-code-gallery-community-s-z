//-----------------------------------------------------------------------
// <copyright file="WorkflowDebuggerBase.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio.Execution
{
    using System;
    using System.Activities;
    using System.Activities.Debugger;
    using System.Activities.Presentation;
    using System.Activities.Presentation.Debug;
    using System.Activities.Presentation.Services;
    using System.Activities.Tracking;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Diagnostics;
    using System.IO;
    using System.Threading;
    using System.Windows;
    using System.Windows.Controls;
    using Microsoft.Consulting.WorkflowStudio.Properties;
    using Microsoft.Consulting.WorkflowStudio.Utilities;
    using Microsoft.Consulting.WorkflowStudio.ViewModel;

    public abstract class WorkflowDebuggerBase : IWorkflowDebugger
    {
        protected TextWriter output;
        protected IDesignerDebugView debuggerService;
        protected WorkflowDesigner workflowDesigner;
        protected IList<SourceLocationDebugItem> sourceLocations;
        protected Dictionary<int, SourceLocation> textLineToSourceLocationMap;
        protected bool running;
        protected int sourceLocationSteppedCount;
        protected int pauseBetweenDebugStepsInMilliseconds = 1000;
        protected bool disableDebugViewOutput = false;
        protected DataGrid debugView;
        protected string workflowName;
        protected TraceSource debugTraceSource;
        protected TraceSource allDebugTraceSource;

        public WorkflowDebuggerBase(TextWriter output, string workflowName, WorkflowDesigner workflowDesigner, bool disableDebugViewOutput)
        {
            this.output = output;
            this.workflowDesigner = workflowDesigner;
            this.workflowName = workflowName;

            this.debugView = new DataGrid();
            this.debugView.IsReadOnly = true;
            this.debugView.SelectionMode = DataGridSelectionMode.Single;

            this.debugView.SelectionChanged += delegate(object sender, SelectionChangedEventArgs args)
            {
                this.HighlightActivity(this.debugView.SelectedIndex);
            };

            this.disableDebugViewOutput = disableDebugViewOutput;
            this.debugTraceSource = new TraceSource(Path.GetFileNameWithoutExtension(workflowName) + "Debug");
            this.allDebugTraceSource = new TraceSource("AllDebug");

            ConfigurationManager.RefreshSection("appSettings");

            string pauseBetweenDebugStepsInMillisecondsValue = ConfigurationManager.AppSettings["PauseBetweenDebugStepsInMilliseconds"];
            if (!string.IsNullOrEmpty(pauseBetweenDebugStepsInMillisecondsValue))
            {
                this.pauseBetweenDebugStepsInMilliseconds = int.Parse(pauseBetweenDebugStepsInMillisecondsValue);
            }
        }

        public IList<SourceLocationDebugItem> SourceLocations
        {
            get
            {
                return this.sourceLocations;
            }
        }

        public bool IsRunning
        {
            get
            {
                return this.running;
            }
        }

        public UIElement GetDebugView()
        {
            return this.debugView;
        }

        public abstract void Abort();

        public void Run()
        {
            this.workflowDesigner.Flush();

            this.debuggerService = this.workflowDesigner.DebugManagerView;

            StatusViewModel.SetStatusText(Resources.DebuggingStatus, this.workflowName);

            this.sourceLocations = new List<SourceLocationDebugItem>();
            this.textLineToSourceLocationMap = new Dictionary<int, SourceLocation>();
            this.sourceLocationSteppedCount = 0;

            try
            {
                this.LoadAndExecute();
            }
            catch (Exception e)
            {
                this.output.WriteLine(ExceptionHelper.FormatStackTrace(e));
                StatusViewModel.SetStatusText(Resources.ExceptionInDebugStatus, this.workflowName);
                this.running = false;
            }
        }

        public void HighlightActivity(int selectedRowNumber)
        {
            DispatcherService.Dispatch(() =>
            {
                try
                {
                    if (selectedRowNumber >= 0 && selectedRowNumber < textLineToSourceLocationMap.Count)
                    {
                        this.workflowDesigner.DebugManagerView.CurrentLocation = textLineToSourceLocationMap[selectedRowNumber];
                    }
                }
                catch (Exception)
                {
                    // If the user clicks other than on the tracking records themselves.
                    this.workflowDesigner.DebugManagerView.CurrentLocation = new SourceLocation("Workflow.xaml", 1, 1, 1, 10);
                }
            });
        }

        protected VisualTrackingParticipant InitialiseVisualTrackingParticipant(Activity workflowToRun)
        {
            // Mapping between the object and Line No.
            Dictionary<object, SourceLocation> elementToSourceLocationMap = this.UpdateSourceLocationMappingInDebuggerService(workflowToRun);

            // Mapping between the object and the Instance Id
            Dictionary<string, Activity> activityIdToElementMap = this.BuildactivityIdToElementMap(elementToSourceLocationMap);

            // Setup custom tracking
            const string All = "*";
            VisualTrackingParticipant simTracker = new VisualTrackingParticipant()
            {
                TrackingProfile = new TrackingProfile()
                {
                    Name = "CustomTrackingProfile",
                    Queries = 
                        {
                            new CustomTrackingQuery() 
                            {
                                Name = All,
                                ActivityName = All
                            },
                            new WorkflowInstanceQuery()
                            {
                                // Limit workflow instance tracking records for started and completed workflow states
                                States = { WorkflowInstanceStates.Started, WorkflowInstanceStates.Completed },
                            },
                            new ActivityStateQuery()
                            {
                                // Subscribe for track records from all activities for all states
                                ActivityName = All,
                                States = { All },

                                // Extract workflow variables and arguments as a part of the activity tracking record
                                // VariableName = "*" allows for extraction of all variables in the scope
                                // of the activity
                                Variables = 
                                {                                
                                    { All }   
                                }
                            }   
                        }
                }
            };

            simTracker.ActivityIdToWorkflowElementMap = activityIdToElementMap;

            // As the tracking events are received
            simTracker.TrackingRecordReceived += (trackingParticpant, trackingEventArgs) =>
            {
                if (trackingEventArgs.Activity != null)
                {
                    ShowDebug(elementToSourceLocationMap[trackingEventArgs.Activity]);

                    Thread.Sleep(this.pauseBetweenDebugStepsInMilliseconds);

                    SourceLocationDebugItem debugItem = new SourceLocationDebugItem()
                    {
                        ActivityName = trackingEventArgs.Activity.DisplayName,
                        Id = trackingEventArgs.Activity.Id,
                        State = ((ActivityStateRecord)trackingEventArgs.Record).State,
                        StepCount = sourceLocationSteppedCount,
                        InstanceId = ((ActivityStateRecord)trackingEventArgs.Record).InstanceId
                    };

                    this.debugTraceSource.TraceData(
                        TraceEventType.Information,
                        0,
                        trackingEventArgs.Activity.DisplayName,
                        trackingEventArgs.Activity.Id,
                            ((ActivityStateRecord)trackingEventArgs.Record).State,
                        sourceLocationSteppedCount,
                        ((ActivityStateRecord)trackingEventArgs.Record).InstanceId);

                    this.allDebugTraceSource.TraceData(
                        TraceEventType.Information,
                        0,
                        Path.GetFileNameWithoutExtension(this.workflowName),
                        trackingEventArgs.Activity.DisplayName,
                        trackingEventArgs.Activity.Id,
                            ((ActivityStateRecord)trackingEventArgs.Record).State,
                        sourceLocationSteppedCount,
                        ((ActivityStateRecord)trackingEventArgs.Record).InstanceId);

                    sourceLocationSteppedCount++;

                    if (!this.disableDebugViewOutput)
                    {
                        this.textLineToSourceLocationMap.Add(this.sourceLocations.Count, elementToSourceLocationMap[trackingEventArgs.Activity]);
                        this.sourceLocations.Add(debugItem);

                        DispatcherService.Dispatch(() =>
                        {
                            debugView.ItemsSource = this.SourceLocations;
                            debugView.Items.Refresh();
                        });
                    }
                }
            };

            return simTracker;
        }

        protected abstract void LoadAndExecute();

        protected abstract Activity GetRootRuntimeWorkflowElement(Activity root);

        private void ShowDebug(SourceLocation srcLoc)
        {
            DispatcherService.Dispatch(() =>
            {
                this.workflowDesigner.DebugManagerView.CurrentLocation = srcLoc;
            });
        }

        private Dictionary<string, Activity> BuildactivityIdToElementMap(Dictionary<object, SourceLocation> elementToSourceLocationMap)
        {
            Dictionary<string, Activity> map = new Dictionary<string, Activity>();

            Activity workflowElement;
            foreach (object instance in elementToSourceLocationMap.Keys)
            {
                workflowElement = instance as Activity;
                if (workflowElement != null)
                {
                    map.Add(workflowElement.Id, workflowElement);
                }
            }

            return map;
        }

        private Dictionary<object, SourceLocation> UpdateSourceLocationMappingInDebuggerService(Activity root)
        {
            object rootInstance = this.GetRootInstance();
            Dictionary<object, SourceLocation> sourceLocationMapping = new Dictionary<object, SourceLocation>();
            Dictionary<object, SourceLocation> designerSourceLocationMapping = new Dictionary<object, SourceLocation>();

            if (rootInstance != null)
            {
                Activity documentRootElement = this.GetRootWorkflowElement(rootInstance);
                SourceLocationProvider.CollectMapping(
                    this.GetRootRuntimeWorkflowElement(root), 
                    documentRootElement, 
                    sourceLocationMapping,
                    this.workflowDesigner.Context.Items.GetValue<WorkflowFileItem>().LoadedFile);
                SourceLocationProvider.CollectMapping(
                   documentRootElement,
                   documentRootElement,
                   designerSourceLocationMapping,
                   this.workflowDesigner.Context.Items.GetValue<WorkflowFileItem>().LoadedFile);
            }

            // Notify the DebuggerService of the new sourceLocationMapping.
            // When rootInstance == null, it'll just reset the mapping.
            if (this.debuggerService != null)
            {
                ((DebuggerService)this.debuggerService).UpdateSourceLocations(designerSourceLocationMapping);
            }

            return sourceLocationMapping;
        }

        private object GetRootInstance()
        {
            ModelService modelService = this.workflowDesigner.Context.Services.GetService<ModelService>();
            if (modelService != null)
            {
                return modelService.Root.GetCurrentValue();
            }
            else
            {
                return null;
            }
        }

        private Activity GetRootWorkflowElement(object rootModelObject)
        {
            // Get root WorkflowElement.  Currently only handle when the object is ActivitySchemaType or WorkflowElement.
            // May return null if it does not know how to get the root activity.
            Debug.Assert(rootModelObject != null, "Cannot pass null as rootModelObject");

            Activity rootWorkflowElement;
            IDebuggableWorkflowTree debuggableWorkflowTree = rootModelObject as IDebuggableWorkflowTree;
            if (debuggableWorkflowTree != null)
            {
                rootWorkflowElement = debuggableWorkflowTree.GetWorkflowRoot();
            }
            else 
            {
                // Loose xaml case.
                rootWorkflowElement = rootModelObject as Activity;
            }

            return rootWorkflowElement;
        }
    }
}
