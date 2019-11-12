//-----------------------------------------------------------------------
// <copyright file="DispatcherService.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio.Utilities
{
    using System;
    using System.Windows.Threading;

    public static class DispatcherService
    {
        public static Dispatcher DispatchObject { get; set; }

        public static void Dispatch(Action action)
        {
            if (DispatchObject == null || DispatchObject.CheckAccess())
            {
                action();
            }
            else
            {
                DispatchObject.Invoke(action);
            }
        }
    }
}