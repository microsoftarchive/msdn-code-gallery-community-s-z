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
	Partial Public Class FrmAddFriend
		Inherits Form

		Public Property FriendsEmailAddress() As String
		Public Property MyEmailAddress() As String
		Public Sub New()
			InitializeComponent()
		End Sub

		''' <summary>
		''' Get's the friends email address
		''' No Validation here, it needs to be added for production
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnAdd_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnAdd.Click
			If String.IsNullOrWhiteSpace(tbFriendsEmailAddress.Text) Then
				MessageBox.Show(My.Resources.YouMustEnterTheValidEmailAddressOfYourFriend)
			Else
				FriendsEmailAddress = tbFriendsEmailAddress.Text
				If FriendsEmailAddress <> MyEmailAddress Then
					DialogResult = System.Windows.Forms.DialogResult.OK
					Me.Close()
				Else
					MessageBox.Show(My.Resources.YouCanTAddYourselfAsAFriend)
				End If
			End If
		End Sub

		''' <summary>
		''' The EU has changed their mind - or they don't have any friends!
		''' </summary>
		''' <param name="sender"></param>
		''' <param name="e"></param>
		Private Sub btnCancel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnCancel.Click
			DialogResult = System.Windows.Forms.DialogResult.Cancel
			Me.Close()
		End Sub
	End Class
End Namespace
