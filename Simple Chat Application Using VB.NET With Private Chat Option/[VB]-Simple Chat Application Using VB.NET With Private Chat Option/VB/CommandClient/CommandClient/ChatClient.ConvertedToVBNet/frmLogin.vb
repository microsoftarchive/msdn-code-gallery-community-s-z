Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Windows.Forms
Imports System.Net
Imports Proshot.UtilityLib.CommonDialogs

Public Partial Class frmLogin
	Inherits Form
	Private canClose As Boolean
	Private m_client As Proshot.CommandClient.CMDClient
	Public ReadOnly Property Client() As Proshot.CommandClient.CMDClient
		Get
			Return m_client
		End Get
	End Property
	Public Sub New(serverIP As IPAddress, serverPort As Integer)
		InitializeComponent()
		Me.canClose = False
		Control.CheckForIllegalCrossThreadCalls = False
		Me.m_client = New Proshot.CommandClient.CMDClient(serverIP, serverPort, "None")
        AddHandler Me.m_client.CommandReceived, AddressOf CommandReceived
        AddHandler Me.m_client.ConnectingSuccessed, AddressOf client_ConnectingSuccessed
        AddHandler Me.m_client.ConnectingFailed, AddressOf client_ConnectingFailed
    End Sub

	Private Sub client_ConnectingFailed(sender As Object, e As EventArgs)
		Dim popup As New frmPopup(PopupSkins.SmallInfoSkin)
		popup.ShowPopup("Error", "Server Is Not Accessible !", 200, 2000, 2000)
		Me.SetEnablity(True)
	End Sub

	Private Sub client_ConnectingSuccessed(sender As Object, e As EventArgs)
		Me.m_client.SendCommand(New Proshot.CommandClient.Command(Proshot.CommandClient.CommandType.IsNameExists, Me.m_client.IP, Me.m_client.NetworkName))
	End Sub

	Private Sub CommandReceived(sender As Object, e As Proshot.CommandClient.CommandEventArgs)
		If e.Command.CommandType = Proshot.CommandClient.CommandType.IsNameExists Then
			If e.Command.MetaData.ToLower() = "true" Then
				Dim popup As New frmPopup(PopupSkins.SmallInfoSkin)
				popup.ShowPopup("Error", "The Username is already exists !", 300, 2000, 2000)
				Me.m_client.Disconnect()
				Me.SetEnablity(True)
			Else
				Me.canClose = True
				Me.Close()
			End If
		End If
	End Sub

	Private Sub LoginToServer()
		If Me.txtUsetName.Text.Trim() = "" Then
			Dim popup As New frmPopup(PopupSkins.SmallInfoSkin)
			popup.ShowPopup("Error", "Username is empty !", 1000, 2000, 2000)
			Me.SetEnablity(True)
		Else
			Me.m_client.NetworkName = Me.txtUsetName.Text.Trim()
			Me.m_client.ConnectToServer()
		End If
	End Sub
	Private Sub btnEnter_Click(sender As Object, e As EventArgs)
		Me.SetEnablity(False)
		Me.LoginToServer()
	End Sub
	Private Sub SetEnablity(enable As Boolean)
		Me.btnEnter.Enabled = enable
		Me.txtUsetName.Enabled = enable
		Me.btnExit.Enabled = enable
	End Sub

	Private Sub btnExit_Click(sender As Object, e As EventArgs)
		Me.canClose = True
	End Sub

	Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs)
		If Not Me.canClose Then
			e.Cancel = True
		Else
            RemoveHandler Me.m_client.CommandReceived, AddressOf CommandReceived
		End If
	End Sub
End Class
