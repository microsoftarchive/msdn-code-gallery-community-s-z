using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CRUDDemo.Models
{
    public class BookModel
    {
public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }

        public DateTime PublishDate { get; set; }
    }
    //BookDBContext inherited form DBContext Class.
    //This Class helps us to work with LocalDatabase.
    //Remember the localDB connnectiostring by deuflt congigured with application once you created the DBContext Class.
    //This connctions string present under Configure.cs file.
    
    public class BookDBContext : DbContext
    {
        public DbSet<BookModel> BookLst { get; set; }
    }
}
