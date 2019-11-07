namespace ArchiveManager
{
    static class Messages
    {
        public const string SyncConfirm = "Files and subfolders in folder '{0}' will be updated and some files and folders may be lost.\r\nAre you sure you want to synchronize folder '{0}' with local folder '{1}'?";
        public const string OverwriteFileConfirm = "Are you sure you want to overwrite file: {0}\r\n{1} Bytes, {2}\r\n\r\nWith file: {3}\r\n{4} Bytes, {5}?";
        public const string InvalidCharacters = "Character '/' or '\\' should not be entered";
        public const string EmptyName = "Name cannot be empty.";
    }
}
