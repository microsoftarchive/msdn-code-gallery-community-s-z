Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.IO
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace ServerClientChat1._3.Forms
	Partial Public Class FrmAzureDatabaseLogin
		Inherits Form

		Public Property ServerName() As String
		Public Property UserName() As String
		Public Property Password() As String

		Public Sub New()
			InitializeComponent()
			ProcessCheckedState()

#If DEBUG Then ' Only show the buttons we need depending upon the running mode.
			btnLoad.Enabled = True
			btnLoad.Visible = True
			btnCancel.Enabled = False
			btnCancel.Visible = False
			btnConnect.Visible = False
			btnConnect.Enabled = False

#Else
			btnLoad.Enabled = True
			btnLoad.Visible = True
			btnCancel.Enabled = True
			btnCancel.Visible = True
			btnConnect.Visible = True
			btnConnect.Enabled = True
#End If
		End Sub

		''' <summary>
		''' Validate the Server name
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub tbServername_Validating(ByVal sender As Object, ByVal e As CancelEventArgs) Handles tbServername.Validating
			ServerName = tbServername.Text.Replace("tcp:", "").Trim() ' Remove the tcp: if there and any extra spaces
#If DEBUG Then
			' Get Results from the Load Button
			' If we do not use the Compile Time constants the ErrorProvider stops us from using the Load Button.
#Else
			 If String.IsNullOrWhiteSpace(ServerName) Then
				errorProvider1.SetError(tbServername, "Server name cannot be empty")
				e.Cancel = True ' Don't move to next control
			Else
				If Not ServerName.Contains(","c) Then
					errorProvider1.SetError(tbServername, "Add , then the port to be used.") ' We should check that the name does not end in , but I will leave that to you to work out how to validate that.
					e.Cancel = True ' Don't move to next control
				Else
					errorProvider1.Clear() ' We don't need to show the Error icon now if it is showing
					e.Cancel = False ' move to next control
				End If
			End If
#End If
		End Sub

		''' <summary>
		''' Validate the User name
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub tbUsername_Validating(ByVal sender As Object, ByVal e As CancelEventArgs) Handles tbUsername.Validating
#If DEBUG Then
			' Get values from Load Button
#Else
			 If String.IsNullOrWhiteSpace(tbUsername.Text) Then
				errorProvider1.SetError(tbUsername, "User name cannot be empty")
				e.Cancel = True ' Don't move to next control
			Else
				UserName = tbUsername.Text.Trim() ' Make sure there are no extra spaces.
				errorProvider1.Clear() ' We don't need to show the Error icon now if it is showing
				e.Cancel = False ' move to next control
			End If
#End If
		End Sub

		''' <summary>
		''' Validate the User's Password
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub tbPassword_Validating(ByVal sender As Object, ByVal e As CancelEventArgs) Handles tbPassword.Validating
#If DEBUG Then
			' Get Values from Load button.
#Else
			If String.IsNullOrWhiteSpace(tbPassword.Text) Then
				errorProvider1.SetError(tbPassword, "Password name cannot be empty")
				e.Cancel = True ' Don't move to next textbox
			Else
				Password = tbPassword.Text.Trim() ' Make sure there are no extra spaces.
				errorProvider1.Clear() ' We don't need to show the Error icon now if it is showing
				e.Cancel = False ' move to next control
			End If
#End If
		End Sub

		''' <summary>
		''' User canceled connection
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
			Me.Close()
		End Sub

		''' <summary>
		''' Make the Connection
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnConnect_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnConnect.Click
			DialogResult = System.Windows.Forms.DialogResult.OK
			Me.Close()
		End Sub

		Private Sub cbRememberForThisSession_CheckedChanged(ByVal sender As Object, ByVal e As EventArgs) Handles cbRememberForThisSession.CheckedChanged
			ProcessCheckedState()
		End Sub

		Private Sub ProcessCheckedState()
			If cbRememberForThisSession.Checked Then
				tbServername.Text = ServerName
				tbUsername.Text = UserName
				tbPassword.Text = Password
			End If
		End Sub

		''' <summary>
		''' Loads the User Connection Details from a File called ChatAzureDB.txt located in My Documents
		''' The file contains three lines
		''' Line 1 Server Details: xxxxxxxxxx.database.windows.net,1433
		''' Line 2 User Name     : YourUserName@xxxxxxxxxx
		''' Line 3 Plain text Password: xxxxxxxxxxxxxxxxxx
		''' 
		''' This is only to aid us in Debugging and SHOULD NOT BE USED IN PRODUCTION
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnLoad_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnLoad.Click
			Try
				Dim path As String = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
				path = System.IO.Path.Combine(path, "ChatAzureDB.txt")

				Dim fs As New FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)
				Dim sr As New StreamReader(fs)

				ServerName = sr.ReadLine()
				UserName = sr.ReadLine()
				Password = sr.ReadLine()

				sr.Close()
				fs.Close()
				DialogResult = System.Windows.Forms.DialogResult.OK
				Me.Close()
			Catch ex As Exception
				MessageBox.Show("Load Configuration File: " & ex.Message)
			End Try

		End Sub
	End Class
End Namespace
