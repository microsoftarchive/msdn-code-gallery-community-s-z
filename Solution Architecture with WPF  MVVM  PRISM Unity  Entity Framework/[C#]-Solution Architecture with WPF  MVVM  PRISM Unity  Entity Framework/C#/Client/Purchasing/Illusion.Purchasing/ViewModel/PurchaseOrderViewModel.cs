namespace Illusion.Purchasing.ViewModel
{
    using System;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Windows;
    using System.Windows.Input;
    using System.Windows.Threading;
    using Illusion.Common;
    using Illusion.Purchasing.Services;
    using Illusion.UI.Entities;

    /// <summary>
    /// PurchaseOrder ViewModel class
    /// </summary>
    public sealed class PurchaseOrderViewModel : ViewModelBase
    {
        #region Private Properties
        /// <summary>
        /// The purchase order collection
        /// </summary>
        private ObservableCollection<PurchaseOrderEntity> purchaseOrderCollection = new ObservableCollection<PurchaseOrderEntity>();
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the purchase order collection.
        /// </summary>
        /// <value>
        /// The purchase order collection.
        /// </value>
        public ObservableCollection<PurchaseOrderEntity> PurchaseOrderCollection
        {
            get
            {
                return this.purchaseOrderCollection;
            }
            set
            {
                this.purchaseOrderCollection = value;
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="PurchaseOrderViewModel"/> class.
        /// </summary>
        public PurchaseOrderViewModel()
        {
            this.LoadPurchaseOrdersBackground();
        }
        #endregion

        #region Background Worker


        /// <summary>
        /// Loads the purchase orders background.
        /// </summary>
        private void LoadPurchaseOrdersBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
           
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadPurchaseOrdersBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadPurchaseOrdersBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadPurchaseOrdersBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadPurchaseOrdersBackground(object sender, DoWorkEventArgs e)
        {
            IPurchaseOrderRepository purchaseOrderRepository = new PurchaseOrderRepository();

            BackgroundWorker source = (BackgroundWorker)sender;

            var results = purchaseOrderRepository.GetAllPurchaseOrders();
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
        private void LoadPurchaseOrdersBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            this.PurchaseOrderCollection.Add((PurchaseOrderEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadPurchaseOrdersBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("PurchaseOrderCollection");
        }

        #endregion Background Worker
    }
}
