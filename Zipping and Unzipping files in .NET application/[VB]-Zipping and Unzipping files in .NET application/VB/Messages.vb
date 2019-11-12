Namespace ArchiveManager
	Friend NotInheritable Class Messages

		Private Sub New()
		End Sub

		Public Const SyncConfirm As String = "Files and subfolders in folder '{0}' will be updated and some files and folders may be lost." & vbCrLf & "Are you sure you want to synchronize folder '{0}' with local folder '{1}'?"
		Public Const OverwriteFileConfirm As String = "Are you sure you want to overwrite file: {0}" & vbCrLf & "{1} Bytes, {2}" & vbCrLf & vbCrLf & "With file: {3}" & vbCrLf & "{4} Bytes, {5}?"
		Public Const InvalidCharacters As String = "Character '/' or '\' should not be entered"
		Public Const EmptyName As String = "Name cannot be empty."
	End Class
End Namespace
