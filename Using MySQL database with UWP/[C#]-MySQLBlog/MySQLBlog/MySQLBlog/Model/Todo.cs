using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySQLBlog.Model
{
    public class Todo
    {
        public string whatToDO { get; set; }
        public Todo(string what)
        {
            whatToDO = what;
        }
    }
}
