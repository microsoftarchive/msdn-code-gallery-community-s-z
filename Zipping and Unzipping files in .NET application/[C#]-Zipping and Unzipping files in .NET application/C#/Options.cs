using System;
using System.Windows.Forms;
using ComponentPro.Compression;

namespace ArchiveManager
{
    public partial class Options : Form
    {
        readonly ArchiveManagerSettingInfo _settings;

        public Options()
        {
            InitializeComponent();
        }

        public Options(ArchiveManagerSettingInfo settings)
            : this()
        {
            _settings = settings;

            cbxLevel.SelectedIndex = settings.CompressionLevel;

            switch (_settings.CompressionMethod)
            {
                case CompressionMethod.None:
                    cbxCompressionMethod.SelectedIndex = 0;
                    break;

                case CompressionMethod.Deflate:
                    cbxCompressionMethod.SelectedIndex = 1;
                    break;

                case CompressionMethod.BZIP2:
                    cbxCompressionMethod.SelectedIndex = 2;
                    break;

                case CompressionMethod.PPMd:
                    cbxCompressionMethod.SelectedIndex = 3;
                    break;
            }

            cbxPath.SelectedIndex = (int)settings.PathStoringMode;
            chkRecursive.Checked = settings.Recursive;
        }

        /// <summary>
        /// Handles the OK button's Click event.
        /// </summary>
        /// <param name="sender">The button object.</param>
        /// <param name="e">The event arguments.</param>
        private void btnOK_Click(object sender, EventArgs e)
        {
            _settings.CompressionLevel = cbxLevel.SelectedIndex;

            switch (cbxCompressionMethod.SelectedIndex)
            {
                case 0:
                    _settings.CompressionMethod = CompressionMethod.None;
                    break;

                case 1:
                    _settings.CompressionMethod = CompressionMethod.Deflate;
                    break;

                case 2:
                    _settings.CompressionMethod = CompressionMethod.BZIP2;
                    break;

                case 3:
                    _settings.CompressionMethod = CompressionMethod.PPMd;
                    break;
            }

            _settings.PathStoringMode = (ZipPathStoringMode)cbxPath.SelectedIndex;
            _settings.Recursive = chkRecursive.Checked;
        }
    }
}