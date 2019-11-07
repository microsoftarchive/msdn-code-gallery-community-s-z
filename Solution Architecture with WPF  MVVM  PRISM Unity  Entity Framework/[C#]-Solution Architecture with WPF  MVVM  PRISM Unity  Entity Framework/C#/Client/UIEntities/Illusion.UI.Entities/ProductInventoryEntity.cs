namespace Illusion.UI.Entities
{
    /// <summary>
    /// ProductInventoryEntity class
    /// </summary>
    public class ProductInventoryEntity : EntityBase
    {
        #region Private Properties
       
        /// <summary>
        /// The product inventory ID
        /// </summary>
        private int productInventoryID;


        /// <summary>
        /// The inventory location
        /// </summary>
        private string inventoryLocation;

        /// <summary>
        /// The qty available
        /// </summary>
        private int? qtyAvailable;
      
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the product inventory ID.
        /// </summary>
        /// <value>
        /// The product inventory ID.
        /// </value>
        public int ProductInventoryID
        {

            get
            {
                return this.productInventoryID;
            }
            set
            {
                this.productInventoryID = value;
                this.OnPropertyChanged("ProductInventoryID");
            }
        }

        /// <summary>
        /// Gets or sets the inventory location.
        /// </summary>
        /// <value>
        /// The inventory location.
        /// </value>
        public string InventoryLocation
        {

            get
            {
                return this.inventoryLocation;
            }
            set
            {
                this.inventoryLocation = value;
                this.OnPropertyChanged("InventoryLocation");
            }
        }

        /// <summary>
        /// Gets or sets the qty available.
        /// </summary>
        /// <value>
        /// The qty available.
        /// </value>
        public int? QtyAvailable
        {

            get
            {
                return this.qtyAvailable;
            }
            set
            {
                this.qtyAvailable = value;
                this.OnPropertyChanged("QtyAvailable");
            }
        }
        
        #endregion
    }
}
