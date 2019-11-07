Imports System.Collections
Imports System.IO
Imports System.Runtime.InteropServices

Namespace ArchiveManager
	''' <summary>
	''' Options to specify the size of icons to return.
	''' </summary>
	Public Enum IconSize
		''' <summary>
		''' Specify large icon - 32 pixels by 32 pixels.
		''' </summary>
		Large = 0
		''' <summary>
		''' Specify small icon - 16 pixels by 16 pixels.
		''' </summary>
		Small = 1
	End Enum

	''' <summary>
	''' Options to specify whether folders should be in the open or closed state.
	''' </summary>
	Public Enum FolderType
		''' <summary>
		''' Specify open folder.
		''' </summary>
		Open = 0
		''' <summary>
		''' Specify closed folder.
		''' </summary>
		Closed = 1
	End Enum

	''' <summary>
	''' Wraps necessary Shell32.dll structures and functions required to retrieve Icon Handles using SHGetFileInfo. Code
	''' courtesy of MSDN Cold Rooster Consulting case study.
	''' </summary>
	Public Class NativeMethodsShell32
		Public Const BIF_BROWSEFORCOMPUTER As UInteger = &H1000
		Public Const BIF_BROWSEFORPRINTER As UInteger = &H2000
		Public Const BIF_BROWSEINCLUDEFILES As UInteger = &H4000
		Public Const BIF_BROWSEINCLUDEURLS As UInteger = &H80
		Public Const BIF_DONTGOBELOWDOMAIN As UInteger = &H2
		Public Const BIF_EDITBOX As UInteger = &H10
		Public Const BIF_NEWDIALOGSTYLE As UInteger = &H40
		Public Const BIF_RETURNFSANCESTORS As UInteger = &H8
		Public Const BIF_RETURNONLYFSDIRS As UInteger = &H1
		Public Const BIF_SHAREABLE As UInteger = &H8000
		Public Const BIF_STATUSTEXT As UInteger = &H4
		Public Const BIF_USENEWUI As UInteger = (BIF_NEWDIALOGSTYLE Or BIF_EDITBOX)
		Public Const BIF_VALIDATE As UInteger = &H20
		Public Const FILE_ATTRIBUTE_DIRECTORY As UInteger = &H10
		Public Const FILE_ATTRIBUTE_NORMAL As UInteger = &H80
		Public Const MAX_PATH As Integer = 256
		Public Const SHGFI_ADDOVERLAYS As UInteger = &H20 ' apply the appropriate overlays
		Public Const SHGFI_ATTR_SPECIFIED As UInteger = &H20000 ' get only specified attributes

		Public Const SHGFI_ATTRIBUTES As UInteger = &H800 ' get attributes
		Public Const SHGFI_DISPLAYNAME As UInteger = &H200 ' get display name
		Public Const SHGFI_EXETYPE As UInteger = &H2000 ' return exe type
		Public Const SHGFI_ICON As UInteger = &H100 ' get icon
		Public Const SHGFI_ICONLOCATION As UInteger = &H1000 ' get icon location
		Public Const SHGFI_LARGEICON As UInteger = &H0 ' get large icon
		Public Const SHGFI_LINKOVERLAY As UInteger = &H8000 ' put a link overlay on icon
		Public Const SHGFI_OPENICON As UInteger = &H2 ' get open icon
		Public Const SHGFI_OVERLAYINDEX As UInteger = &H40 ' Get the index of the overlay
		Public Const SHGFI_PIDL As UInteger = &H8 ' pszPath is a pidl
		Public Const SHGFI_SELECTED As UInteger = &H10000 ' show icon in selected state
		Public Const SHGFI_SHELLICONSIZE As UInteger = &H4 ' get shell size icon
		Public Const SHGFI_SMALLICON As UInteger = &H1 ' get small icon
		Public Const SHGFI_SYSICONINDEX As UInteger = &H4000 ' get system icon index
		Public Const SHGFI_TYPENAME As UInteger = &H400 ' get type name
		Public Const SHGFI_USEFILEATTRIBUTES As UInteger = &H10 ' use passed dwFileAttribute

		<DllImport("Shell32.dll", CharSet := CharSet.Ansi)> _
		Public Shared Function SHGetFileInfo(ByVal pszPath As String, ByVal dwFileAttributes As UInteger, ByRef psfi As SHFILEINFO, ByVal cbFileInfo As UInteger, ByVal uFlags As UInteger) As IntPtr
		End Function

		#Region "Nested type: BROWSEINFO"

		<StructLayout(LayoutKind.Sequential)> _
		Public Structure BROWSEINFO
			Public hwndOwner As IntPtr
			Public pidlRoot As IntPtr
			Public pszDisplayName As IntPtr
			<MarshalAs(UnmanagedType.LPTStr)> _
			Public lpszTitle As String
			Public ulFlags As UInteger
			Public lpfn As IntPtr
			Public lParam As Integer
			Public iImage As IntPtr
		End Structure

		#End Region

		#Region "Nested type: ITEMIDLIST"

		<StructLayout(LayoutKind.Sequential)> _
		Public Structure ITEMIDLIST
			Public mkid As SHITEMID
		End Structure

		#End Region

		#Region "Nested type: SHFILEINFO"

		<StructLayout(LayoutKind.Sequential)> _
		Public Structure SHFILEINFO
			Public hIcon As IntPtr
			Public iIcon As IntPtr
			Public dwAttributes As UInteger
			<MarshalAs(UnmanagedType.ByValTStr, SizeConst := MAX_PATH)> _
			Public szDisplayName As String
			<MarshalAs(UnmanagedType.ByValTStr, SizeConst := 80)> _
			Public szTypeName As String
		End Structure

		#End Region

		#Region "Nested type: SHITEMID"

		<StructLayout(LayoutKind.Sequential)> _
		Public Structure SHITEMID
			Public cb As UShort
			<MarshalAs(UnmanagedType.LPArray)> _
			Public abID() As Byte
		End Structure

		#End Region
	End Class

	''' <summary>
	''' Wraps necessary functions imported from User32.dll. Code courtesy of MSDN Cold Rooster Consulting example.
	''' </summary>
	Public Class NativeMethodsUser32
		''' <summary>
		''' Provides access to function required to delete handle. This method is used internally
		''' and is not required to be called separately.
		''' </summary>
		''' <param name="hIcon">Pointer to icon handle.</param>
		''' <returns>N/A</returns>
		<DllImport("User32.dll")> _
		Public Shared Function DestroyIcon(ByVal hIcon As IntPtr) As Integer
		End Function
	End Class

	Public Class FileIconManager
		Private ReadOnly _extensionList As New Hashtable()
		Private ReadOnly _typeNameList As New Hashtable()
		Private ReadOnly _iconSize As IconSize
		Private ReadOnly _imageLists As New ArrayList() 'will hold ImageList objects
		Private ReadOnly _manageBothSizes As Boolean 'flag, used to determine whether to create two ImageLists.

		''' <summary>
		''' Creates an instance of <c>FileIconManager</c> that will add icons to a single <c>ImageList</c> using the
		''' specified <c>IconSize</c>.
		''' </summary>
		''' <param name="imageList"><c>ImageList</c> to add icons to.</param>
		''' <param name="iconSize">Size to use (either 32 or 16 pixels).</param>
		Public Sub New(ByVal imageList As ImageList, ByVal iconSize As IconSize)
			' Initialise the members of the class that will hold the image list we're
			' targeting, as well as the icon size (32 or 16)
			_imageLists.Add(imageList)
			_iconSize = iconSize
		End Sub

		''' <summary>
		''' Creates an instance of FileIconManager that will add icons to two <c>ImageList</c> types. The two
		''' image lists are intended to be one for large icons, and the other for small icons.
		''' </summary>
		''' <param name="smallImageList">The <c>ImageList</c> that will hold small icons.</param>
		''' <param name="largeImageList">The <c>ImageList</c> that will hold large icons.</param>
		Public Sub New(ByVal smallImageList As ImageList, ByVal largeImageList As ImageList)
			'add both our image lists
			_imageLists.Add(smallImageList)
			_imageLists.Add(largeImageList)

			'set flag
			_manageBothSizes = True
		End Sub

		''' <summary>
		''' Returns an icon for a given file - indicated by the name parameter.
		''' </summary>
		''' <param name="name">Pathname for file.</param>
		''' <param name="size">Large or small</param>
		''' <param name="linkOverlay">Whether to include the link icon</param>
		''' <returns>System.Drawing.Icon</returns>
		Public Shared Function GetFileIcon(ByVal name As String, ByVal size As IconSize, ByVal linkOverlay As Boolean, <System.Runtime.InteropServices.Out()> ByRef typeName As String) As Icon
			Dim shfi As New NativeMethodsShell32.SHFILEINFO()
			Dim flags As UInteger = NativeMethodsShell32.SHGFI_ICON Or NativeMethodsShell32.SHGFI_USEFILEATTRIBUTES Or NativeMethodsShell32.SHGFI_TYPENAME

			If linkOverlay Then
				flags = flags Or NativeMethodsShell32.SHGFI_LINKOVERLAY
			End If

			' Check the size specified for return. 
			If IconSize.Small = size Then
				flags = flags Or NativeMethodsShell32.SHGFI_SMALLICON
			Else
				flags = flags Or NativeMethodsShell32.SHGFI_LARGEICON
			End If

			NativeMethodsShell32.SHGetFileInfo(name, NativeMethodsShell32.FILE_ATTRIBUTE_NORMAL, shfi, CUInt(Marshal.SizeOf(shfi)), flags)

			' Copy (clone) the returned icon to a new object, thus allowing us to clean-up properly
			Dim icon As System.Drawing.Icon = CType(System.Drawing.Icon.FromHandle(shfi.hIcon).Clone(), System.Drawing.Icon)
			NativeMethodsUser32.DestroyIcon(shfi.hIcon) ' Cleanup

			typeName = shfi.szTypeName

			Return icon
		End Function

		''' <summary>
		''' Used to access system folder icons.
		''' </summary>
		''' <param name="size">Specify large or small icons.</param>
		''' <param name="folderType">Specify open or closed FolderType.</param>
		''' <returns>System.Drawing.Icon</returns>
		Public Shared Function GetFolderIcon(ByVal size As IconSize, ByVal folderType As FolderType) As Icon
			' Need to add size check, although errors generated at present!
			Dim flags As UInteger = NativeMethodsShell32.SHGFI_ICON Or NativeMethodsShell32.SHGFI_USEFILEATTRIBUTES

			If FolderType.Open = folderType Then
				flags += NativeMethodsShell32.SHGFI_OPENICON
			End If

			If IconSize.Small = size Then
				flags += NativeMethodsShell32.SHGFI_SMALLICON
			Else
				flags += NativeMethodsShell32.SHGFI_LARGEICON
			End If

			' Get the folder icon
			Dim shfi As New NativeMethodsShell32.SHFILEINFO()
			NativeMethodsShell32.SHGetFileInfo(System.AppDomain.CurrentDomain.BaseDirectory, NativeMethodsShell32.FILE_ATTRIBUTE_DIRECTORY, shfi, CUInt(Marshal.SizeOf(shfi)), flags)

			System.Drawing.Icon.FromHandle(shfi.hIcon) ' Load the icon from an HICON handle

			' Now clone the icon, so that it can be successfully stored in an ImageList
			Dim icon As Icon = CType(Icon.FromHandle(shfi.hIcon).Clone(), Icon)

			NativeMethodsUser32.DestroyIcon(shfi.hIcon) ' Cleanup
			Return icon
		End Function

		''' <summary>
		''' Used internally, adds the extension to the hashtable, so that its value can then be returned.
		''' </summary>
		''' <param name="extension"><c>String</c> of the file's extension.</param>
		''' <param name="imageListPosition">Position of the extension in the <c>ImageList</c>.</param>
		Private Sub AddExtension(ByVal extension As String, ByVal imageListPosition As Integer)
			_extensionList.Add(extension, imageListPosition)
		End Sub

		''' <summary>
		''' Used internally, adds the extension to the hashtable, so that its value can then be returned.
		''' </summary>
		''' <param name="extension"><c>String</c> of the file's extension.</param>
		''' <param name="imageListPosition">Position of the extension in the <c>ImageList</c>.</param>
		Private Sub AddExtension(ByVal extension As String, ByVal imageListPosition As Integer, ByVal typeName As String)
			_extensionList.Add(extension, imageListPosition)
			_typeNameList.Add(extension, typeName)
		End Sub

		''' <summary>
		''' Called publicly to add a file's icon to the ImageList.
		''' </summary>
		''' <param name="filePath">Full path to the file.</param>
		''' <returns>Integer of the icon's position in the ImageList</returns>
		Public Function AddFileIcon(ByVal filePath As String, <System.Runtime.InteropServices.Out()> ByRef typeName As String) As Integer
			Dim extension As String = Path.GetExtension(filePath).ToLower()
			Dim needIcon As Boolean = extension = ".exe" OrElse extension = ".ico"
			Dim key As String
			If needIcon Then
				key = filePath
			Else
				key = extension
			End If

			'Check that we haven't already got the extension, if we have, then
			'return back its index
			If _extensionList.ContainsKey(key) Then
				typeName = CStr(_typeNameList(key))
				Return CInt(Fix(_extensionList(key))) 'return existing index
			End If

			' It's not already been added, so add it and record its position.

			Dim pos As Integer = CType(_imageLists(0), ImageList).Images.Count 'store current count -- new item's index

			If _manageBothSizes Then
				'managing two lists, so add it to small first, then large
				CType(_imageLists(0), ImageList).Images.Add(GetFileIcon(filePath, IconSize.Small, False, typeName))
				CType(_imageLists(1), ImageList).Images.Add(GetFileIcon(filePath, IconSize.Large, False, typeName))
			Else
				'only doing one size, so use IconSize as specified in _iconSize.
				CType(_imageLists(0), ImageList).Images.Add(GetFileIcon(filePath, _iconSize, False, typeName))
				'add to image list
			End If

			AddExtension(key, pos, typeName) ' add to hash table

			Return pos
		End Function

		Public Function AddFolderIcon(ByVal folderType As FolderType) As Integer
			Dim extension As String = "*Folder" & folderType

			If _extensionList.ContainsKey(extension) Then
				Return CInt(Fix(_extensionList(extension)))
			End If

			' It's not already been added, so add it and record its position.

			Dim pos As Integer = CType(_imageLists(0), ImageList).Images.Count 'store current count -- new item's index

			If _manageBothSizes Then
				'managing two lists, so add it to small first, then large
				CType(_imageLists(0), ImageList).Images.Add(GetFolderIcon(IconSize.Small, folderType))
				CType(_imageLists(1), ImageList).Images.Add(GetFolderIcon(IconSize.Large, folderType))
			Else
				'only doing one size, so use IconSize as specified in _iconSize.
				CType(_imageLists(0), ImageList).Images.Add(GetFolderIcon(_iconSize, folderType)) 'add to image list
			End If

			AddExtension(extension, pos) ' add to hash table
			Return pos
		End Function

#If false Then
		Public Function AddFileExtension(ByVal extension As String) As Integer
			Return AddFileIcon("filePath" & extension)
		End Function
#End If

		''' <summary>
		''' Clears any <c>ImageLists</c> that <c>FileIconManager</c> is managing.
		''' </summary>
		Public Sub Clear()
			For Each imageList As ImageList In _imageLists
				imageList.Images.Clear() 'clear current imagelist.
			Next imageList

			_extensionList.Clear() 'empty hashtable of entries too.
		End Sub
	End Class
End Namespace