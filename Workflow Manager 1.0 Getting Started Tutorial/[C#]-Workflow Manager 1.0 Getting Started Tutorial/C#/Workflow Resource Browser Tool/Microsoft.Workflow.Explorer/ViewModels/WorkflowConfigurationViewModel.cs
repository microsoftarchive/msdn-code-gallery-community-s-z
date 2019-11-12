//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System.Xml.Linq;
    using Microsoft.Workflow.Client;

    // TODO: Add a detailed set of properties
    public class WorkflowConfigurationViewModel : ViewModelBase
    {
        public WorkflowConfigurationViewModel(WorkflowConfiguration configuration)
        {
            this.SerializedXml = Utils.DataContractSerialize(configuration);
        }

        public XElement SerializedXml
        {
            get;
            private set;
        }
    }
}
