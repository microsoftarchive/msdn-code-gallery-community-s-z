namespace Illusion.UI.Entities
{
    /// <summary>
    /// LocationEntity class
    /// </summary>
    public class LocationEntity : EntityBase
    {
        #region Private Properties

        /// <summary>
        /// The country ID
        /// </summary>
        private int countryID;
       
        #endregion

        #region Private Properties

        /// <summary>
        /// Gets or sets the country ID.
        /// </summary>
        /// <value>
        /// The country ID.
        /// </value>
        public int CountryID
        {
            get
            {
                return this.countryID;
            }
            set
            {
                this.countryID = value;
                this.OnPropertyChanged("CountryID");
            }
        }
        #endregion
    }
}
