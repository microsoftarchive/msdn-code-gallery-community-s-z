namespace Illusion.Navigation
{
    using Illusion.Common;
    using Illusion.Navigation.View;
    using Microsoft.Practices.Prism.Modularity;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// Navigation Module class
    /// </summary>
    public class NavigationModule : IModule
    {
        #region Private Properties

        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="NavigationModule"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public NavigationModule(IRegionManager regionManager)
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
            //Resolving Instances with Unity
            this.regionManager.RegisterViewWithRegion(RegionNames.HeaderRegion,
                 () => ServiceLocator.Current.GetInstance<HeaderView>());

            //Resolving Instances with Unity
            this.regionManager.RegisterViewWithRegion(RegionNames.MainRegion,
                 () => ServiceLocator.Current.GetInstance<MainView>());
        }
        
        #endregion
    }
}
