Namespace ArchiveManager
	Partial Public Class SFXCreation
		Inherits Form
		Public Sub New(ByVal stubFileName As String, ByVal sfxOutputFileName As String)
			InitializeComponent()

			txtName.Text = stubFileName
			txtSfx.Text = sfxOutputFileName
		End Sub

		''' <summary>
		''' Gets the desired Stub file name.
		''' </summary>
		Public Property StubFileName() As String
			Get
				Return txtName.Text
			End Get
			Set(ByVal value As String)
				txtName.Text = value
			End Set
		End Property

		''' <summary>
		''' Gets the desired SFX file name.
		''' </summary>
		Public Property SfxFileName() As String
			Get
				Return txtSfx.Text
			End Get
			Set(ByVal value As String)
				txtSfx.Text = value
			End Set
		End Property

		''' <summary>
		''' Handles the OK button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOk_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOk.Click
#If false Then
			' Check for invalid characters.
			If StubFileName.Contains("/") OrElse StubFileName.Contains("\") Then
				MessageBox.Show(Messages.InvalidCharacters, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Return
			End If

			If SfxFileName.Contains("/") OrElse SfxFileName.Contains("\") Then
				MessageBox.Show(Messages.InvalidCharacters, Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop)
				Return
			End If
#End If

			Me.DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub

		Private Sub btnStubFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnStubFile.Click
			Try
				Dim dlg As New OpenFileDialog()
				dlg.Title = "Select an SFX stub file"
				dlg.FileName = txtName.Text
				dlg.Filter = "All files|*.*"
				dlg.FilterIndex = 1
				If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					txtName.Text = dlg.FileName
				End If
			Catch exc As Exception
				Util.ShowError(exc)
			End Try
		End Sub

		Private Sub btnBrowseSfx_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnBrowseSfx.Click
			Try
				Dim dlg As New OpenFileDialog()
				dlg.Title = "Select an SFX file"
				dlg.FileName = txtSfx.Text
				dlg.Filter = "All files|*.*"
				dlg.FilterIndex = 1
				If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					txtSfx.Text = dlg.FileName
				End If
			Catch exc As Exception
				Util.ShowError(exc)
			End Try
		End Sub
	End Class
End Namespace