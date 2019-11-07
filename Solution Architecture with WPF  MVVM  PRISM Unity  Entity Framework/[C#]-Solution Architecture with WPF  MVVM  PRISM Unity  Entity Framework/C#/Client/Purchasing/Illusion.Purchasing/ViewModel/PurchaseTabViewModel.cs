namespace Illusion.Purchasing.ViewModel
{
    using Illusion.Common;
    using Illusion.Purchasing.View;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// PurchaseTab ViewModel class
    /// </summary>
    public sealed class PurchaseTabViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;
       
        /// <summary>
        /// The vendor click command
        /// </summary>
        private readonly DelegateCommand vendorClickCommand = null;

        /// <summary>
        /// The product vendor click command
        /// </summary>
        private readonly DelegateCommand productVendorClickCommand = null;

        /// <summary>
        /// The purchase order click command
        /// </summary>
        private readonly DelegateCommand purchaseOrderClickCommand = null;

        /// <summary>
        /// The vendor contact click command
        /// </summary>
        private readonly DelegateCommand vendorContactClickCommand = null;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the vendor click command.
        /// </summary>
        /// <value>
        /// The vendor click command.
        /// </value>
        public DelegateCommand VendorClickCommand
        {
            get
            {
                return (this.vendorClickCommand ?? new DelegateCommand(this.ShowVendor));
            }
        }

        /// <summary>
        /// Gets the product vendor click command.
        /// </summary>
        /// <value>
        /// The product vendor click command.
        /// </value>
        public DelegateCommand ProductVendorClickCommand
        {
            get
            {
                return (this.productVendorClickCommand ?? new DelegateCommand(this.ShowProductVendor));
            }
        }

        /// <summary>
        /// Gets the purchase order click command.
        /// </summary>
        /// <value>
        /// The purchase order click command.
        /// </value>
        public DelegateCommand PurchaseOrderClickCommand
        {
            get
            {
                return (this.purchaseOrderClickCommand ?? new DelegateCommand(this.ShowPurchaseOrder));
            }
        }

        /// <summary>
        /// Gets the vendor contact click command.
        /// </summary>
        /// <value>
        /// The vendor contact click command.
        /// </value>
        public DelegateCommand VendorContactClickCommand
        {
            get
            {
                return (this.vendorContactClickCommand ?? new DelegateCommand(this.ShowVendorContact));
            }
        }

        #endregion

        #region Constructor 

        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseTabViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public PurchaseTabViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        #endregion

        #region Private Methods

        /// <summary>
        /// Shows the vendor.
        /// </summary>
        private void ShowVendor()
        {
            var mainview = ServiceLocator.Current.GetInstance<VendorView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
        }

        /// <summary>
        /// Shows the product vendor.
        /// </summary>
        private void ShowProductVendor()
        {
            var mainview = ServiceLocator.Current.GetInstance<ProductVendorView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
        }

        /// <summary>
        /// Shows the purchase order.
        /// </summary>
        private void ShowPurchaseOrder()
        {
            var mainview = ServiceLocator.Current.GetInstance<PurchaseOrderView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
        }

        /// <summary>
        /// Shows the vendor contact.
        /// </summary>
        private void ShowVendorContact()
        {
            var mainview = ServiceLocator.Current.GetInstance<VendorContactView>();

            var mainregion = this.regionManager.Regions[RegionNames.MainRegion];
            mainregion.Add(mainview);
            if (mainregion != null)
            {
                mainregion.Activate(mainview);
            }
        }
        #endregion
    }
}
