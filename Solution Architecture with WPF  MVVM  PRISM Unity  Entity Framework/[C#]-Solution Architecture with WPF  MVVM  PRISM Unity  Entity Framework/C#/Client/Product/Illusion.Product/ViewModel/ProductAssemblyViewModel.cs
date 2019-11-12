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
    /// ProductAssembly ViewModel class
    /// </summary>
    public sealed class ProductAssemblyViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The product assembly collection
        /// </summary>
        private ObservableCollection<ProductAssemblyEntity> productAssemblyCollection = new ObservableCollection<ProductAssemblyEntity>();
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the product assembly collection.
        /// </summary>
        /// <value>
        /// The product assembly collection.
        /// </value>
        public ObservableCollection<ProductAssemblyEntity> ProductAssemblyCollection
        {
            get
            {
                return this.productAssemblyCollection;
            }
            set
            {
                this.productAssemblyCollection = value;
            }
        }
        
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ProductAssemblyViewModel"/> class.
        /// </summary>
        public ProductAssemblyViewModel()
        {
            this.LoadProductAssembliesBackground();
        }
        
        #endregion

        #region Background Worker

        /// <summary>
        /// Loads the product assemblies background.
        /// </summary>
        private void LoadProductAssembliesBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
           
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadProductAssembliesBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadProductAssembliesBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadProductAssembliesBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadProductAssembliesBackground(object sender, DoWorkEventArgs e)
        {
            IProductAssemblyRepository productAssemblyRepository = new ProductAssemblyRepository();

            BackgroundWorker source = (BackgroundWorker)sender;

            var results = productAssemblyRepository.GetAllProductAssemblylies();
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
        private void LoadProductAssembliesBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            this.ProductAssemblyCollection.Add((ProductAssemblyEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadProductAssembliesBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("ProductAssemblyCollection");
        }

        #endregion Background Worker
    }
}
