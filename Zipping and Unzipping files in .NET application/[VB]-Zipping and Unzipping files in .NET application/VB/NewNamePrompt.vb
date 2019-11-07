Namespace ArchiveManager
	Partial Public Class NewNamePrompt
		Inherits Form
		Public Sub New(ByVal oldName As String)
			InitializeComponent()

			txtNewName.Text = oldName
		End Sub

		''' <summary>
		''' Gets the desired new name.
		''' </summary>
		Public Property NewName() As String
			Get
				Return txtNewName.Text
			End Get
			Set(ByVal value As String)
				txtNewName.Text = value
			End Set
		End Property

		''' <summary>
		''' Gets the desired new name caption.
		''' </summary>
		Public Property NewNameCaption() As String
			Get
				Return lbl.Text
			End Get
			Set(ByVal value As String)
				lbl.Text = value
			End Set
		End Property

		Private _rename As Boolean = True
		''' <summary>
		''' Gets the desired new name caption.
		''' </summary>
		Public Property Rename() As Boolean
			Get
				Return _rename
			End Get
			Set(ByVal value As Boolean)
				_rename = value
			End Set
		End Property

		''' <summary>
		''' Handles the OK button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
			If _rename Then
				' Check for invalid characters.
				If NewName.Contains("/") OrElse NewName.Contains("\") Then
					MessageBox.Show(Messages.InvalidCharacters, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Return
				End If
			End If

			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub
	End Class
End Namespace