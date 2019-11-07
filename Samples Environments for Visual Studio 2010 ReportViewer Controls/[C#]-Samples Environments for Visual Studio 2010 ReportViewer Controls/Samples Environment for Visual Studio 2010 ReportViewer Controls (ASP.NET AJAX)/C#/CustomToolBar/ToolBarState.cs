//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;

namespace CustomToolBar
{
    /// <summary>
    /// Helper class for passing the toolbar state to the client side.
    /// </summary>
    sealed class ToolBarState
    {
        public ToolBarState()
        {
            PageNumberString = String.Empty;
            FindString = String.Empty;
        }

        public bool IsButtonFirstPageEnabled 
        { 
            get; 
            set; 
        }

        public bool IsButtonPreviousPageEnabled
        {
            get;
            set;
        }

        public string PageNumberString
        {
            get;
            set;
        }

        public bool IsButtonNextPageEnabled
        {
            get;
            set;
        }

        public bool IsButtonLastPageEnabled
        {
            get;
            set;
        }

        public bool IsButtonBackToParentEnabled
        {
            get;
            set;
        }

        public string FindString
        {
            get;
            set;
        }

        public bool IsButtonFindEnabled
        {
            get;
            set;
        }

        public bool IsButtonNextEnabled
        {
            get;
            set;
        }

        public bool IsButtonRefreshEnabled
        {
            get;
            set;
        }

        public bool IsButtonPrintEnabled
        {
            get;
            set;
        }
    }
}