using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestDemo.Model
{
    public class Phone
    {
        public string mobile { get; set; }
        public string home { get; set; }
        public string office { get; set; }
    }

    public class Contact
    {
        public string id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string address { get; set; }
        public string gender { get; set; }
        public Phone phone { get; set; }
    }

    //public class ContactList
    //{
    //    public List<Contact> contacts { get; set; }
    //}
}
