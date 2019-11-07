using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Draft.BatchPrint
{
    /// <summary>
    /// Static class containing PInvoke signatures.
    /// </summary>

    internal sealed class NativeMethods
    {
        #region Winuser.h
        
        public const int WM_ERASEBKGND = 0x14;

        #endregion //Winuser.h

        #region Shellapi.h

        public const int SHGFI_ICON = 0x00100;
        public const int SHGFI_DISPLAYNAME = 0x00200;
        public const int SHGFI_TYPENAME = 0x00400;
        public const int SHGFI_ATTRIBUTES = 0x00800;
        public const int SHGFI_ICONLOCATION = 0x01000;
        public const int SHGFI_EXETYPE = 0x02000;
        public const int SHGFI_SYSICONINDEX = 0x04000;
        public const int SHGFI_LINKOVERLAY = 0x08000;
        public const int SHGFI_SELECTED = 0x10000;
        public const int SHGFI_ATTR_SPECIFIED = 0x20000;
        public const int SHGFI_LARGEICON = 0x00000;
        public const int SHGFI_SMALLICON = 0x00001;
        public const int SHGFI_OPENICON = 0x00002;
        public const int SHGFI_SHELLICONSIZE = 0x00004;
        public const int SHGFI_PIDL = 0x00008;
        public const int SHGFI_USEFILEATTRIBUTES = 0x00010;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public int iIcon;
            public int dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        }

        [DllImport("shell32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SHGetFileInfo(string pszPath, int dwFileAttributes, out SHFILEINFO psfi, int cbFileInfo, int uFlags);

        #endregion // Shellapi.h

        #region Windows.h

        public const int FILE_ATTRIBUTE_NORMAL = 0x00080;     // Normal file

        #endregion // Windows.h

        #region Uxtheme.h

        [DllImport("uxtheme.dll", CharSet = CharSet.Auto, SetLastError = true, ExactSpelling = true)]
        public static extern IntPtr SetWindowTheme(IntPtr hWnd, string subApp, string subIdList);

        #endregion //Uxtheme.h

        #region ObjIdl.h

        internal enum SERVERCALL
        {
            SERVERCALL_ISHANDLED = 0,
            SERVERCALL_REJECTED = 1,
            SERVERCALL_RETRYLATER = 2
        }

        internal enum PENDINGMSG
        {
            PENDINGMSG_CANCELCALL = 0,
            PENDINGMSG_WAITNOPROCESS = 1,
            PENDINGMSG_WAITDEFPROCESS = 2
        }

        #endregion

        #region WinError.h

        internal const int MK_E_UNAVAILABLE = (int)(0x800401E3 - 0x100000000);
        internal const int CO_E_NOT_SUPPORTED = (int)(0x80004021 - 0x100000000);

        #endregion

        [DllImport("Ole32.dll")]
        internal static extern int CoRegisterMessageFilter(IMessageFilter newFilter, out IMessageFilter oldFilter);

    }
}
