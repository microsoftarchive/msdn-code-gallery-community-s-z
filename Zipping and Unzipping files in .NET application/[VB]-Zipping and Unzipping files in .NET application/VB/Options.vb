Imports ComponentPro.Compression

Namespace ArchiveManager
	Partial Public Class Options
		Inherits Form
		Private ReadOnly _settings As ArchiveManagerSettingInfo

		Public Sub New()
			InitializeComponent()
		End Sub

		Public Sub New(ByVal settings As ArchiveManagerSettingInfo)
			Me.New()
			_settings = settings

			cbxLevel.SelectedIndex = settings.CompressionLevel

			Select Case _settings.CompressionMethod
				Case CompressionMethod.None
					cbxCompressionMethod.SelectedIndex = 0

				Case CompressionMethod.Deflate
					cbxCompressionMethod.SelectedIndex = 1

				Case CompressionMethod.BZIP2
					cbxCompressionMethod.SelectedIndex = 2

				Case CompressionMethod.PPMd
					cbxCompressionMethod.SelectedIndex = 3
			End Select

			cbxPath.SelectedIndex = CInt(Fix(settings.PathStoringMode))
			chkRecursive.Checked = settings.Recursive
		End Sub

		''' <summary>
		''' Handles the OK button's Click event.
		''' </summary>
		''' <param name="sender">The button object.</param>
		''' <param name="e">The event arguments.</param>
		Private Sub btnOK_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnOK.Click
			_settings.CompressionLevel = cbxLevel.SelectedIndex

			Select Case cbxCompressionMethod.SelectedIndex
				Case 0
					_settings.CompressionMethod = CompressionMethod.None

				Case 1
					_settings.CompressionMethod = CompressionMethod.Deflate

				Case 2
					_settings.CompressionMethod = CompressionMethod.BZIP2

				Case 3
					_settings.CompressionMethod = CompressionMethod.PPMd
			End Select

			_settings.PathStoringMode = CType(cbxPath.SelectedIndex, ZipPathStoringMode)
			_settings.Recursive = chkRecursive.Checked
		End Sub
	End Class
End Namespace