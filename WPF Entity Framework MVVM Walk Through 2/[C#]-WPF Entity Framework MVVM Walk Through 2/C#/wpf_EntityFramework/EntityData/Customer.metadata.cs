using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
namespace wpf_EntityFramework.EntityData
{

   [MetadataTypeAttribute(typeof(Customer.CustomerMetadata))]
    public partial class Customer : BaseEntity
    {
    //    [RegularExpression(@"^(?=.*[a-z])(?=.*\d)[a-zA-Z\d]{8,}$",
    //ErrorMessage = "Password must contain, letters and numbers")]
    //    [Required(ErrorMessage = "Your password is too short")]
    //    [NotMapped]
    //    public string AnotherPasword { get; set; }

        //    private string anotherPasword;
        //    [RegularExpression(@"^(?=.*[a-z])(?=.*\d)[a-zA-Z\d]{8,}$",
        //ErrorMessage = "Password must contain, letters and numbers")]
        //    [Required(ErrorMessage = "Your password is too short")]
        //    [NotMapped]
        //    public string AnotherPasword
        //    {
        //        get { return anotherPasword; }
        //        set { anotherPasword = value; RaisePropertyChanged("Address1"); }
        //    }


        public void MetaSetUp()
       {
        // In wpf you need to explicitly state the metadata file.
        // Maybe this will be improved in future versions of EF.
           TypeDescriptor.AddProviderTransparent(
               new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Customer),
               typeof(CustomerMetadata)),
               typeof(Customer));
       }
       internal sealed class CustomerMetadata
       {

           [Required]
            //[ExcludeChar("X", ErrorMessage="No X please")]
            [StringLength(80, MinimumLength=4, ErrorMessage="Invalid customer name")]
           public string CustomerName { get; set; }
           [Required]
           [StringLength(80, MinimumLength = 4, ErrorMessage = "Invalid first line of address")]
           public string Address1 { get; set; }
           [StringLength(80)]
            //    [MustEqual("Address1", ErrorMessage = "Both the first address lines must match")]
            public string Address2 { get; set; }
           [StringLength(80)]
           public string Address3 { get; set; }
           [Required]
           [StringLength(50, MinimumLength = 4, ErrorMessage = "Invalid Town or City")]
           public string TownCity { get; set; }
           [Required(ErrorMessage = "Town or City is a required field")]
           [StringLength(8)]
           [RegularExpression("(GIR 0AA)|((([A-Z-[QVX]][0-9][0-9]?)|(([A-Z-[QVX]][A-Z-[IJZ]][0-9][0-9]?)|(([A-Z-[QVX]][0-9][A-HJKSTUW])|([A-Z-[QVX]][A-Z-[IJZ]][0-9][ABEHMNPRVWXY])))) [0-9][A-Z-[CIKMOV]]{2})"
               , ErrorMessage= "Invalid pattern post code")]
           public string PostCode { get; set; }
           [Required(ErrorMessage="PostCode is a required field")]
           [Range (0,50000, ErrorMessage= "Credit Limit must be between 0 and 50,000" )]
           [DataType(DataType.Currency)]
           public Nullable<decimal> CreditLimit { get; set; }
           [Required]
           [DataType(DataType.Currency)]
           public Nullable<decimal> Outstanding { get; set; }
           private CustomerMetadata()
           { }
       }
    }
}
