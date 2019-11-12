Imports System.IO
Imports System.Runtime.InteropServices
Imports System.Text

Namespace SolidEdge.Draft.BatchPrint
	Public Class CustomListView
		Inherits ListView

		Private _useExplorerTheme As Boolean
		Public DraftPrintUtilityOptions As DraftPrintUtilityOptions

		Public Sub New()
			MyBase.New()
			' Turn on double buffering.
			DoubleBuffered = True

			' Setup image list.
			SmallImageList = New ImageList()
			SmallImageList.ColorDepth = ColorDepth.Depth32Bit
		End Sub

		Protected Overrides Sub OnCreateControl()
			MyBase.OnCreateControl()

			' If set in designer, UseExplorerTheme will get called before control is actually created thus calling it a 2nd time here. 
			UseExplorerTheme = _useExplorerTheme
		End Sub

		Protected Overrides Sub OnDragOver(ByVal e As DragEventArgs)
			e.Effect = DragDropEffects.Copy
		End Sub

		Protected Overrides Sub OnDragDrop(ByVal e As DragEventArgs)
			' Can only drop folders\files, so check
			If Not e.Data.GetDataPresent(DataFormats.FileDrop) Then
				Return
			End If

			' Get the paths to the dropped items.
			Dim paths() As String = CType(e.Data.GetData(DataFormats.FileDrop), String())

			' Process each path.
			For Each path As String In paths
				' Determine if path is directory or file.
				If Directory.Exists(path) Then
					Dim searchOption As SearchOption = System.IO.SearchOption.TopDirectoryOnly
					Dim directoryInfo As New DirectoryInfo(path)
					Dim subDirectoryInfos() As DirectoryInfo = directoryInfo.GetDirectories()

					' If directory has subdirectories, ask user if we should process those as well.
					If subDirectoryInfos.Length > 0 Then
						' Build the question to ask the user.
						Dim message As String = String.Format("'{0}' contains subdirectories. Would you like to include those in the search?", directoryInfo.FullName)

						' Ask the question.
						Select Case MessageBox.Show(message, "Process subdirectories?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)
							Case DialogResult.Yes
								searchOption = System.IO.SearchOption.AllDirectories
							Case DialogResult.Cancel
								' Bail out of entire OnDragDrop().
								Return
						End Select
					End If

					AddFolder(directoryInfo, searchOption)
				Else
					Dim fileInfo As New FileInfo(path)

					' We are only interested in Draft files.
					If fileInfo.Extension.Equals(".dft", StringComparison.OrdinalIgnoreCase) Then
						AddFile(fileInfo)
					End If
				End If
			Next path

			' Adjust column(s) width to fit the item content.
			AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent)
		End Sub

		Protected Overrides Sub OnKeyDown(ByVal e As KeyEventArgs)
			MyBase.OnKeyDown(e)

			Try
				' Disable ListView updating while adding items.
				BeginUpdate()

				' Determine the key pressed.
				Select Case e.KeyCode
					Case Keys.A ' CTRL + A = Select All
						If e.Control Then
							For Each item As ListViewItem In Items
								item.Selected = True
							Next item
						End If
					Case Keys.Delete ' DELETE = Remove selected items.
						Do While SelectedItems.Count > 0
							SelectedItems(0).Remove()
						Loop
				End Select
			Catch
				Throw
			Finally
				' Enable ListView updating.
				EndUpdate()
			End Try
		End Sub

		Public Sub AddFolder(ByVal directoryInfo As DirectoryInfo)
			AddFolder(directoryInfo, SearchOption.TopDirectoryOnly)
		End Sub

		Public Sub AddFolder(ByVal directoryInfo As DirectoryInfo, ByVal searchOption As SearchOption)
			AddFiles(directoryInfo.GetFiles("*.dft", searchOption))
		End Sub

		Public Sub AddFiles(ByVal fileInfos() As FileInfo)
			For Each fileInfo As FileInfo In fileInfos
				AddFile(fileInfo)
			Next fileInfo
		End Sub

		Public Sub AddFile(ByVal fileInfo As FileInfo)
			' Only add .dft files.
			If Not fileInfo.Extension.Equals(".dft", StringComparison.OrdinalIgnoreCase) Then
				Return
			End If

			' If the file has already been added, ignore it.
			If Items.ContainsKey(fileInfo.FullName) Then
				Return
			End If

			' Add the icon to the image list if it's not there.
			If Not SmallImageList.Images.ContainsKey(fileInfo.Extension) Then
				' Note: GetSmallIcon() is an extension method.
				Dim icon As Icon = fileInfo.GetSmallIcon()
				SmallImageList.Images.Add(fileInfo.Extension, icon)
			End If


			' Add the list view item.
			Dim listViewItem As ListViewItem = Items.Add(key:= fileInfo.FullName, text:= fileInfo.FullName, imageKey:= fileInfo.Extension)

			' Make a clone of the DraftPrintUtility settings for this individual item.
			listViewItem.Tag = DraftPrintUtilityOptions.Clone()
		End Sub

		Public Property UseExplorerTheme() As Boolean
			Get
				Return _useExplorerTheme
			End Get
			Set(ByVal value As Boolean)
				_useExplorerTheme = value
				If Me.Created Then
					NativeMethods.SetWindowTheme(Me.Handle,If(value, "explorer", ""), Nothing)
				End If
			End Set
		End Property
	End Class
End Namespace
