Imports System.Text
Imports System.Runtime.InteropServices

Namespace SolidEdge.GlobalParameters
	Public Class ExplorerListView
		Inherits ListView

		<DllImport("uxtheme.dll")> _
		Shared Function SetWindowTheme(ByVal hWnd As IntPtr, <MarshalAs(UnmanagedType.LPWStr)> ByVal pszSubAppName As String, <MarshalAs(UnmanagedType.LPWStr)> ByVal pszSubIdList As String) As Integer
		End Function

		Public Sub New()
			MyBase.New()
		End Sub

		Protected Overrides Sub OnCreateControl()
			MyBase.OnCreateControl()
			SetWindowTheme(Handle, "explorer", Nothing)
		End Sub

		Public Property SelectedItem() As ListViewItem
			Get
				Dim item As ListViewItem = Nothing

				If SelectedItems.Count = 1 Then
					item = SelectedItems(0)
				End If

				Return item
			End Get
			Set(ByVal value As ListViewItem)
				SelectedItems.Clear()
				If value IsNot Nothing Then
					value.Selected = True
				End If
			End Set
		End Property
	End Class
End Namespace
