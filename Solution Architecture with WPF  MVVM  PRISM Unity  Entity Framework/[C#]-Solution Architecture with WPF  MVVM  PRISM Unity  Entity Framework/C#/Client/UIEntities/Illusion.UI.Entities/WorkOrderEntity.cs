namespace Illusion.UI.Entities
{
    using System;

    /// <summary>
    /// WorkOrderEntity class
    /// </summary>
    public class WorkOrderEntity : EntityBase
    {
        #region Private Properties

        /// <summary>
        /// The work order ID
        /// </summary>
        private int workOrderID;


        /// <summary>
        /// The order quantity
        /// </summary>
        private int? orderQuantity;

        /// <summary>
        /// The due date
        /// </summary>
        private DateTime? dueDate;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the work order ID.
        /// </summary>
        /// <value>
        /// The work order ID.
        /// </value>
        public int WorkOrderID
        {
            get
            {
                return this.workOrderID;
            }
            set
            {
                this.workOrderID = value;
                this.OnPropertyChanged("WorkOrderID");
            }
        }

        /// <summary>
        /// Gets or sets the order quantity.
        /// </summary>
        /// <value>
        /// The order quantity.
        /// </value>
        public int? OrderQuantity
        {
            get
            {
                return this.orderQuantity;
            }
            set
            {
                this.orderQuantity = value;
                this.OnPropertyChanged("OrderQuantity");
            }
        }

        /// <summary>
        /// Gets or sets the due date.
        /// </summary>
        /// <value>
        /// The due date.
        /// </value>
        public DateTime? DueDate
        {
            get
            {
                return this.dueDate;
            }
            set
            {
                this.dueDate = value;
                this.OnPropertyChanged("DueDate");
            }
        }
       
        #endregion
    }
}
