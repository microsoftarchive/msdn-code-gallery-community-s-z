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
    using System.Web;
    using System.Linq;
    using System.Configuration;
    using System.Diagnostics;
    using System.Security.Cryptography.X509Certificates;

    using Microsoft.WindowsAzure.ServiceRuntime;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Properties;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Internal;
    #endregion

    /// <summary>
    /// Provides helper functions to enable user code to get safe access to the environmental parameters of the cloud infrastructure.
    /// </summary>
    public static class CloudEnvironment
    {
        #region Private members
        private readonly static TimeSpan maxQueueVisibilityTimeout = TimeSpan.FromHours(2);
        private readonly static bool runtimeAvailable;
        #endregion

        #region Constructor
        static CloudEnvironment()
        {
            try
            {
                runtimeAvailable = RoleEnvironment.IsAvailable;
            }
            catch
            {
                // Really don't care if we get an exception here as we simply assume that Azure environment is not available.
                runtimeAvailable = false;
            }
        } 
        #endregion

        #region Public properties
        /// <summary>
        /// Indicates whether the role instance is running in the Windows Azure environment.
        /// </summary>
        public static bool IsAvailable
        {
            get { return runtimeAvailable; }
        }

        /// <summary>
        /// Indicates whether the role instance is running in the Windows Azure Development Fabric environment.
        /// </summary>
        public static bool IsDevFabric
        {
            get
            {
                var devFabricTraceListeners = from TraceListener listener in Trace.Listeners.Cast<TraceListener>()
                             where String.Compare(listener.GetType().Name, Resources.DevelopmentFabricTraceListenerName, true) == 0
                             select listener;
                return devFabricTraceListeners.Count() > 0;
            }
        }

        /// <summary>
        /// Gets the ID of the object representing the role instance in which this code is currently executing.
        /// </summary>
        public static string CurrentRoleInstanceId
        {
            get { return IsAvailable ? RoleEnvironment.CurrentRoleInstance.Id : Guid.NewGuid().ToString("N"); }
        }

        /// <summary>
        /// Gets the name of the role in which this code is currently executing.
        /// </summary>
        public static string CurrentRoleName
        {
            get { return IsAvailable ? RoleEnvironment.CurrentRoleInstance.Role.Name : AppDomain.CurrentDomain.SetupInformation.ApplicationName; }
        }

        /// <summary>
        /// Gets the machine name on which this code is currently executing.
        /// </summary>
        public static string CurrentMachineName
        {
            get { return Environment.MachineName; }
        }

        /// <summary>
        /// Gets the deployment ID, a string value that uniquely identifies the deployment in which this role instance is running.
        /// </summary>
        public static string DeploymentId 
        {
            get { return IsAvailable ? RoleEnvironment.DeploymentId : CurrentMachineName; }
        }

        /// <summary>
        /// Gets a maximum allowed visibility timeout for messages stored in the Azure queues.
        /// </summary>
        public static TimeSpan MaxQueueVisibilityTimeout
        {
            get { return maxQueueVisibilityTimeout; }
        }

        /// <summary>
        /// Gets a visibility timeout for messages stored in the Azure queues that is intended to avoid a race condition whereby
        /// Azure storage fabric attempts to reset the message visibility and remove it at the same time. The default safe value is
        /// 5 minutes below the maximum allowed visibility timeout.
        /// </summary>
        public static TimeSpan SafeQueueVisibilityTimeout
        {
            get { return maxQueueVisibilityTimeout.Subtract(TimeSpan.FromMinutes(5)); }
        }

        /// <summary>
        /// Retrieves the value of a setting in the service configuration file.
        /// </summary>
        /// <param name="configurationSettingName">The name of the configuration setting.</param>
        /// <returns>A String containing the value of the configuration setting.</returns>
        public static string GetConfigurationSettingValue(string configurationSettingName)
        {
            if (IsAvailable)
            {
                try
                {
                    return RoleEnvironment.GetConfigurationSettingValue(configurationSettingName);
                }
                catch (RoleEnvironmentException)
                {
                    return null;
                }
            }
            else
            {
                return ConfigurationManager.AppSettings[configurationSettingName];
            }
        }

        /// <summary>
        /// Ensures that the HttpContext object is safe to use in the given context and returns an object that rolls the HttpContext object back to its original state.
        /// </summary>
        /// <returns>An object that needs to be explicitly disposed so that HttpContext can return back to its original state.</returns>
        public static IDisposable EnsureSafeHttpContext()
        {
            HttpContext oldHttpContext = HttpContext.Current;
            HttpContext.Current = null;

            return new AnonymousDisposable(() =>
            {
                HttpContext.Current = oldHttpContext;
            });
        }
        #endregion
    }
}