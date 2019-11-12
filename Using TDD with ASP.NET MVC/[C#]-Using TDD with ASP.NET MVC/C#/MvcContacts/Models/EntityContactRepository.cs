// <snippet3>
using System.Collections.Generic;
using System.Linq;

namespace MvcContacts.Models {
    public class EF_ContactRepository : MvcContacts.Models.IContactRepository {

        private ContactEntities _db = new ContactEntities();

        public Contact GetContactByID(int id) {
            return _db.Contacts.FirstOrDefault(d => d.Id == id);
        }

        public IEnumerable<Contact> GetAllContacts() {
            return _db.Contacts.ToList();
        }

        public void CreateNewContact(Contact contactToCreate) {
            _db.AddToContacts(contactToCreate);
            _db.SaveChanges();
         //   return contactToCreate;
        }

        public int SaveChanges() {
            return _db.SaveChanges();
        }

        public void DeleteContact(int id) {
            var conToDel = GetContactByID(id);
            _db.Contacts.DeleteObject(conToDel);
            _db.SaveChanges();
        }

    }
} 
// </snippet3>
