Imports ComponentPro.Compression

Namespace ArchiveManager
	Public Class ArchiveManagerSettingInfo
		Private _pathStoringMode As ZipPathStoringMode
		Private _compressionLevel As Integer
		Private _compressionMethod As CompressionMethod
		Private _recursive As Boolean

		''' <summary>
		''' Gets or sets the path storing mode.
		''' </summary>
		Public Property PathStoringMode() As ZipPathStoringMode
			Get
				Return _pathStoringMode
			End Get
			Set(ByVal value As ZipPathStoringMode)
				_pathStoringMode = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the compression level.
		''' </summary>
		Public Property CompressionLevel() As Integer
			Get
				Return _compressionLevel
			End Get
			Set(ByVal value As Integer)
				_compressionLevel = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the compression method.
		''' </summary>
		Public Property CompressionMethod() As CompressionMethod
			Get
				Return _compressionMethod
			End Get
			Set(ByVal value As CompressionMethod)
				_compressionMethod = value
			End Set
		End Property

		''' <summary>
		''' Gets or sets the boolean value indicating whether to allow zip/unzip files and directories recursively.
		''' </summary>
		Public Property Recursive() As Boolean
			Get
				Return _recursive
			End Get
			Set(ByVal value As Boolean)
				_recursive = value
			End Set
		End Property

		Private _syncAttributes As Boolean
		Public Property SyncAttributes() As Boolean
			Get
				Return _syncAttributes
			End Get
			Set(ByVal value As Boolean)
				_syncAttributes = value
			End Set
		End Property

		Private _syncTime As Boolean
		Public Property SyncDateTime() As Boolean
			Get
				Return _syncTime
			End Get
			Set(ByVal value As Boolean)
				_syncTime = value
			End Set
		End Property

		Private _syncDeleteFiles As Boolean
		Public Property SyncDeleteFiles() As Boolean
			Get
				Return _syncDeleteFiles
			End Get
			Set(ByVal value As Boolean)
				_syncDeleteFiles = value
			End Set
		End Property

		Private _syncCheckForResumability As Boolean
		Public Property SyncCheckForResumability() As Boolean
			Get
				Return _syncCheckForResumability
			End Get
			Set(ByVal value As Boolean)
				_syncCheckForResumability = value
			End Set
		End Property

		Private _syncSearchPattern As String
		Public Property SyncSearchPattern() As String
			Get
				Return _syncSearchPattern
			End Get
			Set(ByVal value As String)
				_syncSearchPattern = value
			End Set
		End Property

		Private _syncComparisonMethod As Integer
		Public Property SyncComparisonMethod() As Integer
			Get
				Return _syncComparisonMethod
			End Get
			Set(ByVal value As Integer)
				_syncComparisonMethod = value
			End Set
		End Property

		Private _syncSourceDir As String
		Public Property SyncSourceDir() As String
			Get
				Return _syncSourceDir
			End Get
			Set(ByVal value As String)
				_syncSourceDir = value
			End Set
		End Property

		Private _progressUpdateInterval As Integer
		Public Property ProgressUpdateInterval() As Integer
			Get
				Return _progressUpdateInterval
			End Get
			Set(ByVal value As Integer)
				_progressUpdateInterval = value
			End Set
		End Property

		Private _sfxStubFile As String
		Public Property SfxStubFile() As String
			Get
				Return _sfxStubFile
			End Get
			Set(ByVal value As String)
				_sfxStubFile = value
			End Set
		End Property

		Private _sfxOutputFile As String
		Public Property SfxOutputFile() As String
			Get
				Return _sfxOutputFile
			End Get
			Set(ByVal value As String)
				_sfxOutputFile = value
			End Set
		End Property

		#Region "Static Methods"

		''' <summary>
		''' Loads settings from the Registry.
		''' </summary>
		''' <returns>The ArchiveManagerSettingInfo class.</returns>
		Public Shared Function LoadConfig() As ArchiveManagerSettingInfo
			Dim s As New ArchiveManagerSettingInfo()

			s._compressionLevel = Util.GetIntProperty("CompressionLevel", 6)
			s._compressionMethod = CType(Util.GetIntProperty("CompressionMethod", CInt(Fix(ComponentPro.Compression.CompressionMethod.Deflate))), CompressionMethod)
			s._pathStoringMode = CType(Util.GetIntProperty("PathStoringMode", CInt(Fix(ZipPathStoringMode.RelativePath))), ZipPathStoringMode)
			s._recursive = CStr(Util.GetProperty("Recursive", "True")) = "True"

			s._syncAttributes = CStr(Util.GetProperty("SyncAttributes", "True")) = "True"
			s._syncTime = CStr(Util.GetProperty("SyncDateTime", "True")) = "True"
			s._syncCheckForResumability = CStr(Util.GetProperty("SyncCheckForResumability", "True")) = "True"
			s._syncDeleteFiles = CStr(Util.GetProperty("SyncDeleteFiles", "True")) = "True"
			s._syncSearchPattern = CStr(Util.GetProperty("SyncSearchPattern", "*.*"))
			s._syncComparisonMethod = Util.GetIntProperty("SyncComparisonMethod", 0)
			s._syncSourceDir = CStr(Util.GetProperty("SyncSourceDir", ""))

			s._progressUpdateInterval = Util.GetIntProperty("ProgressUpdateInterval", 50)

			s._sfxStubFile = CStr(Util.GetProperty("SfxStubFile", Util.DataDir & "\SfxStubSelfExtractor.exe"))
			s._sfxOutputFile = CStr(Util.GetProperty("SfxOutputFile", Util.OutputDir & "\SelfExtractor.exe"))

			Return s
		End Function

		''' <summary>
		''' Saves settings from the Registry.
		''' </summary>
		''' <returns>The ArchiveManagerSettingInfo class.</returns>
		Public Sub SaveConfig()
			Util.SaveProperty("CompressionLevel", _compressionLevel)
			Util.SaveProperty("CompressionMethod", CInt(Fix(_compressionMethod)))
			Util.SaveProperty("PathStoringMode", CInt(Fix(_pathStoringMode)))
			Util.SaveProperty("Recursive", _recursive)

			Util.SaveProperty("SyncAttributes", _syncAttributes)
			Util.SaveProperty("SyncDateTime", _syncTime)
			Util.SaveProperty("SyncDeleteFiles", _syncDeleteFiles)
			Util.SaveProperty("SyncCheckForResumability", _syncCheckForResumability)
			Util.SaveProperty("SyncSearchPattern", _syncSearchPattern)
			Util.SaveProperty("SyncComparisonMethod", _syncComparisonMethod)
			Util.SaveProperty("SyncSourceDir", _syncSourceDir)

			Util.SaveProperty("ProgressUpdateInterval", ProgressUpdateInterval)

			Util.SaveProperty("SfxStubFile", _sfxStubFile)
			Util.SaveProperty("SfxOutputFile", _sfxOutputFile)
		End Sub

		#End Region
	End Class
End Namespace