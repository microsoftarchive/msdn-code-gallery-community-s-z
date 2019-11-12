namespace Illusion.UI.Entities
{
    /// <summary>
    /// ProductEntity class
    /// </summary>
    public class ProductEntity : EntityBase
    {
        #region Private Properties

        /// <summary>
        /// The product ID
        /// </summary>
        private int productID;

        /// <summary>
        /// The category
        /// </summary>
        private string category;

        /// <summary>
        /// The sub category
        /// </summary>
        private string subCategory;

        /// <summary>
        /// The model
        /// </summary>
        private string model;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the product ID.
        /// </summary>
        /// <value>
        /// The product ID.
        /// </value>
        public int ProductID
        {
            get
            {
                return this.productID;
            }
            set
            {
                this.productID = value;
                this.OnPropertyChanged("ProductID");
            }
        }

        /// <summary>
        /// Gets or sets the category.
        /// </summary>
        /// <value>
        /// The category.
        /// </value>
        public string Category
        {
            get
            {
                return this.category;
            }
            set
            {
                this.category = value;
                this.OnPropertyChanged("Category");
            }
        }

        /// <summary>
        /// Gets or sets the sub category.
        /// </summary>
        /// <value>
        /// The sub category.
        /// </value>
        public string SubCategory
        {
            get
            {
                return this.subCategory;
            }
            set
            {
                this.subCategory = value;
                this.OnPropertyChanged("SubCategory");
            }
        }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>
        /// The model.
        /// </value>
        public string Model
        {
            get
            {
                return this.model;
            }
            set
            {
                this.model = value;
                this.OnPropertyChanged("Model");
            }
        }

        #endregion
    }
}
