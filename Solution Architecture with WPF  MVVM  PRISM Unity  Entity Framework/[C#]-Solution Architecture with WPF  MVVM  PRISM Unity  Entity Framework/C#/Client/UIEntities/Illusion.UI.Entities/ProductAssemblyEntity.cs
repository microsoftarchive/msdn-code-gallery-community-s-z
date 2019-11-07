namespace Illusion.UI.Entities
{
    using System;

    /// <summary>
    /// ProductAssemblyEntity class
    /// </summary>
    public class ProductAssemblyEntity : EntityBase
    {
        #region Private Properties

        /// <summary>
        /// The product assembly ID
        /// </summary>
        private int productAssemblyID;

        /// <summary>
        /// The assembly ID
        /// </summary>
        private int? assemblyID;

        /// <summary>
        /// The component ID
        /// </summary>
        private int? componentID;


        /// <summary>
        /// The per assembly qty
        /// </summary>
        private decimal? perAssemblyQty;

        /// <summary>
        /// The end date
        /// </summary>
        private DateTime? endDate;

        private int? componentLevel;
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the product assembly ID.
        /// </summary>
        /// <value>
        /// The product assembly ID.
        /// </value>
        public int ProductAssemblyID
        {
            get
            {
                return this.productAssemblyID;
            }
            set
            {
                this.productAssemblyID = value;
                this.OnPropertyChanged("ProductAssemblyID");
            }
        }

        /// <summary>
        /// Gets or sets the assembly ID.
        /// </summary>
        /// <value>
        /// The assembly ID.
        /// </value>
        public int? AssemblyID
        {
            get
            {
                return this.assemblyID;
            }
            set
            {
                this.assemblyID = value;
                this.OnPropertyChanged("AssemblyID");
            }
        }

        /// <summary>
        /// Gets or sets the component ID.
        /// </summary>
        /// <value>
        /// The component ID.
        /// </value>
        public int?  ComponentID
        {
            get
            {
                return this.componentID;
            }
            set
            {
                this.componentID = value;
                this.OnPropertyChanged("ComponentID");
            }
        }

        /// <summary>
        /// Gets or sets the per assembly qty.
        /// </summary>
        /// <value>
        /// The per assembly qty.
        /// </value>
        public decimal? PerAssemblyQty
        {
            get
            {
                return this.perAssemblyQty;
            }
            set
            {
                this.perAssemblyQty = value;
                this.OnPropertyChanged("PerAssemblyQty");
            }
        }

        /// <summary>
        /// Gets or sets the end date.
        /// </summary>
        /// <value>
        /// The end date.
        /// </value>
        public DateTime? EndDate
        {
            get
            {
                return this.endDate;
            }
            set
            {
                this.endDate = value;
                this.OnPropertyChanged("EndDate");
            }
        }

        /// <summary>
        /// Gets or sets the component level.
        /// </summary>
        /// <value>
        /// The component level.
        /// </value>
        public int? ComponentLevel
        {
            get
            {
                return this.componentLevel;
            }
            set
            {
                this.componentLevel = value;
                this.OnPropertyChanged("ComponentLevel");
            }
        }
        #endregion
    }
}
