Imports System.ComponentModel
Imports System.Text

Namespace ArchiveManager
	Partial Public Class CreateNewArchive
		Inherits Form
		Public Sub New()
			InitializeComponent()

			cbxFileFormat.SelectedIndex = 0
		End Sub

		Public ReadOnly Property Type() As ArchiverType
			Get
				Return CType(cbxFileFormat.SelectedIndex, ArchiverType)
			End Get
		End Property
	End Class
End Namespace