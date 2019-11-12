//------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//------------------------------------------------------------

namespace Microsoft.Workflow.Explorer.ViewModels
{
    using System;
    using System.Collections.ObjectModel;
    using Microsoft.Workflow.Client.Security;

    public class SecuritySettingsViewModel : ViewModelBase
    {
        int policyCount;
        string xmlBlob;

        public SecuritySettingsViewModel(KeyedCollection<string, ScopeSecurityConfiguration> securitySettings)
        {
            if (securitySettings == null)
            {
                throw new ArgumentNullException("securitySettings");
            }

            this.PolicyCount = securitySettings.Count;
            this.XmlBlob = Utils.DataContractSerialize(securitySettings).ToString();
        }

        public int PolicyCount
        {
            get { return this.policyCount; }
            private set
            {
                if (this.policyCount != value)
                {
                    this.policyCount = value;
                    this.RaisePropertyChanged("PolicyCount");
                }
            }
        }

        public string XmlBlob
        {
            get { return this.xmlBlob; }
            private set
            {
                if (this.xmlBlob != value)
                {
                    this.xmlBlob = value;
                    this.RaisePropertyChanged("XmlBlob");
                }
            }
        }
    }
}
