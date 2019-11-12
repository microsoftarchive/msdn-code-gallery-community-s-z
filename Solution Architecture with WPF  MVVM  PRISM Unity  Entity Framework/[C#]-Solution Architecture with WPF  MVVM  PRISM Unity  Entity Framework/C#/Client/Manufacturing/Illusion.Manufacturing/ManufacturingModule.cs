namespace Illusion.Manufacturing
{
    using Illusion.Common;
    using Illusion.Manufacturing.View;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// Manufacturing Module class
    /// </summary>
    public class ManufacturingModule : IModule
    {
        #region Private Properties
      
        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;
        
        #endregion
       
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturingModule"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public ManufacturingModule(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        
        #endregion
       
        #region Public Method

        /// <summary>
        /// Initializes this instance.
        /// </summary>
        public void Initialize()
        {
            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
                () => ServiceLocator.Current.GetInstance<BillOfMaterialView>());

            this.regionManager.RegisterViewWithRegion(RegionNames.MenuBarRegion,
               () => ServiceLocator.Current.GetInstance<ManufacturingTabView>());
        }
       
        #endregion
    }
}
