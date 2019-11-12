Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Draft.BatchPrint
	Public Module FileInfoExtensions
		<System.Runtime.CompilerServices.Extension> _
		Public Function GetSmallIcon(ByVal fi As FileInfo) As Icon
			Dim flags As Integer = NativeMethods.SHGFI_ICON Or NativeMethods.SHGFI_SMALLICON
			Dim fileAttributes As Integer = NativeMethods.FILE_ATTRIBUTE_NORMAL

			Dim shfi As New NativeMethods.SHFILEINFO()
			Dim result As IntPtr = NativeMethods.SHGetFileInfo(fi.FullName, fileAttributes, shfi, Marshal.SizeOf(shfi), flags)

			If result.ToInt32() = 0 Then
				Return Nothing
			Else
				Return Icon.FromHandle(shfi.hIcon)
			End If
		End Function
	End Module
End Namespace
