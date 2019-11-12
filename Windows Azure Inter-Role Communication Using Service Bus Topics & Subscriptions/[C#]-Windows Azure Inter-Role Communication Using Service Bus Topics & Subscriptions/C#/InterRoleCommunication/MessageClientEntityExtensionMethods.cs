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
    using Microsoft.ServiceBus.Messaging;
    #endregion

    /// <summary>
    /// Provides value-add extension methods for Service Bus communication objects.
    /// </summary>
    public static class MessageClientEntityExtensionMethods
    {
        /// <summary>
        /// Performs a safe close of the current communication object instance.
        /// </summary>
        /// <param name="commObj">The instance of the <see cref="Microsoft.ServiceBus.Messaging.MessageClientEntity"/> object.</param>
        public static void SafeClose(this MessageClientEntity commObj)
        {
            try
            {
                commObj.Close();
            }
            catch
            {
                // It is acceptable to ignore any exceptions if close falls through. In addition, we don't have to call Abort in the event of an exception. 
                // The Abort method is called internally by Close method when the latter was unsuccessful.
            }
        }
    }
}
