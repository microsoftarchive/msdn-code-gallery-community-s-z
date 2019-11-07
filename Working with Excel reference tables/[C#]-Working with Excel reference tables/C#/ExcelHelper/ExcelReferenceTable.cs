using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExcelHelper
{
    public class ExcelReferenceTable
    {
        public string Name { get; set; }
        public string SheetName { get; set; }
        public string Address { get; set; }
        public string SelectString
        {
            get
            {
                return "SELECT * FROM [" + SheetName + "$" + Address + "]";
            }
        }
        public string SourceDataFile { get; set; }
        [System.Diagnostics.DebuggerStepThrough()]
        public ExcelReferenceTable()
        {
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
