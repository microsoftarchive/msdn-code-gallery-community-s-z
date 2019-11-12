using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcMusicStore.Models
{
    public class Address
    {
        [Required(ErrorMessage = "First Name is required")]
        [DisplayName("First Name")]
        [StringLength(160)]
        public object FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [DisplayName("Last Name")]
        [StringLength(160)]
        public object LastName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(70)]
        public object Street { get; set; }

        [Required(ErrorMessage = "City is required")]
        [StringLength(40)]
        public object City { get; set; }

        [Required(ErrorMessage = "State is required")]
        [StringLength(40)]
        public object State { get; set; }

        [Required(ErrorMessage = "Postal Code is required")]
        [DisplayName("Postal Code")]
        [StringLength(10)]
        public object PostalCode { get; set; }

        [Required(ErrorMessage = "Country is required")]
        [StringLength(40)]
        public object Country { get; set; }

    }
}