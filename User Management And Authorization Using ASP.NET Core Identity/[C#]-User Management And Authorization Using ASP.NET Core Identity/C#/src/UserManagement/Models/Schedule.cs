using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace UserManagement.Models
{
    [NotMapped]
    public class Schedule
    {
        public string Department { get; set; }

        public string Manager { get; set; }

        public string Assistant { get; set; }

    }
}
