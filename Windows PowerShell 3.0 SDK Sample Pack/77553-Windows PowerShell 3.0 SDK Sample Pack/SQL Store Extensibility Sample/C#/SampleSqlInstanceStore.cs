// <copyright file="AssemblyInfo.cs" company="Microsoft Corporation">
// Copyright (c) 2012 Microsoft Corporation. All rights reserved.
// </copyright>
// DISCLAIMER OF WARRANTY: The software is licensed “as-is.” You 
// bear the risk of using it. Microsoft gives no express warranties, 
// guarantees or conditions. You may have additional consumer rights 
// under your local laws which this agreement cannot change. To the extent 
// permitted under your local laws, Microsoft excludes the implied warranties 
// of merchantability, fitness for a particular purpose and non-infringement.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.PowerShell.Workflow;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Runtime.DurableInstancing;
using System.Activities.Persistence;
using System.Activities.DurableInstancing;
using System.Runtime.Serialization;
using System.Management.Automation;
using System.Collections.ObjectModel;
using System.Activities.XamlIntegration;
using System.Xml.Linq;

namespace SQLStoreExtensibilitySample
{
    public class SampleSqlInstanceStore : PSWorkflowInstanceStore
    {
        #region Constructor

        // Class constructor. The reference to the PSWorkflowConfigurationProvider must be available to the class to access configuration properties.
        // The workflow instance reference provides access to the instance ID and properties during load and save operations.
        public SampleSqlInstanceStore(PSWorkflowConfigurationProvider configuration, PSWorkflowInstance instance, string connectionString)
            : base(instance)
        {
            _configuration = configuration;
            this._connectionString = connectionString;

            this._psWorkflowStore = new SqlOperations(connectionString);
        }

        #endregion

        #region Store Logic
        
        // This method should be overriden by the drived class.
        // This method defines the storing of all of the components of the data.
        protected override void DoSave(IEnumerable<object> components)
        {
            foreach (object component in components)
            {
                Type componentType = component.GetType();

                if (componentType == typeof(PowerShellStreams<PSObject, PSObject>))
                {
                    // store the workflow streams.
                    StoreStreams((PowerShellStreams<PSObject, PSObject>)component);
                }
                else if (componentType == typeof(PSWorkflowContext))
                {
                    // Store the workflow job context that contains the metadata information.
                    StoreMetadata((PSWorkflowContext)component);
                }
                else if (componentType == typeof(PSWorkflowDefinition))
                {
                    // Store the worflow XAML definition.
                    StoreObject(((PSWorkflowDefinition)component).WorkflowXaml, "Definition");
                }
                else if (componentType == typeof(PSWorkflowTimer))
                {
                    // Store workflow timer information.
                    StoreTimer((PSWorkflowTimer)component);
                }
                else if (componentType == typeof(JobState))
                {
                    // Store workflow job state, for example 'running', 'stopped' or 'completed'.
                    StoreObject((JobState)component, "JobState");
                }
                else if (componentType == typeof(Exception))
                {
                    // Store the exception in case of error.
                    StoreObject(component, "TerminatingError");
                }
            }
        }

        #endregion

        #region Load Logic
        
        protected override IEnumerable<object> DoLoad(IEnumerable<Type> typeComponents)
        {
            Collection<object> loadedComponents = new Collection<object>();

            foreach (Type componentType in typeComponents)
            {
                if (componentType == typeof(PSWorkflowContext))
                {
                    // Load the job context that contains the metadata for the workflow.
                    loadedComponents.Add(LoadMetadata());
                }
                else if (componentType == typeof(JobState))
                {
                    // Load the job state.
                    JobState state = (JobState)LoadObject("JobState");
                    if (state != JobState.Stopped && state != JobState.Failed && state != JobState.Completed)
                    {
                        // If the state is not terminal state, then the state should be suspended.
                        // This is very important, because we want to resume the job if it was not in completed state.
                        // The resumed job will only work if the job is in suspended state.
                        state = JobState.Suspended;
                    }

                    loadedComponents.Add(state);
                }
                else if (componentType == typeof(PSWorkflowDefinition))
                {
                    // Load the workflow definition.
                    loadedComponents.Add(LoadDefinition());
                }
                else if (componentType == typeof(Exception))
                {
                    // Load the error exception if there is an error.
                    loadedComponents.Add(LoadObject("TerminatingError"));
                }
                else if (componentType == typeof(PowerShellStreams<PSObject, PSObject>))
                {
                    // Load the stream from the persistence store.
                    loadedComponents.Add(LoadStreams());
                }
                else if (componentType == typeof(PSWorkflowTimer))
                {
                    // Load the timer information from the store.
                    var timerState = LoadObject("Timer");
                    loadedComponents.Add(new PSWorkflowTimer(this.PSWorkflowInstance, timerState));
                }
            }

            return loadedComponents;
        }

        #endregion

        # region Delete Logic

        // You must implement this method, because when RemoveJob is called, the database entry is removed.
        protected override void DoDelete()
        {
            _psWorkflowStore.DeleteState(this.InstanceId);
        }

        #endregion

        #region Serialization/Deserialization Logic

        // In this example we are using a data contract serializer to serialize the data.
        private ArraySegment<byte> SerializeObject(object source)
        {
            XmlObjectSerializer serializer = new NetDataContractSerializer();
            MemoryStream outputStream = new MemoryStream();
            serializer.WriteObject(outputStream, source);

            return new ArraySegment<byte>(outputStream.GetBuffer(), 0, (int)outputStream.Length);
        }

        // In this example we are using data contract serializer to deserialize the data.
        private object DeserializeObject(ArraySegment<byte> source)
        {
            XmlObjectSerializer serializer = new NetDataContractSerializer();
            MemoryStream inputStream = new MemoryStream(source.Array, source.Offset, source.Count);
            return serializer.ReadObject(inputStream);
        }

        #endregion

        # region private variables and functions

        private PSWorkflowConfigurationProvider _configuration;
        private readonly string _connectionString;
        private readonly SqlOperations _psWorkflowStore;
        private Guid InstanceId
        {
            get { return this.PSWorkflowInstance.InstanceId.Guid; }
        }
        private Guid JobId
        {
            get { return this.PSWorkflowInstance.PSWorkflowJob.InstanceId; }
        }

        private void StoreObject(object obj, string name)
        {
            var serialized = SerializeObject(obj);
            this._psWorkflowStore.StoreState(this.InstanceId, name, serialized);
        }

        private void StoreStreams(PowerShellStreams<PSObject, PSObject> streams)
        {
            StoreObject(streams.InputStream, "Stream.Input");
            StoreObject(streams.OutputStream, "Stream.Output");
            StoreObject(streams.ErrorStream, "Stream.Error");
            StoreObject(streams.WarningStream, "Stream.Warning");
            StoreObject(streams.VerboseStream, "Stream.Verbose");
            StoreObject(streams.ProgressStream, "Stream.Progress");
            StoreObject(streams.DebugStream, "Stream.Debug");
        }

        private void StoreMetadata(PSWorkflowContext metadata)
        {
            StoreObject(metadata.WorkflowParameters, "Metadata.Input");
            StoreObject(metadata.PSWorkflowCommonParameters, "Metadata.UbiquitousInput");
            StoreObject(metadata.JobMetadata, "Metadata.JobMetadata");
            StoreObject(metadata.PrivateMetadata, "Metadata.PrivateMetadata");
        }

        private void StoreTimer(PSWorkflowTimer timer)
        {
            StoreObject(timer.GetSerializedData(), "Timer");
        }

        private PSWorkflowDefinition LoadDefinition()
        {
            string xamlDefinition = (string)this.LoadObject("Definition");

            System.Activities.Activity activity = ActivityXamlServices.Load(new StringReader(xamlDefinition));
            PSWorkflowDefinition workflowDefinition = new PSWorkflowDefinition(activity, xamlDefinition, null);

            return workflowDefinition;
        }

        private PSWorkflowContext LoadMetadata()
        {
            PSWorkflowContext metadata = new PSWorkflowContext();
            metadata.WorkflowParameters = (Dictionary<string, object>)LoadObject("Metadata.Input");
            metadata.PSWorkflowCommonParameters = (Dictionary<string, object>)LoadObject("Metadata.UbiquitousInput");
            metadata.JobMetadata = (Dictionary<string, object>)LoadObject("Metadata.JobMetadata");
            metadata.PrivateMetadata = (Dictionary<string, object>)LoadObject("Metadata.PrivateMetadata");
            return metadata;
        }

        private PowerShellStreams<PSObject, PSObject> LoadStreams()
        {
            var stream = new PowerShellStreams<PSObject, PSObject>(null);

            var inputStream = (PSDataCollection<PSObject>)LoadObject("Stream.Input");
            var tmpInputStream = new PSDataCollection<PSObject>();
            Append(inputStream, tmpInputStream);
            tmpInputStream.Complete();
            stream.InputStream = tmpInputStream;

            var outputStream = (PSDataCollection<PSObject>)LoadObject("Stream.Output");
            foreach (PSObject psobject in outputStream)
            {
                stream.OutputStream.Add(PSObject.AsPSObject(psobject));
            }

            var errorStream = (PSDataCollection<ErrorRecord>)LoadObject("Stream.Error");
            Append(errorStream, stream.ErrorStream);

            var warningStream = (PSDataCollection<WarningRecord>)LoadObject("Stream.Warning");
            Append(warningStream, stream.WarningStream);

            var verboseStream = (PSDataCollection<VerboseRecord>)LoadObject("Stream.Verbose");
            Append(verboseStream, stream.VerboseStream);

            var progressStream = (PSDataCollection<ProgressRecord>)LoadObject("Stream.Progress");
            Append(progressStream, stream.ProgressStream);

            var debugStream = (PSDataCollection<DebugRecord>)LoadObject("Stream.Debug");
            Append(debugStream, stream.DebugStream);
            return stream;
        }

        private object LoadObject(string name)
        {
            var serialized = this._psWorkflowStore.LoadState(this.InstanceId, name);
            if (!serialized.HasValue)
                return null;

            return DeserializeObject(serialized.Value);
        }

        public override InstanceStore CreateInstanceStore()
        {
            return new SqlWorkflowInstanceStore(_connectionString);
        }

        public override PersistenceIOParticipant CreatePersistenceIOParticipant()
        {
            return new SampleSqlIOParticipant(this);
        }

        private static void VerifyKnownComponents(WorkflowStoreComponents components)
        {
            const WorkflowStoreComponents knownComponents =
                        WorkflowStoreComponents.Streams
                        | WorkflowStoreComponents.Metadata
                        | WorkflowStoreComponents.Definition
                        | WorkflowStoreComponents.Timer
                        | WorkflowStoreComponents.JobState
                        | WorkflowStoreComponents.TerminatingError;

            WorkflowStoreComponents unknownComponents = components & ~knownComponents;

            if (unknownComponents != 0)
                throw new ArgumentException(string.Format("Unknown WorkflowStoreComponents value: {0}", unknownComponents));
        }

        private static void Append<T>(PSDataCollection<T> from, PSDataCollection<T> to)
        {
            foreach (var record in from)
            {
                to.Add(record);
            }
        }



        #endregion
    }
}
