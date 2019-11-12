using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using System.Collections.Generic;

namespace MvcMusicStore.Models
{
  //  [Bind(Exclude = "AlbumId")]  // ricka this breaks create
    public class Album
    {
        [ScaffoldColumn(false)]
        public int AlbumId { get; set; }

        // [DisplayName("Genre")]    
        public int GenreId { get; set; }

        //  [DisplayName("Artist")]  
        public int ArtistId { get; set; }

        [Required]
        [StringLength(160, MinimumLength=2)]   
        public string Title { get; set; }

        [Required()]
        [Range(0.01, 100.00)]
        public decimal Price { get; set; }

        [DisplayName("Album Art URL")]
        [StringLength(1024)]
        public string AlbumArtUrl { get; set; }

        public virtual Genre Genre { get; set; }
        public virtual Artist Artist { get; set; }
        public virtual List<OrderDetail> OrderDetails { get; set; }
    }
}