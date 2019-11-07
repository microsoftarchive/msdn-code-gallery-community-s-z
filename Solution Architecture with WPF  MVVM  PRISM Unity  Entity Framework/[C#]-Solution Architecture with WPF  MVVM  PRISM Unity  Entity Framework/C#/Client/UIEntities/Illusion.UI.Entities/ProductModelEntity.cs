namespace Illusion.UI.Entities
{
    /// <summary>
    /// ProductModelEntity class
    /// </summary>
    public class ProductModelEntity : EntityBase
    {
        #region Private Properties

        /// <summary>
        /// The product model ID
        /// </summary>
        private int productModelID;

        /// <summary>
        /// The product model
        /// </summary>
        private string productModel;

        /// <summary>
        /// The culture
        /// </summary>
        private string culture;

        /// <summary>
        /// The language
        /// </summary>
        private string language;
        
        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the product model ID.
        /// </summary>
        /// <value>
        /// The product model ID.
        /// </value>
        public int ProductModelID
        {
            get
            {
                return this.productModelID;
            }
            set
            {
                this.productModelID = value;
                this.OnPropertyChanged("ProductModelID");
            }
        }

        /// <summary>
        /// Gets or sets the product model.
        /// </summary>
        /// <value>
        /// The product model.
        /// </value>
        public string ProductModel
        {
            get
            {
                return this.productModel;
            }
            set
            {
                this.productModel = value;
                this.OnPropertyChanged("ProductModelID");
            }
        }

        /// <summary>
        /// Gets or sets the culture.
        /// </summary>
        /// <value>
        /// The culture.
        /// </value>
        public string Culture
        {
            get
            {
                return this.culture;
            }
            set
            {
                this.culture = value;
                this.OnPropertyChanged("Culture");
            }
        }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>
        /// The language.
        /// </value>
        public string Language
        {
            get
            {
                return this.language;
            }
            set
            {
                this.language = value;
                this.OnPropertyChanged("Language");
            }
        }
       
        #endregion
    }
}
