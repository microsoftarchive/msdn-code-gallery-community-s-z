using System.ComponentModel.DataAnnotations;

namespace GridExampleMVC.Models
{
    public class Asset
    {
        public System.Guid AssetID { get; set; }

        [Display(Name = "Barcode")]
        public string Barcode { get; set; }

        [Display(Name = "Serial-Number")]
        public string SerialNumber { get; set; }

        [Display(Name = "Facility-Site")]
        public string FacilitySite { get; set; }

        [Display(Name = "PM-Guide-ID")]
        public string PMGuide { get; set; }

        [Required]
        [Display(Name = "Asset-ID")]
        public string AstID { get; set; }

        [Display(Name = "Child-Asset")]
        public string ChildAsset { get; set; }

        [Display(Name = "General-Asset-Description")]
        public string GeneralAssetDescription { get; set; }

        [Display(Name = "Secondary-Asset-Description")]
        public string SecondaryAssetDescription { get; set; }
        public int Quantity { get; set; }

        [Display(Name = "Manufacturer")]
        public string Manufacturer { get; set; }

        [Display(Name = "Model-Number")]
        public string ModelNumber { get; set; }

        [Display(Name = "Main-Location (Building)")]
        public string Building { get; set; }

        [Display(Name = "Sub-Location 1 (Floor)")]
        public string Floor { get; set; }

        [Display(Name = "Sub-Location 2 (Corridor)")]
        public string Corridor { get; set; }

        [Display(Name = "Sub-Location 3 (Room No)")]
        public string RoomNo { get; set; }

        [Display(Name = "Sub-Location 4 (MER#)")]
        public string MERNo { get; set; }

        [Display(Name = "Sub-Location 5 (Equip/System)")]
        public string EquipSystem { get; set; }

        public string Comments { get; set; }

        public bool Issued { get; set; }

    }
}
