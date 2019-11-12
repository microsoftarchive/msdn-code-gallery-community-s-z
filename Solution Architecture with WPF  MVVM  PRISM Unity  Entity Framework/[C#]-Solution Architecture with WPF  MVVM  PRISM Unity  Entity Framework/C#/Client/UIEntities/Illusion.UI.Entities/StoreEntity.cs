namespace Illusion.UI.Entities
{
    using System;
    /// <summary>
    /// StoreEntity class 
    /// </summary>
    public class StoreEntity : EntityBase
    {
        #region Private Properties
        /// <summary>
        /// The store ID
        /// </summary>
        private int storeID;

        /// <summary>
        /// The sales order number
        /// </summary>
        private string salesOrderNumber;

        /// <summary>
        /// The order date
        /// </summary>
        private DateTime? orderDate;

        /// <summary>
        /// The total due
        /// </summary>
        private decimal? totalDue;
        #endregion

        #region Public Properties
        /// <summary>
        /// Gets or sets the store ID.
        /// </summary>
        /// <value>
        /// The store ID.
        /// </value>
        public int StoreID
        {
            get
            {
                return this.storeID;
            }
            set
            {
                this.storeID = value;
                this.OnPropertyChanged("StoreID");
            }
        }

        /// <summary>
        /// Gets or sets the sales order number.
        /// </summary>
        /// <value>
        /// The sales order number.
        /// </value>
        public string SalesOrderNumber
        {
            get
            {
                return this.salesOrderNumber;
            }
            set
            {
                this.salesOrderNumber = value;
                this.OnPropertyChanged("SalesOrderNumber");
            }
        }

        /// <summary>
        /// Gets or sets the order date.
        /// </summary>
        /// <value>
        /// The order date.
        /// </value>
        public DateTime? OrderDate
        {
            get
            {
                return this.orderDate;
            }
            set
            {
                this.orderDate = value;
                this.OnPropertyChanged("OrderDate");
            }
        }

        /// <summary>
        /// Gets or sets the total due.
        /// </summary>
        /// <value>
        /// The total due.
        /// </value>
        public decimal? TotalDue
        {
            get
            {
                return this.totalDue;
            }
            set
            {
                this.totalDue = value;
                this.OnPropertyChanged("TotalDue");
            }
        }
        #endregion
    }
}
