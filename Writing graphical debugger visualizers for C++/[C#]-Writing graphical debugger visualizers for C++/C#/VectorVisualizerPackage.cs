//********************************************************* 
// Copyright (c) Microsoft. All rights reserved. 
// This code is licensed under the Microsoft Public License. 
// THIS CODE IS PROVIDED *AS IS* WITHOUT WARRANTY OF 
// ANY KIND, EITHER EXPRESS OR IMPLIED, INCLUDING ANY 
// IMPLIED WARRANTIES OF FITNESS FOR A PARTICULAR 
// PURPOSE, MERCHANTABILITY, OR NON-INFRINGEMENT. 
//********************************************************* 

using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel.Design;
using System.Runtime.InteropServices;

namespace VectorVisualizer
{
    /// <summary>
    /// Vector visualizer service exposed by the package
    /// </summary>
    [Guid("5452AFEA-3DF6-46BB-9177-C0B08F318025")]
    public interface IVectorVisualizerService { }

    [PackageRegistration(UseManagedResourcesOnly = true)]
    [ProvideService(typeof(IVectorVisualizerService), ServiceName = "VectorVisualizerService")]
    [InstalledProductRegistration("Vector Visualizer Sample", "Vector Visualizer Sample", "1.0")]
    [Guid("C37A4CFC-670F-454A-B40E-AC08578ABABD")]
    public sealed class VectorVisualizerPackage : Package
    {
        /// <summary>
        /// Initialization of the package; register vector visualizer service
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();

            IServiceContainer serviceContainer = (IServiceContainer)this;

            if (serviceContainer != null)
            {
                serviceContainer.AddService(typeof(IVectorVisualizerService), new VectorVisualizerService(), true);
            }
        }
    }
}
