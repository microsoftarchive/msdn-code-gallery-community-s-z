Imports System.Text

Namespace ArchiveManager
	Public Enum ArchiverType
		Zip
		Gzip
		Tar
		Tgz
	End Enum

	<Flags> _
	Public Enum MenuOptions
		ArchiveComment = 1
		Password = 2
		CreateSfx = 4
		AddFolder = 8
		Delete = 16
		CreateDirectory = 32
		Move = 64
		ArchiveItemComment = 128
		Update = 256

		All = &HFFFF
	End Enum
End Namespace
