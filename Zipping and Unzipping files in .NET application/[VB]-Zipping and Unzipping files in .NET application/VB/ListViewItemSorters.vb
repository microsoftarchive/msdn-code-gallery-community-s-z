Imports System.Collections
Imports System.IO
Imports ComponentPro.Compression
Imports ComponentPro.IO

Namespace ArchiveManager
	Public Class TagInfo
		Public Name As String
		Public FullName As String
		Public Size As Long
		Public CompressedSize As Long
		Public CompressionRate As Double
		Public TypeName As String
		Public Modified As Date
		Public Crc As UInteger
		Public Attributes As FileAttributes

		Public Sub New(ByVal name As String, ByVal fullName As String, ByVal size As Long, ByVal compressedSize As Long, ByVal compressionRate As Double, ByVal typeName As String, ByVal modified As Date, ByVal crc As UInteger, ByVal attributes As FileAttributes)
			Me.Name = name
			Me.FullName = fullName
			Me.Size = size
			Me.CompressedSize = compressedSize
			Me.CompressionRate = compressionRate
			Me.TypeName = typeName
			Me.Modified = modified
			Me.Crc = crc
			Me.Attributes = attributes
		End Sub
	End Class

	''' <summary>
	''' Base comparer class for comparing two list view items.
	''' </summary>
	Public MustInherit Class ListViewItemComparerBase
		Implements IComparer
		Private ReadOnly _folderImageIndex As Integer
		Protected _sortOrder As SortOrder

		''' <summary>
		''' Initializes a new instance of the ListViewItemComparerBase.
		''' </summary>
		''' <param name="sortOrder">The sort order.</param>
		''' <param name="folderImageIndex">The defined folder image index.</param>
		''' <param name="folderLinkImageIndex">The defined folder link image index.</param>
		Protected Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer)
			_sortOrder = sortOrder

			_folderImageIndex = folderImageIndex
		End Sub

		Public Function Compare(ByVal xobject As Object, ByVal yobject As Object) As Integer Implements IComparer.Compare
			Dim x As ListViewItem = CType(xobject, ListViewItem)
			Dim y As ListViewItem = CType(yobject, ListViewItem)

			' Compare file to file or folder to folder only.
			Dim xIsFolder As Integer
			If x.ImageIndex = _folderImageIndex Then
				xIsFolder = 1
			Else
				xIsFolder = 0
			End If
			Dim yIsFolder As Integer
			If y.ImageIndex = _folderImageIndex Then
				yIsFolder = 1
			Else
				yIsFolder = 0
			End If

			If xIsFolder <> yIsFolder Then
				If _sortOrder = SortOrder.Ascending Then
					Return yIsFolder - xIsFolder
				Else
					Return (xIsFolder - yIsFolder)
				End If
			End If
			If _sortOrder = SortOrder.Ascending Then
				Return OnCompare(CType(x.Tag, TagInfo), CType(y.Tag, TagInfo), x.Text, y.Text)
			Else
				Return OnCompare(CType(y.Tag, TagInfo), CType(x.Tag, TagInfo), y.Text, x.Text)
			End If
		End Function

		Public MustOverride Function OnCompare(ByVal x As TagInfo, ByVal y As TagInfo, ByVal xtext As String, ByVal ytext As String) As Integer
	End Class

	''' <summary>
	''' Date time comparer.
	''' </summary>
	Public Class ListViewItemDateComparer
		Inherits ListViewItemComparerBase
		Public Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer)
			MyBase.New(sortOrder, folderImageIndex)
		End Sub

		Public Overrides Function OnCompare(ByVal x As TagInfo, ByVal y As TagInfo, ByVal xtext As String, ByVal ytext As String) As Integer
			Return Date.Compare(x.Modified, y.Modified)
		End Function
	End Class

	''' <summary>
	''' File attributes comparer.
	''' </summary>
	Public Class ListViewItemFileAttributesComparer
		Inherits ListViewItemComparerBase
		Public Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer)
			MyBase.New(sortOrder, folderImageIndex)
		End Sub

		Public Overrides Function OnCompare(ByVal x As TagInfo, ByVal y As TagInfo, ByVal xtext As String, ByVal ytext As String) As Integer
			Return x.Attributes - y.Attributes
		End Function
	End Class

	''' <summary>
	''' Name comparer.
	''' </summary>
	Public Class ListViewItemNameComparer
		Inherits ListViewItemComparerBase
		Public Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer)
			MyBase.New(sortOrder, folderImageIndex)
		End Sub

		Public Overrides Function OnCompare(ByVal x As TagInfo, ByVal y As TagInfo, ByVal xtext As String, ByVal ytext As String) As Integer
			Return String.Compare(xtext, ytext, True)
		End Function
	End Class

	''' <summary>
	''' Size comparer.
	''' </summary>
	Public Class ListViewItemSizeComparer
		Inherits ListViewItemComparerBase
		Public Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer)
			MyBase.New(sortOrder, folderImageIndex)
		End Sub

		Public Overrides Function OnCompare(ByVal x As TagInfo, ByVal y As TagInfo, ByVal xtext As String, ByVal ytext As String) As Integer
			If x.Size = y.Size Then
				Return 0
			End If
			If x.Size > y.Size Then
				Return 1
			Else
				Return -1
			End If
		End Function
	End Class

	''' <summary>
	''' Compressed Size comparer.
	''' </summary>
	Public Class ListViewItemCompressedSizeComparer
		Inherits ListViewItemComparerBase
		Public Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer)
			MyBase.New(sortOrder, folderImageIndex)
		End Sub

		Public Overrides Function OnCompare(ByVal x As TagInfo, ByVal y As TagInfo, ByVal xtext As String, ByVal ytext As String) As Integer
			If x.CompressedSize = y.CompressedSize Then
				Return 0
			End If
			If x.CompressedSize > y.CompressedSize Then
				Return 1
			Else
				Return -1
			End If
		End Function
	End Class

	''' <summary>
	''' Compressed Size comparer.
	''' </summary>
	Public Class ListViewItemTypeNameComparer
		Inherits ListViewItemComparerBase
		Public Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer)
			MyBase.New(sortOrder, folderImageIndex)
		End Sub

		Public Overrides Function OnCompare(ByVal x As TagInfo, ByVal y As TagInfo, ByVal xtext As String, ByVal ytext As String) As Integer
			Return String.Compare(x.TypeName, y.TypeName)
		End Function
	End Class

	''' <summary>
	''' Ratio comparer.
	''' </summary>
	Public Class ListViewItemRatioComparer
		Inherits ListViewItemComparerBase
		Public Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer)
			MyBase.New(sortOrder, folderImageIndex)
		End Sub

		Public Overrides Function OnCompare(ByVal x As TagInfo, ByVal y As TagInfo, ByVal xtext As String, ByVal ytext As String) As Integer
			If x.CompressionRate = y.CompressionRate Then
				Return 0
			End If

			If x.CompressionRate > y.CompressionRate Then
				Return 1
			Else
				Return -1
			End If
		End Function
	End Class

	''' <summary>
	''' Checksum comparer.
	''' </summary>
	Public Class ListViewItemChecksumComparer
		Inherits ListViewItemComparerBase
		Public Sub New(ByVal sortOrder As SortOrder, ByVal folderImageIndex As Integer)
			MyBase.New(sortOrder, folderImageIndex)
		End Sub

		Public Overrides Function OnCompare(ByVal x As TagInfo, ByVal y As TagInfo, ByVal xtext As String, ByVal ytext As String) As Integer
			Return CInt(x.Crc - y.Crc)
		End Function
	End Class
End Namespace
