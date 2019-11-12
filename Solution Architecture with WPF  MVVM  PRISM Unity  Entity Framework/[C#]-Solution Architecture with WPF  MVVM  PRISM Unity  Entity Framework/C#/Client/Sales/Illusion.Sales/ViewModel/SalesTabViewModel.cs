namespace Illusion.Sales.ViewModel
{
    using Illusion.Common;
    using Illusion.Sales.Views;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// class SalesTabViewModel
    /// </summary>
    public sealed class SalesTabViewModel : ViewModelBase
    {
        #region Private Properties
        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// The customer click command
        /// </summary>
        private readonly DelegateCommand customerClickCommand = null;

        /// <summary>
        /// The contact click command
        /// </summary>
        private readonly DelegateCommand contactClickCommand = null;

        /// <summary>
        /// The store click command
        /// </summary>
        private readonly DelegateCommand storeClickCommand = null;

        /// <summary>
        /// The location click command
        /// </summary>
        private readonly DelegateCommand locationClickCommand = null;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the customer click command.
        /// </summary>
        /// <value>
        /// The customer click command.
        /// </value>
        public DelegateCommand CustomerClickCommand
        {
            get
            {
                return (this.customerClickCommand ?? new DelegateCommand(this.ShowCustomerView));
            }
        }


        /// <summary>
        /// Gets the contact click command.
        /// </summary>
        /// <value>
        /// The contact click command.
        /// </value>
        public DelegateCommand ContactClickCommand
        {
            get
            {
                return (this.contactClickCommand ?? new DelegateCommand(this.ShowContactView));
            }
        }

        /// <summary>
        /// Gets the store click command.
        /// </summary>
        /// <value>
        /// The store click command.
        /// </value>
        public DelegateCommand StoreClickCommand
        {
            get
            {
                return (this.storeClickCommand ?? new DelegateCommand(this.ShowStoreView));
            }
        }

        /// <summary>
        /// Gets the location click command.
        /// </summary>
        /// <value>
        /// The location click command.
        /// </value>
        public DelegateCommand LocationClickCommand
        {
            get
            {
                return (this.locationClickCommand ?? new DelegateCommand(this.ShowLocationView));
            }
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="SalesTabViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public SalesTabViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Shows the customer view.
        /// </summary>
        private void ShowCustomerView()
        {
            var view = ServiceLocator.Current.GetInstance<CustomerView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }

        }

        /// <summary>
        /// Shows the contact view.
        /// </summary>
        private void ShowContactView()
        {
            var view = ServiceLocator.Current.GetInstance<ContactView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
        }

        /// <summary>
        /// Shows the store view.
        /// </summary>
        private void ShowStoreView()
        {
            var view = ServiceLocator.Current.GetInstance<StoreView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
        }

        /// <summary>
        /// Shows the location view.
        /// </summary>
        private void ShowLocationView()
        {
            var view = ServiceLocator.Current.GetInstance<LocationView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
        }
        #endregion
    }
}
