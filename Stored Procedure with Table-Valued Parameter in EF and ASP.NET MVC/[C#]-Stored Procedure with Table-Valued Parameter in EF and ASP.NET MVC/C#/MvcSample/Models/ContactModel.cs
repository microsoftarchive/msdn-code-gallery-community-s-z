using System;
using System.ComponentModel.DataAnnotations;

namespace MvcSample.Models
{
    public class ContactModel
    {
        public Guid ContactID { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Phone { get; set; }
    }
}