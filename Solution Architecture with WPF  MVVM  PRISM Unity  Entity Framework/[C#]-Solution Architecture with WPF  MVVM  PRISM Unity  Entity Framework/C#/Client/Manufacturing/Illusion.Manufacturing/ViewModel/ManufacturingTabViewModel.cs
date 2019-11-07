namespace Illusion.Manufacturing.ViewModel
{
    using Illusion.Common;
    using Illusion.Manufacturing.View;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// ManufacturingTab ViewModel class
    /// </summary>
    public sealed class ManufacturingTabViewModel : ViewModelBase
    {
        #region Private Properties
        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;
        
        /// <summary>
        /// The bill of material click command
        /// </summary>
        private readonly DelegateCommand billOfMaterialClickCommand = null;

        /// <summary>
        /// The product inventory click command
        /// </summary>
        private readonly DelegateCommand productInventoryClickCommand = null;

        /// <summary>
        /// The work order click command
        /// </summary>
        private readonly DelegateCommand workOrderClickCommand = null;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the bill of material click command.
        /// </summary>
        /// <value>
        /// The bill of material click command.
        /// </value>
        public DelegateCommand BillOfMaterialClickCommand
        {
            get
            {
                return (this.billOfMaterialClickCommand ?? new DelegateCommand(this.ShowBillOfMaterialView));
            }
        }

        /// <summary>
        /// Gets the product inventory click command.
        /// </summary>
        /// <value>
        /// The product inventory click command.
        /// </value>
        public DelegateCommand ProductInventoryClickCommand
        {
            get
            {
                return (this.productInventoryClickCommand ?? new DelegateCommand(this.ShowProductInventoryView));
            }
        }

        /// <summary>
        /// Gets the work order click command.
        /// </summary>
        /// <value>
        /// The work order click command.
        /// </value>
        public DelegateCommand WorkOrderClickCommand
        {
            get
            {
                return (this.workOrderClickCommand ?? new DelegateCommand(this.ShowWorkOrderView));
            }
        }
        #endregion
        
        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ManufacturingTabViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public ManufacturingTabViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
       
        #endregion

        #region Private Methods

        /// <summary>
        /// Shows the bill of material view.
        /// </summary>
        private void ShowBillOfMaterialView()
        {
            var view = ServiceLocator.Current.GetInstance<BillOfMaterialView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
        }

        /// <summary>
        /// Shows the product inventory view.
        /// </summary>
        private void ShowProductInventoryView()
        {
            var view = ServiceLocator.Current.GetInstance<ProductInventoryView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
        }

        /// <summary>
        /// Shows the work order view.
        /// </summary>
        private void ShowWorkOrderView()
        {
            var view = ServiceLocator.Current.GetInstance<WorkOrderView>();

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
