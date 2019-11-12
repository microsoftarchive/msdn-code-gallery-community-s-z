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
    /// Location View Model Class
    /// </summary>
    public sealed class LocationViewModel : ViewModelBase
    {
        #region Private Properties

        /// <summary>
        /// The location collection
        /// </summary>
        private ObservableCollection<LocationEntity> locationCollection = new ObservableCollection<LocationEntity>();

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the location collection.
        /// </summary>
        /// <value>
        /// The location collection.
        /// </value>
        public ObservableCollection<LocationEntity> LocationCollection
        {
            get
            {
                return this.locationCollection;
            }
            set
            {
                this.locationCollection = value;
            }
        }

        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="LocationViewModel"/> class.
        /// </summary>
        public LocationViewModel()
        {
            this.LoadLocationsBackground();
        }
        #endregion Constructor

        #region Background Worker

        /// <summary>
        /// Loads the locations background.
        /// </summary>
        private void LoadLocationsBackground()
        {
            Mouse.OverrideCursor = Cursors.Wait;
           
            //run time-consuming operations on a background thread
            BackgroundWorker worker = new BackgroundWorker();

            //Set the WorkerReportsProgress property to true if you want the BackgroundWorker to support progress updates.
            //When this property is true, user code can call the ReportProgress method to raise the ProgressChanged event.
            worker.WorkerReportsProgress = true;

            //This event is raised when you call the RunWorkerAsync method. This is where you start the time-consuming operation.
            worker.DoWork += new DoWorkEventHandler(this.LoadLocationsBackground);

            // This event is raised when you call the ReportProgress method.
            worker.ProgressChanged += new ProgressChangedEventHandler(this.LoadLocationsBackgroundProgress);

            //The RunWorkerCompleted event is raised when the background worker has completed. 
            //Depending on whether the background operation completed successfully, encountered an error,
            //or was canceled, update the user interface accordingly
            worker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.LoadLocationsBackgroundComplete);

            //Starts running a background operation
            worker.RunWorkerAsync();
        }

        /// <summary>
        /// Occurs when RunWorkerAsync is called.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="DoWorkEventArgs"/> instance containing the event data.</param>
        private void LoadLocationsBackground(object sender, DoWorkEventArgs e)
        {
            ILocationRepository locationRepository = new LocationRepository();

            BackgroundWorker source = (BackgroundWorker)sender;

            var results = locationRepository.GetAllLocations();
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
        private void LoadLocationsBackgroundProgress(object sender, ProgressChangedEventArgs e)
        {
            this.LocationCollection.Add((LocationEntity)e.UserState);
        }

        /// <summary>
        ///  Occurs when the background operation has completed, has been canceled, or has raised an exception.
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="RunWorkerCompletedEventArgs"/> instance containing the event data.</param>
        private void LoadLocationsBackgroundComplete(object sender, RunWorkerCompletedEventArgs e)
        {
           
            Mouse.OverrideCursor = null;
            this.OnPropertyChanged("LocationCollection");
        }

        #endregion Background Worker
    }
}
