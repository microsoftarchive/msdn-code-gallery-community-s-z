namespace Illusion.Product.ViewModel
{
    using Illusion.Common;
    using Illusion.Product.View;
    using Microsoft.Practices.Prism.Commands;
    using Microsoft.Practices.Prism.Regions;
    using Microsoft.Practices.ServiceLocation;

    /// <summary>
    /// ProductTab ViewModel class
    /// </summary>
    public sealed class ProductTabViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The product click command
        /// </summary>
        private readonly DelegateCommand productClickCommand = null;

        /// <summary>
        /// The product model click command
        /// </summary>
        private readonly DelegateCommand productModelClickCommand = null;

        /// <summary>
        /// The product assembly click command
        /// </summary>
        private readonly DelegateCommand productAssemblyClickCommand = null;

        /// <summary>
        /// The region manager
        /// </summary>
        private readonly IRegionManager regionManager;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets the product click command.
        /// </summary>
        /// <value>
        /// The product click command.
        /// </value>
        public DelegateCommand ProductClickCommand
        {
            get
            {
                return (this.productClickCommand ?? new DelegateCommand(this.ShowProductView));
            }
        }

        /// <summary>
        /// Gets the product model click command.
        /// </summary>
        /// <value>
        /// The product model click command.
        /// </value>
        public DelegateCommand ProductModelClickCommand
        {
            get
            {
                return (this.productModelClickCommand ?? new DelegateCommand(this.ShowProductModelView));
            }
        }

        /// <summary>
        /// Gets the product assembly click command.
        /// </summary>
        /// <value>
        /// The product assembly click command.
        /// </value>
        public DelegateCommand ProductAssemblyClickCommand
        {
            get
            {
                return (this.productAssemblyClickCommand ?? new DelegateCommand(this.ShowProductAssemblyView));
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductTabViewModel"/> class.
        /// </summary>
        /// <param name="regionManager">The region manager.</param>
        public ProductTabViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        #endregion

        #region Constructor

        /// <summary>
        /// Shows the product view.
        /// </summary>
        private void ShowProductView()
        {
            var view = ServiceLocator.Current.GetInstance<ProductView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
        }

        /// <summary>
        /// Shows the product model view.
        /// </summary>
        private void ShowProductModelView()
        {
            var view = ServiceLocator.Current.GetInstance<ProductModelView>();

            var region = this.regionManager.Regions[RegionNames.MainRegion];
            region.Add(view);
            if (region != null)
            {
                region.Activate(view);
            }
        }

        /// <summary>
        /// Shows the product assembly view.
        /// </summary>
        private void ShowProductAssemblyView()
        {
            var view = ServiceLocator.Current.GetInstance<ProductAssemblyView>();

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
