using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    static class ColumnExtenstion
    {
        public static bool IsCalendarCell(this DataGridView GridView, DataGridViewCellEventArgs e)
        {
            return GridView.Columns[e.ColumnIndex] is CalendarColumn && !(e.RowIndex == -1);
        }
        public static bool IsTimeCell(this DataGridView GridView, DataGridViewCellEventArgs e)
        {
            return GridView.Columns[e.ColumnIndex] is TimeColumn && !(e.RowIndex == -1);
        }
    }
    public static class DataGridViewExtensions
    {
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
