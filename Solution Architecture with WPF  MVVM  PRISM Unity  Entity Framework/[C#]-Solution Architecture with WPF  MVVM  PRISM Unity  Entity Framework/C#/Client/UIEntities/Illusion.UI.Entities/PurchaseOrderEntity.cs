namespace Illusion.UI.Entities
{
    /// <summary>
    /// Purchase Order Class
    /// </summary>
    public class PurchaseOrderEntity : EntityBase
    {
        #region Private Members

        /// <summary>
        /// The purchase order ID
        /// </summary>
        private int purchaseOrderID;

        /// <summary>
        /// The total purchase
        /// </summary>
        private decimal? totalPurchase;

        /// <summary>
        /// The average purchase
        /// </summary>
        private decimal? averagePurchase;

        /// <summary>
        /// The minimum purchase
        /// </summary>
        private decimal? minimumPurchase;

        /// <summary>
        /// The maximum purchase
        /// </summary>
        private decimal? maximumPurchase;
       
        #endregion
     
        #region Private Members

        /// <summary>
        /// Gets or sets the purchase order ID.
        /// </summary>
        /// <value>
        /// The purchase order ID.
        /// </value>
        public int PurchaseOrderID
        {
            get
            {
                return this.purchaseOrderID;
            }
            set
            {
                this.purchaseOrderID = value;
                this.OnPropertyChanged("PurchaseOrderID");
            }
        }

        /// <summary>
        /// Gets or sets the total purchase.
        /// </summary>
        /// <value>
        /// The total purchase.
        /// </value>
        public decimal? TotalPurchase
        {
            get
            {
                return this.totalPurchase;
            }
            set
            {
                this.totalPurchase = value;
                this.OnPropertyChanged("TotalPurchase");
            }
        }

        /// <summary>
        /// Gets or sets the average purchase.
        /// </summary>
        /// <value>
        /// The average purchase.
        /// </value>
        public decimal? AveragePurchase
        {
            get
            {
                return this.averagePurchase;
            }
            set
            {
                this.averagePurchase = value;
                this.OnPropertyChanged("AveragePurchase");
            }
        }

        /// <summary>
        /// Gets or sets the minimum purchase.
        /// </summary>
        /// <value>
        /// The minimum purchase.
        /// </value>
        public decimal? MinimumPurchase
        {
            get
            {
                return this.minimumPurchase;
            }
            set
            {
                this.minimumPurchase = value;
                this.OnPropertyChanged("MinimumPurchase");
            }
        }

        /// <summary>
        /// Gets or sets the maximum purchase.
        /// </summary>
        /// <value>
        /// The maximum purchase.
        /// </value>
        public decimal? MaximumPurchase
        {
            get
            {
                return this.maximumPurchase;
            }
            set
            {
                this.maximumPurchase = value;
                this.OnPropertyChanged("MaximumPurchase");
            }
        }
        
        #endregion
    }
}
