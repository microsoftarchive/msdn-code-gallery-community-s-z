namespace Illusion.Manufacturing.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Illusion.Common;
    using Illusion.Manufacturing.Services;
    using Illusion.UI.Entities;

    /// <summary>
    /// ProductInventory ViewModel class
    /// </summary>
    public sealed class ProductInventoryViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The product inventory collection
        /// </summary>
        private ObservableCollection<ProductInventoryEntity> productInventoryCollection = new ObservableCollection<ProductInventoryEntity>();
        
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the product inventory collection.
        /// </summary>
        /// <value>
        /// The product inventory collection.
        /// </value>
        public ObservableCollection<ProductInventoryEntity> ProductInventoryCollection
        {
            get
            {
                return this.productInventoryCollection;
            }
            set
            {
                this.productInventoryCollection = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductInventoryViewModel"/> class.
        /// </summary>
        public ProductInventoryViewModel()
        {
            this.LoadProductInventoriesBackground();
        }
        #endregion

        #region Background Worker

        /// <summary>
        /// Loads the product inventories background.
        /// </summary>
        private void LoadProductInventoriesBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
           
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadProductInventoriesBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadProductInventoriesBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadProductInventoriesBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadProductInventoriesBackground(object sender, DoWorkEventArgs e)
        {
            IProductInventoryRepository productInventoryRepository = new ProductInventoryRepository();

            BackgroundWorker source = (BackgroundWorker)sender;

            var results = productInventoryRepository.GetAllProductInventories();
            int index = 0;
            foreach (var item in results)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
                source.ReportProgress(++index, item);
            }
        }

        /// <summary>
        ///  Occurs when System.ComponentModel.BackgroundWorker.ReportProgress(System.Int32) is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ProgressChangedEventArgs"/> instance containing the event data.</param>
        private void LoadProductInventoriesBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            this.ProductInventoryCollection.Add((ProductInventoryEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadProductInventoriesBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("BillOfMaterialCollection");
        }

        #endregion Background Worker
    }
}
