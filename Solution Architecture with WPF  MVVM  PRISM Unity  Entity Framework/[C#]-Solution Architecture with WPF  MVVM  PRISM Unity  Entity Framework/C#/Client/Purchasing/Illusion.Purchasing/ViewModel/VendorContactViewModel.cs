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
    /// VendorContact ViewModel class
    /// </summary>
    public sealed class VendorContactViewModel : ViewModelBase
    {
        #region

        /// <summary>
        /// The vendor contact collection
        /// </summary>
        private ObservableCollection<VendorContactEntity> vendorContactCollection = new ObservableCollection<VendorContactEntity>();

        #endregion

        #region

        /// <summary>
        /// Gets or sets the vendor contact collection.
        /// </summary>
        /// <value>
        /// The vendor contact collection.
        /// </value>
        public ObservableCollection<VendorContactEntity> VendorContactCollection
        {
            get
            {
                return this.vendorContactCollection;
            }
            set
            {
                this.vendorContactCollection = value;
            }
        }

        #endregion

        #region
        /// <summary>
        /// Initializes a new instance of the <see cref="VendorContactViewModel"/> class.
        /// </summary>
        public VendorContactViewModel()
        {
            this.LoadVendorContactsBackground();
        }
        #endregion

        #region Background Worker

        /// <summary>
        /// Loads the vendor contacts background.
        /// </summary>
        private void LoadVendorContactsBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
           
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadVendorContactsBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadVendorContactsBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadVendorContactsBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadVendorContactsBackground(object sender, DoWorkEventArgs e)
        {
            IVendorContactRepository vendorContactRepository = new VendorContactRepository();

            BackgroundWorker source = (BackgroundWorker)sender;

            var results = vendorContactRepository.GetAllVendorContacts();
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
        private void LoadVendorContactsBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            this.VendorContactCollection.Add((VendorContactEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadVendorContactsBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("VendorContactCollection");
        }

        #endregion Background Worker
    }
}
