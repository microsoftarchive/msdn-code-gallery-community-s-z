using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolidEdge.Assembly.BOM
{
    public class BomItem : MarshalByRefObject
    {
        public BomItem(string fullName)
        {
            FullName = fullName;
            FileName = System.IO.Path.GetFileName(fullName);
            Quantity = 1;
        }

        public int Level;
        public string DocumentNumber;
        public string Revision;
        public string Title;
        public int Quantity;
        public string FullName;
        public string FileName;
        public bool IsSubassembly;
    }
}
