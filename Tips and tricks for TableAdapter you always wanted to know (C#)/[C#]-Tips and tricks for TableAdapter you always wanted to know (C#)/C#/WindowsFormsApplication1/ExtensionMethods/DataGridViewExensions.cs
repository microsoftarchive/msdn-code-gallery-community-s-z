using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1.ExtensionMethods
{
    public static class DataGridViewExensions
    {
        public static void ExpandColumns(this DataGridView pSender)
        {
            foreach (DataGridViewColumn col in pSender.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }

    }
}
