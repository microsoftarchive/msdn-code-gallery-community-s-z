using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcMusicStore.Models
{
    public class PaymentOption
    {
       
        public String Name { get; set; }
        public String Description { get; set; }
    }
}