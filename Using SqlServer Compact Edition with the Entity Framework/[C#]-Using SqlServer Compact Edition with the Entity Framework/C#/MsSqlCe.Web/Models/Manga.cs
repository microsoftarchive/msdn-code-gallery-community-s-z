using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MsSqlCe.Models
{
    public class Manga
    {
        public int id { get; set; }
        public string title { get; set; }
        public string mangaka { get; set; }
        public int pages { get; set; }
    }

    public class DataContex : DbContext
    {
        public DbSet<Manga> mangas { get; set; }
    }
}