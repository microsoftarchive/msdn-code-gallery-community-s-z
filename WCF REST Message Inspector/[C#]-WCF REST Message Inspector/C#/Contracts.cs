using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.IO;

namespace InspectNonXmlMessages
{
    [DataContract(Namespace = "")]
    public class Contact
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string[] Telephones { get; set; }
    }

    [ServiceContract(Namespace = "")]
    public interface IContactManager
    {
        [WebInvoke(
            Method = "POST",
            UriTemplate = "/Contacts",
            ResponseFormat = WebMessageFormat.Json)]
        string AddContact(Contact contact);

        [WebInvoke(
            Method = "PUT",
            UriTemplate = "/Contacts/{id}",
            ResponseFormat = WebMessageFormat.Json)]
        void UpdateContact(string id, Contact contact);

        [WebInvoke(
            Method = "DELETE",
            UriTemplate = "/Contacts/{id}",
            ResponseFormat = WebMessageFormat.Json)]
        void DeleteContact(string id);
        
        [WebGet(UriTemplate = "/Contacts", ResponseFormat = WebMessageFormat.Json)]
        List<Contact> GetAllContacts();
        
        [WebGet(UriTemplate = "/Contacts/{id}", ResponseFormat = WebMessageFormat.Json)]
        Contact GetContact(string id);

        [WebGet(UriTemplate = "/ContactsAsText")]
        Stream GetContactsAsText();
    }
}
