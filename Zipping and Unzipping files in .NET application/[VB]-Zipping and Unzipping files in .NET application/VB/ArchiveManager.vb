'#define TEST
#Const SHOWSPEED = True
#Const PROGRESSBARTOTAL = True

Imports System.ComponentModel
Imports System.Text
Imports System.IO
Imports ComponentPro.Compression
Imports ComponentPro.IO

Namespace ArchiveManager
	Partial Public Class ArchiveManager
		Inherits Form
		Private Const DefaultTitle As String = "ComponentPro UltimateZip ArchiveManager"

		Private ReadOnly _exception As Boolean ' A flag indicating whether an error occurred.

		Private _archiveFileName As String
		Private _settings As ArchiveManagerSettingInfo
		Private _iconManager As FileIconManager

		Private _fileOpForm As FileOperation

		Private _newArchive As Boolean

		Private _folderImageIndex As Integer
		Private Const UpFolderImageIndex As Integer = 0
		Private _tempZipFile As String
		Private _abort As Boolean

		Private _archiverType As ArchiverType
		Private _archiver As ArchiverBase
		Private _menuOptions As MenuOptions

		''' <summary>
		''' Initializes a new instance of the ArchiveManager class.
		''' </summary>
		Public Sub New()
			Try
				InitializeComponent()
			Catch exc As ComponentPro.Licensing.Zip.UltimateLicenseException
				MessageBox.Show(Me, exc.Message)
				_exception = True
				Return
			End Try
		End Sub

		Private Sub CreateArchiver()
			Select Case _archiverType
				Case ArchiverType.Zip
					Dim zipArchiver As New Zip()

					AddHandler zipArchiver.PasswordNeeded, AddressOf zip_PasswordNeeded

					zipArchiver.Password = String.Empty
					zipArchiver.EncryptionAlgorithm = EncryptionAlgorithm.PkzipClassic

'					#Region "Options"
					zipArchiver.CompressionMode = CByte(_settings.CompressionLevel)
					zipArchiver.CompressionMethod = _settings.CompressionMethod
'					#End Region

					_menuOptions = MenuOptions.All

					_archiver = zipArchiver

				Case ArchiverType.Gzip
					Dim gzipArchiver As New Gzip()

					_menuOptions = MenuOptions.ArchiveItemComment

					_archiver = gzipArchiver

				Case ArchiverType.Tar
					Dim tarArchiver As New Tar()

					_menuOptions = MenuOptions.AddFolder Or MenuOptions.CreateDirectory Or MenuOptions.Delete Or MenuOptions.Move Or MenuOptions.Update
					_archiver = tarArchiver

				Case ArchiverType.Tgz
					Dim tgzArchiver As New Tgz()

					_menuOptions = MenuOptions.AddFolder Or MenuOptions.CreateDirectory Or MenuOptions.Delete Or MenuOptions.Move Or MenuOptions.Update
					AddHandler tgzArchiver.SaveProgress, AddressOf zip_SaveProgress
					_archiver = tgzArchiver
			End Select

'			#Region "Options"
			_archiver.PathStoringMode = _settings.PathStoringMode
'			#End Region

			AddHandler _archiver.Progress, AddressOf zip_Progress
			AddHandler _archiver.SaveProgress, AddressOf zip_SaveProgress
			AddHandler _archiver.TransferConfirm, AddressOf archiver_MultipleFilesTransferActionConfirm
		End Sub

		''' <summary>
		''' Handles the form's Load event.
		''' </summary>
		''' <param name="e">The event arguments.</param>
		Protected Overrides Sub OnLoad(ByVal e As EventArgs)
			MyBase.OnLoad(e)

			If _exception Then
				Me.Close()
			End If

			' Load settings from the Registry.
			_settings = ArchiveManagerSettingInfo.LoadConfig()

			_fileOpForm = New FileOperation()

			' Initiate the Icon Manager with small icon size.
			_iconManager = New FileIconManager(imglist, IconSize.Small)
			' Open archive and find all files
			_folderImageIndex = _iconManager.AddFolderIcon(FolderType.Closed)

			' Clear the address bar.
			txtAddress.Text = String.Empty
		End Sub

		''' <summary>
		''' Handles the form's Closing event.
		''' </summary>
		''' <param name="e">The event arguments.</param>
		Protected Overrides Sub OnClosing(ByVal e As CancelEventArgs)
			 MyBase.OnClosing(e)

			If _settings IsNot Nothing Then
				' Save settings.
				_settings.SaveConfig()

				If _newArchive Then
					' If new archive and not saved, then ask user to save it.
					If CloseArchive() = System.Windows.Forms.DialogResult.Cancel Then
						e.Cancel = True
					End If
				End If
			End If
		End Sub

		Private Sub optionsToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles optionsToolStripMenuItem.Click
			' Show options dialog.
			ShowOptions()
		End Sub

		#Region "Commands"

		''' <summary>
		''' Enables toolbar buttons.
		''' </summary>
		Private Sub EnableButtons(ByVal enable As Boolean)
			Dim opened As Boolean = enable AndAlso ((_archiver IsNot Nothing AndAlso _archiver.Opened) OrElse _newArchive)
			Dim selected As Boolean = opened AndAlso (listView.Items.Count > 0 AndAlso listView.SelectedItems.Count > 1 OrElse (listView.SelectedItems.Count = 1 AndAlso listView.SelectedItems(0).ImageIndex <> UpFolderImageIndex))
			Dim folder As Boolean = selected AndAlso listView.SelectedItems(0).ImageIndex = _folderImageIndex

			closeArchiveToolStripMenuItem.Enabled = opened
			tsbClose.Enabled = opened
			testArchiveToolStripMenuItem.Enabled = opened
			tsbTestArchive.Enabled = testArchiveToolStripMenuItem.Enabled
			passwordToolStripMenuItem.Enabled = opened AndAlso (_menuOptions And MenuOptions.Password) <> 0
			archiveCommentToolStripMenuItem.Enabled = opened AndAlso (_menuOptions And MenuOptions.ArchiveComment) <> 0
			addFilesToolStripMenuItem.Enabled = opened
			addFilesContextMenuItem.Enabled = opened
			tsbAddFiles.Enabled = opened
			addFolderToArchiveToolStripMenuItem.Enabled = opened AndAlso (_menuOptions And MenuOptions.AddFolder) <> 0
			addFolderContextMenuItem.Enabled = addFolderToArchiveToolStripMenuItem.Enabled
			tsbAddFolder.Enabled = addFolderToArchiveToolStripMenuItem.Enabled
			refreshToolStripMenuItem.Enabled = opened
			refreshContextMenuItem.Enabled = opened
			tsbRefresh.Enabled = opened
			calculateDirectorySizeToolStripMenuItem.Enabled = selected
			calculateTotalSizeContextMenuItem.Enabled = calculateDirectorySizeToolStripMenuItem.Enabled

			createSFXToolStripMenuItem.Enabled = opened AndAlso (_menuOptions And MenuOptions.CreateSfx) <> 0

			updateArchiveToolStripMenuItem.Enabled = opened AndAlso (_menuOptions And MenuOptions.Update) <> 0
			moveContextMenuItem.Enabled = selected AndAlso (_menuOptions And MenuOptions.Move) <> 0
			moveToolStripMenuItem.Enabled = moveContextMenuItem.Enabled
			fileCommentContextMenuItem.Enabled = selected AndAlso (Not folder) AndAlso (_menuOptions And MenuOptions.ArchiveItemComment) <> 0
			fileCommentToolStripMenuItem.Enabled = fileCommentContextMenuItem.Enabled

			selectAllToolStripMenuItem.Enabled = opened
			invertSelectionToolStripMenuItem.Enabled = selected

			extractToFolderToolStripMenuItem.Enabled = selected
			extractContextMenuItem.Enabled = extractToFolderToolStripMenuItem.Enabled
			tsbExtract.Enabled = extractToFolderToolStripMenuItem.Enabled

			viewFileToolStripMenuItem.Enabled = selected AndAlso Not folder
			viewContextMenuItem.Enabled = viewFileToolStripMenuItem.Enabled
			tsbView.Enabled = viewFileToolStripMenuItem.Enabled
			viewWithInternalViewerContextMenuItem.Enabled = viewFileToolStripMenuItem.Enabled
			viewWithInternalViewerToolStripMenuItem.Enabled = viewFileToolStripMenuItem.Enabled

			deleteFilesToolStripMenuItem.Enabled = selected AndAlso (_menuOptions And MenuOptions.Delete) <> 0
			deleteContextMenuItem.Enabled = deleteFilesToolStripMenuItem.Enabled
			tsbDelete.Enabled = deleteFilesToolStripMenuItem.Enabled

			renameContextMenuItem.Enabled = selected
			renameFileToolStripMenuItem.Enabled = renameContextMenuItem.Enabled

			createDirectoryContextMenuItem.Enabled = opened AndAlso (_menuOptions And MenuOptions.CreateDirectory) <> 0
			createDirectoryToolStripMenuItem.Enabled = createDirectoryContextMenuItem.Enabled

			addressBar.Enabled = opened

			tsbAbort.Enabled = Not enable
			tsbRefresh.Enabled = opened
			tsbSettings.Enabled = enable
			tsbNewArchive.Enabled = enable
			tsbOpenArchive.Enabled = enable
			tsbClose.Enabled = opened
		End Sub

		''' <summary>
		''' Enables dialog's controls.
		''' </summary>
		''' <param name="enable">A boolean value indicating whether to enable dialog's controls.</param>
		Private Sub EnableDialog(ByVal enable As Boolean)
			Util.EnableCloseButton(Me, enable)

'            tsbAddFiles.Enabled = enable;
'            tsbAddFolder.Enabled = enable;
'            tsbClose.Enabled = enable;
'            tsbDelete.Enabled = enable;
'            tsbExtract.Enabled = enable;
'            tsbNewArchive.Enabled = enable;
'            tsbOpenArchive.Enabled = enable;
'            tsbRefresh.Enabled = enable;
'            tsbSettings.Enabled = enable;
'            tsbTestArchive.Enabled = enable;
'            tsbView.Enabled = enable;
'            tsbAbort.Enabled = !enable;

			listView.Enabled = enable
			menuStrip.Enabled = enable

			addressBar.Enabled = enable
		End Sub

		Private Sub EnableProgress(ByVal enable As Boolean)
			EnableProgress(enable, True)
		End Sub

		''' <summary>
		''' Enables dialog's progress bar control.
		''' </summary>
		''' <param name="enable">A boolean value indicating whether to enable dialog's progress bar control.</param>
		Private Sub EnableProgress(ByVal enable As Boolean, ByVal showHideProgressBars As Boolean)
			If showHideProgressBars Then
				toolStripProgressBar.Visible = enable
				progressBarTotal.Visible = enable
			End If

			toolStripStatusSelectionLabel.Visible = enable
			toolStripStatusSelectionLabel.Text = String.Empty
			toolStripStatusLabel.Visible = Not enable
			EnableButtons((Not enable))
			EnableDialog((Not enable))

			If enable Then
				_fileOpForm.Init()
			End If

			_abort = False
		End Sub

		''' <summary>
		''' Shows options dialog.
		''' </summary>
		Private Sub ShowOptions()
			Dim dlg As New Options(_settings)
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK AndAlso _archiver IsNot Nothing Then
				_archiver.PathStoringMode = _settings.PathStoringMode

				If _archiverType = ArchiverType.Zip Then
					Dim zip As Zip = CType(_archiver, Zip)

					zip.CompressionMode = CByte(_settings.CompressionLevel)
					zip.CompressionMethod = _settings.CompressionMethod
				End If
			End If
		End Sub

		''' <summary>
		''' Refreshes the file list view.
		''' </summary>
		Private Sub RefreshView()
			' Clear the list first.
			listView.Items.Clear()
			EnableDialog(False)
			Try
				Dim list As ArchiveItemInfoCollection = CType(_archiver.ListDirectory(), ArchiveItemInfoCollection)

				' Loop though the list and add to the list box
				For Each f As ArchiveItemInfo In list
					Dim typeName As String = Nothing
					Dim iconIndex As Integer = _iconManager.AddFileIcon(f.Name, typeName)

					Dim arr() As String
					If f.Encrypted Then
						If f.LastWriteTime <> Date.MinValue Then
							If f.IsDirectory Then
								If f.CompressedLength = 0 Then
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								Else
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								End If
							Else
								If f.CompressedLength = 0 Then
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								Else
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *",f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								End If
							End If
						Else
							If f.IsDirectory Then
								If f.CompressedLength = 0 Then
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","","","","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","","","","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","","","","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","","","","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","","","",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","","","",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","","","",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","","","",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								Else
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","","",f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","","",f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","","",f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","","",f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","","",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","","",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","","",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","","",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								End If
							Else
								If f.CompressedLength = 0 Then
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","",f.Length.ToString(),"","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","",f.Length.ToString(),"","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","",f.Length.ToString(),"","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","",f.Length.ToString(),"","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","",f.Length.ToString(),"",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","",f.Length.ToString(),"",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","",f.Length.ToString(),"",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","",f.Length.ToString(),"",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								Else
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name & " *","",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name & " *","",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								End If
							End If
						End If
					Else
						If f.LastWriteTime <> Date.MinValue Then
							If f.IsDirectory Then
								If f.CompressedLength = 0 Then
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"","",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								Else
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),"",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								End If
							Else
								If f.CompressedLength = 0 Then
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),"",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								Else
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,f.LastWriteTime.ToShortDateString() & " " & f.LastWriteTime.ToShortTimeString(),f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								End If
							End If
						Else
							If f.IsDirectory Then
								If f.CompressedLength = 0 Then
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"","","","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"","","","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"","","","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"","","","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"","","",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"","","",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"","","",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"","","",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								Else
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"","",f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"","",f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"","",f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"","",f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"","",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"","",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"","",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"","",f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								End If
							Else
								If f.CompressedLength = 0 Then
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"",f.Length.ToString(),"","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"",f.Length.ToString(),"","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"",f.Length.ToString(),"","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"",f.Length.ToString(),"","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"",f.Length.ToString(),"",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"",f.Length.ToString(),"",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"",f.Length.ToString(),"",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"",f.Length.ToString(),"",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								Else
									If (f.CompressedLength <> f.Length AndAlso f.CompressedLength = 0) OrElse f.IsDirectory Then
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","","Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%","",typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									Else
										If f.IsDirectory Then
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),"Directory", ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										Else
											If f.IsDirectory OrElse f.Checksum = 0 Then
												arr = New String() {f.Name,"",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,""}
											Else
												arr = New String() {f.Name,"",f.Length.ToString(),f.CompressionRate.ToString("#.#") & "%",f.CompressedLength.ToString(),typeName, ToAttrs(f.Attributes), f.DirectoryPath,String.Format("{0:X8}", f.Checksum)}
											End If
										End If
									End If
								End If
							End If
						End If
					End If
					Dim item As New ListViewItem(arr)
					If f.IsDirectory Then
						item.ImageIndex = _folderImageIndex
					Else
						item.ImageIndex = iconIndex
					End If
					item.Tag = New TagInfo(f.Name, f.FullName, f.Length, f.CompressedLength, f.CompressionRate, typeName, f.LastWriteTime, f.Checksum, f.Attributes)
					listView.Items.Add(item)
				Next f

				UpdateListViewSorter()

				If _archiver.GetCurrentDirectory().Length > 1 Then ' Not root dir?
					' Add Cdup list item.
					Dim cdup As New ListViewItem("..", 0)
					listView.Items.Insert(0, cdup)
				End If

				' Update local dir textbox's value.
				txtAddress.Text = _archiver.GetCurrentDirectory()
				If listView.Items.Count > 0 Then
					listView.Items(0).Selected = True
				End If
			Catch exc As Exception
				Util.ShowError(exc)
			End Try

			' Re-enable controls.
			EnableDialog(True)
			EnableButtons(True)

			If _archiver IsNot Nothing Then
				txtAddress.Text = _archiver.GetCurrentDirectory()
			Else
				txtAddress.Text = ""
			End If
		End Sub

		''' <summary>
		''' Converts file's attributes to string.
		''' </summary>
		''' <param name="attrs">The FileAttributes object.</param>
		''' <returns>The converted file attribute in string.</returns>
		Private Shared Function ToAttrs(ByVal attrs As FileAttributes) As String
			Dim sb As New StringBuilder()

			If (attrs And FileAttributes.Archive) = FileAttributes.Archive Then
				sb.Append("A"c)
			End If

			If (attrs And FileAttributes.ReadOnly) = FileAttributes.ReadOnly Then
				sb.Append("R"c)
			End If

			If (attrs And FileAttributes.Hidden) = FileAttributes.Hidden Then
				sb.Append("H"c)
			End If

			If (attrs And FileAttributes.System) = FileAttributes.System Then
				sb.Append("S"c)
			End If

			Return sb.ToString()
		End Function

		''' <summary>
		''' Creates a new archive.
		''' </summary>
		Private Sub NewArchive()
			Dim dlg As New CreateNewArchive()
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.Cancel Then
				Return
			End If

			If dlg.Type = ArchiverType.Tgz Then
				Dim saveDlg As New SaveFileDialog()

				saveDlg.Filter = "Tgz File (*.tgz)|*.tgz"

				saveDlg.FilterIndex = 1
				saveDlg.Title = "Create TGZ Archive"
				If saveDlg.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
					Return
				End If

				_archiveFileName = saveDlg.FileName
			Else
				_archiveFileName = Nothing
				' Get temp file path.
				_tempZipFile = System.IO.Path.GetTempFileName()
			End If

			_archiverType = dlg.Type

			Try
				DeleteTempFile()
				_newArchive = _archiveFileName Is Nothing

				If _newArchive Then
					Me.Text = DefaultTitle & " - New Archive - " & _archiverType.ToString()
				Else
					' Set form's title.
					Me.Text = DefaultTitle & " - " & System.IO.Path.GetFileName(_archiveFileName) & " - " & _archiverType.ToString()
				End If

				CreateArchiver()

				If _archiveFileName IsNot Nothing Then
					_archiver.Open(_archiveFileName, FileMode.Create)
				Else
					_archiver.Open(_tempZipFile, FileMode.Create)
				End If
				listView.Items.Clear()

				EnableButtons(True)

				listView.Enabled = True
			Catch exc As Exception
				Util.ShowError(exc)
			End Try
		End Sub

		''' <summary>
		''' Opens an existing archive.
		''' </summary>
		Private Sub OpenArchive()
			If CloseArchive() = System.Windows.Forms.DialogResult.Cancel Then
				Return
			End If

			Dim dlg As New OpenFileDialog()
			Try
				dlg.FileName = _archiveFileName
				dlg.Filter = "Zip File (*.zip;*.zipx)|*.zip;*.zipx|GZip File (*.gz;*.z)|*.gz;*.z|Tar File (*.tar)|*.tar|Tgz File (*.tgz;*.tar.gz)|*.tgz;*.tar.gz|All files (*.*)|*.*"
				dlg.FilterIndex = 1
				dlg.Title = "Select Archive"
				If dlg.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
					Return
				End If
			Catch
				MessageBox.Show(Me, dlg.FileName & " is not a valid archive", "Error")
				Return
			End Try

			Try
				_archiveFileName = dlg.FileName

				If dlg.FileName.ToLower().EndsWith(".tar.gz") OrElse dlg.FileName.ToLower().EndsWith(".tar.z") Then
					_archiverType = ArchiverType.Tgz
				Else
					Select Case Path.GetExtension(dlg.FileName)
						Case ".zip"
							_archiverType = ArchiverType.Zip

						Case ".z", ".gz"
							_archiverType = ArchiverType.Gzip

						Case ".tar"
							_archiverType = ArchiverType.Tar

						Case ".tgz"
							_archiverType = ArchiverType.Tgz
					End Select
				End If

				CreateArchiver()

				' Set encryption algorithm and protection password.
				' Open the archive.
				Try
					_archiver.Open(_archiveFileName)

					' Set form's title.
					Me.Text = DefaultTitle & " - " & System.IO.Path.GetFileName(_archiveFileName)
				Catch e1 As UnauthorizedAccessException
					' Try to open file in read-only mode.
					_archiver.Open(_archiveFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)

					' Set form's title.
					Me.Text = DefaultTitle & " - " & System.IO.Path.GetFileName(_archiveFileName) & " (read-only)"
				End Try
				_newArchive = False

				Me.Text &= " - " & _archiverType.ToString()

				' Refresh the file list view.
				RefreshView()

				' Enable toolbar buttons.
				EnableButtons(True)
			Catch exc As Exception
				Util.ShowError(exc)
				If _archiver.Opened Then
					CloseArchive()
				End If
			End Try
		End Sub

		''' <summary>
		''' Deletes the temporary file.
		''' </summary>
		Private Sub DeleteTempFile()
			Try
				File.Delete(_tempZipFile)
				File.Delete(_tempViewFile)
			Catch
			End Try
		End Sub

		''' <summary>
		''' Closes the archive.
		''' </summary>
		''' <returns>true if new archive will be save; false means closing existing file or new archive will not be saved.</returns>
		Private Function CloseArchive() As DialogResult
			Dim result As DialogResult = System.Windows.Forms.DialogResult.Yes

			If _newArchive AndAlso listView.Items.Count > 0 Then
				result = MessageBox.Show(Me, "The archive is not saved. Do you want to save it?", "ArchiveManager", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)

				If result = System.Windows.Forms.DialogResult.Cancel Then
					Return result
				End If

				If result = System.Windows.Forms.DialogResult.No Then
					GoTo Close
				End If

				Dim dlg As New SaveFileDialog()

				Select Case _archiverType
					Case ArchiverType.Zip
						dlg.Filter = "Zip File (*.zip)|*.zip"

					Case ArchiverType.Gzip
						dlg.Filter = "Gzip File (*.gz)|*.gz|Z File (*.z)|*.z"

					Case ArchiverType.Tar
						dlg.Filter = "Tar File (*.tar)|*.tar"

					Case ArchiverType.Tgz
						dlg.Filter = "Tgz File (*.tgz)|*.tgz"
				End Select

				dlg.FilterIndex = 1
				dlg.Title = "Save Archive as"
				_archiver.Close()

				If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					If File.Exists(dlg.FileName) Then
						File.Delete(dlg.FileName)
					End If

					File.Move(_tempZipFile, dlg.FileName)
				Else
					DeleteTempFile()
					Return System.Windows.Forms.DialogResult.Cancel
				End If
			ElseIf _archiver IsNot Nothing AndAlso _archiver.Opened Then ' Opened?, close it.
				If TypeOf _archiver Is Tgz Then
					EnableProgress(True)
				End If

				_archiver.Close()

				If TypeOf _archiver Is Tgz Then
					EnableProgress(False)
				End If
			End If

		Close:

			Me.Text = DefaultTitle

			listView.Items.Clear()
			listView.Enabled = False
			_newArchive = False
			If _archiver IsNot Nothing Then
				_archiver.Close()
			End If
			_archiver = Nothing

			EnableButtons(True)
			txtAddress.Text = String.Empty

			Return result
		End Function

		''' <summary>
		''' Tests archive.
		''' </summary>
		Private Sub TestArchive()
			Try
				EnableProgress(True)

				' Test the archive.
				Dim errors() As Exception = _archiver.TestAllFiles()

				If errors Is Nothing Then
					MessageBox.Show(Me, "Archive tested", "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Information)
				Else
					Dim sb As New StringBuilder()
					For i As Integer = 0 To errors.Length - 1
						Dim ex As Exception = errors(i)
						Dim ze As ZipException = TryCast(ex, ZipException)

						If ze IsNot Nothing Then
							sb.AppendLine("File " & ze.FileInfo.FullName & " has errors. " & errors(i).Message)
						Else
							sb.AppendLine(errors(i).Message)
						End If
					Next i

					MessageBox.Show(Me, sb.ToString(), "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Warning)
				End If
			Catch exc As Exception
				Util.ShowError(exc)
			Finally
				EnableProgress(False)
			End Try
		End Sub

		''' <summary>
		''' Shows password dialog.
		''' </summary>
		Private Sub ShowPassword()
			Dim zip As Zip = CType(_archiver, Zip)

			Dim dlg As New Password()
			dlg.EncryptionAlgorithm = zip.EncryptionAlgorithm
			dlg.Pass = zip.Password
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				zip.Password = dlg.Pass
				zip.EncryptionAlgorithm = dlg.EncryptionAlgorithm
			End If
		End Sub

		''' <summary>
		''' Shows comment dialog.
		''' </summary>
		Private Sub ShowComment()
			Dim zip As Zip = CType(_archiver, Zip)

			Dim dlg As New ArchiveComment()
			dlg.Comment = zip.Comment

			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				zip.Comment = dlg.Comment
			End If
		End Sub

		''' <summary>
		''' Selects all file in the file list view.
		''' </summary>
		Private Sub SelectAll()
			For Each item As ListViewItem In listView.Items
				item.Selected = True
			Next item
		End Sub

		''' <summary>
		''' Inverts the selection.
		''' </summary>
		Private Sub InvertSelection()
			For Each item As ListViewItem In listView.Items
				item.Selected = Not item.Selected
			Next item
		End Sub

		''' <summary>
		''' Adds files to the current archive.
		''' </summary>
		Private Sub AddFiles()
			Dim dlg As New OpenFileDialog()
			dlg.Filter = "All files (*.*)|*.*"
			dlg.FilterIndex = 1
			dlg.Title = "Select files to add to the archive"
			dlg.Multiselect = True

			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Try
					EnableProgress(True)

					Dim opt As New TransferOptions()
					opt.FileExistsResolveAction = FileExistsResolveAction.Confirm

					Dim path As String = System.IO.Path.GetDirectoryName(dlg.FileNames(0))

					Dim statistics As FileSystemTransferStatistics = _archiver.AddFiles(path, dlg.FileNames, "", opt)

					If (Not _abort) AndAlso statistics.FilesTransferred > 0 Then
						MessageBox.Show(Me, String.Format("{0} file(s) have been added", statistics.FilesTransferred), "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Information)
					End If
#If Not TEST Then
				Catch exc As Exception
					Util.ShowError(exc)
#End If
				Finally
					EnableProgress(False)

					' Refresh the file list view.
					RefreshView()
				End Try
			End If
		End Sub

		Private _selectedPathToAdd As String
		''' <summary>
		''' Adds a folder to the archive.
		''' </summary>
		Private Sub AddFolder()
			Dim dlg As New FolderBrowserDialog()
			dlg.Description = "Select a folder to add to the archive"
			dlg.SelectedPath = _selectedPathToAdd
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Try
					EnableProgress(True)
					_selectedPathToAdd = dlg.SelectedPath
					' Add an entire directory.
					Dim opt As New TransferOptions()
					opt.FileExistsResolveAction = FileExistsResolveAction.Confirm
					Dim statistics As FileSystemTransferStatistics = _archiver.Add(_selectedPathToAdd, "", opt) ' Add the selected directory into the archive.

					If (Not _abort) AndAlso statistics.FilesTransferred > 0 Then
						MessageBox.Show(Me, String.Format("{0} file(s) have been added", statistics.FilesTransferred), "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Information)
					End If
#If Not TEST Then
				Catch exc As Exception
					Util.ShowError(exc)
#End If
				Finally
					EnableProgress(False)

					' Refresh the list view.
					RefreshView()
				End Try
			End If
		End Sub

		Private _selectedPathToExtract As String
		''' <summary>
		''' Extracts to a folder.
		''' </summary>
		Private Sub ExtractToFolder()
			Dim dlg As New FolderBrowserDialog()
			dlg.Description = "Select a folder to extract files to"
			dlg.SelectedPath = _selectedPathToExtract
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Try
					EnableProgress(True)
					_selectedPathToExtract = dlg.SelectedPath
					' Extract selected files.
					Dim list As New List(Of String)()
					For Each item As ListViewItem In listView.SelectedItems
						Dim info As TagInfo = CType(item.Tag, TagInfo)

						If info IsNot Nothing Then
							list.Add(info.FullName)
						End If
					Next item

					Dim opt As New TransferOptions()
					If _settings.Recursive Then
						opt.Recursive = RecursionMode.RecurseIntoAllSubFolders
					Else
						opt.Recursive = RecursionMode.None
					End If
					opt.FileExistsResolveAction = FileExistsResolveAction.Confirm
					_archiver.ExtractFiles(_archiver.GetCurrentDirectory(), list.ToArray(), _selectedPathToExtract, opt)
				Catch exc As Exception
					Util.ShowError(exc)
				Finally
					EnableProgress(False)
				End Try
			End If
		End Sub

		''' <summary>
		''' Aborts the current operation.
		''' </summary>
		Private Sub AbortOperation()
			_abort = True
			_archiver.Cancel()
		End Sub

		Private _tempViewFile As String
		''' <summary>
		''' Views the selected file.
		''' </summary>
		Private Sub ViewFile()
			Dim info As TagInfo = CType(listView.SelectedItems(0).Tag, TagInfo)

			If info Is Nothing Then
				Return
			End If

			_tempViewFile = System.IO.Path.Combine(Path.GetTempPath(), info.Name)

			If File.Exists(_tempViewFile) Then
				Try
					File.Delete(_tempViewFile)
				Catch
				End Try
			End If

			Try
				EnableProgress(True)
				' Extract the selected file to the temporary file for viewing.
				_archiver.ExtractFile(info.FullName, _tempViewFile)
			Catch exc As Exception
				Util.ShowError(exc)
				Return
			Finally
				EnableProgress(False)
			End Try

			System.Diagnostics.Process.Start(_tempViewFile)
		End Sub

		Private Sub InternalViewFile()
			Dim previewStream As Stream = New MemoryStream()
			Dim info As TagInfo = CType(listView.SelectedItems(0).Tag, TagInfo)

			If info Is Nothing Then
				Return
			End If

			Try
				EnableProgress(True)
				' Extract the selected file to the memory stream for viewing.
				_archiver.ExtractFile(info.FullName, previewStream)
			Catch exc As Exception
				Util.ShowError(exc)
				Return
			Finally
				EnableProgress(False)
			End Try

			Dim dlg As New Preview(info.FullName, previewStream)
			If dlg.SupportedFormat Then
				dlg.Text = info.FullName
				dlg.ShowDialog()
			End If
			previewStream.Close()
		End Sub

		''' <summary>
		''' Deletes files.
		''' </summary>
		Private Sub DeleteFiles()
			If MessageBox.Show(Me, String.Format("Are you sure you want to delete {0} file(s)?", listView.SelectedItems.Count), "ArchiveManager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
				EnableProgress(True, False)

				Try
					_archiver.BeginUpdate()

					_abort = False
					Dim count As Integer = listView.SelectedItems.Count
					' Delete the selected files.
					For Each item As ListViewItem In listView.SelectedItems
						If _abort Then
							Exit For
						End If
						Dim info As TagInfo = CType(item.Tag, TagInfo)

						If info Is Nothing Then
							Continue For
						End If

						If item.ImageIndex = _folderImageIndex Then
							' Delete an entire directory.
							_archiver.DeleteDirectory(info.Name, True)
						ElseIf item.ImageIndex <> UpFolderImageIndex Then
							' Delete a file.
							_archiver.DeleteFile(info.Name)
						End If
					Next item

					RefreshView()

					EnableButtons(True)

#If false Then
					MessageBox.Show(Me, String.Format("{0} file(s) have been removed", count), "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Information)
#End If
				Catch exc As Exception
					Util.ShowError(exc)
				End Try
				_archiver.EndUpdate()

				EnableProgress(False, True)

				RefreshView()
			End If
		End Sub

		''' <summary>
		''' Renames selected file.
		''' </summary>
		Private Sub RenameFile()
			If listView.SelectedItems.Count > 0 Then
				listView.SelectedItems(0).BeginEdit()
			End If
		End Sub

		''' <summary>
		''' Renames selected file.
		''' </summary>
		''' <param name="newName">The new file name.</param>
		Private Function DoRename(ByVal newName As String) As Boolean
			If Not String.IsNullOrEmpty(newName) Then
				If newName.IndexOfAny(_archiver.InvalidPathChars) <> -1 OrElse newName.IndexOfAny(_archiver.DirectorySeparators) <> -1 Then
					MessageBox.Show(Me, "The provided file name is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop)
					Return False
				End If

				Dim item As ListViewItem = listView.SelectedItems(0)

				If item.StateImageIndex <> _folderImageIndex Then
					Try
						Dim info As TagInfo = CType(item.Tag, TagInfo)

						If info Is Nothing Then
							Return False
						End If

						Dim oldName As String = info.FullName
						info.Name = newName
						newName = _archiver.CombinePath(_archiver.GetDirectoryName(oldName), newName)
						_archiver.Rename(oldName, newName)
						Dim typeName As String = Nothing
						If item.ImageIndex <> _folderImageIndex Then
							item.ImageIndex = _iconManager.AddFileIcon(newName, typeName)
							info.TypeName = typeName
						End If
						info.FullName = newName


						Return True
					Catch exc As Exception
						Util.ShowError(exc)
					End Try
				End If
			End If

			Return False
		End Function

		''' <summary>
		''' Closes the application.
		''' </summary>
		Private Sub Quit()
			Me.Close()
		End Sub

		#End Region

		''' <summary>
		''' Handles the UltimateZip's PasswordNeeded event.
		''' </summary>
		Private Sub zip_PasswordNeeded(ByVal sender As Object, ByVal e As PasswordNeededEventArgs)
			Dim dlg As New AskPassword()
			dlg.FileName = e.FileName
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				If dlg.Skip Then
					e.SkipFile = True
				Else
					e.Password = dlg.Pass
					e.UpdateArchivePassword = dlg.UpdateArchivePassword ' Update the entire archive password or not?
				End If
			Else
				e.Cancel = True
			End If
		End Sub

		Private Sub newArchiveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles newArchiveToolStripMenuItem.Click
			NewArchive()
		End Sub

		Private Sub openArchiveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles openArchiveToolStripMenuItem.Click
			OpenArchive()
		End Sub

		Private Sub closeArchiveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles closeArchiveToolStripMenuItem.Click
			CloseArchive()
		End Sub

		Private Sub testArchiveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles testArchiveToolStripMenuItem.Click
			TestArchive()
		End Sub

		Private Sub passwordToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles passwordToolStripMenuItem.Click
			ShowPassword()
		End Sub

		Private Sub archiveCommentToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles archiveCommentToolStripMenuItem.Click
			ShowComment()
		End Sub

		Private Sub selectAllToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles selectAllToolStripMenuItem.Click
			SelectAll()
		End Sub

		Private Sub invertSelectionToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles invertSelectionToolStripMenuItem.Click
			InvertSelection()
		End Sub

		Private Sub quitToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles quitToolStripMenuItem.Click
			Quit()
		End Sub

		Private Sub addFilesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addFilesToolStripMenuItem.Click
			AddFiles()
		End Sub

		Private Sub addFolderToArchiveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addFolderToArchiveToolStripMenuItem.Click
			AddFolder()
		End Sub

		Private Sub extractToFolderToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles extractToFolderToolStripMenuItem.Click
			ExtractToFolder()
		End Sub

		Private Sub viewFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles viewFileToolStripMenuItem.Click
			ViewFile()
		End Sub

		Private Sub viewWithInternalViewerToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles viewWithInternalViewerToolStripMenuItem.Click
			InternalViewFile()
		End Sub

		Private Sub deleteFilesToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles deleteFilesToolStripMenuItem.Click
			DeleteFiles()
		End Sub

		Private Sub renameFileToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles renameFileToolStripMenuItem.Click
			RenameFile()
		End Sub

		Private Sub refreshToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles refreshToolStripMenuItem.Click
			RefreshView()
		End Sub

		Private Sub tsbNewArchive_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbNewArchive.Click
			NewArchive()
		End Sub

		Private Sub tsbOpenArchive_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbOpenArchive.Click
			OpenArchive()
		End Sub

		Private Sub tsbClose_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbClose.Click
			CloseArchive()
		End Sub

		Private Sub tsbTestArchive_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbTestArchive.Click
			TestArchive()
		End Sub

		Private Sub tsbAddFiles_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbAddFiles.Click
			AddFiles()
		End Sub

		Private Sub tsbAddFolder_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbAddFolder.Click
			AddFolder()
		End Sub

		Private Sub tsbExtract_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbExtract.Click
			ExtractToFolder()
		End Sub

		Private Sub tsbDelete_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbDelete.Click
			DeleteFiles()
		End Sub

		Private Sub tsbView_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbView.Click
			ViewFile()
		End Sub

		Private Sub tsbRefresh_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbRefresh.Click
			RefreshView()
		End Sub

		Private Sub tsbSettings_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbSettings.Click
			ShowOptions()
		End Sub

		Private Sub lvwArchive_SelectedIndexChanged(ByVal sender As Object, ByVal e As EventArgs) Handles listView.SelectedIndexChanged
			EnableButtons(True)
		End Sub

		Private Sub lvwArchive_DoubleClick(ByVal sender As Object, ByVal e As EventArgs) Handles listView.DoubleClick
			If listView.SelectedItems(0).ImageIndex = _folderImageIndex Then ' Change to the specified folder
				Dim info As TagInfo = CType(listView.SelectedItems(0).Tag, TagInfo)

				_archiver.SetCurrentDirectory(info.Name)

				RefreshView()
			ElseIf listView.SelectedItems(0).ImageIndex = UpFolderImageIndex Then ' Up one level.
				Dim dirPath As String = _archiver.GetDirectoryName(_archiver.GetCurrentDirectory())
				_archiver.SetCurrentDirectory(dirPath)

				RefreshView()
			ElseIf listView.SelectedItems.Count > 0 Then
				tsbView_Click(sender, e)
			End If

			listView.Focus()
		End Sub

		Private Sub addFilesContextMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addFilesContextMenuItem.Click
			AddFiles()
		End Sub

		Private Sub addFolderContextMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles addFolderContextMenuItem.Click
			AddFolder()
		End Sub

		Private Sub extractContextMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles extractContextMenuItem.Click
			ExtractToFolder()
		End Sub

		Private Sub deleteContextMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles deleteContextMenuItem.Click
			DeleteFiles()
		End Sub

		Private Sub viewContextMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles viewContextMenuItem.Click
			ViewFile()
		End Sub

		Private Sub viewWithInternalViewerContextMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles viewWithInternalViewerContextMenuItem.Click
			InternalViewFile()
		End Sub

		Private Sub renameContextMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles renameContextMenuItem.Click
			RenameFile()
		End Sub

		Private Sub refreshContextMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles refreshContextMenuItem.Click
			RefreshView()
		End Sub

		Private Sub listView_AfterLabelEdit(ByVal sender As Object, ByVal e As LabelEditEventArgs) Handles listView.AfterLabelEdit
			e.CancelEdit = Not DoRename(e.Label)
		End Sub

		Private Sub tsbAbort_Click(ByVal sender As Object, ByVal e As EventArgs) Handles tsbAbort.Click
			AbortOperation()
		End Sub

		Private _lastSaveProgressTime As Integer
		Private Sub zip_SaveProgress(ByVal sender As Object, ByVal e As SaveProgressEventArgs)
			Dim tick As Integer = Environment.TickCount
			If tick - _lastSaveProgressTime <= 100 Then
				Return
			End If

			_lastSaveProgressTime = tick

			Dim msg As String = Nothing
			Select Case e.State
				Case SaveProgressState.BackupArchive
					msg = "Backing up archive..."

				Case SaveProgressState.PreserveFile
					msg = "Preserving file " & e.FileName & "..."

				Case SaveProgressState.Rollback
					msg = "Rolling back..."

				Case SaveProgressState.SaveArchive
					msg = "Saving archive..."
			End Select

			toolStripProgressBar.Visible = True
			toolStripStatusSelectionLabel.Visible = True
			toolStripProgressBar.Value = CInt(Fix(e.Percentage))
			toolStripStatusSelectionLabel.Text = msg

#If DEBUG Then
			System.Diagnostics.Trace.WriteLine(msg & " " & e.Percentage & "%")
#End If

			Application.DoEvents()
		End Sub

		Private Sub zip_Progress(ByVal sender As Object, ByVal e As ComponentPro.IO.FileSystemProgressEventArgs)
			Select Case e.State
				Case TransferState.MultiFileOperationCompleted
					System.Diagnostics.Trace.WriteLine(String.Format("Multi-file operation completed. Elapsed time: {0}, Bps: {1}/sec", e.TransferStatistics.ElapsedTime, Util.FormatSize(e.TransferStatistics.BytesPerSecond)))

				Case TransferState.DeletingDirectory
					' It's about to delete a directory. To skip deleting this directory, simply set e.Skip = true.
					toolStripStatusSelectionLabel.Text = String.Format("Deleting directory {0}...", e.SourceFileSystem.GetFileName(e.SourcePath))
					Application.DoEvents()
					Return

				Case TransferState.DeletingFile
					' It's about to delete a file. To skip deleting this file, simply set e.Skip = true.
					toolStripStatusSelectionLabel.Text = String.Format("Deleting file {0}...", e.SourceFileSystem.GetFileName(e.SourcePath))
					Application.DoEvents()
					Return

				Case TransferState.BuildingDirectoryStructure
					' It informs us that the directory structure has been prepared for the multiple file transfer.
					toolStripStatusSelectionLabel.Text = "Building directory structure..."
					toolStripProgressBar.Value = 0
					progressBarTotal.Value = 0
					Application.DoEvents()

				Case TransferState.CreatingDirectory
					' It informs us that a directory is being created.
					toolStripStatusSelectionLabel.Text = "Creating directory " & e.DestinationFileInfo.Name
					toolStripProgressBar.Value = 0
					progressBarTotal.Value = 0
					Application.DoEvents()

'				#Region "Comparing File Events"

				Case TransferState.StartComparingFile
					' Source file and destination file are about to be compared.
					' To skip comparing these files, simply set e.Skip = true.
					' To override the comparison result, set the e.ComparionResult property.
					toolStripStatusSelectionLabel.Text = String.Format("Comparing file {0}...", System.IO.Path.GetFileName(e.SourcePath))
					toolStripProgressBar.Value = CInt(Fix(e.Percentage))
#If PROGRESSBARTOTAL Then
					progressBarTotal.Value = CInt(Fix(e.TotalPercentage))
#End If
					Application.DoEvents()

				Case TransferState.Comparing
					' Source file and destination file are being compared.
					'time = Environment.TickCount;
#If SHOWSPEED Then
					'if (time - _timeLastEvent >= _settings.ProgressUpdateInterval && e.BytesPerSecond > 0)
						toolStripStatusSelectionLabel.Text = String.Format("Comparing file {0}... {1}/sec {2} remaining", System.IO.Path.GetFileName(e.SourcePath), Util.FormatSize(e.BytesPerSecond), e.RemainingTime)
						'_timeLastEvent = time;
						toolStripProgressBar.Value = CInt(Fix(e.Percentage))
#If PROGRESSBARTOTAL Then
						progressBarTotal.Value = CInt(Fix(e.TotalPercentage))
#End If
#End If
					Application.DoEvents()

				Case TransferState.FileCompared
					' Source file and destination file have been compared.
					' Comparison result is saved in the e.ComparisonResult property.
					toolStripProgressBar.Value = CInt(Fix(e.Percentage))
#If PROGRESSBARTOTAL Then
					progressBarTotal.Value = CInt(Fix(e.TotalPercentage))
#End If
					Application.DoEvents()

'				#End Region

'				#Region "Storing File Events"

				Case TransferState.StartStoringFile
					' Source file (local file) is about to be storeed. Destination file is the archive item.
					' To skip storing this file, simply set e.Skip = true.
					toolStripStatusSelectionLabel.Text = String.Format("Storing file {0}...", System.IO.Path.GetFileName(e.SourcePath))
					toolStripProgressBar.Value = CInt(Fix(e.Percentage))
#If PROGRESSBARTOTAL Then
					progressBarTotal.Value = CInt(Fix(e.TotalPercentage))
#End If
					Application.DoEvents()

				Case TransferState.Storing
					' Source file is being storeed to the remote server.
					'time = Environment.TickCount;
#If SHOWSPEED Then

					'if (time - _timeLastEvent >= _settings.ProgressUpdateInterval && e.BytesPerSecond > 0)
						toolStripStatusSelectionLabel.Text = String.Format("Storing file {0}... {1}/sec {2} remaining", System.IO.Path.GetFileName(e.SourcePath), Util.FormatSize(e.BytesPerSecond), e.RemainingTime)
						'_timeLastEvent = time;
						toolStripProgressBar.Value = CInt(Fix(e.Percentage))
#If PROGRESSBARTOTAL Then
						progressBarTotal.Value = CInt(Fix(e.TotalPercentage))
#End If

#End If
					Application.DoEvents()

				Case TransferState.FileStored
					' Source file has been storeed.
					toolStripProgressBar.Value = CInt(Fix(e.Percentage))
#If PROGRESSBARTOTAL Then
					progressBarTotal.Value = CInt(Fix(e.TotalPercentage))
#End If
					Application.DoEvents()

'				#End Region

'				#Region "Extracting File Events"

				Case TransferState.StartExtractingFile
					' Source file (within the archive) is about to be extracted.
					' To skip storing this file, simply set e.Skip = true.
					toolStripStatusSelectionLabel.Text = String.Format("Extracting file {0}...", System.IO.Path.GetFileName(e.SourcePath))
					toolStripProgressBar.Value = CInt(Fix(e.Percentage))
#If PROGRESSBARTOTAL Then
					progressBarTotal.Value = CInt(Fix(e.TotalPercentage))
#End If
					Application.DoEvents()

				Case TransferState.Extracting
					' Source file is being extracted to the local disk.
					'time = Environment.TickCount;
#If SHOWSPEED Then
					'if (time - _timeLastEvent >= _settings.ProgressUpdateInterval && e.BytesPerSecond > 0)
						toolStripStatusSelectionLabel.Text = String.Format("Extracting file {0}... {1}/sec {2} remaining", System.IO.Path.GetFileName(e.SourcePath), Util.FormatSize(e.BytesPerSecond), e.RemainingTime)
						'_timeLastEvent = time;
						toolStripProgressBar.Value = CInt(Fix(e.Percentage))
						progressBarTotal.Value = CInt(Fix(e.TotalPercentage))
#End If
					Application.DoEvents()

				Case TransferState.FileExtracted
					' Remote file has been extracted.
					toolStripProgressBar.Value = CInt(Fix(e.Percentage))
#If PROGRESSBARTOTAL Then
					progressBarTotal.Value = CInt(Fix(e.TotalPercentage))
#End If
					Application.DoEvents()

'				#End Region
			End Select

			Application.DoEvents()

			If _abort Then
				_archiver.Cancel()
			End If
		End Sub

		Private Sub archiver_MultipleFilesTransferActionConfirm(ByVal sender As Object, ByVal e As TransferConfirmEventArgs)
			If Not IsDisposed Then
				Invoke(New EventHandler(Of TransferConfirmEventArgs)(AddressOf MultipleFilesTransferActionConfirm), sender, e)
			End If
		End Sub

		''' <summary>
		''' Handles the client's TransferConfirm event.
		''' </summary>
		''' <param name="sender">The Zip object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub MultipleFilesTransferActionConfirm(ByVal sender As Object, ByVal e As TransferConfirmEventArgs)
			_fileOpForm.Show(Me, e)
		End Sub

		Private Sub applicationMenu_ExitButtonClick(ByVal sender As Object, ByVal e As EventArgs)
			Me.Close()
		End Sub

		Private Sub applicationMenu_OptionsButtonClick(ByVal sender As Object, ByVal e As EventArgs)
			tsbSettings_Click(sender, e)
		End Sub

		Private Sub listView_KeyDown(ByVal sender As Object, ByVal e As KeyEventArgs) Handles listView.KeyDown
			If listView.SelectedItems.Count = 0 Then
				Return
			End If

			Select Case e.KeyCode
				Case System.Windows.Forms.Keys.Back
					btnUpOneLevel_Click(Nothing, Nothing)

				Case Keys.Enter
					If listView.SelectedItems.Count > 0 Then
						lvwArchive_DoubleClick(Nothing, Nothing)
					End If

#If DEBUG Then
				Case Keys.B
					If e.Control AndAlso e.Shift Then
						_archiver.BeginUpdate()
						MessageBox.Show(Me, "Transaction started")
					End If

				Case Keys.E
					If e.Control AndAlso e.Shift Then
						MessageBox.Show(Me, "Ending transaction")

						EnableProgress(True)

						_archiver.EndUpdate()

						EnableProgress(False)
						RefreshView()
					End If

				Case Keys.C
					If e.Control AndAlso e.Shift Then
						_archiver.CancelUpdate()
						MessageBox.Show(Me, "Transaction cancelled")
					End If
#End If
			End Select
		End Sub

		Private _lastLocalColumnToSort As Integer ' last sort action on this column.
		Private _lastLocalSortOrder As SortOrder = SortOrder.Ascending ' last sort order.

		Private Sub UpdateListViewSorter()
			Select Case _lastLocalColumnToSort
				Case 0 ' name
					listView.ListViewItemSorter = New ListViewItemNameComparer(_lastLocalSortOrder, _folderImageIndex)
				Case 1 ' modified
					listView.ListViewItemSorter = New ListViewItemDateComparer(_lastLocalSortOrder, _folderImageIndex)
				Case 2 ' size
					listView.ListViewItemSorter = New ListViewItemSizeComparer(_lastLocalSortOrder, _folderImageIndex)
				Case 3 ' ratio
					listView.ListViewItemSorter = New ListViewItemRatioComparer(_lastLocalSortOrder, _folderImageIndex)
				Case 4 ' compressed size
					listView.ListViewItemSorter = New ListViewItemCompressedSizeComparer(_lastLocalSortOrder, _folderImageIndex)
				Case 5 ' type
					listView.ListViewItemSorter = New ListViewItemTypeNameComparer(_lastLocalSortOrder, _folderImageIndex)
				Case 6 ' attributes
					listView.ListViewItemSorter = New ListViewItemFileAttributesComparer(_lastLocalSortOrder, _folderImageIndex)
				Case 8 ' crc
					listView.ListViewItemSorter = New ListViewItemChecksumComparer(_lastLocalSortOrder, _folderImageIndex)
			End Select

			listView.ListViewItemSorter = Nothing
		End Sub

		Private Sub listView_ColumnClick(ByVal sender As Object, ByVal e As ColumnClickEventArgs) Handles listView.ColumnClick
			If listView.Items.Count = 0 Then
				Return
			End If

			Dim cdup As ListViewItem
			If listView.Items(0).ImageIndex = UpFolderImageIndex Then
				cdup = listView.Items(0)
			Else
				cdup = Nothing
			End If
			If cdup IsNot Nothing Then
				listView.Items.Remove(cdup)
			End If

			Dim sortOrder As SortOrder
			If _lastLocalColumnToSort = e.Column Then
				If _lastLocalSortOrder = SortOrder.Ascending Then
					sortOrder = SortOrder.Descending
				Else
					sortOrder = SortOrder.Ascending
				End If
			Else
				sortOrder = SortOrder.Ascending
			End If

			_lastLocalColumnToSort = e.Column
			_lastLocalSortOrder = sortOrder

			UpdateListViewSorter()

			listView.ListViewItemSorter = Nothing
			If cdup IsNot Nothing Then
				listView.Items.Insert(0, cdup)
			End If
		End Sub

		Private Sub btnUpOneLevel_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUpOneLevel.Click
			Dim dirPath As String = _archiver.GetDirectoryName(_archiver.GetCurrentDirectory())
			_archiver.SetCurrentDirectory(dirPath)

			RefreshView()

			listView.Focus()
		End Sub

		Private Sub createDirectoryToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles createDirectoryContextMenuItem.Click, createDirectoryToolStripMenuItem.Click
			Dim dlg As New NewNamePrompt(Nothing)
			dlg.Text = "Enter Folder Name"
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Try
					_archiver.CreateDirectory(dlg.NewName)
				Catch exc As Exception
					Util.ShowError(exc)
				End Try

				RefreshView()
			End If
		End Sub

		Private _selectedPathToMove As String

		Private Sub moveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles moveContextMenuItem.Click, moveToolStripMenuItem.Click
			Dim dlg As NewNamePrompt
			If _selectedPathToMove IsNot Nothing Then
				dlg = New NewNamePrompt(_selectedPathToMove)
			Else
				dlg = New NewNamePrompt("/")
			End If
			dlg.Text = "Move to"
			dlg.NewNameCaption = "Destination Dir"
			dlg.Rename = False

			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Try
					EnableProgress(True)

					' Build selected file list.
					Dim list As New List(Of String)()
					For Each item As ListViewItem In listView.SelectedItems
						Dim info As TagInfo = CType(item.Tag, TagInfo)

						If info Is Nothing Then
							Continue For
						End If

						list.Add(info.FullName)
					Next item

					Dim opt As New TransferOptions()
					opt.Recursive = RecursionMode.RecurseIntoAllSubFolders
					opt.FileExistsResolveAction = FileExistsResolveAction.Confirm

					_archiver.MoveFiles("", list.ToArray(), dlg.NewName, opt)

					_selectedPathToMove = dlg.NewName
				Catch exc As Exception
					Util.ShowError(exc)
				Finally
					EnableProgress(False)
				End Try

				RefreshView()
			End If
		End Sub

		Private Sub updateArchiveToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles updateArchiveToolStripMenuItem.Click
			' Synchronize.
			Dim dlg As New SynchronizeFolders(RecursionMode.RecurseIntoAllSubFolders, _settings.SyncDateTime, _settings.SyncAttributes, _settings.SyncComparisonMethod, _settings.SyncCheckForResumability, _settings.SyncSearchPattern, _settings.SyncSourceDir)

			If dlg.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
				Return
			End If

			If dlg.SourceDir.Length = 0 Then
				MessageBox.Show(Me, "Source directory cannot be empty", "Update Archive", MessageBoxButtons.OK, MessageBoxIcon.Error)
				Return
			End If

			If MessageBox.Show(Me, String.Format(Messages.SyncConfirm, _archiver.GetCurrentDirectory(), dlg.SourceDir), "Zip Manager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = System.Windows.Forms.DialogResult.Yes Then
				EnableProgress(True)

				_settings.SyncDateTime = dlg.SyncDateTime
				_settings.SyncAttributes = dlg.SyncAttributes
				_settings.SyncComparisonMethod = dlg.ComparisonMethod
				_settings.SyncCheckForResumability = dlg.CheckForResumability
				_settings.SyncSearchPattern = dlg.SearchPattern
				_settings.SyncSourceDir = dlg.SourceDir
				_settings.SyncDeleteFiles = dlg.DeleteFiles

				Dim opt As New SyncOptions()
				opt.Recursive = RecursionMode.RecurseIntoAllSubFolders
				opt.AllowDeletion = dlg.DeleteFiles
				opt.SearchCondition = New NameSearchCondition(dlg.SearchPattern)

				Select Case dlg.ComparisonMethod
					Case 0
						opt.Comparer = ComponentPro.IO.FileComparers.FileLastWriteTimeComparer

					Case 1
						If dlg.CheckForResumability Then
							opt.Comparer = ComponentPro.IO.FileComparers.FileContentComparerWithResumabilityCheck
						Else
							opt.Comparer = ComponentPro.IO.FileComparers.FileContentComparer
						End If

					Case 2
						opt.Comparer = ComponentPro.IO.FileComparers.FileNameComparer
				End Select

				Try
					' Synchronize folders.
					_archiver.Synchronize(_archiver.GetCurrentDirectory(), dlg.SourceDir, False, opt)
				Catch exc As Exception
					Util.ShowError(exc)
				End Try

				EnableProgress(False)
				RefreshView()
			End If
		End Sub

		Private Sub fileCommentToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles fileCommentContextMenuItem.Click, fileCommentToolStripMenuItem.Click
			Dim info As TagInfo = CType(listView.SelectedItems(0).Tag, TagInfo)

			If info Is Nothing Then
				Return
			End If

			Dim item As ArchiveItemInfo = CType(_archiver.GetFileInfo(info.FullName), ArchiveItemInfo)

			Dim dlg As New ArchiveComment()
			dlg.Comment = item.Comment
			dlg.Text = "Comment: " & item.FullName

			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				Select Case _archiverType
					Case ArchiverType.Zip
						CType(_archiver, Zip).SetFileComment(item, dlg.Comment)

					Case ArchiverType.Gzip
						CType(_archiver, Gzip).SetFileComment(item, dlg.Comment)
				End Select
			End If
		End Sub

		Private Sub calculateDirectorySizeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles calculateDirectorySizeToolStripMenuItem.Click
			Try
				' Get the time difference.
				Dim total As Long = 0
				For Each item As ListViewItem In listView.SelectedItems
					Dim info As TagInfo = CType(item.Tag, TagInfo)

					If info Is Nothing Then
						Continue For
					End If

					If item.ImageIndex = _folderImageIndex Then
						total += _archiver.GetDirectorySize(info.FullName, True)
					Else
						total += info.Size
					End If
				Next item

				MessageBox.Show(Me, String.Format("Total size: {0}", Util.FormatSize(total)), "Ftp Client Demo", MessageBoxButtons.OK, MessageBoxIcon.Information)
			Catch exc As Exception
				Util.ShowError(exc)
			End Try
		End Sub

		Private Sub calculateTotalSizeToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles calculateTotalSizeContextMenuItem.Click
			calculateDirectorySizeToolStripMenuItem_Click(Nothing, Nothing)
		End Sub

		Private Sub createSFXToolStripMenuItem_Click(ByVal sender As Object, ByVal e As EventArgs) Handles createSFXToolStripMenuItem.Click
			If _newArchive Then
				MessageBox.Show(Me, "Please save the archive before creating an SFX", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
				Return
			End If

			Dim dlg As New SFXCreation(_settings.SfxStubFile, _settings.SfxOutputFile)
			If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
				_settings.SfxOutputFile = dlg.SfxFileName
				_settings.SfxStubFile = dlg.StubFileName

				Dim path As String = System.IO.Path.GetDirectoryName(dlg.SfxFileName)
				If Not Directory.Exists(path) Then
					Directory.CreateDirectory(path)
				End If

				Dim currentDir As String = _archiver.GetCurrentDirectory()
				_archiver.Close()

				_archiver.Open(_archiver.FileName)

				Dim zip As Zip = CType(_archiver, Zip)

				zip.SfxStubFileName = dlg.StubFileName
				Try
					zip.CreateSfx(dlg.SfxFileName)

					' The output file also needs assemblies.
					File.Copy(AppDomain.CurrentDomain.BaseDirectory & "ComponentPro.FileSystem.dll", path & "\ComponentPro.FileSystem.dll", True)
					File.Copy(AppDomain.CurrentDomain.BaseDirectory & "ComponentPro.Common.dll", path & "\ComponentPro.Common.dll", True)
					File.Copy(AppDomain.CurrentDomain.BaseDirectory & "ComponentPro.Zip.dll", path & "\ComponentPro.Zip.dll", True)

					If MessageBox.Show(Me, "SFX created successfully. Would you like to open the folder containing the archive file?", Me.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Information) = System.Windows.Forms.DialogResult.Yes Then
						System.Diagnostics.Process.Start(Directory.GetParent(dlg.SfxFileName).FullName)
					End If
				Catch exc As Exception
					Util.ShowError(exc)
				End Try

				_archiver.SetCurrentDirectory(currentDir)
			End If
		End Sub
	End Class
End Namespace