using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
 * Normally we would not place all these classes in one file but
 * for demoing this is fine.
 */
namespace WindowsFormsApplication2
{
    public class EventItem
    {
        public string Description { get; set; }
        public int id { get; set; }
    }

    public class EventFiles
    {
        public string FileName { get; set; }
        public int? id { get; set; }
    }
    public static class Extensions
    {
        /// <summary>
        /// Expand all columns excluding relational tables
        /// </summary>
        /// <param name="sender"></param>
        public static void ExpandColumns(this DataGridView sender)
        {
            foreach (DataGridViewColumn col in sender.Columns)
            {
                // ensure we are not attempting to do this on a Entity
                if (col.ValueType.Name != "ICollection`1")
                {
                    col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
                }
            }
        }

    }
}
