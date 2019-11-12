namespace Illusion.Product.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows.Input;
    using Illusion.Common;
    using Illusion.Product.Services;
    using Illusion.UI.Entities;
    using System.Windows;
    using System.Windows.Threading;

    /// <summary>
    /// Product ViewModel class
    /// </summary>
    public sealed class ProductViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The product collection
        /// </summary>
        private ObservableCollection<ProductEntity> productCollection = new ObservableCollection<ProductEntity>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the product collection.
        /// </summary>
        /// <value>
        /// The product collection.
        /// </value>
        public ObservableCollection<ProductEntity> ProductCollection
        {
            get
            {
                return this.productCollection;
            }
            set
            {
                this.productCollection = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductViewModel"/> class.
        /// </summary>
        public ProductViewModel()
        {
            this.LoadProductsBackground();
        }
        #endregion

        #region Background Worker

        /// <summary>
        /// Loads the product models background.
        /// </summary>
        private void LoadProductsBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
           
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadProductsBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadProductsBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadProductsBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadProductsBackground(object sender, DoWorkEventArgs e)
        {
            IProductRepository productRepository = new ProductRepository();

            BackgroundWorker source = (BackgroundWorker)sender;

            var results = productRepository.GetAllProducts();
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
        private void LoadProductsBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            this.ProductCollection.Add((ProductEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadProductsBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("ProductCollection");
        }

        #endregion Background Worker
    }
}
