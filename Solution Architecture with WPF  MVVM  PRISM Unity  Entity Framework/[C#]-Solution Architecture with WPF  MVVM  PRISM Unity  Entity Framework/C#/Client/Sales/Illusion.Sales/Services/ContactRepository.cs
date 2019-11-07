namespace Illusion.Sales.Services
{
    using System.Collections.Generic;
    using Illusion.Sales.BL;
    using Illusion.Sales.BLInterface;
    using Illusion.Sales.EDM;
    using Illusion.UI.Entities;

    /// <summary>
    /// Contact Repository class
    /// </summary>
    public class ContactRepository : IContactRepository
    {
        /// <summary>
        /// Gets all contacts.
        /// </summary>
        /// <returns>Get All Contacts</returns>
        public IEnumerable<ContactEntity> GetAllContacts()
        {
            IList<ContactEntity> result = new List<ContactEntity>();
            IContactBL contactBL = new ContactBL();
            List<Contact> contacts = contactBL.GetAllContact();
            foreach (Contact source in contacts)
            {
                ContactEntity target = new ContactEntity();
                target.ContactID = source.ContactID;
                target.Store = source.Store;
                target.FirstName = source.FirstName;
                target.LastName = source.LastName;
                target.Title = source.Title;
                result.Add(target);
            }
            return result;
        }
    }
}
