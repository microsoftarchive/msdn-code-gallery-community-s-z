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
    /// class CustomerViewModel
    /// </summary>
    public sealed class CustomerViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The customer collection
        /// </summary>
        private ObservableCollection<CustomerEntity> customerCollection = new ObservableCollection<CustomerEntity>();

        #endregion  Private Properties

        #region Public Properties

        /// <summary>
        /// Gets or sets the customer collection.
        /// </summary>
        /// <value>
        /// The customer collection.
        /// </value>
        public ObservableCollection<CustomerEntity> CustomerCollection
        {
            get
            {
                return this.customerCollection;
            }
            set
            {
                this.customerCollection = value;
            }
        }

        #endregion  Public Properties

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="CustomerViewModel"/> class.
        /// </summary>
        public CustomerViewModel()
            : base()
        {
            this.LoadCustomersBackground();
        }
        #endregion  Constructor

        #region Background Worker

        /// <summary>
        /// Loads the customers background.
        /// </summary>
        private void LoadCustomersBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
           
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadCustomersBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadCustomersBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadCustomersBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadCustomersBackground(object sender, DoWorkEventArgs e)
        {
            ICustomerRepository customerRepository = new CustomerRepository();

            BackgroundWorker source = (BackgroundWorker)sender;

            var results = customerRepository.GetAllCustomers();
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
        private void LoadCustomersBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            this.CustomerCollection.Add((CustomerEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadCustomersBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("ContactCollection");
        }

        #endregion Background Worker
    }
}
