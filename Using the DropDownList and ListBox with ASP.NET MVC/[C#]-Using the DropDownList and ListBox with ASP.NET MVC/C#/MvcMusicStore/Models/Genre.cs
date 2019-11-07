using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MvcMusicStore.Models
{
    public partial class Genre
    {
        public int GenreId { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 2)]
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Album> Albums { get; set; }
    }
}
