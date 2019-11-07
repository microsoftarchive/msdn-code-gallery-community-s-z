using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public static class CheckedListBoxExtensions
    {
        /// <summary>
        /// Returns all checked items as ColumnDetails list.
        /// </summary>
        /// <param name="sender"></param>
        /// <returns>List of ColumnDetails</returns>
        /// <remarks>recommended to check the count, if 0 no items checked.</remarks>
        public static List<ColumnDetails> CheckedIColumnDetailsList(this CheckedListBox sender)
        {
            var Result = from T in sender.Items.OfType<ColumnDetails>().Where(
                             (item, index) =>
                             {
                                 return sender.GetItemChecked(index);
                             }
                         )
                         select T;

            return Result.ToList();
        }

    }
}
