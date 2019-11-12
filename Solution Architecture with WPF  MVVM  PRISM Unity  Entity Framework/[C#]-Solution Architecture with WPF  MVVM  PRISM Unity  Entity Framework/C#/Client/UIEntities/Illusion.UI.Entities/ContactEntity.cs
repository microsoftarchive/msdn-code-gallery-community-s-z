namespace Illusion.UI.Entities
{
    /// <summary>
    /// ContactEntity class
    /// </summary>
    public class ContactEntity : EntityBase
    {
        #region Private Propeties

        /// <summary>
        /// The contact ID
        /// </summary>
        private int contactID;

        #endregion

        #region Public Properties

        /// <summary>
        /// Gets or sets the contact ID.
        /// </summary>
        /// <value>
        /// The contact ID.
        /// </value>
        public int ContactID
        {
            get
            {
                return this.contactID;
            }
            set
            {
                this.contactID = value;
                this.OnPropertyChanged("ContactID");
            }
        }
        #endregion
    }
}
