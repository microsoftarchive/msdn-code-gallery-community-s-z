namespace Illusion.UI.Entities
{
    /// <summary>
    /// VendorContactEntity class
    /// </summary>
    public class VendorContactEntity : EntityBase
    {
        #region Private Properties

        /// <summary>
        /// The vendor contact ID
        /// </summary>
        private int vendorContactID;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the vendor contact ID.
        /// </summary>
        /// <value>
        /// The vendor contact ID.
        /// </value>
        public int VendorContactID
        {
            get
            {
                return this.vendorContactID;
            }
            set
            {
                this.vendorContactID = value;
                this.OnPropertyChanged("VendorContactID");
            }
        }
        #endregion
    }
}
