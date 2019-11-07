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
    /// WorkOrder ViewModel class
    /// </summary>
    public sealed class WorkOrderViewModel : ViewModelBase
    {
        #region
        /// <summary>
        /// The work order collection
        /// </summary>
        private ObservableCollection<WorkOrderEntity> workOrderCollection = new ObservableCollection<WorkOrderEntity>();
       
        #endregion

        #region

        /// <summary>
        /// Gets or sets the work order collection.
        /// </summary>
        /// <value>
        /// The work order collection.
        /// </value>
        public ObservableCollection<WorkOrderEntity> WorkOrderCollection
        {
            get
            {
                return this.workOrderCollection;
            }
            set
            {
                this.workOrderCollection = value;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="WorkOrderViewModel"/> class.
        /// </summary>
        public WorkOrderViewModel()
        {
            this.LoadWorkOrdersBackground();
        }
        #endregion

        #region Background Worker

        /// <summary>
        /// Loads the work orders background.
        /// </summary>
        private void LoadWorkOrdersBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
           
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadWorkOrdersBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadWorkOrdersBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadWorkOrdersBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadWorkOrdersBackground(object sender, DoWorkEventArgs e)
        {
            IWorkOrderRepository workOrderRepository = new WorkOrderRepository();

            BackgroundWorker source = (BackgroundWorker)sender;

            var results = workOrderRepository.GetAllWorkOrders();
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
        private void LoadWorkOrdersBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            this.WorkOrderCollection.Add((WorkOrderEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadWorkOrdersBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("WorkOrderCollection");
        }

        #endregion Background Worker
    }
}
