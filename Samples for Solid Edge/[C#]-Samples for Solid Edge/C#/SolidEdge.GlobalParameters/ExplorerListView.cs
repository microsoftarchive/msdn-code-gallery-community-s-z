using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace SolidEdge.GlobalParameters
{
    public class ExplorerListView : ListView
    {
        [DllImport("uxtheme.dll")]
        extern static int SetWindowTheme(IntPtr hWnd,
        [MarshalAs(UnmanagedType.LPWStr)] string pszSubAppName,
        [MarshalAs(UnmanagedType.LPWStr)] string pszSubIdList);

        public ExplorerListView()
            : base()
        {
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            SetWindowTheme(Handle, "explorer", null);
        }

        public ListViewItem SelectedItem
        {
            get
            {
                ListViewItem item = null;

                if (SelectedItems.Count == 1)
                {
                    item = SelectedItems[0];
                }

                return item;
            }
            set
            {
                SelectedItems.Clear();
                if (value != null)
                {
                    value.Selected = true;
                }
            }
        }
    }
}
