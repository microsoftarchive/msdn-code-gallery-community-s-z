namespace Illusion.Shell
{
    using Illusion.Common;
    using Microsoft.Practices.Prism.Events;

    /// <summary>
    /// ShellViewModel class
    /// </summary>
    public class ShellViewModel : ViewModelBase
    {
        #region Private Properties
        /// <summary>
        /// The event aggregator
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>
        /// The is menu region visible
        /// </summary>
        private bool isMenuRegionVisible;
      
        #endregion
      
        #region Public Properties
      
        /// <summary>
        /// Gets or sets a value indicating whether this instance is menu region visible.
        /// </summary>
        /// <value>
        /// <c>true</c> if this instance is menu region visible; otherwise, <c>false</c>.
        /// </value>
        public bool IsMenuRegionVisible
        {
            get
            {
                return this.isMenuRegionVisible;
            }
            set
            {
                this.isMenuRegionVisible = value;
                this.OnPropertyChanged("IsMenuRegionVisible");
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="ShellViewModel"/> class.
        /// </summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public ShellViewModel(IEventAggregator eventAggregator)
        {
            this.IsMenuRegionVisible = false;
            this.eventAggregator = eventAggregator;
            eventAggregator.GetEvent<TabVisibilityEvent>().Subscribe(MenuRegionVisible);
        }
        #endregion

        #region Private Methods
        private void MenuRegionVisible(bool isVisible)
        {
            this.IsMenuRegionVisible = isVisible;
            this.OnPropertyChanged("IsMenuRegionVisible");
        }
        #endregion
    }
}
