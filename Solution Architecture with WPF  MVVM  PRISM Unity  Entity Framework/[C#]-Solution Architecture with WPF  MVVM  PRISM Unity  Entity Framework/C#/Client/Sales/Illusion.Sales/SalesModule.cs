namespace Illusion.Sales
{
    using Illusion.Common;
    using Illusion.Sales.Services;
    using Illusion.Sales.Views;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.Unity;

    /// <summary>
    /// Sales Module class
    /// </summary>
    public class SalesModule : IModule
    {
        #region Private Properties
        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// The container
        /// </summary>
        private readonly IUnityContainer container;

        #endregion Private Properties

        #region Constructor
      
        /// <summary>
        /// Initializes a new instance of the <see cref="SalesModule"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        /// <param name="regionManager">The region manager.</param>
        public SalesModule(IUnityContainer container, IRegionManager regionManager)
        {
            this.container = container;
            this.regionManager = regionManager;
        }
       
        #endregion Constructor

        #region public Methods
      
        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            //types of dependencies need to be registered with the container.
            this.container.RegisterType<ICustomerRepository, CustomerRepository>(new ContainerControlledLifetimeManager());

            // Resolving Instances with Unity
            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
                 () => this.container.Resolve<CustomerView>());

            //Resolving Instances with Unity
            this.regionManager.RegisterViewWithRegion(RegionNames.MenuBarRegion,
                 () => this.container.Resolve<SalesTabView>());
        }
        
        #endregion public Methods
    }
}
