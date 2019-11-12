Imports ComponentPro.Compression

Namespace ArchiveManager
	Partial Public Class Password
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
				txtReenter.Text = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the encryption algorithm.
		''' </summary>
		Public Property EncryptionAlgorithm() As EncryptionAlgorithm
			Get
				If txtPassword.Text.Length = 0 Then
					Return EncryptionAlgorithm.None
				End If

				Select Case cboEncryption.SelectedIndex
					Case 0
						Return EncryptionAlgorithm.PkzipClassic

					Case 1
						Return EncryptionAlgorithm.Aes128

					Case 2
						Return EncryptionAlgorithm.Aes192

					Case Else
						Return EncryptionAlgorithm.Aes256
				End Select
			End Get
			Set(ByVal value As EncryptionAlgorithm)
				Select Case value
					Case EncryptionAlgorithm.None, EncryptionAlgorithm.PkzipClassic
						cboEncryption.SelectedIndex = 0

					Case EncryptionAlgorithm.Aes128
						cboEncryption.SelectedIndex = 1

					Case EncryptionAlgorithm.Aes192
						cboEncryption.SelectedIndex = 2

					Case EncryptionAlgorithm.Aes256
						cboEncryption.SelectedIndex = 3
				End Select
			End Set
		End Property

		''' <summary>
		''' Handles the OK button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
			' Check passwords.
			If txtReenter.Text <> txtPassword.Text Then
				MessageBox.Show("Reentered password does not match with password!", "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Return
			End If

			DialogResult = System.Windows.Forms.DialogResult.OK
		End Sub
	End Class
End Namespace