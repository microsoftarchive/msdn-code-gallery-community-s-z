using SQLite;

namespace SQLiteDemo.Models
{
    public class Customer
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string City { get; set; }
        public string Contact { get; set; }
    }
}
