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
    /// class ContactViewModel
    /// </summary>
    public sealed class ContactViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The contact collection
        /// </summary>
        private ObservableCollection<ContactEntity> contactCollection = new ObservableCollection<ContactEntity>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the contact collection.
        /// </summary>
        /// <value>
        /// The contact collection.
        /// </value>
        public ObservableCollection<ContactEntity> ContactCollection
        {
            get
            {
                return this.contactCollection;
            }
            set
            {
                this.contactCollection = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Initializes a new instance of the <see cref="ContactViewModel"/> class.
        /// </summary>
        /// <param name="container">The container.</param>
        public ContactViewModel()
            : base()
        {
            LoadContactsBackground();
        }
        #endregion

        #region BackgroundWorker 

        /// <summary>
        /// Loads the contacts background.
        /// </summary>
        private void LoadContactsBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
           
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadContactsBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadContactsBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadContactsBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadContactsBackground(object sender, DoWorkEventArgs e)
        {
            IContactRepository contactRepository = new ContactRepository();

            BackgroundWorker source = (BackgroundWorker)sender;

            var results = contactRepository.GetAllContacts();
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
        private void LoadContactsBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            this.ContactCollection.Add((ContactEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadContactsBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("ContactCollection");
        }

        #endregion 
    }
}
