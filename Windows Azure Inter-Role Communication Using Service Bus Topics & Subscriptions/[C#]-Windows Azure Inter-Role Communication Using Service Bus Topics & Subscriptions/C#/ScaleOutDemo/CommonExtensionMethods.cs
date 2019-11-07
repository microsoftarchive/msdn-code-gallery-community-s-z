//=======================================================================================
// Microsoft Windows Azure Customer Advisory Team (CAT) Best Practices Series
//
// This sample is supplemental to the technical guidance published on the community
// blog at http://windowsazurecat.com/. 
//
//=======================================================================================
// Copyright © 2011 Microsoft Corporation. All rights reserved.
// 
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE. YOU BEAR THE RISK OF USING IT.
//=======================================================================================
namespace Microsoft.AzureCAT.Samples.InterRoleCommunication
{
    #region Using references
    using System;
    using System.Linq;
    using System.Data.Services.Client;
    using System.Text.RegularExpressions;

    using Microsoft.WindowsAzure.StorageClient;
    #endregion

    /// <summary>
    /// Provides value-add extension methods for various types of runtime exceptions occurring in Windows Azure applications.
    /// </summary>
    public static class CloudExceptionExtensionMethods
    {
        private static Regex errorCodeExtractor = new Regex(@"<code>(\w+)</code>", RegexOptions.IgnoreCase | RegexOptions.Compiled);

        public static bool IsEntityAlreadyExists(this DataServiceRequestException ex)
        {
            return IsErrorStringMatch(GetErrorCode(ex), TableErrorCodeStrings.EntityAlreadyExists);
        }

        public static bool IsTableBeingDeleted(this DataServiceRequestException ex)
        {
            return IsErrorStringMatch(GetErrorCode(ex), TableErrorCodeStrings.TableBeingDeleted);
        }

        private static string GetErrorCode(DataServiceRequestException ex)
        {
            if (ex != null && ex.InnerException != null)
            {
                var match = errorCodeExtractor.Match(ex.InnerException.Message);
                return match.Success ? match.Groups[1].Value : null;
            }
            else
            {
                return null;
            }
        }

        private static bool IsErrorStringMatch(string exceptionErrorString, params string[] errorStrings)
        {
            return errorStrings.Contains(exceptionErrorString);
        }
    }
}
