//-----------------------------------------------------------------------
// <copyright file="StatusViewModel.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio.ViewModel
{
    using Microsoft.Consulting.WorkflowStudio.Properties;

    public class StatusViewModel : ViewModelBase
    {
        private static StatusViewModel statusViewModelSingleton = new StatusViewModel();

        private string statusText = Resources.ReadyStatus;

        public static StatusViewModel GetInstance
        {
            get
            {
                return statusViewModelSingleton;
            }
        }

        public string StatusText
        {
            get
            {
                return this.statusText;            
            }
        }

        public static void SetStatusText(string text, string workflowName)
        {
            statusViewModelSingleton.statusText = string.Format("{0} : {1}", workflowName, text);
            statusViewModelSingleton.OnPropertyChanged("StatusText");
        }
    }
}
