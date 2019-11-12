using System.Windows.Forms;

namespace Operations_cs
{
    public static class Extensions
    {
        /// <summary>
        /// Determines if the current item is not null
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool IsValid(this TestTable sender)
        {
            return (sender != null);
        }
        /// <summary>
        /// Check if BindingSource.Current has data
        /// </summary>
        /// <param name="sender"></param>
        /// <returns></returns>
        public static bool CurrentRowIsValid(this BindingSource sender)
        {
            return (sender.Current != null);
        }

        /// <summary>
        /// Expand all columns excluding in this case Orders column
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
