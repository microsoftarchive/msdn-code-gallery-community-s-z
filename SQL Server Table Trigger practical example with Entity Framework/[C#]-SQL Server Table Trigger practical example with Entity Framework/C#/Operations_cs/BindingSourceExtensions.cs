using System;
using System.Windows.Forms;

namespace Operations_cs
{
    public static class BindingSourceExtensions
    { 
        public static string Status(this BindingSource sender)
        {
            return ((TestTable)sender.Current).OrderStatus;
        }
        public static DateTime? ApprovalDate(this BindingSource sender)
        {
            return ((TestTable)sender.Current).OrderApprovalDateTime;
        }
    }
}
