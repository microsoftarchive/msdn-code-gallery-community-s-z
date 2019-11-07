using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using Illusion.Manufacturing;
using Illusion.Purchasing;
using Illusion.Sales.BL;
using Illusion.Sales.BLInterface;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.UnityExtensions;
using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;

namespace Illusion.Shell
{
    /// <summary>
    /// Boot Strapper class responsible for initialization of an Application
    /// </summary>
    public class IllusionBootStrapper : UnityBootstrapper
    {
        /// <summary>
        /// Creates the shell.
        /// </summary>
        /// <returns></returns>
        protected override System.Windows.DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        /// <summary>
        /// Initializes the shell.
        /// </summary>
        protected override void InitializeShell()
        {
            App.Current.MainWindow = (Window)this.Shell;
            App.Current.MainWindow.Show();
        }

        /// <summary>
        /// Configures the module catalog.
        /// </summary>
        protected override void ConfigureModuleCatalog()
        {
           /*
            * The ModuleCatalog class holds information about th  modules that can be used by the applicaiton.
            * ModuleInfo class tha records the name, type, and location, among the attributes on of the module.
            */

            ModuleCatalog moduleCatalog = (ModuleCatalog)this.ModuleCatalog;
            moduleCatalog.AddModule(typeof(Illusion.Navigation.NavigationModule));

            Type moduleCType = typeof(Illusion.Sales.SalesModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleCType.Name,
                ModuleType = moduleCType.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });

            Type moduleCType2 = typeof(Illusion.Purchasing.PurchasingModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleCType2.Name,
                ModuleType = moduleCType2.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });

            Type moduleCType3 = typeof(Illusion.Manufacturing.ManufacturingModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleCType3.Name,
                ModuleType = moduleCType3.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });

            Type moduleCType4 = typeof(Illusion.Product.ProductModule);
            this.ModuleCatalog.AddModule(new ModuleInfo()
            {
                ModuleName = moduleCType4.Name,
                ModuleType = moduleCType4.AssemblyQualifiedName,
                InitializationMode = InitializationMode.OnDemand
            });
        }

        /// <summary>
        /// A container to Configures and injecting the required dependencies and services.
        /// </summary>
        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();
        }
    }
}
