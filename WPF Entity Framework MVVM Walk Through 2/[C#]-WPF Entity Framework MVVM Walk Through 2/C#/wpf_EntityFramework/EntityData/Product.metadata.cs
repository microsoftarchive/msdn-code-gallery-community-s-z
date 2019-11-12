using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using DataAnnotationsExtensions;

namespace wpf_EntityFramework.EntityData
{
    [MetadataTypeAttribute(typeof(Product.ProductMetadata))]
    public partial class Product : BaseEntity
    {
        public void MetaSetUp()
        {
            // In wpf you need to explicitly state the metadata file.
            // Maybe this will be improved in future versions of EF.
            TypeDescriptor.AddProviderTransparent(
                new AssociatedMetadataTypeTypeDescriptionProvider(typeof(Product),
                typeof(ProductMetadata)),
                typeof(Product));
        }
        internal sealed class ProductMetadata
        {
            // Some of these datannotations rely on dataAnnotationsExtensions ( Nuget package )
            [Required(ErrorMessage="Product Short Name is required")]
            public string ProductShortName { get; set; }
            
            [Required(ErrorMessage = "Product Weight is required")]
            [Min(0.01, ErrorMessage = "Minimum weight is 0.01")]
            [Max(70.00, ErrorMessage = "We don't sell anything weighing more than 70Kg")]
            public Nullable<decimal> Weight { get; set; }
            
            [Required(ErrorMessage = "Bar Code is required")]
            [RegularExpression(@"[0-9]{11}$", ErrorMessage="Bar codes must be 11 digits")]
            public string BarCode { get; set; }

            [Required(ErrorMessage = "Price per product is required")]
            [Range(0,200, ErrorMessage="Price must be 0 - £200") ]
            public Nullable<decimal> PricePer { get; set; }
            private ProductMetadata()
            { }
        }
    }
}
