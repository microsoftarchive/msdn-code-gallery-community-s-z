using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace MvcMusicStore.Models
{
    public class CreditCardInfo
    {
        public List<string> TypeList = new List<string> { "VISA", "Master Card", "Dicover Card" };
        [Required(ErrorMessage = "Card Type is required")]
        [DisplayName("Card Type")]
        [StringLength(25)]
        public string Type { get; set; }
        [Required(ErrorMessage = "Card Holder Name is required")]
        [DisplayName("Card Holder Name")]
        [StringLength(25)]
        public string HolderName { get; set; }
        [Required(ErrorMessage = "ECredit Card Number is required")]
        [DisplayName("Credit Card Number")]
        [StringLength(16)]
        public int Number { get; set; }
        [Required(ErrorMessage = "Expiry Date is required")]
        [DisplayName("Expiry Date")]
        [StringLength(10)]
        public string ExpiryDate { get; set; }

        [Required(ErrorMessage = "CCV Number is required")]
        [DisplayName("CCV Number")]
        [StringLength(10)]
        public int CCV { get; set; }

    }
   
}