using System.Windows.Forms;

namespace DataGridViewExtensionMethods
{
    /// <summary>
    /// Language extension methods for DataGridView
    /// </summary>
    
    public static class DataGridViewMethods
    {
        /// <summary>
        /// Set all columns AutoSizeMode to AllCells
        /// </summary>
        /// <param name="sender">DataGridView</param>
        /// <example>
        /// <code language='vbnet' title='VB.NET Example'>DataGridView1.ExpandColumns()</code>
        /// </example>
        [System.Diagnostics.DebuggerHidden]
        public static void ExpandColumns(this DataGridView sender)
        {
            foreach (DataGridViewColumn col in sender.Columns)
            {
                col.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            }
        }
    }
}