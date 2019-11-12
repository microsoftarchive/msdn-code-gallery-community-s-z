Imports System.ComponentModel
Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text
Imports System.Threading

Namespace SolidEdge.Draft.BatchPrint
	Partial Public Class MainForm
		Inherits Form

		Private _folderBrowserDialog As New FolderBrowserDialog()

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			BeginInvoke(New MethodInvoker(AddressOf MainForm_Load_Async))
		End Sub

		''' <summary>
		''' Asynchronous version of MainForm_Load.
		''' </summary>
		Private Sub MainForm_Load_Async()
			toolStripStatusLabel.Text = "Connecting to Solid Edge to get a copy of DraftPrintUtility settings."

			Dim application As SolidEdgeFramework.Application = Nothing

			Try
				' Connect to or start Solid Edge.
				application = ConnectToSolidEdge(True)

				' Make sure user can see Solid Edge.
				application.Visible = True

				' Minimize Solid Edge.
				'application.WindowState = (int)FormWindowState.Minimized;

				' Get a copy of the settings for use as a template.
				customListView.DraftPrintUtilityOptions = New DraftPrintUtilityOptions(application)

				' Enable UI.
				toolStrip.Enabled = True
				customListView.Enabled = True
			Catch ex As System.Exception
				MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				If application IsNot Nothing Then
					Marshal.ReleaseComObject(application)
				End If
			End Try

			toolStripStatusLabel.Text = "Tip: You can drag folders and files into the ListView."
		End Sub

		Private Sub buttonOpen_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonOpen.Click
			_folderBrowserDialog.ShowNewFolderButton = False

			If _folderBrowserDialog.ShowDialog(Me) = System.Windows.Forms.DialogResult.OK Then
				Dim searchOption As SearchOption = System.IO.SearchOption.TopDirectoryOnly
				Dim directoryInfo As New DirectoryInfo(_folderBrowserDialog.SelectedPath)
				Dim subDirectoryInfos() As DirectoryInfo = directoryInfo.GetDirectories()

				' If directory has subdirectories, ask user if we should process those as well.
				If subDirectoryInfos.Length > 0 Then
					' Build the question to ask the user.
					Dim message As String = String.Format("'{0}' contains subdirectories. Would you like to include those in the search?", directoryInfo.FullName)

					' Ask the question.
					Select Case MessageBox.Show(message, "Process subdirectories?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
						Case System.Windows.Forms.DialogResult.Yes
							searchOption = System.IO.SearchOption.AllDirectories
						Case System.Windows.Forms.DialogResult.Cancel
							' Bail out of entire OnDragDrop().
							Return
					End Select
				End If

				customListView.AddFolder(directoryInfo, searchOption)
			End If
		End Sub

		Private Sub buttonPrint_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonPrint.Click
			' Not necessary but we'll later highlight each one as we print them.
			For Each listViewItem As ListViewItem In customListView.Items
				listViewItem.Selected = False
			Next listViewItem

			' Loop through all of the files and print them.
			For Each listViewItem As ListViewItem In customListView.Items
				' GUI sugar.  Highligh the item.
				listViewItem.Selected = True

				Dim filename As String = listViewItem.Text
				Dim options As DraftPrintUtilityOptions = CType(listViewItem.Tag, DraftPrintUtilityOptions)

				Dim interopDomain As AppDomain = Nothing

				Try
					toolStripStatusLabel.Text = "Setting up an isolated application domation for COM Interop."

					Dim thread = New Thread(Sub()
						' Create a custom AppDomain to do COM Interop.
						' Create a new instance of InteropProxy in the isolated application domain.
						' Start the printing process in the isolated application domain.
						interopDomain = AppDomain.CreateDomain("Interop Domain")
						Dim proxyType As Type = GetType(InteropProxy)
						Dim interopProxy As InteropProxy = TryCast(interopDomain.CreateInstanceAndUnwrap(proxyType.Assembly.FullName, proxyType.FullName), InteropProxy)
						toolStripStatusLabel.Text = String.Format("Printing '{0}' in isolated application.", filename)
						interopProxy.DoPrint(filename, options)
					End Sub)

					thread.SetApartmentState(ApartmentState.STA)
					thread.Start()
					thread.Join()
				Catch ex As System.Exception
					MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
				Finally
					listViewItem.Selected = False

					If interopDomain IsNot Nothing Then
						' Unload the Interop AppDomain. This will automatically free up any COM references.
						AppDomain.Unload(interopDomain)
					End If
				End Try
			Next listViewItem

			toolStripStatusLabel.Text = String.Empty
		End Sub

		Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
			Close()
		End Sub

		Private Sub customListView_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles customListView.SelectedIndexChanged
			Dim list As New List(Of Object)()

			For Each listViewItem As ListViewItem In customListView.Items
				If listViewItem.Selected Then
					list.Add(listViewItem.Tag)
				End If
			Next listViewItem

			propertyGrid.SelectedObjects = list.ToArray()
		End Sub

		''' <summary>
		''' Connects to a running instance of Solid Edge.
		''' </summary>
		Private Shared Function ConnectToSolidEdge() As SolidEdgeFramework.Application
			Return ConnectToSolidEdge(False)
		End Function

		''' <summary>
		''' Connects to a running instance of Solid Edge with an option to start if not running.
		''' </summary>
		Private Shared Function ConnectToSolidEdge(ByVal startIfNotRunning As Boolean) As SolidEdgeFramework.Application
			Try
				' Attempt to connect to a running instance of Solid Edge.
				Return CType(Marshal.GetActiveObject("SolidEdge.Application"), SolidEdgeFramework.Application)
			Catch ex As System.Runtime.InteropServices.COMException
				' Failed to connect.
				If ex.ErrorCode = -2147221021 Then ' MK_E_UNAVAILABLE
					If startIfNotRunning Then
						' Start Solid Edge.
						Return CType(Activator.CreateInstance(Type.GetTypeFromProgID("SolidEdge.Application")), SolidEdgeFramework.Application)
					Else
						Throw
					End If
				Else
					Throw
				End If
			Catch
				Throw
			End Try
		End Function
	End Class
End Namespace
