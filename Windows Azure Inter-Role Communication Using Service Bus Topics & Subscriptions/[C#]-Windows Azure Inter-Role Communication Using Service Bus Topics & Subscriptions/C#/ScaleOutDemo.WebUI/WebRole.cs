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
namespace ScaleOutDemo.WebUI
{
    #region Using references
    using System;
    using System.Collections.Generic;
    using System.Security.Principal;
    using System.Linq;

    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Diagnostics;
    using Microsoft.WindowsAzure.ServiceRuntime;
    using Microsoft.Web.Administration;

    using Microsoft.AzureCAT.Samples.InterRoleCommunication;
    using Microsoft.AzureCAT.Samples.InterRoleCommunication.Framework.Instrumentation;

    using ConfigurationManager = System.Configuration.ConfigurationManager;
    #endregion

    public class WebRole : RoleEntryPoint
    {
        public override bool OnStart()
        {
            if (CloudEnvironment.IsDevFabric)
            {
                // Changing IIS app pool identity to run under developer's domain account as per 
                // http://blogs.msdn.com/b/akshar/archive/2011/05/01/changing-the-windows-azure-web-host-application-pool-identity.aspx
                using (ServerManager serverManager = new ServerManager())
                {
                    string appPoolName = serverManager.Sites[RoleEnvironment.CurrentRoleInstance.Id + "_Web"].Applications.First().ApplicationPoolName;

                    var appPool = serverManager.ApplicationPools[appPoolName];

                    appPool.ProcessModel.IdentityType = ProcessModelIdentityType.SpecificUser;
                    appPool.ProcessModel.UserName = WindowsIdentity.GetCurrent().Name;
                    appPool.ProcessModel.Password = Environment.GetEnvironmentVariable("IISAppPoolUserAccPwd", EnvironmentVariableTarget.User);
                    appPool.ProcessModel.IdleTimeout = TimeSpan.Zero;
                    appPool.Recycling.PeriodicRestart.Time = TimeSpan.Zero;

                    serverManager.CommitChanges();
                }
            }

            return base.OnStart();
        }

        /// <summary>
        /// Called by Windows Azure when the role instance is to be stopped.
        /// </summary>
        public override void OnStop()
        {
            base.OnStop();
        }
   }
}
