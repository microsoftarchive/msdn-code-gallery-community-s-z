namespace Illusion.Sales.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Illusion.Common;
    using Illusion.Sales.Services;
    using Illusion.UI.Entities;

    /// <summary>
    /// class StoreViewModel
    /// </summary>
    public sealed class StoreViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The store collection
        /// </summary>
        private ObservableCollection<StoreEntity> storeCollection = new ObservableCollection<StoreEntity>();
        
        #endregion
      
        #region Public Properties

        /// <summary>
        /// Gets or sets the store collection.
        /// </summary>
        /// <value>
        /// The store collection.
        /// </value>
        public ObservableCollection<StoreEntity> StoreCollection
        {
            get
            {
                return this.storeCollection;
            }
            set
            {
                this.storeCollection = value;
            }
        }
       
        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="StoreViewModel"/> class.
        /// </summary>
        public StoreViewModel() :base()
        {
            LoadStoresBackground();
        }
        #endregion

        #region Background Worker

        /// <summary>
        /// Loads the stores background.
        /// </summary>
        private void LoadStoresBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
           
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadStoresBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadStoresBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadStoresBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadStoresBackground(object sender, DoWorkEventArgs e)
        {
            IStoreRepository storeRepository = new StoreRepository();

            BackgroundWorker source = (BackgroundWorker)sender;

            var results = storeRepository.GetAllStores();
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
        private void LoadStoresBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            this.StoreCollection.Add((StoreEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadStoresBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("StoreCollection");
        }

        #endregion Background Worker
    }
}
