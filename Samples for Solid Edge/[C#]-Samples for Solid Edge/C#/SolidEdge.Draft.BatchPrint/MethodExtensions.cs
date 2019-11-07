using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SolidEdge.Draft.BatchPrint
{
    public static class FileInfoExtensions
    {
        public static Icon GetSmallIcon(this FileInfo fi)
        {
            int flags = NativeMethods.SHGFI_ICON | NativeMethods.SHGFI_SMALLICON;
            int fileAttributes = NativeMethods.FILE_ATTRIBUTE_NORMAL;

            NativeMethods.SHFILEINFO shfi = new NativeMethods.SHFILEINFO();
            IntPtr result = NativeMethods.SHGetFileInfo(
                fi.FullName,
                fileAttributes,
                out shfi,
                Marshal.SizeOf(shfi),
                flags);

            if (result.ToInt32() == 0)
            {
                return null;
            }
            else
            {
                return Icon.FromHandle(shfi.hIcon);
            }
        }
    }
}
