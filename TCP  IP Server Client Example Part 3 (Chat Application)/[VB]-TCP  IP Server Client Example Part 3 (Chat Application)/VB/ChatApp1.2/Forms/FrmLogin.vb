Imports System
Imports System.Linq
Imports System.Windows.Forms


Namespace ChatApp1._2.Forms
	Partial Public Class FrmLogin
		Inherits Form

		Public IsRegistered As Boolean = False
	   Public Property Password() As String
		Public Property EmailAddress() As String

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub LlRegisterLinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles llRegister.LinkClicked
			Dim register As New FrmRegister()
			Dim dr As New DialogResult()
			dr = register.ShowDialog()

			If dr = System.Windows.Forms.DialogResult.OK Then
				EmailAddress = register.RegisteredUserEmail
				Password = register.RegisteredUserPassword
				IsRegistered = True
				Me.Close()
			End If
		End Sub

		Private Sub BtnLoginClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
		   If (Not String.IsNullOrEmpty(tbEmailAddress.Text)) OrElse (Not String.IsNullOrWhiteSpace(tbEmailAddress.Text)) Then
				If (Not String.IsNullOrEmpty(tbPassword.Text)) OrElse (Not String.IsNullOrWhiteSpace(tbPassword.Text)) Then
					EmailAddress = tbEmailAddress.Text
					Password = tbPassword.Text

					Me.Close()
				Else
					MessageBox.Show("Password is invalid")
				End If
			Else
				MessageBox.Show("Email Address is in valid")
			End If
		End Sub

		Private Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
			Me.Close()
		End Sub
	End Class
End Namespace
