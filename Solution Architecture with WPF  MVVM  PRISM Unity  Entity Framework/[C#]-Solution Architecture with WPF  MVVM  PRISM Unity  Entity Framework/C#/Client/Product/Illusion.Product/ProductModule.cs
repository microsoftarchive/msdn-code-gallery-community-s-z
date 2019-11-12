namespace Illusion.Product
{
    using Illusion.Common;
    using Illusion.Product.View;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// Product Module class
    /// </summary>
    public class ProductModule : IModule
    {
        #region Private Properties
        /// <summary>
        /// The region manager
        /// </summary>
        private readonly  IRegionManager regionManager;
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ProductModule"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public ProductModule(IRegionManager regionManager)
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
                () => ServiceLocator.Current.GetInstance<ProductView>());

            this.regionManager.RegisterViewWithRegion(RegionNames.MenuBarRegion,
               () => ServiceLocator.Current.GetInstance<ProductTabView>());
        }
        #endregion
    }
}
