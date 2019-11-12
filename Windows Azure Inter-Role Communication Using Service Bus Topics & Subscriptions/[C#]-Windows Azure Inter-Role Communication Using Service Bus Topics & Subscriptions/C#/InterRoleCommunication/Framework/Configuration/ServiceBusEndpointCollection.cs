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
namespace Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Configuration
{
    #region Using references
    using System;
    using System.Configuration;
    #endregion

    /// <summary>
    /// Implements a collection of configuration elements describing Windows Azure Service Bus endpoints represented by <see cref="ServiceBusEndpointInfo"/> objects.
    /// </summary>
    public class ServiceBusEndpointCollection : ConfigurationElementCollection
    {
        #region Public methods
        /// <summary>
        /// Returns a <see cref="RetryPolicyInfo"/> element from the collection by the specified index.
        /// </summary>
        /// <param name="idx">The item index.</param>
        /// <returns>The <see cref="RetryPolicyInfo"/> element at the specified index.</returns>
        public ServiceBusEndpointInfo this[int idx]
        {
            get { return (ServiceBusEndpointInfo)BaseGet(idx); }
        }

        /// <summary>
        /// Adds a <see cref="RetryPolicyInfo"/> element to the collection.
        /// </summary>
        /// <param name="element">A <see cref="RetryPolicyInfo"/> element to add.</param>
        public void Add(ServiceBusEndpointInfo element)
        {
            BaseAdd(element);
        }

        /// <summary>
        ///  Returns a <see cref="RetryPolicyInfo"/> element with the specified name.
        /// </summary>
        /// <param name="name">The name of the element to return.</param>
        /// <returns>The <see cref="RetryPolicyInfo"/> element with the specified name; otherwise null.</returns>
        public ServiceBusEndpointInfo Get(string name)
        {
            return (ServiceBusEndpointInfo)BaseGet(name);
        }

        /// <summary>
        /// Determines whether or not a <see cref="RetryPolicyInfo"/> element with the specified name exists in the collection.
        /// </summary>
        /// <param name="name">The name of the element to find.</param>
        /// <returns>True if the element was found, otherwise false.</returns>
        public bool Contains(string name)
        {
            return BaseGet(name) != null;
        }
        #endregion

        #region Private methods
        /// <summary>
        /// Creates a new instance of a configuration element which this section contains.
        /// </summary>
        /// <returns>An instance of the <see cref="RetryPolicyInfo"/> object.</returns>
        protected override ConfigurationElement CreateNewElement()
        {
            return new ServiceBusEndpointInfo();
        }

        /// <summary>
        /// Gets the element key for a specified configuration element.
        /// </summary>
        /// <param name="element">The configuration element to return the key for.</param>
        /// <returns>An object that acts as the key for the specified configuration element.</returns>
        protected override object GetElementKey(ConfigurationElement element)
        {
            return ((ServiceBusEndpointInfo)element).Name;
        }
        #endregion
    }
}
