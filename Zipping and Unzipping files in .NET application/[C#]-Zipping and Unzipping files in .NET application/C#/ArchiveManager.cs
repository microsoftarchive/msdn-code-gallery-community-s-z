//#define TEST
#define SHOWSPEED
#define PROGRESSBARTOTAL

using System;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using ComponentPro.Compression;
using ComponentPro.IO;

namespace ArchiveManager
{
    public partial class ArchiveManager : Form
    {
        const string DefaultTitle = "ComponentPro UltimateZip ArchiveManager";

        private readonly bool _exception; // A flag indicating whether an error occurred.

        private string _archiveFileName;
        private ArchiveManagerSettingInfo _settings;
        private FileIconManager _iconManager;

        private FileOperation _fileOpForm;

        private bool _newArchive;

        private int _folderImageIndex;
        private const int UpFolderImageIndex = 0;
        private string _tempZipFile;
        private bool _abort;

        private ArchiverType _archiverType;
        private ArchiverBase _archiver;
        private MenuOptions _menuOptions;

        /// <summary>
        /// Initializes a new instance of the ArchiveManager class.
        /// </summary>
        public ArchiveManager()
        {
            try
            {
                InitializeComponent();
            }
            catch (ComponentPro.Licensing.Zip.UltimateLicenseException exc)
            {
                MessageBox.Show(this, exc.Message);
                _exception = true;
                return;
            }
        }

        void CreateArchiver()
        {
            switch (_archiverType)
            {
                case ArchiverType.Zip:
                    Zip zipArchiver = new Zip();

                    zipArchiver.PasswordNeeded += zip_PasswordNeeded;

                    zipArchiver.Password = string.Empty;
                    zipArchiver.EncryptionAlgorithm = EncryptionAlgorithm.PkzipClassic;

                    #region Options
                    zipArchiver.CompressionMode = (byte)_settings.CompressionLevel;
                    zipArchiver.CompressionMethod = _settings.CompressionMethod;
                    #endregion

                    _menuOptions = MenuOptions.All;

                    _archiver = zipArchiver;
                    break;

                case ArchiverType.Gzip:
                    Gzip gzipArchiver = new Gzip();

                    _menuOptions = MenuOptions.ArchiveItemComment;

                    _archiver = gzipArchiver;
                    break;

                case ArchiverType.Tar:
                    Tar tarArchiver = new Tar();

                    _menuOptions = MenuOptions.AddFolder | MenuOptions.CreateDirectory | MenuOptions.Delete | MenuOptions.Move | MenuOptions.Update;
                    _archiver = tarArchiver;
                    break;

                case ArchiverType.Tgz:
                    Tgz tgzArchiver = new Tgz();

                    _menuOptions = MenuOptions.AddFolder | MenuOptions.CreateDirectory | MenuOptions.Delete | MenuOptions.Move | MenuOptions.Update;
                    tgzArchiver.SaveProgress += zip_SaveProgress;                    
                    _archiver = tgzArchiver;
                    break;
            }

            #region Options
            _archiver.PathStoringMode = _settings.PathStoringMode;
            #endregion

            _archiver.Progress += zip_Progress;
            _archiver.SaveProgress += zip_SaveProgress;
            _archiver.TransferConfirm += archiver_MultipleFilesTransferActionConfirm;
        }

        /// <summary>
        /// Handles the form's Load event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (_exception)
                this.Close();

            // Load settings from the Registry.
            _settings = ArchiveManagerSettingInfo.LoadConfig();

            _fileOpForm = new FileOperation();

            // Initiate the Icon Manager with small icon size.
            _iconManager = new FileIconManager(imglist, IconSize.Small);
            // Open archive and find all files
            _folderImageIndex = _iconManager.AddFolderIcon(FolderType.Closed);

            // Clear the address bar.
            txtAddress.Text = string.Empty;
        }

        /// <summary>
        /// Handles the form's Closing event.
        /// </summary>
        /// <param name="e">The event arguments.</param>
        protected override void OnClosing(CancelEventArgs e)
        {
 	        base.OnClosing(e);

            if (_settings != null)
            {
                // Save settings.
                _settings.SaveConfig();

                if (_newArchive)
                {
                    // If new archive and not saved, then ask user to save it.
                    if (CloseArchive() == DialogResult.Cancel)
                    {
                        e.Cancel = true;
                    }
                }
            }
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Show options dialog.
            ShowOptions();
        }

        #region Commands

        /// <summary>
        /// Enables toolbar buttons.
        /// </summary>
        private void EnableButtons(bool enable)
        {
            bool opened = enable && ((_archiver != null && _archiver.Opened) || _newArchive);
            bool selected = opened && (listView.Items.Count > 0 && listView.SelectedItems.Count > 1 || (listView.SelectedItems.Count == 1 && listView.SelectedItems[0].ImageIndex != UpFolderImageIndex));
            bool folder = selected && listView.SelectedItems[0].ImageIndex == _folderImageIndex;

            closeArchiveToolStripMenuItem.Enabled = opened; tsbClose.Enabled = opened;
            testArchiveToolStripMenuItem.Enabled = opened; tsbTestArchive.Enabled = testArchiveToolStripMenuItem.Enabled;
            passwordToolStripMenuItem.Enabled = opened && (_menuOptions & MenuOptions.Password) != 0;
            archiveCommentToolStripMenuItem.Enabled = opened && (_menuOptions & MenuOptions.ArchiveComment) != 0;
            addFilesToolStripMenuItem.Enabled = opened; addFilesContextMenuItem.Enabled = opened; tsbAddFiles.Enabled = opened;
            addFolderToArchiveToolStripMenuItem.Enabled = opened && (_menuOptions & MenuOptions.AddFolder) != 0; addFolderContextMenuItem.Enabled = addFolderToArchiveToolStripMenuItem.Enabled; tsbAddFolder.Enabled = addFolderToArchiveToolStripMenuItem.Enabled;
            refreshToolStripMenuItem.Enabled = opened; refreshContextMenuItem.Enabled = opened; tsbRefresh.Enabled = opened;
            calculateDirectorySizeToolStripMenuItem.Enabled = selected; calculateTotalSizeContextMenuItem.Enabled = calculateDirectorySizeToolStripMenuItem.Enabled;

            createSFXToolStripMenuItem.Enabled = opened && (_menuOptions & MenuOptions.CreateSfx) != 0;

            updateArchiveToolStripMenuItem.Enabled = opened && (_menuOptions & MenuOptions.Update) != 0;
            moveContextMenuItem.Enabled = selected && (_menuOptions & MenuOptions.Move) != 0; moveToolStripMenuItem.Enabled = moveContextMenuItem.Enabled;
            fileCommentContextMenuItem.Enabled = selected && !folder && (_menuOptions & MenuOptions.ArchiveItemComment) != 0; fileCommentToolStripMenuItem.Enabled = fileCommentContextMenuItem.Enabled;

            selectAllToolStripMenuItem.Enabled = opened;
            invertSelectionToolStripMenuItem.Enabled = selected;

            extractToFolderToolStripMenuItem.Enabled = selected; 
            extractContextMenuItem.Enabled = extractToFolderToolStripMenuItem.Enabled; 
            tsbExtract.Enabled = extractToFolderToolStripMenuItem.Enabled;

            viewFileToolStripMenuItem.Enabled = selected && !folder;
            viewContextMenuItem.Enabled = viewFileToolStripMenuItem.Enabled;
            tsbView.Enabled = viewFileToolStripMenuItem.Enabled;
            viewWithInternalViewerContextMenuItem.Enabled = viewFileToolStripMenuItem.Enabled;
            viewWithInternalViewerToolStripMenuItem.Enabled = viewFileToolStripMenuItem.Enabled;

            deleteFilesToolStripMenuItem.Enabled = selected && (_menuOptions & MenuOptions.Delete) != 0;
            deleteContextMenuItem.Enabled = deleteFilesToolStripMenuItem.Enabled;
            tsbDelete.Enabled = deleteFilesToolStripMenuItem.Enabled;

            renameContextMenuItem.Enabled = selected; 
            renameFileToolStripMenuItem.Enabled = renameContextMenuItem.Enabled;

            createDirectoryContextMenuItem.Enabled = opened && (_menuOptions & MenuOptions.CreateDirectory) != 0;
            createDirectoryToolStripMenuItem.Enabled = createDirectoryContextMenuItem.Enabled;

            addressBar.Enabled = opened;

            tsbAbort.Enabled = !enable;
            tsbRefresh.Enabled = opened;
            tsbSettings.Enabled = enable;
            tsbNewArchive.Enabled = enable;
            tsbOpenArchive.Enabled = enable;
            tsbClose.Enabled = opened;
        }

        /// <summary>
        /// Enables dialog's controls.
        /// </summary>
        /// <param name="enable">A boolean value indicating whether to enable dialog's controls.</param>
        private void EnableDialog(bool enable)
        {
            Util.EnableCloseButton(this, enable);
            
            /*tsbAddFiles.Enabled = enable;
            tsbAddFolder.Enabled = enable;
            tsbClose.Enabled = enable;
            tsbDelete.Enabled = enable;
            tsbExtract.Enabled = enable;
            tsbNewArchive.Enabled = enable;
            tsbOpenArchive.Enabled = enable;
            tsbRefresh.Enabled = enable;
            tsbSettings.Enabled = enable;
            tsbTestArchive.Enabled = enable;
            tsbView.Enabled = enable;
            tsbAbort.Enabled = !enable;*/

            listView.Enabled = enable;
            menuStrip.Enabled = enable;

            addressBar.Enabled = enable;
        }

        private void EnableProgress(bool enable)
        {
            EnableProgress(enable, true);
        }

        /// <summary>
        /// Enables dialog's progress bar control.
        /// </summary>
        /// <param name="enable">A boolean value indicating whether to enable dialog's progress bar control.</param>
        private void EnableProgress(bool enable, bool showHideProgressBars)
        {
            if (showHideProgressBars)
            {
                toolStripProgressBar.Visible = enable;
                progressBarTotal.Visible = enable;
            }

            toolStripStatusSelectionLabel.Visible = enable;
            toolStripStatusSelectionLabel.Text = string.Empty;
            toolStripStatusLabel.Visible = !enable;
            EnableButtons(!enable);
            EnableDialog(!enable);

            if (enable)
                _fileOpForm.Init();

            _abort = false;
        }

        /// <summary>
        /// Shows options dialog.
        /// </summary>
        private void ShowOptions()
        {
            Options dlg = new Options(_settings);
            if (dlg.ShowDialog() == DialogResult.OK && _archiver != null)
            {
                _archiver.PathStoringMode = _settings.PathStoringMode;

                if (_archiverType == ArchiverType.Zip)
                {
                    Zip zip = (Zip) _archiver;

                    zip.CompressionMode = (byte)_settings.CompressionLevel;
                    zip.CompressionMethod = _settings.CompressionMethod;
                }
            }
        }

        /// <summary>
        /// Refreshes the file list view.
        /// </summary>
        private void RefreshView()
        {
            // Clear the list first.
            listView.Items.Clear();
            EnableDialog(false);
            try
            {
                ArchiveItemInfoCollection list = (ArchiveItemInfoCollection)_archiver.ListDirectory();

                // Loop though the list and add to the list box
                foreach (ArchiveItemInfo f in list)
                {
                    string typeName;
                    int iconIndex = _iconManager.AddFileIcon(f.Name, out typeName);

                    string[] arr = new string[]
                                       {
                                           f.Encrypted ? (f.Name + " *") : f.Name, // Name
                                           f.LastWriteTime != DateTime.MinValue ? f.LastWriteTime.ToShortDateString() + " " + f.LastWriteTime.ToShortTimeString() : "", // Modification time
                                           f.IsDirectory ? "" : f.Length.ToString(), // Size
                                           f.CompressedLength == 0 ? "" : f.CompressionRate.ToString("#.#") + "%",  // Rate
                                           ((f.CompressedLength != f.Length && f.CompressedLength == 0) || f.IsDirectory) ? "" : f.CompressedLength.ToString(), // Compressed size
                                           f.IsDirectory ? "Directory" : typeName, // Type
                                           ToAttrs(f.Attributes), // Attributes
                                           f.DirectoryPath,
                                           (f.IsDirectory || f.Checksum == 0) ? "" : string.Format("{0:X8}", f.Checksum)
                                       };
                    ListViewItem item = new ListViewItem(arr);
                    item.ImageIndex = f.IsDirectory ? _folderImageIndex : iconIndex;
                    item.Tag = new TagInfo(f.Name, f.FullName, f.Length, f.CompressedLength, f.CompressionRate, typeName, f.LastWriteTime, f.Checksum, f.Attributes);
                    listView.Items.Add(item);
                }

                UpdateListViewSorter();

                if (_archiver.GetCurrentDirectory().Length > 1) // Not root dir?
                {
                    // Add Cdup list item.
                    ListViewItem cdup = new ListViewItem("..", 0);
                    listView.Items.Insert(0, cdup);
                }

                // Update local dir textbox's value.
                txtAddress.Text = _archiver.GetCurrentDirectory();
                if (listView.Items.Count > 0)
                    listView.Items[0].Selected = true;
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }            

            // Re-enable controls.
            EnableDialog(true);
            EnableButtons(true);

            if (_archiver != null)
                txtAddress.Text = _archiver.GetCurrentDirectory();
            else
                txtAddress.Text = "";
        }

        /// <summary>
        /// Converts file's attributes to string.
        /// </summary>
        /// <param name="attrs">The FileAttributes object.</param>
        /// <returns>The converted file attribute in string.</returns>
        private static string ToAttrs(FileAttributes attrs)
        {
            StringBuilder sb = new StringBuilder();

            if ((attrs & FileAttributes.Archive) == FileAttributes.Archive)
                sb.Append('A');

            if ((attrs & FileAttributes.ReadOnly) == FileAttributes.ReadOnly)
                sb.Append('R');

            if ((attrs & FileAttributes.Hidden) == FileAttributes.Hidden)
                sb.Append('H');

            if ((attrs & FileAttributes.System) == FileAttributes.System)
                sb.Append('S');

            return sb.ToString();
        }

        /// <summary>
        /// Creates a new archive.
        /// </summary>
        private void NewArchive()
        {
            CreateNewArchive dlg = new CreateNewArchive();
            if (dlg.ShowDialog() == DialogResult.Cancel)
                return;

            if (dlg.Type == ArchiverType.Tgz)
            {
                SaveFileDialog saveDlg = new SaveFileDialog();

                saveDlg.Filter = "Tgz File (*.tgz)|*.tgz";

                saveDlg.FilterIndex = 1;
                saveDlg.Title = "Create TGZ Archive";
                if (saveDlg.ShowDialog() != DialogResult.OK)
                    return;

                _archiveFileName = saveDlg.FileName;
            }
            else
            {
                _archiveFileName = null;
                // Get temp file path.
                _tempZipFile = System.IO.Path.GetTempFileName();
            }            

            _archiverType = dlg.Type;

            try
            {
                DeleteTempFile();
                _newArchive = _archiveFileName == null;

                if (_newArchive)
                    this.Text = DefaultTitle + " - New Archive - " + _archiverType.ToString();
                else
                    // Set form's title.
                    this.Text = DefaultTitle + " - " + System.IO.Path.GetFileName(_archiveFileName) + " - " + _archiverType.ToString();

                CreateArchiver();

                _archiver.Open(_archiveFileName ?? _tempZipFile, FileMode.Create);
                listView.Items.Clear();

                EnableButtons(true);

                listView.Enabled = true;
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        /// <summary>
        /// Opens an existing archive.
        /// </summary>
        private void OpenArchive()
        {
            if (CloseArchive() == DialogResult.Cancel)
                return;

            OpenFileDialog dlg = new OpenFileDialog();
            try
            {
                dlg.FileName = _archiveFileName;
                dlg.Filter = "Zip File (*.zip;*.zipx)|*.zip;*.zipx|GZip File (*.gz;*.z)|*.gz;*.z|Tar File (*.tar)|*.tar|Tgz File (*.tgz;*.tar.gz)|*.tgz;*.tar.gz|All files (*.*)|*.*";
                dlg.FilterIndex = 1;
                dlg.Title = "Select Archive";
                if (dlg.ShowDialog() != DialogResult.OK)
                    return;
            }
            catch
            {
                MessageBox.Show(this, dlg.FileName + " is not a valid archive", "Error");
                return;
            }

            try
            {
                _archiveFileName = dlg.FileName;

                if (dlg.FileName.ToLower().EndsWith(".tar.gz") || dlg.FileName.ToLower().EndsWith(".tar.z"))
                    _archiverType = ArchiverType.Tgz;
                else
                    switch (Path.GetExtension(dlg.FileName))
                    {
                        case ".zip":
                            _archiverType = ArchiverType.Zip;
                            break;

                        case ".z":
                        case ".gz":
                            _archiverType = ArchiverType.Gzip;
                            break;

                        case ".tar":
                            _archiverType = ArchiverType.Tar;
                            break;

                        case ".tgz":
                            _archiverType = ArchiverType.Tgz;
                            break;
                    }

                CreateArchiver();

                // Set encryption algorithm and protection password.
                // Open the archive.
                try
                {
                    _archiver.Open(_archiveFileName);

                    // Set form's title.
                    this.Text = DefaultTitle + " - " + System.IO.Path.GetFileName(_archiveFileName);
                }
                catch (UnauthorizedAccessException)
                {
                    // Try to open file in read-only mode.
                    _archiver.Open(_archiveFileName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                    // Set form's title.
                    this.Text = DefaultTitle + " - " + System.IO.Path.GetFileName(_archiveFileName) + " (read-only)";
                }
                _newArchive = false;

                this.Text += " - " + _archiverType.ToString();

                // Refresh the file list view.
                RefreshView();

                // Enable toolbar buttons.
                EnableButtons(true);                
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
                if (_archiver.Opened)
                {
                    CloseArchive();
                }
            }
        }

        /// <summary>
        /// Deletes the temporary file.
        /// </summary>
        private void DeleteTempFile()
        {
            try
            {
                File.Delete(_tempZipFile);
                File.Delete(_tempViewFile);
            }
            catch
            { }
        }

        /// <summary>
        /// Closes the archive.
        /// </summary>
        /// <returns>true if new archive will be save; false means closing existing file or new archive will not be saved.</returns>
        private DialogResult CloseArchive()
        {
            DialogResult result = DialogResult.Yes;

            if (_newArchive && listView.Items.Count > 0)
            {
                result = MessageBox.Show(this, "The archive is not saved. Do you want to save it?", "ArchiveManager",
                                         MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);

                if (result == System.Windows.Forms.DialogResult.Cancel)
                    return result;

                if (result == DialogResult.No)
                    goto Close;

                SaveFileDialog dlg = new SaveFileDialog();

                switch (_archiverType)
                {
                    case ArchiverType.Zip:
                        dlg.Filter = "Zip File (*.zip)|*.zip";
                        break;

                    case ArchiverType.Gzip:
                        dlg.Filter = "Gzip File (*.gz)|*.gz|Z File (*.z)|*.z";
                        break;

                    case ArchiverType.Tar:
                        dlg.Filter = "Tar File (*.tar)|*.tar";
                        break;

                    case ArchiverType.Tgz:
                        dlg.Filter = "Tgz File (*.tgz)|*.tgz";
                        break;
                }

                dlg.FilterIndex = 1;
                dlg.Title = "Save Archive as";
                _archiver.Close();

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (File.Exists(dlg.FileName))
                        File.Delete(dlg.FileName);
                
                    File.Move(_tempZipFile, dlg.FileName);
                }
                else
                {
                    DeleteTempFile();
                    return DialogResult.Cancel;
                }
            }
            else if (_archiver != null && _archiver.Opened) // Opened?, close it.
            {
                if (_archiver is Tgz)
                {
                    EnableProgress(true);
                }

                _archiver.Close();

                if (_archiver is Tgz)
                {
                    EnableProgress(false);
                }
            }

        Close:

            this.Text = DefaultTitle;

            listView.Items.Clear();
            listView.Enabled = false;
            _newArchive = false;
            if (_archiver != null)
                _archiver.Close();
            _archiver = null;

            EnableButtons(true);
            txtAddress.Text = string.Empty;

            return result;
        }

        /// <summary>
        /// Tests archive.
        /// </summary>
        private void TestArchive()
        {
            try
            {
                EnableProgress(true);

                // Test the archive.
                Exception[] errors = _archiver.TestAllFiles();

                if (errors == null)
                    MessageBox.Show(this, "Archive tested", "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                {
                    StringBuilder sb = new StringBuilder();
                    for (int i = 0; i < errors.Length; i++)
                    {
                        Exception ex = errors[i];
                        ZipException ze = ex as ZipException;

                        if (ze != null)
                            sb.AppendLine("File " + ze.FileInfo.FullName + " has errors. " + errors[i].Message);
                        else
                            sb.AppendLine(errors[i].Message);                        
                    }

                    MessageBox.Show(this, sb.ToString(), "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
            finally
            {
                EnableProgress(false);
            }
        }
        
        /// <summary>
        /// Shows password dialog.
        /// </summary>
        private void ShowPassword()
        {
            Zip zip = (Zip) _archiver;

            Password dlg = new Password();
            dlg.EncryptionAlgorithm = zip.EncryptionAlgorithm;
            dlg.Pass = zip.Password;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                zip.Password = dlg.Pass;
                zip.EncryptionAlgorithm = dlg.EncryptionAlgorithm;
            }
        }

        /// <summary>
        /// Shows comment dialog.
        /// </summary>
        private void ShowComment()
        {
            Zip zip = (Zip)_archiver;

            ArchiveComment dlg = new ArchiveComment();
            dlg.Comment = zip.Comment;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                zip.Comment = dlg.Comment;
            }
        }

        /// <summary>
        /// Selects all file in the file list view.
        /// </summary>
        private void SelectAll()
        {
            foreach (ListViewItem item in listView.Items)
            {
                item.Selected = true;
            }
        }

        /// <summary>
        /// Inverts the selection.
        /// </summary>
        private void InvertSelection()
        {
            foreach (ListViewItem item in listView.Items)
            {
                item.Selected = !item.Selected;
            }
        }

        /// <summary>
        /// Adds files to the current archive.
        /// </summary>
        private void AddFiles()
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "All files (*.*)|*.*";
            dlg.FilterIndex = 1;
            dlg.Title = "Select files to add to the archive";
            dlg.Multiselect = true;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EnableProgress(true);

                    TransferOptions opt = new TransferOptions();
                    opt.FileExistsResolveAction = FileExistsResolveAction.Confirm;

                    string path = System.IO.Path.GetDirectoryName(dlg.FileNames[0]);

                    FileSystemTransferStatistics statistics = _archiver.AddFiles(path, dlg.FileNames, "", opt);

                    if (!_abort && statistics.FilesTransferred > 0)
                        MessageBox.Show(this, string.Format("{0} file(s) have been added", statistics.FilesTransferred), "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
#if !TEST
                catch (Exception exc)
                {
                    Util.ShowError(exc);
                }
#endif
                finally
                {
                    EnableProgress(false);

                    // Refresh the file list view.
                    RefreshView();
                }
            }
        }

        string _selectedPathToAdd;
        /// <summary>
        /// Adds a folder to the archive.
        /// </summary>
        private void AddFolder()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Select a folder to add to the archive";
            dlg.SelectedPath = _selectedPathToAdd;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EnableProgress(true);
                    _selectedPathToAdd = dlg.SelectedPath;
                    // Add an entire directory.
                    TransferOptions opt = new TransferOptions();
                    opt.FileExistsResolveAction = FileExistsResolveAction.Confirm;
                    FileSystemTransferStatistics statistics = _archiver.Add(_selectedPathToAdd, "", opt); // Add the selected directory into the archive.

                    if (!_abort && statistics.FilesTransferred > 0)
                        MessageBox.Show(this, string.Format("{0} file(s) have been added", statistics.FilesTransferred), "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
#if !TEST
                catch (Exception exc)
                {
                    Util.ShowError(exc);
                }
#endif
                finally
                {
                    EnableProgress(false);

                    // Refresh the list view.
                    RefreshView();
                }
            }
        }

        string _selectedPathToExtract;
        /// <summary>
        /// Extracts to a folder.
        /// </summary>
        private void ExtractToFolder()
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            dlg.Description = "Select a folder to extract files to";
            dlg.SelectedPath = _selectedPathToExtract;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EnableProgress(true);
                    _selectedPathToExtract = dlg.SelectedPath;
                    // Extract selected files.
                    List<string> list = new List<string>();
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        TagInfo info = (TagInfo) item.Tag;

                        if (info != null)
                            list.Add(info.FullName);
                    }

                    TransferOptions opt = new TransferOptions();
                    opt.Recursive = _settings.Recursive ? RecursionMode.RecurseIntoAllSubFolders : RecursionMode.None;
                    opt.FileExistsResolveAction = FileExistsResolveAction.Confirm;
                    _archiver.ExtractFiles(_archiver.GetCurrentDirectory(), list.ToArray(), _selectedPathToExtract, opt);
                }
                catch (Exception exc)
                {
                    Util.ShowError(exc);
                }
                finally
                {
                    EnableProgress(false);
                }
            }
        }

        /// <summary>
        /// Aborts the current operation.
        /// </summary>
        private void AbortOperation()
        {
            _abort = true;
            _archiver.Cancel();
        }

        private string _tempViewFile;
        /// <summary>
        /// Views the selected file.
        /// </summary>
        private void ViewFile()
        {
            TagInfo info = (TagInfo)listView.SelectedItems[0].Tag;

            if (info == null)
                return;

            _tempViewFile = System.IO.Path.Combine(Path.GetTempPath(), info.Name);

            if (File.Exists(_tempViewFile))
                try
                {
                    File.Delete(_tempViewFile);
                }
                catch { }

            try
            {
                EnableProgress(true);
                // Extract the selected file to the temporary file for viewing.
                _archiver.ExtractFile(info.FullName, _tempViewFile);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
                return;
            }
            finally
            {
                EnableProgress(false);
            }

            System.Diagnostics.Process.Start(_tempViewFile);
        }

        void InternalViewFile()
        {
            Stream previewStream = new MemoryStream();
            TagInfo info = (TagInfo)listView.SelectedItems[0].Tag;

            if (info == null)
                return;

            try
            {
                EnableProgress(true);                
                // Extract the selected file to the memory stream for viewing.
                _archiver.ExtractFile(info.FullName, previewStream);                
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
                return;
            }
            finally
            {
                EnableProgress(false);
            }

            Preview dlg = new Preview(info.FullName, previewStream);
            if (dlg.SupportedFormat)
            {
                dlg.Text = info.FullName;
                dlg.ShowDialog();
            }
            previewStream.Close();
        }

        /// <summary>
        /// Deletes files.
        /// </summary>
        private void DeleteFiles()
        {
            if (MessageBox.Show(this, string.Format("Are you sure you want to delete {0} file(s)?", listView.SelectedItems.Count), "ArchiveManager", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EnableProgress(true, false);

                try
                {
                    _archiver.BeginUpdate();

                    _abort = false;
                    int count = listView.SelectedItems.Count;
                    // Delete the selected files.
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        if (_abort)
                            break;
                        TagInfo info = (TagInfo)item.Tag;

                        if (info == null)
                            continue;

                        if (item.ImageIndex == _folderImageIndex)
                            // Delete an entire directory.
                            _archiver.DeleteDirectory(info.Name, true);
                        else if (item.ImageIndex != UpFolderImageIndex)
                            // Delete a file.
                            _archiver.DeleteFile(info.Name);
                    }

                    RefreshView();

                    EnableButtons(true);

#if false
                    MessageBox.Show(this, string.Format("{0} file(s) have been removed", count), "ArchiveManager", MessageBoxButtons.OK, MessageBoxIcon.Information);
#endif
                }
                catch (Exception exc)
                {
                    Util.ShowError(exc);
                }
                _archiver.EndUpdate();

                EnableProgress(false, true);

                RefreshView();
            }
        }

        /// <summary>
        /// Renames selected file.
        /// </summary>
        private void RenameFile()
        {
            if (listView.SelectedItems.Count > 0)
                listView.SelectedItems[0].BeginEdit();
        }

        /// <summary>
        /// Renames selected file.
        /// </summary>
        /// <param name="newName">The new file name.</param>
        private bool DoRename(string newName)
        {
            if (!string.IsNullOrEmpty(newName))
            {
                if (newName.IndexOfAny(_archiver.InvalidPathChars) != -1 || newName.IndexOfAny(_archiver.DirectorySeparators) != -1)
                {
                    MessageBox.Show(this, "The provided file name is invalid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    return false;
                }
            
                ListViewItem item = listView.SelectedItems[0];

                if (item.StateImageIndex != _folderImageIndex)
                {
                    try
                    {
                        TagInfo info = (TagInfo)item.Tag;

                        if (info == null)
                            return false;
                        
                        string oldName = info.FullName;
                        info.Name = newName;
                        newName = _archiver.CombinePath(_archiver.GetDirectoryName(oldName), newName);
                        _archiver.Rename(oldName, newName);
                        string typeName;
                        if (item.ImageIndex != _folderImageIndex)
                        {
                            item.ImageIndex = _iconManager.AddFileIcon(newName, out typeName);
                            info.TypeName = typeName;
                        }
                        info.FullName = newName;
                        

                        return true;
                    }
                    catch (Exception exc)
                    {
                        Util.ShowError(exc);
                    }
                }
            }

            return false;
        }

        /// <summary>
        /// Closes the application.
        /// </summary>
        private void Quit()
        {
            this.Close();
        }

        #endregion

        /// <summary>
        /// Handles the UltimateZip's PasswordNeeded event.
        /// </summary>
        private void zip_PasswordNeeded(object sender, PasswordNeededEventArgs e)
        {
            AskPassword dlg = new AskPassword();
            dlg.FileName = e.FileName;
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                if (dlg.Skip)
                    e.SkipFile = true;
                else
                {
                    e.Password = dlg.Pass;
                    e.UpdateArchivePassword = dlg.UpdateArchivePassword; // Update the entire archive password or not?
                }
            }
            else
                e.Cancel = true;
        }

        private void newArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewArchive();
        }

        private void openArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenArchive();
        }

        private void closeArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CloseArchive();
        }

        private void testArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TestArchive();
        }

        private void passwordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPassword();
        }

        private void archiveCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowComment();
        }

        private void selectAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        private void invertSelectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InvertSelection();
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Quit();
        }

        private void addFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFiles();
        }

        private void addFolderToArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        private void extractToFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExtractToFolder();
        }

        private void viewFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ViewFile();
        }

        private void viewWithInternalViewerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InternalViewFile();
        }

        private void deleteFilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFiles();
        }

        private void renameFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RenameFile();
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void tsbNewArchive_Click(object sender, EventArgs e)
        {
            NewArchive();
        }

        private void tsbOpenArchive_Click(object sender, EventArgs e)
        {
            OpenArchive();
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            CloseArchive();
        }

        private void tsbTestArchive_Click(object sender, EventArgs e)
        {
            TestArchive();
        }

        private void tsbAddFiles_Click(object sender, EventArgs e)
        {
            AddFiles();
        }

        private void tsbAddFolder_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        private void tsbExtract_Click(object sender, EventArgs e)
        {
            ExtractToFolder();
        }

        private void tsbDelete_Click(object sender, EventArgs e)
        {
            DeleteFiles();
        }

        private void tsbView_Click(object sender, EventArgs e)
        {
            ViewFile();
        }

        private void tsbRefresh_Click(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void tsbSettings_Click(object sender, EventArgs e)
        {
            ShowOptions();
        }

        private void lvwArchive_SelectedIndexChanged(object sender, EventArgs e)
        {
            EnableButtons(true);
        }

        private void lvwArchive_DoubleClick(object sender, EventArgs e)
        {
            if (listView.SelectedItems[0].ImageIndex == _folderImageIndex) // Change to the specified folder
            {
                TagInfo info = (TagInfo)listView.SelectedItems[0].Tag;

                _archiver.SetCurrentDirectory(info.Name);

                RefreshView();
            }
            else if (listView.SelectedItems[0].ImageIndex == UpFolderImageIndex) // Up one level.
            {
                string dirPath = _archiver.GetDirectoryName(_archiver.GetCurrentDirectory());
                _archiver.SetCurrentDirectory(dirPath);

                RefreshView();
            }
            else if (listView.SelectedItems.Count > 0)
                tsbView_Click(sender, e);

            listView.Focus();
        }

        private void addFilesContextMenuItem_Click(object sender, EventArgs e)
        {
            AddFiles();
        }

        private void addFolderContextMenuItem_Click(object sender, EventArgs e)
        {
            AddFolder();
        }

        private void extractContextMenuItem_Click(object sender, EventArgs e)
        {
            ExtractToFolder();
        }

        private void deleteContextMenuItem_Click(object sender, EventArgs e)
        {
            DeleteFiles();
        }

        private void viewContextMenuItem_Click(object sender, EventArgs e)
        {
            ViewFile();
        }

        private void viewWithInternalViewerContextMenuItem_Click(object sender, EventArgs e)
        {
            InternalViewFile();
        }

        private void renameContextMenuItem_Click(object sender, EventArgs e)
        {
            RenameFile();
        }

        private void refreshContextMenuItem_Click(object sender, EventArgs e)
        {
            RefreshView();
        }

        private void listView_AfterLabelEdit(object sender, LabelEditEventArgs e)
        {
            e.CancelEdit = !DoRename(e.Label);
        }

        private void tsbAbort_Click(object sender, EventArgs e)
        {
            AbortOperation();
        }

        int _lastSaveProgressTime;
        private void zip_SaveProgress(object sender, SaveProgressEventArgs e)
        {
            int tick = Environment.TickCount;
            if (tick - _lastSaveProgressTime <= 100)
                return;

            _lastSaveProgressTime = tick;

            string msg = null;
            switch (e.State)
            {
                case SaveProgressState.BackupArchive:
                    msg = "Backing up archive...";
                    break;

                case SaveProgressState.PreserveFile:
                    msg = "Preserving file " + e.FileName + "...";
                    break;

                case SaveProgressState.Rollback:
                    msg = "Rolling back...";
                    break;

                case SaveProgressState.SaveArchive:
                    msg = "Saving archive...";
                    break;
            }

            toolStripProgressBar.Visible = true;
            toolStripStatusSelectionLabel.Visible = true;
            toolStripProgressBar.Value = (int)e.Percentage;
            toolStripStatusSelectionLabel.Text = msg;

#if DEBUG
            System.Diagnostics.Trace.WriteLine(msg + " " + e.Percentage + "%");
#endif

            Application.DoEvents();
        }

        private void zip_Progress(object sender, ComponentPro.IO.FileSystemProgressEventArgs e)
        {
            switch (e.State)
            {
                case TransferState.MultiFileOperationCompleted:
                    System.Diagnostics.Trace.WriteLine(string.Format("Multi-file operation completed. Elapsed time: {0}, Bps: {1}/sec", e.TransferStatistics.ElapsedTime, Util.FormatSize(e.TransferStatistics.BytesPerSecond)));
                    break;

                case TransferState.DeletingDirectory:
                    // It's about to delete a directory. To skip deleting this directory, simply set e.Skip = true.
                    toolStripStatusSelectionLabel.Text = string.Format("Deleting directory {0}...", e.SourceFileSystem.GetFileName(e.SourcePath));
                    Application.DoEvents();
                    return;

                case TransferState.DeletingFile:
                    // It's about to delete a file. To skip deleting this file, simply set e.Skip = true.
                    toolStripStatusSelectionLabel.Text = string.Format("Deleting file {0}...", e.SourceFileSystem.GetFileName(e.SourcePath));
                    Application.DoEvents();
                    return;

                case TransferState.BuildingDirectoryStructure:
                    // It informs us that the directory structure has been prepared for the multiple file transfer.
                    toolStripStatusSelectionLabel.Text = "Building directory structure...";
                    toolStripProgressBar.Value = 0;
                    progressBarTotal.Value = 0;
                    Application.DoEvents();
                    break;

                case TransferState.CreatingDirectory:
                    // It informs us that a directory is being created.
                    toolStripStatusSelectionLabel.Text = "Creating directory " + e.DestinationFileInfo.Name;
                    toolStripProgressBar.Value = 0;
                    progressBarTotal.Value = 0;
                    Application.DoEvents();
                    break;

                #region Comparing File Events

                case TransferState.StartComparingFile:
                    // Source file and destination file are about to be compared.
                    // To skip comparing these files, simply set e.Skip = true.
                    // To override the comparison result, set the e.ComparionResult property.
                    toolStripStatusSelectionLabel.Text = string.Format("Comparing file {0}...", System.IO.Path.GetFileName(e.SourcePath));
                    toolStripProgressBar.Value = (int)e.Percentage;
#if PROGRESSBARTOTAL
                    progressBarTotal.Value = (int)e.TotalPercentage;
#endif
                    Application.DoEvents();
                    break;

                case TransferState.Comparing:
                    // Source file and destination file are being compared.
                    //time = Environment.TickCount;
#if SHOWSPEED
                    //if (time - _timeLastEvent >= _settings.ProgressUpdateInterval && e.BytesPerSecond > 0)
                    {
                        toolStripStatusSelectionLabel.Text =
                            string.Format("Comparing file {0}... {1}/sec {2} remaining",
                                          System.IO.Path.GetFileName(e.SourcePath), Util.FormatSize(e.BytesPerSecond),
                                          e.RemainingTime);
                        //_timeLastEvent = time;
                        toolStripProgressBar.Value = (int)e.Percentage;
#if PROGRESSBARTOTAL
                        progressBarTotal.Value = (int)e.TotalPercentage;
#endif
                    }
#endif
                    Application.DoEvents();
                    break;

                case TransferState.FileCompared:
                    // Source file and destination file have been compared.
                    // Comparison result is saved in the e.ComparisonResult property.
                    toolStripProgressBar.Value = (int)e.Percentage;
#if PROGRESSBARTOTAL
                    progressBarTotal.Value = (int)e.TotalPercentage;
#endif
                    Application.DoEvents();
                    break;

                #endregion

                #region Storing File Events

                case TransferState.StartStoringFile:
                    // Source file (local file) is about to be storeed. Destination file is the archive item.
                    // To skip storing this file, simply set e.Skip = true.
                    toolStripStatusSelectionLabel.Text = string.Format("Storing file {0}...", System.IO.Path.GetFileName(e.SourcePath));
                    toolStripProgressBar.Value = (int)e.Percentage;
#if PROGRESSBARTOTAL
                    progressBarTotal.Value = (int)e.TotalPercentage;
#endif
                    Application.DoEvents();
                    break;

                case TransferState.Storing:
                    // Source file is being storeed to the remote server.
                    //time = Environment.TickCount;
#if SHOWSPEED

                    //if (time - _timeLastEvent >= _settings.ProgressUpdateInterval && e.BytesPerSecond > 0)
                    {
                        toolStripStatusSelectionLabel.Text =
                            string.Format("Storing file {0}... {1}/sec {2} remaining",
                                          System.IO.Path.GetFileName(e.SourcePath), Util.FormatSize(e.BytesPerSecond),
                                          e.RemainingTime);
                        //_timeLastEvent = time;
                        toolStripProgressBar.Value = (int)e.Percentage;
#if PROGRESSBARTOTAL
                        progressBarTotal.Value = (int)e.TotalPercentage;
#endif
                    }

#endif
                    Application.DoEvents();
                    break;

                case TransferState.FileStored:
                    // Source file has been storeed.
                    toolStripProgressBar.Value = (int)e.Percentage;
#if PROGRESSBARTOTAL
                    progressBarTotal.Value = (int)e.TotalPercentage;
#endif
                    Application.DoEvents();
                    break;

                #endregion

                #region Extracting File Events

                case TransferState.StartExtractingFile:
                    // Source file (within the archive) is about to be extracted.
                    // To skip storing this file, simply set e.Skip = true.
                    toolStripStatusSelectionLabel.Text = string.Format("Extracting file {0}...", System.IO.Path.GetFileName(e.SourcePath));
                    toolStripProgressBar.Value = (int)e.Percentage;
#if PROGRESSBARTOTAL
                    progressBarTotal.Value = (int)e.TotalPercentage;
#endif
                    Application.DoEvents();
                    break;

                case TransferState.Extracting:
                    // Source file is being extracted to the local disk.
                    //time = Environment.TickCount;
#if SHOWSPEED
                    //if (time - _timeLastEvent >= _settings.ProgressUpdateInterval && e.BytesPerSecond > 0)
                    {
                        toolStripStatusSelectionLabel.Text =
                            string.Format("Extracting file {0}... {1}/sec {2} remaining",
                                          System.IO.Path.GetFileName(e.SourcePath), Util.FormatSize(e.BytesPerSecond),
                                          e.RemainingTime);
                        //_timeLastEvent = time;
                        toolStripProgressBar.Value = (int)e.Percentage;
                        progressBarTotal.Value = (int)e.TotalPercentage;
                    }
#endif
                    Application.DoEvents();
                    break;

                case TransferState.FileExtracted:
                    // Remote file has been extracted.
                    toolStripProgressBar.Value = (int)e.Percentage;
#if PROGRESSBARTOTAL
                    progressBarTotal.Value = (int)e.TotalPercentage;
#endif
                    Application.DoEvents();
                    break;

                #endregion
            }
                    
            Application.DoEvents();

            if (_abort)
                _archiver.Cancel();
        }

        private void archiver_MultipleFilesTransferActionConfirm(object sender, TransferConfirmEventArgs e)
        {
            if (!IsDisposed)
                Invoke(new EventHandler<TransferConfirmEventArgs>(MultipleFilesTransferActionConfirm), sender, e);
        }

        /// <summary>
        /// Handles the client's TransferConfirm event.
        /// </summary>
        /// <param name="sender">The Zip object.</param>
        /// <param name="e">The event arguments.</param>
        private void MultipleFilesTransferActionConfirm(object sender, TransferConfirmEventArgs e)
        {
            _fileOpForm.Show(this, e);
        }

        private void applicationMenu_ExitButtonClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void applicationMenu_OptionsButtonClick(object sender, EventArgs e)
        {
            tsbSettings_Click(sender, e);
        }

        private void listView_KeyDown(object sender, KeyEventArgs e)
        {
            if (listView.SelectedItems.Count == 0)
                return;

            switch (e.KeyCode)
            {
                case System.Windows.Forms.Keys.Back:
                    btnUpOneLevel_Click(null, null);
                    break;

                case Keys.Enter:
                    if (listView.SelectedItems.Count > 0)
                    {
                        lvwArchive_DoubleClick(null, null);
                    }
                    break;

#if DEBUG
                case Keys.B:
                    if (e.Control && e.Shift)
                    {
                        _archiver.BeginUpdate();
                        MessageBox.Show(this, "Transaction started");
                    }
                    break;

                case Keys.E:
                    if (e.Control && e.Shift)
                    {
                        MessageBox.Show(this, "Ending transaction");

                        EnableProgress(true);

                        _archiver.EndUpdate();

                        EnableProgress(false);
                        RefreshView();
                    }
                    break;

                case Keys.C:
                    if (e.Control && e.Shift)
                    {
                        _archiver.CancelUpdate();
                        MessageBox.Show(this, "Transaction cancelled");
                    }
                    break;
#endif
            }
        }

        private int _lastLocalColumnToSort; // last sort action on this column.
        private SortOrder _lastLocalSortOrder = SortOrder.Ascending; // last sort order.

        private void UpdateListViewSorter()
        {
            switch (_lastLocalColumnToSort)
            {
                case 0: // name
                    listView.ListViewItemSorter = new ListViewItemNameComparer(_lastLocalSortOrder, _folderImageIndex);
                    break;
                case 1: // modified
                    listView.ListViewItemSorter = new ListViewItemDateComparer(_lastLocalSortOrder, _folderImageIndex);
                    break;
                case 2: // size
                    listView.ListViewItemSorter = new ListViewItemSizeComparer(_lastLocalSortOrder, _folderImageIndex);
                    break;
                case 3: // ratio
                    listView.ListViewItemSorter = new ListViewItemRatioComparer(_lastLocalSortOrder, _folderImageIndex);
                    break;
                case 4: // compressed size
                    listView.ListViewItemSorter = new ListViewItemCompressedSizeComparer(_lastLocalSortOrder, _folderImageIndex);
                    break;
                case 5: // type
                    listView.ListViewItemSorter = new ListViewItemTypeNameComparer(_lastLocalSortOrder, _folderImageIndex);
                    break;
                case 6: // attributes
                    listView.ListViewItemSorter = new ListViewItemFileAttributesComparer(_lastLocalSortOrder, _folderImageIndex);
                    break;
                case 8: // crc
                    listView.ListViewItemSorter = new ListViewItemChecksumComparer(_lastLocalSortOrder, _folderImageIndex);
                    break;
            }

            listView.ListViewItemSorter = null;
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            if (listView.Items.Count == 0)
                return;

            ListViewItem cdup = listView.Items[0].ImageIndex == UpFolderImageIndex ? listView.Items[0] : null;
            if (cdup != null)
                listView.Items.Remove(cdup);

            SortOrder sortOrder;
            if (_lastLocalColumnToSort == e.Column)
            {
                sortOrder = _lastLocalSortOrder == SortOrder.Ascending ? SortOrder.Descending : SortOrder.Ascending;
            }
            else
                sortOrder = SortOrder.Ascending;

            _lastLocalColumnToSort = e.Column;
            _lastLocalSortOrder = sortOrder;

            UpdateListViewSorter();

            listView.ListViewItemSorter = null;
            if (cdup != null)
                listView.Items.Insert(0, cdup);
        }

        private void btnUpOneLevel_Click(object sender, EventArgs e)
        {
            string dirPath = _archiver.GetDirectoryName(_archiver.GetCurrentDirectory());
            _archiver.SetCurrentDirectory(dirPath);

            RefreshView();

            listView.Focus();
        }

        private void createDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewNamePrompt dlg = new NewNamePrompt(null);
            dlg.Text = "Enter Folder Name";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _archiver.CreateDirectory(dlg.NewName);
                }
                catch (Exception exc)
                {
                    Util.ShowError(exc);
                }

                RefreshView();
            }
        }

        string _selectedPathToMove;

        private void moveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            NewNamePrompt dlg = new NewNamePrompt(_selectedPathToMove ?? "/");
            dlg.Text = "Move to";
            dlg.NewNameCaption = "Destination Dir";
            dlg.Rename = false;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    EnableProgress(true);
                    
                    // Build selected file list.
                    List<string> list = new List<string>();
                    foreach (ListViewItem item in listView.SelectedItems)
                    {
                        TagInfo info = (TagInfo)item.Tag;

                        if (info == null)
                            continue;

                        list.Add(info.FullName);
                    }

                    TransferOptions opt = new TransferOptions();
                    opt.Recursive = RecursionMode.RecurseIntoAllSubFolders;
                    opt.FileExistsResolveAction = FileExistsResolveAction.Confirm;

                    _archiver.MoveFiles("", list.ToArray(), dlg.NewName, opt);

                    _selectedPathToMove = dlg.NewName;
                }
                catch (Exception exc)
                {
                    Util.ShowError(exc);
                }
                finally
                {
                    EnableProgress(false);
                }

                RefreshView();
            }
        }

        private void updateArchiveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Synchronize.
            SynchronizeFolders dlg = new SynchronizeFolders(RecursionMode.RecurseIntoAllSubFolders, 
                _settings.SyncDateTime, _settings.SyncAttributes, _settings.SyncComparisonMethod, 
                _settings.SyncCheckForResumability, _settings.SyncSearchPattern, _settings.SyncSourceDir);

            if (dlg.ShowDialog() != DialogResult.OK) return;

            if (dlg.SourceDir.Length == 0)
            {
                MessageBox.Show(this, "Source directory cannot be empty", "Update Archive", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show(this, 
                    string.Format(
                            Messages.SyncConfirm,
                            _archiver.GetCurrentDirectory(), dlg.SourceDir
                            ),
                        "Zip Manager",
                        MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                EnableProgress(true);

                _settings.SyncDateTime = dlg.SyncDateTime;
                _settings.SyncAttributes = dlg.SyncAttributes;
                _settings.SyncComparisonMethod = dlg.ComparisonMethod;
                _settings.SyncCheckForResumability = dlg.CheckForResumability;
                _settings.SyncSearchPattern = dlg.SearchPattern;
                _settings.SyncSourceDir = dlg.SourceDir;
                _settings.SyncDeleteFiles = dlg.DeleteFiles;

                SyncOptions opt = new SyncOptions();
                opt.Recursive = RecursionMode.RecurseIntoAllSubFolders;
                opt.AllowDeletion = dlg.DeleteFiles;
                opt.SearchCondition = new NameSearchCondition(dlg.SearchPattern);

                switch (dlg.ComparisonMethod)
                {
                    case 0:
                        opt.Comparer = ComponentPro.IO.FileComparers.FileLastWriteTimeComparer;
                        break;

                    case 1:
                        opt.Comparer = dlg.CheckForResumability ? ComponentPro.IO.FileComparers.FileContentComparerWithResumabilityCheck : ComponentPro.IO.FileComparers.FileContentComparer;
                        break;

                    case 2:
                        opt.Comparer = ComponentPro.IO.FileComparers.FileNameComparer;
                        break;
                }

                try
                {
                    // Synchronize folders.
                    _archiver.Synchronize(_archiver.GetCurrentDirectory(), dlg.SourceDir, false, opt);
                }
                catch (Exception exc)
                {
                    Util.ShowError(exc);
                }

                EnableProgress(false);
                RefreshView();
            }
        }

        private void fileCommentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TagInfo info = (TagInfo)listView.SelectedItems[0].Tag;

            if (info == null)
                return;

            ArchiveItemInfo item = (ArchiveItemInfo)_archiver.GetFileInfo(info.FullName);

            ArchiveComment dlg = new ArchiveComment();
            dlg.Comment = item.Comment;
            dlg.Text = "Comment: " + item.FullName;

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                switch (_archiverType)
                {
                    case ArchiverType.Zip:
                        ((Zip) _archiver).SetFileComment(item, dlg.Comment);
                        break;

                    case ArchiverType.Gzip:
                        ((Gzip)_archiver).SetFileComment(item, dlg.Comment);
                        break;
                }
            }
        }

        private void calculateDirectorySizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                // Get the time difference.
                long total = 0;
                foreach (ListViewItem item in listView.SelectedItems)
                {
                    TagInfo info = (TagInfo)item.Tag;

                    if (info == null)
                        continue;

                    if (item.ImageIndex == _folderImageIndex)
                        total += _archiver.GetDirectorySize(info.FullName, true);
                    else
                        total += info.Size;
                }

                MessageBox.Show(this, string.Format("Total size: {0}", Util.FormatSize(total)), "Ftp Client Demo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception exc)
            {
                Util.ShowError(exc);
            }
        }

        private void calculateTotalSizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            calculateDirectorySizeToolStripMenuItem_Click(null, null);
        }

        private void createSFXToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_newArchive)
            {
                MessageBox.Show(this, "Please save the archive before creating an SFX", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SFXCreation dlg = new SFXCreation(_settings.SfxStubFile, _settings.SfxOutputFile);
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                _settings.SfxOutputFile = dlg.SfxFileName;
                _settings.SfxStubFile = dlg.StubFileName;

                string path = System.IO.Path.GetDirectoryName(dlg.SfxFileName);
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }

                string currentDir = _archiver.GetCurrentDirectory();
                _archiver.Close();

                _archiver.Open(_archiver.FileName);

                Zip zip = (Zip) _archiver;

                zip.SfxStubFileName = dlg.StubFileName;
                try
                {
                    zip.CreateSfx(dlg.SfxFileName);

                    // The output file also needs assemblies.
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + "ComponentPro.FileSystem.dll", path + "\\ComponentPro.FileSystem.dll", true);
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + "ComponentPro.Common.dll", path + "\\ComponentPro.Common.dll", true);
                    File.Copy(AppDomain.CurrentDomain.BaseDirectory + "ComponentPro.Zip.dll", path + "\\ComponentPro.Zip.dll", true);

                    if (MessageBox.Show(this, "SFX created successfully. Would you like to open the folder containing the archive file?", this.Text, MessageBoxButtons.YesNo,
                    MessageBoxIcon.Information) == DialogResult.Yes)
                        System.Diagnostics.Process.Start(Directory.GetParent(dlg.SfxFileName).FullName);
                }
                catch (Exception exc)
                {
                    Util.ShowError(exc);
                }

                _archiver.SetCurrentDirectory(currentDir);
            }
        }
    }
}