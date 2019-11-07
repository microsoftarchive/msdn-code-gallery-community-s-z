Namespace ArchiveManager
	Partial Public Class AskPassword
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Gets or sets the archive's password.
		''' </summary>
		Public Property Pass() As String
			Get
				Return txtPassword.Text
			End Get
			Set(ByVal value As String)
				txtPassword.Text = value
			End Set
		End Property

		Private _skip As Boolean
		Public Property Skip() As Boolean
			Get
				Return _skip
			End Get
			Set(ByVal value As Boolean)
				_skip = value
			End Set
		End Property

		''' <summary>
		''' Gets a boolean value indicating whether to use the password for the entire archive.
		''' </summary>
		Public ReadOnly Property UpdateArchivePassword() As Boolean
			Get
				Return chkUpdateArchivePassword.Checked
			End Get
		End Property

		''' <summary>
		''' Gets or sets the archive file name.
		''' </summary>
		Public Property FileName() As String
			Get
				Return lblFile.Text
			End Get
			Set(ByVal value As String)
				lblFile.Text = value
			End Set
		End Property

		Private Sub btnSkip_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnSkip.Click
			_skip = True
			DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub
	End Class
End Namespace