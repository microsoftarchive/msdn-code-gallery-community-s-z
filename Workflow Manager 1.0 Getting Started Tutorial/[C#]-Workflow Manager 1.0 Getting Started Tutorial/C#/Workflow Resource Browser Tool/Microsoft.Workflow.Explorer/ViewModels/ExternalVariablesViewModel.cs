//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System.Collections.ObjectModel;
    using System.Xaml;
    using Microsoft.Activities;

    public class ExternalVariablesViewModel : ViewModelBase
    {
        Collection<ExternalVariable> externalVariables;

        public ExternalVariablesViewModel(Collection<ExternalVariable> externalVariables)
        {
            this.externalVariables = externalVariables;
        }

        public string XamlBlob
        {
            get { return XamlServices.Save(this.externalVariables); }
        }
    }
}
