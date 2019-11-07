namespace Illusion.UI.Entities
{
    /// <summary>
    /// ProductVendorEntity class
    /// </summary>
    public class ProductVendorEntity : EntityBase
    {
        #region Private Properties

        /// <summary>
        /// The product vendor ID
        /// </summary>
        private int productVendorID;

        /// <summary>
        /// The product number
        /// </summary>
        private string productNumber;

        /// <summary>
        /// The last receipt cost
        /// </summary>
        private decimal? lastReceiptCost;

        #endregion

        #region Private Properties

        /// <summary>
        /// Gets or sets the product vendor ID.
        /// </summary>
        /// <value>
        /// The product vendor ID.
        /// </value>
        public int ProductVendorID
        {
            get
            {
                return this.productVendorID;
            }
            set
            {
                this.productVendorID = value;
                this.OnPropertyChanged("ProductVendorID");
            }
        }

        /// <summary>
        /// Gets or sets the product number.
        /// </summary>
        /// <value>
        /// The product number.
        /// </value>
        public string ProductNumber
        {
            get
            {
                return this.productNumber;
            }
            set
            {
                this.productNumber = value;
                this.OnPropertyChanged("ProductNumber");
            }
        }

        /// <summary>
        /// Gets or sets the last receipt cost.
        /// </summary>
        /// <value>
        /// The last receipt cost.
        /// </value>
        public decimal? LastReceiptCost
        {
            get
            {
                return this.lastReceiptCost;
            }
            set
            {
                this.lastReceiptCost = value;
                this.OnPropertyChanged("LastReceiptCost");
            }
        }
       
        #endregion
    }
}
