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
namespace ScaleOutDemo
{
    #region Using references
    using System;
    using System.Text.RegularExpressions;
    #endregion

    public static class CommonFuncs
    {
        private static Regex idExtractor = new Regex(@"(\d+)$", RegexOptions.Compiled | RegexOptions.Singleline);

        /// <summary>
        /// Extract the Id from the RoleInstance ID string representation
        /// Traverses from the end of the string and extracts the number representing the ID
        /// Works in Devfabric (where the delimiter is ".") and on Azure deployment (where the delimiter is "_")
        /// </summary>
        public static int GetRoleInstanceIndex(string instanceId)
        {
            Match match = idExtractor.Match(instanceId);

            if (match.Success)
            {
                return Convert.ToInt32(match.Value);
            }
            else
            {
                throw new ArgumentException("The role instance ID is in some kind of unexpected format.", instanceId);
            }
        }
    }
}