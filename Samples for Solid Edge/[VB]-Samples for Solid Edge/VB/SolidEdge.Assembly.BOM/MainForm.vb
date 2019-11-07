Imports System.ComponentModel
Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Assembly.BOM
	Partial Public Class MainForm
		Inherits Form

		Public Sub New()
			InitializeComponent()
		End Sub

		Private Sub MainForm_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
			' Register with OLE to handle concurrency issues on the current thread.
			OleMessageFilter.Register()
		End Sub

		Private Sub exitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles exitToolStripMenuItem.Click
			Close()
		End Sub

		Private Sub copyToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles copyToolStripMenuItem.Click
			Clipboard.Clear()
			Dim buffer As New StringBuilder()

			' Column Headers
			For i As Integer = 0 To lvBOM.Columns.Count - 1
				buffer.Append(lvBOM.Columns(i).Text)
				buffer.Append(vbTab)
			Next i

			buffer.Append(Environment.NewLine)

			' Rows
			For i As Integer = 0 To lvBOM.Items.Count - 1
				If lvBOM.Items(i).Selected Then
					For j As Integer = 0 To lvBOM.Columns.Count - 1
						buffer.Append(lvBOM.Items(i).SubItems(j).Text)
						buffer.Append(vbTab)
					Next j
					buffer.Append(Environment.NewLine)
				End If
			Next i

			Clipboard.SetText(buffer.ToString())
		End Sub

		Private Sub selectAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles selectAllToolStripMenuItem.Click
			lvBOM.BeginUpdate()

			For Each item As ListViewItem In lvBOM.Items
				item.Selected = True
			Next item

			lvBOM.EndUpdate()
		End Sub

		Private Sub refreshToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles refreshToolStripMenuItem.Click
			RefreshListView()
		End Sub

		Private Sub buttonRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles buttonRefresh.Click
			RefreshListView()
		End Sub

		Private Sub RefreshListView()
			Dim interopDomain As AppDomain = Nothing
			Dim bomItems() As BomItem = Nothing

			Try
				Dim thread = New System.Threading.Thread(Sub()
						' Create a custom AppDomain to do COM Interop.
						' Create a new instance of InteropProxy in the isolated application domain.
					interopDomain = AppDomain.CreateDomain("Interop Domain")
					Dim proxyType As Type = GetType(InteropProxy)
					Dim interopProxy As InteropProxy = TryCast(interopDomain.CreateInstanceAndUnwrap(proxyType.Assembly.FullName, proxyType.FullName), InteropProxy)
					bomItems = interopProxy.GetBomItems()
				End Sub)

				thread.SetApartmentState(System.Threading.ApartmentState.STA)
				thread.Start()
				thread.Join()
				Dim listViewItems As New List(Of ListViewItem)()

				For Each bomItem As BomItem In bomItems
					Dim listViewItem As New ListViewItem(String.Format("{0}", bomItem.Level))
					listViewItem.SubItems.Add(bomItem.DocumentNumber)
					listViewItem.SubItems.Add(bomItem.Revision)
					listViewItem.SubItems.Add(bomItem.Title)
					listViewItem.SubItems.Add(String.Format("{0}", bomItem.Quantity))
					listViewItem.SubItems.Add(bomItem.FileName)
					listViewItem.ImageIndex = If(bomItem.IsSubassembly, 0, 1)
					listViewItems.Add(listViewItem)
				Next bomItem

				lvBOM.Items.Clear()
				lvBOM.Items.AddRange(listViewItems.ToArray())
				lvBOM.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize)
			Catch ex As System.Exception
				MessageBox.Show(ex.StackTrace, ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error)
			Finally
				If interopDomain IsNot Nothing Then
					' Unload the Interop AppDomain. This will automatically free up any COM references.
					AppDomain.Unload(interopDomain)
				End If
			End Try
		End Sub
	End Class
End Namespace
