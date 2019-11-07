using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CompositeKeySupport.Models
{
    public class Person
    {
        [Key]
        public string FirstName { get; set; }
        [Key]
        public string LastName { get; set; }

        public int Age { get; set; }
    }
}