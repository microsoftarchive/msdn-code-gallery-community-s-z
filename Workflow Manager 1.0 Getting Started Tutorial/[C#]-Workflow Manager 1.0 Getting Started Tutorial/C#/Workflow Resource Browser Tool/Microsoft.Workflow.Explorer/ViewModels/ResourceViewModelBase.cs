//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;

    public abstract class ResourceViewModelBase : ViewModelBase
    {
        public ResourceViewModelBase(ScopeViewModel parentScope)
        {
            this.ParentScope = parentScope;
        }

        public ScopeViewModel ParentScope
        {
            get;
            private set;
        }

        public abstract Uri Uri
        {
            get;
        }
    }
}
