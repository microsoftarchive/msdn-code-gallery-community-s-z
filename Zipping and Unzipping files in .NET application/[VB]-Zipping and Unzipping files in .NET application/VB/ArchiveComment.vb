Namespace ArchiveManager
	Partial Public Class ArchiveComment
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Gets or sets the archive's comment.
		''' </summary>
		Public Property Comment() As String
			Get
				Return txtComment.Text
			End Get
			Set(ByVal value As String)
				txtComment.Text = value
			End Set
		End Property
	End Class
End Namespace