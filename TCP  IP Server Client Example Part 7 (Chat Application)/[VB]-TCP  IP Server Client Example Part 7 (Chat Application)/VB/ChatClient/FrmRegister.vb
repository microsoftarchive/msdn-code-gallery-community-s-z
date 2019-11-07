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
	Partial Public Class FrmRegister
		Inherits Form

		Public Property RegisteredUserEmail() As String
		Public Property RegisteredUserPassword() As String

		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Allow user to Register and Login Simultaneously
		''' Add your own Error Validation
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
			Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.Close()
		End Sub

		''' <summary>
		''' Allow user to Register and Login Simultaneously
		''' Add your own Error Validation
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnLogin_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLogin.Click
			If Me.tbEmailAddress.Text.Length > 0 AndAlso Me.tbPassword.Text.Length > 0 AndAlso Me.tbPassword.Text = Me.tbConfirmPassword.Text Then
				Me.RegisteredUserEmail = Me.tbEmailAddress.Text
				Me.RegisteredUserPassword = Me.tbPassword.Text.Replace(",", "") ' Remove ',' (commas) from passwords as it could invalidate with our messages
				Me.DialogResult = System.Windows.Forms.DialogResult.OK
				Me.Close()
			Else
				MessageBox.Show("Registration Details are not Valid")
			End If
		End Sub
	End Class
End Namespace
