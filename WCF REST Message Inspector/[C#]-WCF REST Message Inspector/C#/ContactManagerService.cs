using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.ServiceModel.Web;
using System.Text;
using System.Threading;

namespace InspectNonXmlMessages
{
    public class ContactManagerService : IContactManager
    {
        static List<Contact> AllContacts = new List<Contact>();
        static int currentId = 0;
        static object syncRoot = new object();

        public string AddContact(Contact contact)
        {
            int contactId = Interlocked.Increment(ref currentId);
            contact.Id = contactId.ToString(CultureInfo.InvariantCulture);
            lock (syncRoot)
            {
                AllContacts.Add(contact);
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.Created;
            }

            return contact.Id;
        }

        public void UpdateContact(string id, Contact contact)
        {
            contact.Id = id;
            lock (syncRoot)
            {
                int index = this.FetchContact(id);
                if (index >= 0)
                {
                    AllContacts[index] = contact;
                }
            }
        }

        public void DeleteContact(string id)
        {
            lock (syncRoot)
            {
                int index = this.FetchContact(id);
                if (index >= 0)
                {
                    AllContacts.RemoveAt(index);
                }
            }
        }

        public List<Contact> GetAllContacts()
        {
            List<Contact> result;
            lock (syncRoot)
            {
                result = AllContacts.ToList();
            }

            return result;
        }

        public Contact GetContact(string id)
        {
            Contact result;
            lock (syncRoot)
            {
                int index = this.FetchContact(id);
                result = index < 0 ? null : AllContacts[index];
            }

            return result;
        }

        public Stream GetContactsAsText()
        {
            StringBuilder sb = new StringBuilder();
            WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain";
            lock (syncRoot)
            {
                foreach (var contact in AllContacts)
                {
                    sb.AppendLine("Contact " + contact.Id + ":");
                    sb.AppendLine("  Name: " + contact.Name);
                    sb.AppendLine("  Email: " + contact.Email);
                    sb.AppendLine("  Telephones:");
                    foreach (var phone in contact.Telephones)
                    {
                        sb.AppendLine("    " + phone);
                    }
                }
            }

            WebOperationContext.Current.OutgoingResponse.ContentType = "text/plain; charset=utf-8";
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(sb.ToString()));
            return ms;
        }

        private int FetchContact(string id)
        {
            int result = -1;
            for (int i = 0; i < AllContacts.Count; i++)
            {
                if (AllContacts[i].Id == id)
                {
                    result = i;
                    break;
                }
            }

            if (result < 0)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.NotFound;
            }

            return result;
        }
    }
}
