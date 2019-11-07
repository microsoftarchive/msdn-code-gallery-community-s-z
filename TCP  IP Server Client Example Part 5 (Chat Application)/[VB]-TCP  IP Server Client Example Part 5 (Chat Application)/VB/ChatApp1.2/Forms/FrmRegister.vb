Imports System
Imports System.Linq
Imports System.Windows.Forms

Namespace ChatApp1._2.Forms
	Partial Public Class FrmRegister
		Inherits Form

		Public Property RegisteredUserEmail() As String
		Public Property RegisteredUserPassword() As String

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub FrmRegister_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load

		End Sub

		' Validate Input
		Private Sub BtnLoginClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
			If tbEmailAddress.Text.Length > 0 Then
				If tbPassword.Text.Length > 0 AndAlso tbPassword.Text = tbConfirmPassword.Text Then
					RegisteredUserEmail = tbEmailAddress.Text
					RegisteredUserPassword = tbPassword.Text.Replace(",", "")
					Me.Close()
				Else
					MessageBox.Show("Passwords are invalid or do not match")
				End If
			Else
				MessageBox.Show("Email Address is not Valid")
			End If
		End Sub

		Private Sub BtnCancelClick(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
			Me.Close()
		End Sub
	End Class
End Namespace
