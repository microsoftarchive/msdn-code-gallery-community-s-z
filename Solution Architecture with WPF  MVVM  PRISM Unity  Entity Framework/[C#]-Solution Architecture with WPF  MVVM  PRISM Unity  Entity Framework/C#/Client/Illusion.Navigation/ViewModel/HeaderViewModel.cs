namespace Illusion.Navigation.ViewModel
{
    using Illusion.Common;
    using Illusion.Navigation.View;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// Header ViewModel class
    /// </summary>
    public sealed class HeaderViewModel : ViewModelBase
    {
        #region Private Properties
        /// <summary>
        /// The about click command
        /// </summary>
        private readonly DelegateCommand aboutClickCommand = null;
       
        /// <summary>
        /// The home click command
        /// </summary>
        private readonly DelegateCommand homeClickCommand = null;

        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the home click command.
        /// </summary>
        /// <value>
        /// The home click command.
        /// </value>
        public DelegateCommand HomeClickCommand
        {
            get
            {
                return (this.homeClickCommand ?? new DelegateCommand(this.ShowMainView));
            }
        }


        /// <summary>
        /// Gets the about click command.
        /// </summary>
        /// <value>
        /// The about click command.
        /// </value>
        public DelegateCommand AboutClickCommand
        {
            get
            {
                return (this.aboutClickCommand ?? new DelegateCommand(this.ShowAboutMeView));
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="HeaderViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public HeaderViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Shows the main view.
        /// </summary>
        private void ShowMainView()
        {
            var view = ServiceLocator.Current.GetInstance<MainView>();

            IRegion region1 = this.regionManager.Regions[RegionNames.MainRegion];
            region1.Add(view);
            if (region1 != null)
            {
                region1.Activate(view);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(false);
        }

        /// <summary>
        /// Shows the about me view.
        /// </summary>
        private void ShowAboutMeView()
        {
            var view = ServiceLocator.Current.GetInstance<AboutMeView>();

            IRegion region1 = this.regionManager.Regions[RegionNames.MainRegion];
            region1.Add(view);
            if (region1 != null)
            {
                region1.Activate(view);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(false);
        }
        #endregion
    }
}
