Imports ComponentPro.IO

Namespace ArchiveManager
	Partial Public Class SynchronizeFolders
		Inherits Form
		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub New(ByVal recursive As RecursionMode, ByVal syncDateTime As Boolean, ByVal syncAttributes As Boolean, ByVal comparisonMethod As Integer, ByVal checkForResumability As Boolean, ByVal searchPattern As String, ByVal sourceDir As String)
			InitializeComponent()

			chkRecursive.Checked = recursive = RecursionMode.RecurseIntoAllSubFolders
			chkUpdateTime.Checked = syncDateTime
			chkUpdateAttributes.Checked = syncAttributes
			cbxComparisonType.SelectedIndex = comparisonMethod
			chkResumability.Checked = checkForResumability
			txtSearchPattern.Text = searchPattern
			txtSourceDir.Text = sourceDir
		End Sub

		Public ReadOnly Property Recursive() As RecursionMode
			Get
				If chkRecursive.Checked Then
					Return RecursionMode.RecurseIntoAllSubFolders
				Else
					Return RecursionMode.None
				End If
			End Get
		End Property

		Public ReadOnly Property SyncDateTime() As Boolean
			Get
				Return chkUpdateTime.Checked
			End Get
		End Property

		Public ReadOnly Property SyncAttributes() As Boolean
			Get
				Return chkUpdateAttributes.Checked
			End Get
		End Property

		Public ReadOnly Property ComparisonMethod() As Integer
			Get
				Return cbxComparisonType.SelectedIndex
			End Get
		End Property

		Public ReadOnly Property SearchPattern() As String
			Get
				Return txtSearchPattern.Text
			End Get
		End Property

		Public ReadOnly Property SourceDir() As String
			Get
				Return txtSourceDir.Text
			End Get
		End Property

		Public ReadOnly Property CheckForResumability() As Boolean
			Get
				Return chkResumability.Checked
			End Get
		End Property

		Public ReadOnly Property DeleteFiles() As Boolean
			Get
				Return chkDeleteFiles.Checked
			End Get
		End Property

		Private Sub cbxComparisonType_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles cbxComparisonType.SelectedIndexChanged
			chkResumability.Visible = cbxComparisonType.SelectedIndex = 1
		End Sub

		Private Sub btnSourceDir_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSourceDir.Click
			Try
				Dim dlg As New FolderBrowserDialog()
				dlg.Description = "Select local folder"
				dlg.SelectedPath = txtSourceDir.Text
				If dlg.ShowDialog() = System.Windows.Forms.DialogResult.OK Then
					txtSourceDir.Text = dlg.SelectedPath
				End If
			Catch exc As System.Exception
				Util.ShowError(exc)
			End Try
		End Sub
	End Class
End Namespace