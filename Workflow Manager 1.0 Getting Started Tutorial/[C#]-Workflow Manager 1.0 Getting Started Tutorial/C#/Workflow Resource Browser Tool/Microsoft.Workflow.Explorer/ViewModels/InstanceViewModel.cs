//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Globalization;
    using System.Linq;
    using System.Windows.Input;
    using System.Xml.Linq;
    using Microsoft.Workflow.Client;
    using Microsoft.Workflow.Explorer.Controllers;

    public class InstanceViewModel : ViewModelBase
    {
        public InstanceViewModel(WorkflowInstanceInfo instanceInfo)
        {
            if (instanceInfo != null)
            {
                this.Name = instanceInfo.InstanceName;
                this.LastModified = instanceInfo.LastModified.ToLocalTime();
                this.CreatedTime = instanceInfo.CreationTime.ToLocalTime();
                this.UserStatus = instanceInfo.UserStatus ?? "(None)";
                this.WorkflowStatus = instanceInfo.WorkflowStatus.ToString();
                this.ActivationMetadata = (IDictionary)instanceInfo.ActivationParameters.Metadata;

                if (instanceInfo.MappedVariables != null)
                {
                    // CONSIDER: Create a view model specifically for mapped variables which removes the XName namespace
                    IDictionary mappedVariableHashtable = new Hashtable(instanceInfo.MappedVariables.Count);
                    foreach (KeyValuePair<XName, string> pair in instanceInfo.MappedVariables)
                    {
                        mappedVariableHashtable.Add(pair.Key.LocalName, pair.Value);
                    }

                    this.MappedVariables = mappedVariableHashtable;
                }

                this.ShowActivationMetadataCommand = new SimpleActionCommand(this.OnShowMetadata);
                this.ShowMappedVariablesCommand = new SimpleActionCommand(this.OnShowMappedVariables);
            }
        }

        public string Name
        {
            get;
            private set;
        }

        public DateTime CreatedTime
        {
            get;
            private set;
        }

        public string WorkflowStatus
        {
            get;
            private set;
        }

        public DateTime LastModified
        {
            get;
            private set;
        }

        public string UserStatus
        {
            get;
            private set;
        }

        public string CreatedDescription
        {
            get
            {
                TimeSpan age = DateTime.Now.Subtract(this.CreatedTime);

                int duration;
                string unit;
                if (age < TimeSpan.FromMinutes(1))
                {
                    duration = (int)age.TotalSeconds;
                    unit = "second";
                }
                else if (age < TimeSpan.FromHours(1))
                {
                    duration = (int)age.TotalMinutes;
                    unit = "minute";
                }
                else if (age < TimeSpan.FromDays(1))
                {
                    duration = (int)age.TotalHours;
                    unit = "hour";
                }
                else if (age < TimeSpan.FromDays(30))
                {
                    duration = (int)age.TotalDays;
                    unit = "day";
                }
                else
                {
                    duration = (int)age.TotalDays / 30;
                    unit = "month";
                }

                return string.Format(
                    CultureInfo.CurrentUICulture,
                    "Created {0} {1}{2} ago",
                    duration,
                    unit,
                    duration > 1 ? "s" : string.Empty);
            }
        }

        public IDictionary MappedVariables
        {
            get;
            private set;
        }

        public int MappedVariablesCount
        {
            get { return this.MappedVariables != null ? this.MappedVariables.Count : 0; }
        }

        public IDictionary ActivationMetadata
        {
            get;
            private set;
        }

        public ICommand ShowMappedVariablesCommand
        {
            get;
            private set;
        }

        public ICommand ShowActivationMetadataCommand
        {
            get;
            private set;
        }

        public override string ToString()
        {
            return this.Name;
        }

        void OnShowMetadata(object sender)
        {
            if (this.ActivationMetadata != null && this.ActivationMetadata.Count > 0)
            {
                ScopeNavigationController.Default.NavigateToDictionaryPage(this.ActivationMetadata);
            }
        }

        void OnShowMappedVariables(object sender)
        {
            if (this.MappedVariables != null && this.MappedVariables.Count > 0)
            {
                ScopeNavigationController.Default.NavigateToDictionaryPage(this.MappedVariables);
            }
        }
    }
}