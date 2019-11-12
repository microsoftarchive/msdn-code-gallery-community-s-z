namespace Illusion.UI.Entities
{
    /// <summary>
    /// Vendor class
    /// </summary>
    public class VendorEntity : EntityBase
    {
        #region Private Properties

        /// <summary>
        /// The vendor ID
        /// </summary>
        private int vendorID;
       
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the vendor ID.
        /// </summary>
        /// <value>
        /// The vendor ID.
        /// </value>
        public int VendorID
        {
            get
            {
                return this.vendorID;
            }
            set
            {
                this.vendorID = value;
                this.OnPropertyChanged("VendorID");
            }
        }
        #endregion
    }
}
