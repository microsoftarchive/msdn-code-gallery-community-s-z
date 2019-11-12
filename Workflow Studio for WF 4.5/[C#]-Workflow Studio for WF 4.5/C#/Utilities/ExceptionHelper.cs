//-----------------------------------------------------------------------
// <copyright file="ExceptionHelper.cs" company="Microsoft Corporation">
// Copyright (c) Microsoft Corporation. All rights reserved.
// THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER EXPRESSED OR IMPLIED, 
// INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// </copyright>
//-----------------------------------------------------------------------
namespace Microsoft.Consulting.WorkflowStudio.Utilities
{
    using System;
    using System.Text;

    public class ExceptionHelper
    {
        public static string FormatStackTrace(Exception exception)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(exception.Message);
            sb.Append(exception.StackTrace);

            if (exception.InnerException != null)
            {
                return sb.Append(FormatStackTrace(exception.InnerException)).ToString();
            }
            else
            {
                return sb.ToString();
            }
        }
    }
}
