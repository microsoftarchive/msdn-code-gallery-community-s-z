//-----------------------------------------------------------------------
// <copyright file="ValidationErrorService.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio.Execution
{
    using System;
    using System.Activities.Presentation.Validation;
    using System.Collections.Generic;

    public class ValidationErrorService : IValidationErrorService
    {
        private IList<ValidationErrorInfo> errorList;

        public ValidationErrorService(IList<ValidationErrorInfo> errorList)
        {
            this.errorList = errorList;
        }

        public delegate void ErrorsChangedHandler(object sender, EventArgs e);

        public event ErrorsChangedHandler ErrorsChangedEvent;

        public void ShowValidationErrors(IList<ValidationErrorInfo> errors)
        {
            this.errorList.Clear();

            foreach (var error in errors)
            {
                this.errorList.Add(error);
            }

            if (this.ErrorsChangedEvent != null)
            {
                this.ErrorsChangedEvent(this, null);
            }
        }
    }
}