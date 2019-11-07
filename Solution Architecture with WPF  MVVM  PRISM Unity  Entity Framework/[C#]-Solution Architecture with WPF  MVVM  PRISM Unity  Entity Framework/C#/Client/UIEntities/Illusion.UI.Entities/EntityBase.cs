namespace Illusion.UI.Entities
{
    using System.ComponentModel;

    /// <summary>
    /// EntityBase class
    /// </summary>
    public class EntityBase
    {
        #region Private Properties
        private string country;
        private string state;
        /// <summary>
        /// The product
        /// </summary>
        private string product;

        /// <summary>
        /// The address
        /// </summary>
        private string address;

        /// <summary>
        /// The city
        /// </summary>
        private string city;

        /// <summary>
        /// The name
        /// </summary>
        private string name;

        /// <summary>
        /// The store
        /// </summary>
        private string store;

        /// <summary>
        /// The first name
        /// </summary>
        private string firstName;

        /// <summary>
        /// The last name
        /// </summary>
        private string lastName;

        /// <summary>
        /// The title
        /// </summary>
        private string title;

        /// <summary>
        /// The vendor
        /// </summary>
        private string vendor;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the Country.
        /// </summary>
        /// <value>
        /// The vendor.
        /// </value>
        public string Country
        {
            get
            {
                return this.country;
            }
            set
            {
                this.country = value;
                this.OnPropertyChanged("Country");
            }
        }

        /// <summary>
        /// Gets or sets the State.
        /// </summary>
        /// <value>
        /// The vendor.
        /// </value>
        public string State
        {
            get
            {
                return this.state;
            }
            set
            {
                this.state = value;
                this.OnPropertyChanged("State");
            }
        }
        /// <summary>
        /// Gets or sets the vendor.
        /// </summary>
        /// <value>
        /// The vendor.
        /// </value>
        public string Vendor
        {
            get
            {
                return this.vendor;
            }
            set
            {
                this.vendor = value;
                this.OnPropertyChanged("Vendor");
            }
        }

        /// <summary>
        /// Gets or sets the product.
        /// </summary>
        /// <value>
        /// The product.
        /// </value>
        public string Product
        {
            get
            {
                return this.product;
            }
            set
            {
                this.product = value;
                this.OnPropertyChanged("Product");
            }
        }

        /// <summary>
        /// Gets or sets the address.
        /// </summary>
        /// <value>
        /// The address.
        /// </value>
        public string Address
        {
            get
            {
                return this.address;
            }
            set
            {
                this.address = value;
                this.OnPropertyChanged("Address");
            }
        }

        /// <summary>
        /// Gets or sets the city.
        /// </summary>
        /// <value>
        /// The city.
        /// </value>
        public string City
        {
            get
            {
                return this.city;
            }
            set
            {
                this.city = value;
                this.OnPropertyChanged("City");
            }
        }
        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>
        /// The name.
        /// </value>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
                this.OnPropertyChanged("Name");
            }
        }

        /// <summary>
        /// Gets or sets the store.
        /// </summary>
        /// <value>
        /// The store.
        /// </value>
        public string Store
        {
            get
            {
                return this.store;
            }
            set
            {
                this.store = value;
                this.OnPropertyChanged("Store");
            }
        }

        /// <summary>
        /// Gets or sets the first name.
        /// </summary>
        /// <value>
        /// The first name.
        /// </value>
        public string FirstName
        {
            get
            {
                return this.firstName;
            }
            set
            {
                this.firstName = value;
                this.OnPropertyChanged("FirstName");
            }
        }

        /// <summary>
        /// Gets or sets the last name.
        /// </summary>
        /// <value>
        /// The last name.
        /// </value>
        public string LastName
        {
            get
            {
                return this.lastName;
            }
            set
            {
                this.lastName = value;
                this.OnPropertyChanged("LastName");
            }
        }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title
        {
            get
            {
                return this.title;
            }
            set
            {
                this.title = value;
                this.OnPropertyChanged("Title");
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="EntityBase"/> class.
        /// </summary>
        public EntityBase()
        {

        }
        #endregion

        /// <summary>
        /// Occurs when a property value changes.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Called when [property changed].
        /// </summary>
        /// <param name="name">The name.</param>
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }
    }
}
