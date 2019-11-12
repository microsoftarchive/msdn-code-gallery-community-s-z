using System;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ArchiveManager
{
    /// <summary>
    /// Options to specify the size of icons to return.
    /// </summary>
    public enum IconSize
    {
        /// <summary>
        /// Specify large icon - 32 pixels by 32 pixels.
        /// </summary>
        Large = 0,
        /// <summary>
        /// Specify small icon - 16 pixels by 16 pixels.
        /// </summary>
        Small = 1
    }

    /// <summary>
    /// Options to specify whether folders should be in the open or closed state.
    /// </summary>
    public enum FolderType
    {
        /// <summary>
        /// Specify open folder.
        /// </summary>
        Open = 0,
        /// <summary>
        /// Specify closed folder.
        /// </summary>
        Closed = 1
    }

    /// <summary>
    /// Wraps necessary Shell32.dll structures and functions required to retrieve Icon Handles using SHGetFileInfo. Code
    /// courtesy of MSDN Cold Rooster Consulting case study.
    /// </summary>
    public class NativeMethodsShell32
    {
        public const uint BIF_BROWSEFORCOMPUTER = 0x1000;
        public const uint BIF_BROWSEFORPRINTER = 0x2000;
        public const uint BIF_BROWSEINCLUDEFILES = 0x4000;
        public const uint BIF_BROWSEINCLUDEURLS = 0x0080;
        public const uint BIF_DONTGOBELOWDOMAIN = 0x0002;
        public const uint BIF_EDITBOX = 0x0010;
        public const uint BIF_NEWDIALOGSTYLE = 0x0040;
        public const uint BIF_RETURNFSANCESTORS = 0x0008;
        public const uint BIF_RETURNONLYFSDIRS = 0x0001;
        public const uint BIF_SHAREABLE = 0x8000;
        public const uint BIF_STATUSTEXT = 0x0004;
        public const uint BIF_USENEWUI = (BIF_NEWDIALOGSTYLE | BIF_EDITBOX);
        public const uint BIF_VALIDATE = 0x0020;
        public const uint FILE_ATTRIBUTE_DIRECTORY = 0x00000010;
        public const uint FILE_ATTRIBUTE_NORMAL = 0x00000080;
        public const int MAX_PATH = 256;
        public const uint SHGFI_ADDOVERLAYS = 0x000000020; // apply the appropriate overlays
        public const uint SHGFI_ATTR_SPECIFIED = 0x000020000; // get only specified attributes

        public const uint SHGFI_ATTRIBUTES = 0x000000800; // get attributes
        public const uint SHGFI_DISPLAYNAME = 0x000000200; // get display name
        public const uint SHGFI_EXETYPE = 0x000002000; // return exe type
        public const uint SHGFI_ICON = 0x000000100; // get icon
        public const uint SHGFI_ICONLOCATION = 0x000001000; // get icon location
        public const uint SHGFI_LARGEICON = 0x000000000; // get large icon
        public const uint SHGFI_LINKOVERLAY = 0x000008000; // put a link overlay on icon
        public const uint SHGFI_OPENICON = 0x000000002; // get open icon
        public const uint SHGFI_OVERLAYINDEX = 0x000000040; // Get the index of the overlay
        public const uint SHGFI_PIDL = 0x000000008; // pszPath is a pidl
        public const uint SHGFI_SELECTED = 0x000010000; // show icon in selected state
        public const uint SHGFI_SHELLICONSIZE = 0x000000004; // get shell size icon
        public const uint SHGFI_SMALLICON = 0x000000001; // get small icon
        public const uint SHGFI_SYSICONINDEX = 0x000004000; // get system icon index
        public const uint SHGFI_TYPENAME = 0x000000400; // get type name
        public const uint SHGFI_USEFILEATTRIBUTES = 0x000000010; // use passed dwFileAttribute

        [DllImport("Shell32.dll", CharSet = CharSet.Ansi)]
        public static extern IntPtr SHGetFileInfo(
            string pszPath,
            uint dwFileAttributes,
            ref SHFILEINFO psfi,
            uint cbFileInfo,
            uint uFlags
            );

        #region Nested type: BROWSEINFO

        [StructLayout(LayoutKind.Sequential)]
        public struct BROWSEINFO
        {
            public IntPtr hwndOwner;
            public IntPtr pidlRoot;
            public IntPtr pszDisplayName;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string lpszTitle;
            public uint ulFlags;
            public IntPtr lpfn;
            public int lParam;
            public IntPtr iImage;
        }

        #endregion

        #region Nested type: ITEMIDLIST

        [StructLayout(LayoutKind.Sequential)]
        public struct ITEMIDLIST
        {
            public SHITEMID mkid;
        }

        #endregion

        #region Nested type: SHFILEINFO

        [StructLayout(LayoutKind.Sequential)]
        public struct SHFILEINFO
        {
            public IntPtr hIcon;
            public IntPtr iIcon;
            public uint dwAttributes;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = MAX_PATH)]
            public string szDisplayName;
            [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
            public string szTypeName;
        } ;

        #endregion

        #region Nested type: SHITEMID

        [StructLayout(LayoutKind.Sequential)]
        public struct SHITEMID
        {
            public ushort cb;
            [MarshalAs(UnmanagedType.LPArray)]
            public byte[] abID;
        }

        #endregion
    }

    /// <summary>
    /// Wraps necessary functions imported from User32.dll. Code courtesy of MSDN Cold Rooster Consulting example.
    /// </summary>
    public class NativeMethodsUser32
    {
        /// <summary>
        /// Provides access to function required to delete handle. This method is used internally
        /// and is not required to be called separately.
        /// </summary>
        /// <param name="hIcon">Pointer to icon handle.</param>
        /// <returns>N/A</returns>
        [DllImport("User32.dll")]
        public static extern int DestroyIcon(IntPtr hIcon);
    }

    public class FileIconManager
    {
        private readonly Hashtable _extensionList = new Hashtable();
        private readonly Hashtable _typeNameList = new Hashtable();
        private readonly IconSize _iconSize;
        private readonly ArrayList _imageLists = new ArrayList(); //will hold ImageList objects
        private readonly bool _manageBothSizes; //flag, used to determine whether to create two ImageLists.

        /// <summary>
        /// Creates an instance of <c>FileIconManager</c> that will add icons to a single <c>ImageList</c> using the
        /// specified <c>IconSize</c>.
        /// </summary>
        /// <param name="imageList"><c>ImageList</c> to add icons to.</param>
        /// <param name="iconSize">Size to use (either 32 or 16 pixels).</param>
        public FileIconManager(ImageList imageList, IconSize iconSize)
        {
            // Initialise the members of the class that will hold the image list we're
            // targeting, as well as the icon size (32 or 16)
            _imageLists.Add(imageList);
            _iconSize = iconSize;
        }

        /// <summary>
        /// Creates an instance of FileIconManager that will add icons to two <c>ImageList</c> types. The two
        /// image lists are intended to be one for large icons, and the other for small icons.
        /// </summary>
        /// <param name="smallImageList">The <c>ImageList</c> that will hold small icons.</param>
        /// <param name="largeImageList">The <c>ImageList</c> that will hold large icons.</param>
        public FileIconManager(ImageList smallImageList, ImageList largeImageList)
        {
            //add both our image lists
            _imageLists.Add(smallImageList);
            _imageLists.Add(largeImageList);

            //set flag
            _manageBothSizes = true;
        }

        /// <summary>
        /// Returns an icon for a given file - indicated by the name parameter.
        /// </summary>
        /// <param name="name">Pathname for file.</param>
        /// <param name="size">Large or small</param>
        /// <param name="linkOverlay">Whether to include the link icon</param>
        /// <returns>System.Drawing.Icon</returns>
        public static Icon GetFileIcon(string name, IconSize size, bool linkOverlay, out string typeName)
        {
            NativeMethodsShell32.SHFILEINFO shfi = new NativeMethodsShell32.SHFILEINFO();
            uint flags = NativeMethodsShell32.SHGFI_ICON | NativeMethodsShell32.SHGFI_USEFILEATTRIBUTES | NativeMethodsShell32.SHGFI_TYPENAME;

            if (linkOverlay)
                flags |= NativeMethodsShell32.SHGFI_LINKOVERLAY;

            /* Check the size specified for return. */
            if (IconSize.Small == size)
            {
                flags |= NativeMethodsShell32.SHGFI_SMALLICON;
            }
            else
            {
                flags |= NativeMethodsShell32.SHGFI_LARGEICON;
            }

            NativeMethodsShell32.SHGetFileInfo(name,
                                               NativeMethodsShell32.FILE_ATTRIBUTE_NORMAL,
                                               ref shfi,
                                               (uint)Marshal.SizeOf(shfi),
                                               flags);

            // Copy (clone) the returned icon to a new object, thus allowing us to clean-up properly
            System.Drawing.Icon icon = (System.Drawing.Icon)System.Drawing.Icon.FromHandle(shfi.hIcon).Clone();
            NativeMethodsUser32.DestroyIcon(shfi.hIcon); // Cleanup

            typeName = shfi.szTypeName;

            return icon;
        }

        /// <summary>
        /// Used to access system folder icons.
        /// </summary>
        /// <param name="size">Specify large or small icons.</param>
        /// <param name="folderType">Specify open or closed FolderType.</param>
        /// <returns>System.Drawing.Icon</returns>
        public static Icon GetFolderIcon(IconSize size, FolderType folderType)
        {
            // Need to add size check, although errors generated at present!
            uint flags = NativeMethodsShell32.SHGFI_ICON | NativeMethodsShell32.SHGFI_USEFILEATTRIBUTES;

            if (FolderType.Open == folderType)
            {
                flags += NativeMethodsShell32.SHGFI_OPENICON;
            }

            if (IconSize.Small == size)
            {
                flags += NativeMethodsShell32.SHGFI_SMALLICON;
            }
            else
            {
                flags += NativeMethodsShell32.SHGFI_LARGEICON;
            }

            // Get the folder icon
            NativeMethodsShell32.SHFILEINFO shfi = new NativeMethodsShell32.SHFILEINFO();
            NativeMethodsShell32.SHGetFileInfo(System.AppDomain.CurrentDomain.BaseDirectory,
                                               NativeMethodsShell32.FILE_ATTRIBUTE_DIRECTORY,
                                               ref shfi,
                                               (uint)Marshal.SizeOf(shfi),
                                               flags);

            System.Drawing.Icon.FromHandle(shfi.hIcon); // Load the icon from an HICON handle

            // Now clone the icon, so that it can be successfully stored in an ImageList
            Icon icon = (Icon)Icon.FromHandle(shfi.hIcon).Clone();

            NativeMethodsUser32.DestroyIcon(shfi.hIcon); // Cleanup
            return icon;
        }

        /// <summary>
        /// Used internally, adds the extension to the hashtable, so that its value can then be returned.
        /// </summary>
        /// <param name="extension"><c>String</c> of the file's extension.</param>
        /// <param name="imageListPosition">Position of the extension in the <c>ImageList</c>.</param>
        private void AddExtension(string extension, int imageListPosition)
        {
            _extensionList.Add(extension, imageListPosition);
        }

        /// <summary>
        /// Used internally, adds the extension to the hashtable, so that its value can then be returned.
        /// </summary>
        /// <param name="extension"><c>String</c> of the file's extension.</param>
        /// <param name="imageListPosition">Position of the extension in the <c>ImageList</c>.</param>
        private void AddExtension(string extension, int imageListPosition, string typeName)
        {
            _extensionList.Add(extension, imageListPosition);
            _typeNameList.Add(extension, typeName);
        }

        /// <summary>
        /// Called publicly to add a file's icon to the ImageList.
        /// </summary>
        /// <param name="filePath">Full path to the file.</param>
        /// <returns>Integer of the icon's position in the ImageList</returns>
        public int AddFileIcon(string filePath, out string typeName)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            bool needIcon = extension == ".exe" || extension == ".ico";
            string key = needIcon ? filePath : extension;

            //Check that we haven't already got the extension, if we have, then
            //return back its index
            if (_extensionList.ContainsKey(key))
            {
                typeName = (string)_typeNameList[key];
                return (int)_extensionList[key]; //return existing index
            }

            // It's not already been added, so add it and record its position.

            int pos = ((ImageList)_imageLists[0]).Images.Count; //store current count -- new item's index

            if (_manageBothSizes)
            {
                //managing two lists, so add it to small first, then large
                ((ImageList)_imageLists[0]).Images.Add(GetFileIcon(filePath, IconSize.Small, false, out typeName));
                ((ImageList)_imageLists[1]).Images.Add(GetFileIcon(filePath, IconSize.Large, false, out typeName));
            }
            else
            {
                //only doing one size, so use IconSize as specified in _iconSize.
                ((ImageList)_imageLists[0]).Images.Add(GetFileIcon(filePath, _iconSize, false, out typeName));
                //add to image list
            }

            AddExtension(key, pos, typeName); // add to hash table

            return pos;
        }

        public int AddFolderIcon(FolderType folderType)
        {
            string extension = "*Folder" + folderType;

            if (_extensionList.ContainsKey(extension))
            {
                return (int)_extensionList[extension];
            }

            // It's not already been added, so add it and record its position.

            int pos = ((ImageList)_imageLists[0]).Images.Count; //store current count -- new item's index

            if (_manageBothSizes)
            {
                //managing two lists, so add it to small first, then large
                ((ImageList)_imageLists[0]).Images.Add(GetFolderIcon(IconSize.Small, folderType));
                ((ImageList)_imageLists[1]).Images.Add(GetFolderIcon(IconSize.Large, folderType));
            }
            else
            {
                //only doing one size, so use IconSize as specified in _iconSize.
                ((ImageList)_imageLists[0]).Images.Add(GetFolderIcon(_iconSize, folderType)); //add to image list
            }

            AddExtension(extension, pos); // add to hash table
            return pos;
        }

#if false
        public int AddFileExtension(string extension)
        {
            return AddFileIcon("filePath" + extension);
        }
#endif

        /// <summary>
        /// Clears any <c>ImageLists</c> that <c>FileIconManager</c> is managing.
        /// </summary>
        public void Clear()
        {
            foreach (ImageList imageList in _imageLists)
            {
                imageList.Images.Clear(); //clear current imagelist.
            }

            _extensionList.Clear(); //empty hashtable of entries too.
        }
    }
}