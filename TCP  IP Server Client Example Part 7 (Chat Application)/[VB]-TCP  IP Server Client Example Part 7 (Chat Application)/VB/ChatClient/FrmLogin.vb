Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace ChatClient
	Partial Public Class FrmLogin
		Inherits Form

		Public Property IsRegistered() As Boolean
		Public Property Password() As String
		Public Property EmailAddress() As String

		Public Sub New()
			InitializeComponent()
			Me.IsRegistered = False ' This is changed if the EU clicks the Register link and successfully registers
		End Sub

		''' <summary>
		''' Cancel the login process
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
			Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.Close()
		End Sub

		''' <summary>
		''' Add your own validation just as it was done in the AzureDB Login Form
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
			If (Not String.IsNullOrWhiteSpace(Me.tbEmailAddress.Text)) AndAlso (Not String.IsNullOrWhiteSpace(Me.tbPassword.Text)) Then

				Me.EmailAddress = tbEmailAddress.Text
				Me.Password = tbPassword.Text.Replace(",", "")

				Me.DialogResult = System.Windows.Forms.DialogResult.OK
				Me.Close()

			Else
				MessageBox.Show("Login details are in valid")
			End If
		End Sub

		''' <summary>
		''' Let the EU Register from here.
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub llRegister_LinkClicked(ByVal sender As Object, ByVal e As LinkLabelLinkClickedEventArgs) Handles llRegister.LinkClicked
			Dim register As New FrmRegister()
			Dim dr As New DialogResult()
			dr = register.ShowDialog()

			If dr = System.Windows.Forms.DialogResult.OK Then
				Me.EmailAddress = register.RegisteredUserEmail
				Me.Password = register.RegisteredUserPassword.Replace(",", "")
				Me.IsRegistered = True
				Me.Close()
			Else
				Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
				Me.Close()
			End If
		End Sub
	End Class
End Namespace
