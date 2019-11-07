namespace Illusion.UI.Entities
{
    /// <summary>
    /// CustomerEntity class
    /// </summary>
    public class CustomerEntity : EntityBase
    {
        #region Private Propertes
       
        /// <summary>
        /// The customer ID
        /// </summary>
        private int customerID;
        
        #endregion

        #region Private Propertes
       
        /// <summary>
        /// Gets or sets the customer ID.
        /// </summary>
        /// <value>
        /// The customer ID.
        /// </value>
        public int CustomerID
        {
            get
            {
                return this.customerID;
            }
            set
            {
                this.customerID = value;
                this.OnPropertyChanged("CustomerID");
            }
        }
       
        #endregion
    }
}
