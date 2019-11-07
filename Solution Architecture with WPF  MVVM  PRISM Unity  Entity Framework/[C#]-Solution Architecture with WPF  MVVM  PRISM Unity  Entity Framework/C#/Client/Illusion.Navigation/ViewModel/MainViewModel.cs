namespace Illusion.Navigation.ViewModel
{
    using Illusion.Common;
    using Illusion.Manufacturing.View;
    using Illusion.Product.View;
    using Illusion.Purchasing.View;
    using Illusion.Sales.Views;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Events;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// Main View Model Class
    /// </summary>
    public sealed class MainViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// The product click command
        /// </summary>
        private readonly DelegateCommand productClickCommand = null;

        /// <summary>
        /// The manufacturing click command
        /// </summary>
        private readonly DelegateCommand manufacturingClickCommand = null;

        /// <summary>
        /// The button click command
        /// </summary>
        private readonly DelegateCommand<object> salesClickCommand = null;

        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;

        /// <summary>
        /// The purchase click command
        /// </summary>
        private readonly DelegateCommand purchaseClickCommand = null;

        #endregion

        #region Public Properties
        /// <summary>
        /// Gets the products click command.
        /// </summary>
        /// <value>
        /// The products click command.
        /// </value>
        public DelegateCommand ProductsClickCommand
        {
            get
            {
                return (this.productClickCommand ?? new DelegateCommand(this.ProductView));
            }
        }

        /// <summary>
        /// Gets the manufacturing click command.
        /// </summary>
        /// <value>
        /// The manufacturing click command.
        /// </value>
        public DelegateCommand ManufacturingClickCommand
        {
            get
            {
                return (this.manufacturingClickCommand ?? new DelegateCommand(this.ShowManufacturingView));
            }
        }

        /// <summary>
        /// Gets the purchase click command.
        /// </summary>
        /// <value>
        /// The purchase click command.
        /// </value>
        public DelegateCommand PurchaseClickCommand
        {
            get
            {
                return (this.purchaseClickCommand ?? new DelegateCommand(this.ShowPurchaseView));
            }
        }

        /// <summary>
        /// Gets the button click command.
        /// </summary>
        /// <value>
        /// The button click command.
        /// </value>
        public DelegateCommand<object> SalesClickCommand
        {
            get
            {
                return (this.salesClickCommand ?? new DelegateCommand<object>(this.ShowSalesViews));
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="MainViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public MainViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
        {
            this.regionManager = regionManager;
            this.eventAggregator = eventAggregator;
        }

        #endregion

        #region Private Methods

        /// <summary>
        /// Shows the views.
        /// </summary>
        /// <param name="sender">The sender.</param>
        private void ShowSalesViews(object sender)
        {
            if (sender != null)
            {
                var view = ServiceLocator.Current.GetInstance<CustomerView>();

                IRegion region = this.regionManager.Regions[RegionNames.MainRegion];

                region.Add(view);
                if (region != null)
                {
                    region.Activate(view);
                }

                var view2 = ServiceLocator.Current.GetInstance<SalesTabView>();

                IRegion region2 = this.regionManager.Regions[RegionNames.MenuBarRegion];

                region2.Add(view2);
                if (region2 != null)
                {
                    region2.Activate(view2);
                }
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
        }

        /// <summary>
        /// Shows the purchase view.
        /// </summary>
        private void ShowPurchaseView()
        {
            var tabview = ServiceLocator.Current.GetInstance<PurchaseTabView>();

            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }

            var mainview = ServiceLocator.Current.GetInstance<VendorView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
        }

        /// <summary>
        /// Shows the manufacturing view.
        /// </summary>
        private void ShowManufacturingView()
        {
            var tabview = ServiceLocator.Current.GetInstance<ManufacturingTabView>();

            var region = this.regionManager.Regions[RegionNames.MenuBarRegion];
            region.Add(tabview);
            if (region != null)
            {
                region.Activate(tabview);
            }

            var view = ServiceLocator.Current.GetInstance<BillOfMaterialView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(view);
            if (mainregion != null)
            {
                mainregion.Activate(view);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
        }

        /// <summary>
        /// Products the view.
        /// </summary>
        private void ProductView()
        {
            var mainview = ServiceLocator.Current.GetInstance<ProductView>();
            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }


            var tabview = ServiceLocator.Current.GetInstance<ProductTabView>();
            var tabregion = this.regionManager.Regions[RegionNames.MenuBarRegion];
            tabregion.Add(tabview);
            if (tabregion != null)
            {
                tabregion.Activate(tabview);
            }
            eventAggregator.GetEvent<TabVisibilityEvent>().Publish(true);
        }

        #endregion
    }
}
