namespace Illusion.Product.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Illusion.Common;
    using Illusion.Product.Services;
    using Illusion.UI.Entities;

    /// <summary>
    /// ProductModel ViewModel class
    /// </summary>
    public sealed class ProductModelViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The product model collection
        /// </summary>
        private ObservableCollection<ProductModelEntity> productModelCollection = new ObservableCollection<ProductModelEntity>();

        #endregion

        #region

        /// <summary>
        /// Gets or sets the product model collection.
        /// </summary>
        /// <value>
        /// The product model collection.
        /// </value>
        public ObservableCollection<ProductModelEntity> ProductModelCollection
        {
            get
            {
                return this.productModelCollection;
            }
            set
            {
                this.productModelCollection = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductModelViewModel"/> class.
        /// </summary>
        public ProductModelViewModel()
        {
            this.LoadProductModelsBackground();
        }

        #endregion
       
        #region Background Worker

        /// <summary>
        /// Loads the product models background.
        /// </summary>
        private void LoadProductModelsBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
           
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadProductModelsBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadProductModelsBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadProductModelsBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadProductModelsBackground(object sender, DoWorkEventArgs e)
        {
            IProductModelRepository productModelRepository = new ProductModelRepository();

            BackgroundWorker source = (BackgroundWorker)sender;

            var results = productModelRepository.GetAllProductModels();
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
        private void LoadProductModelsBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            this.ProductModelCollection.Add((ProductModelEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadProductModelsBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("ProductModelCollection");
        }

        #endregion Background Worker
    }
}
