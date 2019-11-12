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
    /// BillOfMaterial ViewModel class
    /// </summary>
    public sealed class BillOfMaterialViewModel : ViewModelBase
    {
        #region Private Properties
        
        /// <summary>
        /// The bill of material collection
        /// </summary>
        private ObservableCollection<BillOfMaterialEntity> billOfMaterialCollection = new ObservableCollection<BillOfMaterialEntity>();
        
        #endregion

        #region Public Properties
       
        /// <summary>
        /// Gets or sets the bill of material collection.
        /// </summary>
        /// <value>
        /// The bill of material collection.
        /// </value>
        public ObservableCollection<BillOfMaterialEntity> BillOfMaterialCollection
        {
            get
            {
                return this.billOfMaterialCollection;
            }
            set
            {
                this.billOfMaterialCollection = value;
            }
        }
      
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="BillOfMaterialViewModel"/> class.
        /// </summary>
        public BillOfMaterialViewModel()
        {
            this.LoadBillOfMaterialsBackground();
        }
        #endregion

        #region Background Worker


        /// <summary>
        /// Loads the bill of materials background.
        /// </summary>
        private void LoadBillOfMaterialsBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
           
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadBillOfMaterialsBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadBillOfMaterialsBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadBillOfMaterialsBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadBillOfMaterialsBackground(object sender, DoWorkEventArgs e)
        {
            IBillOfMaterialRepository billOfMaterialRepository = new BillOfMaterialRepository();

            BackgroundWorker source = (BackgroundWorker)sender;

            var results = billOfMaterialRepository.GetAllBillOfMaterials();
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
        private void LoadBillOfMaterialsBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            this.BillOfMaterialCollection.Add((BillOfMaterialEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadBillOfMaterialsBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("BillOfMaterialCollection");
        }

        #endregion Background Worker
    }
}
