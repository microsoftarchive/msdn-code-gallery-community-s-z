using ComponentPro.Compression;

namespace ArchiveManager
{
    public class ArchiveManagerSettingInfo
    {
        private ZipPathStoringMode _pathStoringMode;
        private int _compressionLevel;
        private CompressionMethod _compressionMethod;
        private bool _recursive;

        /// <summary>
        /// Gets or sets the path storing mode.
        /// </summary>
        public ZipPathStoringMode PathStoringMode
        {
            get { return _pathStoringMode; }
            set { _pathStoringMode = value; }
        }

        /// <summary>
        /// Gets or sets the compression level.
        /// </summary>
        public int CompressionLevel
        {
            get { return _compressionLevel; }
            set { _compressionLevel = value; }
        }

        /// <summary>
        /// Gets or sets the compression method.
        /// </summary>
        public CompressionMethod CompressionMethod
        {
            get { return _compressionMethod; }
            set { _compressionMethod = value; }
        }

        /// <summary>
        /// Gets or sets the boolean value indicating whether to allow zip/unzip files and directories recursively.
        /// </summary>
        public bool Recursive
        {
            get { return _recursive; }
            set { _recursive = value; }
        }

        bool _syncAttributes;
        public bool SyncAttributes
        {
            get { return _syncAttributes; }
            set { _syncAttributes = value; }
        }

        bool _syncTime;
        public bool SyncDateTime
        {
            get { return _syncTime; }
            set { _syncTime = value; }
        }

        bool _syncDeleteFiles;
        public bool SyncDeleteFiles
        {
            get { return _syncDeleteFiles; }
            set { _syncDeleteFiles = value; }
        }

        bool _syncCheckForResumability;
        public bool SyncCheckForResumability
        {
            get { return _syncCheckForResumability; }
            set { _syncCheckForResumability = value; }
        }

        string _syncSearchPattern;
        public string SyncSearchPattern
        {
            get { return _syncSearchPattern; }
            set { _syncSearchPattern = value; }
        }

        int _syncComparisonMethod;
        public int SyncComparisonMethod
        {
            get { return _syncComparisonMethod; }
            set { _syncComparisonMethod = value; }
        }

        string _syncSourceDir;
        public string SyncSourceDir
        {
            get { return _syncSourceDir; }
            set { _syncSourceDir = value; }
        }

        int _progressUpdateInterval;
        public int ProgressUpdateInterval
        {
            get { return _progressUpdateInterval; }
            set { _progressUpdateInterval = value; }
        }

        string _sfxStubFile;
        public string SfxStubFile
        {
            get { return _sfxStubFile; }
            set { _sfxStubFile = value; }
        }

        string _sfxOutputFile;
        public string SfxOutputFile
        {
            get { return _sfxOutputFile; }
            set { _sfxOutputFile = value; }
        }

        #region Static Methods

        /// <summary>
        /// Loads settings from the Registry.
        /// </summary>
        /// <returns>The ArchiveManagerSettingInfo class.</returns>
        public static ArchiveManagerSettingInfo LoadConfig()
        {
            ArchiveManagerSettingInfo s = new ArchiveManagerSettingInfo();

            s._compressionLevel = Util.GetIntProperty("CompressionLevel", 6);
            s._compressionMethod = (CompressionMethod)Util.GetIntProperty("CompressionMethod", (int)ComponentPro.Compression.CompressionMethod.Deflate);
            s._pathStoringMode = (ZipPathStoringMode) Util.GetIntProperty("PathStoringMode", (int) ZipPathStoringMode.RelativePath);
            s._recursive = (string)Util.GetProperty("Recursive", "True") == "True";

            s._syncAttributes = (string)Util.GetProperty("SyncAttributes", "True") == "True";
            s._syncTime = (string)Util.GetProperty("SyncDateTime", "True") == "True";
            s._syncCheckForResumability = (string)Util.GetProperty("SyncCheckForResumability", "True") == "True";
            s._syncDeleteFiles = (string)Util.GetProperty("SyncDeleteFiles", "True") == "True";
            s._syncSearchPattern = (string)Util.GetProperty("SyncSearchPattern", "*.*");
            s._syncComparisonMethod = Util.GetIntProperty("SyncComparisonMethod", 0);
            s._syncSourceDir = (string)Util.GetProperty("SyncSourceDir", "");

            s._progressUpdateInterval = Util.GetIntProperty("ProgressUpdateInterval", 50);

            s._sfxStubFile = (string)Util.GetProperty("SfxStubFile", Util.DataDir + "\\SfxStubSelfExtractor.exe");
            s._sfxOutputFile = (string)Util.GetProperty("SfxOutputFile", Util.OutputDir + "\\SelfExtractor.exe");

            return s;
        }

        /// <summary>
        /// Saves settings from the Registry.
        /// </summary>
        /// <returns>The ArchiveManagerSettingInfo class.</returns>
        public void SaveConfig()
        {
            Util.SaveProperty("CompressionLevel", _compressionLevel);
            Util.SaveProperty("CompressionMethod", (int)_compressionMethod);
            Util.SaveProperty("PathStoringMode", (int)_pathStoringMode);
            Util.SaveProperty("Recursive", _recursive);

            Util.SaveProperty("SyncAttributes", _syncAttributes);
            Util.SaveProperty("SyncDateTime", _syncTime);
            Util.SaveProperty("SyncDeleteFiles", _syncDeleteFiles);
            Util.SaveProperty("SyncCheckForResumability", _syncCheckForResumability);
            Util.SaveProperty("SyncSearchPattern", _syncSearchPattern);
            Util.SaveProperty("SyncComparisonMethod", _syncComparisonMethod);
            Util.SaveProperty("SyncSourceDir", _syncSourceDir);

            Util.SaveProperty("ProgressUpdateInterval", ProgressUpdateInterval);

            Util.SaveProperty("SfxStubFile", _sfxStubFile);
            Util.SaveProperty("SfxOutputFile", _sfxOutputFile);
        }

        #endregion
    }
}