// <snippet1>
using System.ComponentModel.DataAnnotations;

namespace MvcContacts.Models {
    [MetadataType(typeof(ContactMD))]
    public partial class Contact {
        public class ContactMD {
            [ScaffoldColumn(false)]
            public object Id { get; set; }
            [Required()]
            public object FirstName { get; set; }
            [Required()]
            public object LastName { get; set; }
            [RegularExpression(@"^\d{3}-?\d{3}-?\d{4}$")]
            public object Phone { get; set; }
            [Required()]
            [DataType(DataType.EmailAddress)]
            [RegularExpression(@"^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$")]
            public object Email { get; set; }
        }
    }
} 
// </snippet1>

