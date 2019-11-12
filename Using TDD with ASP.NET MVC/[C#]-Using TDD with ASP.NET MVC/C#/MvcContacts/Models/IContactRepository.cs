// <snippet2>
using System;
using System.Collections.Generic;

namespace MvcContacts.Models {
    public interface IContactRepository {
        void CreateNewContact(Contact contactToCreate);
        void DeleteContact(int id);
        Contact GetContactByID(int id);
        IEnumerable<Contact> GetAllContacts();
        int SaveChanges();

    }
} 
// </snippet2>
