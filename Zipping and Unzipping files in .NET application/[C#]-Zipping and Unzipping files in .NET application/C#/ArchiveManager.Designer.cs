using System.Drawing;
using System.Windows.Forms;

namespace ArchiveManager
{
    partial class ArchiveManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ArchiveManager));
            this.listView = new System.Windows.Forms.ListView();
            this.colName = new System.Windows.Forms.ColumnHeader();
            this.colModified = new System.Windows.Forms.ColumnHeader();
            this.colSize = new System.Windows.Forms.ColumnHeader();
            this.colRatio = new System.Windows.Forms.ColumnHeader();
            this.colPacked = new System.Windows.Forms.ColumnHeader();
            this.colTypeName = new System.Windows.Forms.ColumnHeader();
            this.colAttributes = new System.Windows.Forms.ColumnHeader();
            this.colPath = new System.Windows.Forms.ColumnHeader();
            this.colCrc = new System.Windows.Forms.ColumnHeader();
            this.listContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.addFilesContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDirectoryContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateTotalSizeContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewWithInternalViewerContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileCommentContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshContextMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.imglist = new System.Windows.Forms.ImageList(this.components);
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBarTotal = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.toolStripStatusSelectionLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsbNewArchive = new System.Windows.Forms.ToolStripButton();
            this.tsbOpenArchive = new System.Windows.Forms.ToolStripButton();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.tsbTestArchive = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbAddFiles = new System.Windows.Forms.ToolStripButton();
            this.tsbAddFolder = new System.Windows.Forms.ToolStripButton();
            this.tsbExtract = new System.Windows.Forms.ToolStripButton();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbView = new System.Windows.Forms.ToolStripButton();
            this.tsbAbort = new System.Windows.Forms.ToolStripButton();
            this.tsbRefresh = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSettings = new System.Windows.Forms.ToolStripButton();
            this.newArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.passwordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.selectAllToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.invertSelectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.refreshToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.commandsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addFolderToArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extractToFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateDirectorySizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.viewFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewWithInternalViewerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.renameFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileCommentToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.moveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.updateArchiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.archiveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createSFXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolbarMain = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.addressBar = new System.Windows.Forms.Panel();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.btnUpOneLevel = new System.Windows.Forms.Button();
            this.listContextMenu.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.menuStrip.SuspendLayout();
            this.toolbarMain.SuspendLayout();
            this.addressBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.AllowDrop = true;
            this.listView.BackColor = System.Drawing.SystemColors.Window;
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colName,
            this.colModified,
            this.colSize,
            this.colRatio,
            this.colPacked,
            this.colTypeName,
            this.colAttributes,
            this.colPath,
            this.colCrc});
            this.listView.ContextMenuStrip = this.listContextMenu;
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.Enabled = false;
            this.listView.FullRowSelect = true;
            this.listView.GridLines = true;
            this.listView.LabelEdit = true;
            this.listView.Location = new System.Drawing.Point(0, 105);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(721, 355);
            this.listView.SmallImageList = this.imglist;
            this.listView.TabIndex = 2;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.AfterLabelEdit += new System.Windows.Forms.LabelEditEventHandler(this.listView_AfterLabelEdit);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.lvwArchive_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.lvwArchive_DoubleClick);
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.listView_KeyDown);
            // 
            // colName
            // 
            this.colName.Text = "Name";
            this.colName.Width = 120;
            // 
            // colModified
            // 
            this.colModified.Text = "Modified";
            this.colModified.Width = 120;
            // 
            // colSize
            // 
            this.colSize.Text = "Size";
            this.colSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colRatio
            // 
            this.colRatio.Text = "Ratio";
            this.colRatio.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colRatio.Width = 40;
            // 
            // colPacked
            // 
            this.colPacked.Text = "Packed";
            this.colPacked.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // colTypeName
            // 
            this.colTypeName.Text = "Type";
            this.colTypeName.Width = 120;
            // 
            // colAttributes
            // 
            this.colAttributes.Text = "Attributes";
            // 
            // colPath
            // 
            this.colPath.Text = "Path";
            this.colPath.Width = 120;
            // 
            // colCrc
            // 
            this.colCrc.Text = "CRC32";
            // 
            // listContextMenu
            // 
            this.listContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addFilesContextMenuItem,
            this.addFolderContextMenuItem,
            this.extractContextMenuItem,
            this.createDirectoryContextMenuItem,
            this.calculateTotalSizeContextMenuItem,
            this.deleteContextMenuItem,
            this.moveContextMenuItem,
            this.viewContextMenuItem,
            this.viewWithInternalViewerContextMenuItem,
            this.renameContextMenuItem,
            this.fileCommentContextMenuItem,
            this.toolStripSeparator2,
            this.refreshContextMenuItem});
            this.listContextMenu.Name = "listContextMenu";
            this.listContextMenu.Size = new System.Drawing.Size(196, 296);
            // 
            // addFilesContextMenuItem
            // 
            this.addFilesContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFilesContextMenuItem.Image")));
            this.addFilesContextMenuItem.Name = "addFilesContextMenuItem";
            this.addFilesContextMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addFilesContextMenuItem.Text = "Add Files...";
            this.addFilesContextMenuItem.Click += new System.EventHandler(this.addFilesContextMenuItem_Click);
            // 
            // addFolderContextMenuItem
            // 
            this.addFolderContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFolderContextMenuItem.Image")));
            this.addFolderContextMenuItem.Name = "addFolderContextMenuItem";
            this.addFolderContextMenuItem.Size = new System.Drawing.Size(195, 22);
            this.addFolderContextMenuItem.Text = "Add Folder...";
            this.addFolderContextMenuItem.Click += new System.EventHandler(this.addFolderContextMenuItem_Click);
            // 
            // extractContextMenuItem
            // 
            this.extractContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("extractContextMenuItem.Image")));
            this.extractContextMenuItem.Name = "extractContextMenuItem";
            this.extractContextMenuItem.Size = new System.Drawing.Size(195, 22);
            this.extractContextMenuItem.Text = "Extract...";
            this.extractContextMenuItem.Click += new System.EventHandler(this.extractContextMenuItem_Click);
            // 
            // createDirectoryContextMenuItem
            // 
            this.createDirectoryContextMenuItem.Name = "createDirectoryContextMenuItem";
            this.createDirectoryContextMenuItem.Size = new System.Drawing.Size(195, 22);
            this.createDirectoryContextMenuItem.Text = "Create Directory...";
            this.createDirectoryContextMenuItem.Click += new System.EventHandler(this.createDirectoryToolStripMenuItem_Click);
            // 
            // calculateTotalSizeContextMenuItem
            // 
            this.calculateTotalSizeContextMenuItem.Name = "calculateTotalSizeContextMenuItem";
            this.calculateTotalSizeContextMenuItem.Size = new System.Drawing.Size(195, 22);
            this.calculateTotalSizeContextMenuItem.Text = "Calculate Total Size";
            this.calculateTotalSizeContextMenuItem.Click += new System.EventHandler(this.calculateTotalSizeToolStripMenuItem_Click);
            // 
            // deleteContextMenuItem
            // 
            this.deleteContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteContextMenuItem.Image")));
            this.deleteContextMenuItem.Name = "deleteContextMenuItem";
            this.deleteContextMenuItem.Size = new System.Drawing.Size(195, 22);
            this.deleteContextMenuItem.Text = "Delete";
            this.deleteContextMenuItem.Click += new System.EventHandler(this.deleteContextMenuItem_Click);
            // 
            // moveContextMenuItem
            // 
            this.moveContextMenuItem.Name = "moveContextMenuItem";
            this.moveContextMenuItem.Size = new System.Drawing.Size(195, 22);
            this.moveContextMenuItem.Text = "Move...";
            this.moveContextMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // viewContextMenuItem
            // 
            this.viewContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewContextMenuItem.Image")));
            this.viewContextMenuItem.Name = "viewContextMenuItem";
            this.viewContextMenuItem.Size = new System.Drawing.Size(195, 22);
            this.viewContextMenuItem.Text = "View";
            this.viewContextMenuItem.Click += new System.EventHandler(this.viewContextMenuItem_Click);
            // 
            // viewWithInternalViewerContextMenuItem
            // 
            this.viewWithInternalViewerContextMenuItem.Name = "viewWithInternalViewerContextMenuItem";
            this.viewWithInternalViewerContextMenuItem.Size = new System.Drawing.Size(195, 22);
            this.viewWithInternalViewerContextMenuItem.Text = "View with Internal Viewer";
            this.viewWithInternalViewerContextMenuItem.Click += new System.EventHandler(this.viewWithInternalViewerContextMenuItem_Click);
            // 
            // renameContextMenuItem
            // 
            this.renameContextMenuItem.Name = "renameContextMenuItem";
            this.renameContextMenuItem.Size = new System.Drawing.Size(195, 22);
            this.renameContextMenuItem.Text = "Rename";
            this.renameContextMenuItem.Click += new System.EventHandler(this.renameContextMenuItem_Click);
            // 
            // fileCommentContextMenuItem
            // 
            this.fileCommentContextMenuItem.Name = "fileCommentContextMenuItem";
            this.fileCommentContextMenuItem.Size = new System.Drawing.Size(195, 22);
            this.fileCommentContextMenuItem.Text = "File Comment...";
            this.fileCommentContextMenuItem.Click += new System.EventHandler(this.fileCommentToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(192, 6);
            // 
            // refreshContextMenuItem
            // 
            this.refreshContextMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshContextMenuItem.Image")));
            this.refreshContextMenuItem.Name = "refreshContextMenuItem";
            this.refreshContextMenuItem.Size = new System.Drawing.Size(195, 22);
            this.refreshContextMenuItem.Text = "Refresh";
            this.refreshContextMenuItem.Click += new System.EventHandler(this.refreshContextMenuItem_Click);
            // 
            // imglist
            // 
            this.imglist.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imglist.ImageStream")));
            this.imglist.TransparentColor = System.Drawing.Color.Transparent;
            this.imglist.Images.SetKeyName(0, "UpFolder.gif");
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.progressBarTotal,
            this.toolStripProgressBar,
            this.toolStripStatusSelectionLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 460);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(721, 22);
            this.statusStrip.TabIndex = 138;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(38, 17);
            this.toolStripStatusLabel.Text = "Ready";
            // 
            // progressBarTotal
            // 
            this.progressBarTotal.Name = "progressBarTotal";
            this.progressBarTotal.Size = new System.Drawing.Size(100, 16);
            this.progressBarTotal.Visible = false;
            // 
            // toolStripProgressBar
            // 
            this.toolStripProgressBar.Name = "toolStripProgressBar";
            this.toolStripProgressBar.Size = new System.Drawing.Size(100, 16);
            this.toolStripProgressBar.Visible = false;
            // 
            // toolStripStatusSelectionLabel
            // 
            this.toolStripStatusSelectionLabel.Name = "toolStripStatusSelectionLabel";
            this.toolStripStatusSelectionLabel.Size = new System.Drawing.Size(146, 17);
            this.toolStripStatusSelectionLabel.Text = "toolStripStatusSelectionLabel";
            this.toolStripStatusSelectionLabel.Visible = false;
            // 
            // tsbNewArchive
            // 
            this.tsbNewArchive.AutoSize = false;
            this.tsbNewArchive.Image = ((System.Drawing.Image)(resources.GetObject("tsbNewArchive.Image")));
            this.tsbNewArchive.Name = "tsbNewArchive";
            this.tsbNewArchive.Size = new System.Drawing.Size(49, 49);
            this.tsbNewArchive.Text = "New";
            this.tsbNewArchive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbNewArchive.Click += new System.EventHandler(this.tsbNewArchive_Click);
            // 
            // tsbOpenArchive
            // 
            this.tsbOpenArchive.AutoSize = false;
            this.tsbOpenArchive.Image = ((System.Drawing.Image)(resources.GetObject("tsbOpenArchive.Image")));
            this.tsbOpenArchive.Name = "tsbOpenArchive";
            this.tsbOpenArchive.Size = new System.Drawing.Size(49, 49);
            this.tsbOpenArchive.Text = "Open";
            this.tsbOpenArchive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbOpenArchive.Click += new System.EventHandler(this.tsbOpenArchive_Click);
            // 
            // tsbClose
            // 
            this.tsbClose.AutoSize = false;
            this.tsbClose.Enabled = false;
            this.tsbClose.Image = ((System.Drawing.Image)(resources.GetObject("tsbClose.Image")));
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(49, 49);
            this.tsbClose.Text = "Close";
            this.tsbClose.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // tsbTestArchive
            // 
            this.tsbTestArchive.AutoSize = false;
            this.tsbTestArchive.Enabled = false;
            this.tsbTestArchive.Image = ((System.Drawing.Image)(resources.GetObject("tsbTestArchive.Image")));
            this.tsbTestArchive.Name = "tsbTestArchive";
            this.tsbTestArchive.Size = new System.Drawing.Size(49, 49);
            this.tsbTestArchive.Text = "Test";
            this.tsbTestArchive.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbTestArchive.Click += new System.EventHandler(this.tsbTestArchive_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbAddFiles
            // 
            this.tsbAddFiles.Enabled = false;
            this.tsbAddFiles.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddFiles.Image")));
            this.tsbAddFiles.Name = "tsbAddFiles";
            this.tsbAddFiles.Size = new System.Drawing.Size(54, 49);
            this.tsbAddFiles.Text = "Add Files";
            this.tsbAddFiles.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAddFiles.Click += new System.EventHandler(this.tsbAddFiles_Click);
            // 
            // tsbAddFolder
            // 
            this.tsbAddFolder.Enabled = false;
            this.tsbAddFolder.Image = ((System.Drawing.Image)(resources.GetObject("tsbAddFolder.Image")));
            this.tsbAddFolder.Name = "tsbAddFolder";
            this.tsbAddFolder.Size = new System.Drawing.Size(63, 49);
            this.tsbAddFolder.Text = "Add Folder";
            this.tsbAddFolder.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAddFolder.Click += new System.EventHandler(this.tsbAddFolder_Click);
            // 
            // tsbExtract
            // 
            this.tsbExtract.AutoSize = false;
            this.tsbExtract.Enabled = false;
            this.tsbExtract.Image = ((System.Drawing.Image)(resources.GetObject("tsbExtract.Image")));
            this.tsbExtract.Name = "tsbExtract";
            this.tsbExtract.Size = new System.Drawing.Size(49, 49);
            this.tsbExtract.Text = "Extract";
            this.tsbExtract.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbExtract.Click += new System.EventHandler(this.tsbExtract_Click);
            // 
            // tsbDelete
            // 
            this.tsbDelete.AutoSize = false;
            this.tsbDelete.Enabled = false;
            this.tsbDelete.Image = ((System.Drawing.Image)(resources.GetObject("tsbDelete.Image")));
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(49, 49);
            this.tsbDelete.Text = "Delete";
            this.tsbDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            // 
            // tsbView
            // 
            this.tsbView.AutoSize = false;
            this.tsbView.Enabled = false;
            this.tsbView.Image = ((System.Drawing.Image)(resources.GetObject("tsbView.Image")));
            this.tsbView.Name = "tsbView";
            this.tsbView.Size = new System.Drawing.Size(49, 49);
            this.tsbView.Text = "View";
            this.tsbView.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbView.Click += new System.EventHandler(this.tsbView_Click);
            // 
            // tsbAbort
            // 
            this.tsbAbort.AutoSize = false;
            this.tsbAbort.Enabled = false;
            this.tsbAbort.Image = ((System.Drawing.Image)(resources.GetObject("tsbAbort.Image")));
            this.tsbAbort.Name = "tsbAbort";
            this.tsbAbort.Size = new System.Drawing.Size(49, 49);
            this.tsbAbort.Text = "Abort";
            this.tsbAbort.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbAbort.Click += new System.EventHandler(this.tsbAbort_Click);
            // 
            // tsbRefresh
            // 
            this.tsbRefresh.AutoSize = false;
            this.tsbRefresh.Enabled = false;
            this.tsbRefresh.Image = ((System.Drawing.Image)(resources.GetObject("tsbRefresh.Image")));
            this.tsbRefresh.Name = "tsbRefresh";
            this.tsbRefresh.Size = new System.Drawing.Size(49, 49);
            this.tsbRefresh.Text = "Refresh";
            this.tsbRefresh.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbRefresh.Click += new System.EventHandler(this.tsbRefresh_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(6, 39);
            // 
            // tsbSettings
            // 
            this.tsbSettings.AutoSize = false;
            this.tsbSettings.Image = ((System.Drawing.Image)(resources.GetObject("tsbSettings.Image")));
            this.tsbSettings.Name = "tsbSettings";
            this.tsbSettings.Size = new System.Drawing.Size(49, 49);
            this.tsbSettings.Text = "Settings";
            this.tsbSettings.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsbSettings.Click += new System.EventHandler(this.tsbSettings_Click);
            // 
            // newArchiveToolStripMenuItem
            // 
            this.newArchiveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("newArchiveToolStripMenuItem.Image")));
            this.newArchiveToolStripMenuItem.Name = "newArchiveToolStripMenuItem";
            this.newArchiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newArchiveToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.newArchiveToolStripMenuItem.Text = "New Archive...";
            this.newArchiveToolStripMenuItem.Click += new System.EventHandler(this.newArchiveToolStripMenuItem_Click);
            // 
            // openArchiveToolStripMenuItem
            // 
            this.openArchiveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("openArchiveToolStripMenuItem.Image")));
            this.openArchiveToolStripMenuItem.Name = "openArchiveToolStripMenuItem";
            this.openArchiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openArchiveToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.openArchiveToolStripMenuItem.Text = "Open Archive...";
            this.openArchiveToolStripMenuItem.Click += new System.EventHandler(this.openArchiveToolStripMenuItem_Click);
            // 
            // closeArchiveToolStripMenuItem
            // 
            this.closeArchiveToolStripMenuItem.Enabled = false;
            this.closeArchiveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("closeArchiveToolStripMenuItem.Image")));
            this.closeArchiveToolStripMenuItem.Name = "closeArchiveToolStripMenuItem";
            this.closeArchiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.W)));
            this.closeArchiveToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.closeArchiveToolStripMenuItem.Text = "Close Archive";
            this.closeArchiveToolStripMenuItem.Click += new System.EventHandler(this.closeArchiveToolStripMenuItem_Click);
            // 
            // testArchiveToolStripMenuItem
            // 
            this.testArchiveToolStripMenuItem.Enabled = false;
            this.testArchiveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("testArchiveToolStripMenuItem.Image")));
            this.testArchiveToolStripMenuItem.Name = "testArchiveToolStripMenuItem";
            this.testArchiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.T)));
            this.testArchiveToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.testArchiveToolStripMenuItem.Text = "Test Archive";
            this.testArchiveToolStripMenuItem.Click += new System.EventHandler(this.testArchiveToolStripMenuItem_Click);
            // 
            // passwordToolStripMenuItem
            // 
            this.passwordToolStripMenuItem.Enabled = false;
            this.passwordToolStripMenuItem.Name = "passwordToolStripMenuItem";
            this.passwordToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.passwordToolStripMenuItem.Text = "Password...";
            this.passwordToolStripMenuItem.Click += new System.EventHandler(this.passwordToolStripMenuItem_Click);
            // 
            // archiveCommentToolStripMenuItem
            // 
            this.archiveCommentToolStripMenuItem.Enabled = false;
            this.archiveCommentToolStripMenuItem.Name = "archiveCommentToolStripMenuItem";
            this.archiveCommentToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.archiveCommentToolStripMenuItem.Text = "Comment...";
            this.archiveCommentToolStripMenuItem.Click += new System.EventHandler(this.archiveCommentToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(188, 6);
            // 
            // selectAllToolStripMenuItem
            // 
            this.selectAllToolStripMenuItem.Enabled = false;
            this.selectAllToolStripMenuItem.Name = "selectAllToolStripMenuItem";
            this.selectAllToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.selectAllToolStripMenuItem.Text = "Select All";
            this.selectAllToolStripMenuItem.Click += new System.EventHandler(this.selectAllToolStripMenuItem_Click);
            // 
            // invertSelectionToolStripMenuItem
            // 
            this.invertSelectionToolStripMenuItem.Enabled = false;
            this.invertSelectionToolStripMenuItem.Name = "invertSelectionToolStripMenuItem";
            this.invertSelectionToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.invertSelectionToolStripMenuItem.Text = "Invert Selection";
            this.invertSelectionToolStripMenuItem.Click += new System.EventHandler(this.invertSelectionToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(224, 6);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.O)));
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.optionsToolStripMenuItem.Text = "&Options";
            this.optionsToolStripMenuItem.Click += new System.EventHandler(this.optionsToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(188, 6);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(188, 6);
            // 
            // refreshToolStripMenuItem
            // 
            this.refreshToolStripMenuItem.Enabled = false;
            this.refreshToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("refreshToolStripMenuItem.Image")));
            this.refreshToolStripMenuItem.Name = "refreshToolStripMenuItem";
            this.refreshToolStripMenuItem.Size = new System.Drawing.Size(191, 22);
            this.refreshToolStripMenuItem.Text = "Refresh";
            this.refreshToolStripMenuItem.Click += new System.EventHandler(this.refreshToolStripMenuItem_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMenu,
            this.optionsToolStripMenuItem,
            this.commandsToolStripMenuItem,
            this.archiveToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(721, 24);
            this.menuStrip.TabIndex = 140;
            // 
            // fileMenu
            // 
            this.fileMenu.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newArchiveToolStripMenuItem,
            this.openArchiveToolStripMenuItem,
            this.closeArchiveToolStripMenuItem,
            this.testArchiveToolStripMenuItem,
            this.passwordToolStripMenuItem,
            this.archiveCommentToolStripMenuItem,
            this.toolStripSeparator3,
            this.selectAllToolStripMenuItem,
            this.invertSelectionToolStripMenuItem,
            this.toolStripSeparator5,
            this.refreshToolStripMenuItem,
            this.toolStripSeparator6,
            this.quitToolStripMenuItem});
            this.fileMenu.Name = "fileMenu";
            this.fileMenu.Size = new System.Drawing.Size(35, 20);
            this.fileMenu.Text = "&File";
            // 
            // commandsToolStripMenuItem
            // 
            this.commandsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createDirectoryToolStripMenuItem,
            this.addFilesToolStripMenuItem,
            this.addFolderToArchiveToolStripMenuItem,
            this.extractToFolderToolStripMenuItem,
            this.calculateDirectorySizeToolStripMenuItem,
            this.toolStripSeparator8,
            this.viewFileToolStripMenuItem,
            this.viewWithInternalViewerToolStripMenuItem,
            this.deleteFilesToolStripMenuItem,
            this.renameFileToolStripMenuItem,
            this.fileCommentToolStripMenuItem,
            this.moveToolStripMenuItem,
            this.toolStripSeparator9,
            this.updateArchiveToolStripMenuItem});
            this.commandsToolStripMenuItem.Name = "commandsToolStripMenuItem";
            this.commandsToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
            this.commandsToolStripMenuItem.Text = "&Commands";
            // 
            // createDirectoryToolStripMenuItem
            // 
            this.createDirectoryToolStripMenuItem.Enabled = false;
            this.createDirectoryToolStripMenuItem.Name = "createDirectoryToolStripMenuItem";
            this.createDirectoryToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.createDirectoryToolStripMenuItem.Text = "&Create Directory...";
            this.createDirectoryToolStripMenuItem.Click += new System.EventHandler(this.createDirectoryToolStripMenuItem_Click);
            // 
            // addFilesToolStripMenuItem
            // 
            this.addFilesToolStripMenuItem.Enabled = false;
            this.addFilesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFilesToolStripMenuItem.Image")));
            this.addFilesToolStripMenuItem.Name = "addFilesToolStripMenuItem";
            this.addFilesToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.addFilesToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.addFilesToolStripMenuItem.Text = "Add Files to Archive...";
            this.addFilesToolStripMenuItem.Click += new System.EventHandler(this.addFilesToolStripMenuItem_Click);
            // 
            // addFolderToArchiveToolStripMenuItem
            // 
            this.addFolderToArchiveToolStripMenuItem.Enabled = false;
            this.addFolderToArchiveToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("addFolderToArchiveToolStripMenuItem.Image")));
            this.addFolderToArchiveToolStripMenuItem.Name = "addFolderToArchiveToolStripMenuItem";
            this.addFolderToArchiveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.A)));
            this.addFolderToArchiveToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.addFolderToArchiveToolStripMenuItem.Text = "Add Folder to Archive...";
            this.addFolderToArchiveToolStripMenuItem.Click += new System.EventHandler(this.addFolderToArchiveToolStripMenuItem_Click);
            // 
            // extractToFolderToolStripMenuItem
            // 
            this.extractToFolderToolStripMenuItem.Enabled = false;
            this.extractToFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("extractToFolderToolStripMenuItem.Image")));
            this.extractToFolderToolStripMenuItem.Name = "extractToFolderToolStripMenuItem";
            this.extractToFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.extractToFolderToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.extractToFolderToolStripMenuItem.Text = "Extract to Folder...";
            this.extractToFolderToolStripMenuItem.Click += new System.EventHandler(this.extractToFolderToolStripMenuItem_Click);
            // 
            // calculateDirectorySizeToolStripMenuItem
            // 
            this.calculateDirectorySizeToolStripMenuItem.Enabled = false;
            this.calculateDirectorySizeToolStripMenuItem.Name = "calculateDirectorySizeToolStripMenuItem";
            this.calculateDirectorySizeToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.calculateDirectorySizeToolStripMenuItem.Text = "Calculate Total Size";
            this.calculateDirectorySizeToolStripMenuItem.Click += new System.EventHandler(this.calculateDirectorySizeToolStripMenuItem_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(256, 6);
            // 
            // viewFileToolStripMenuItem
            // 
            this.viewFileToolStripMenuItem.Enabled = false;
            this.viewFileToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("viewFileToolStripMenuItem.Image")));
            this.viewFileToolStripMenuItem.Name = "viewFileToolStripMenuItem";
            this.viewFileToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.viewFileToolStripMenuItem.Text = "View File...";
            this.viewFileToolStripMenuItem.Click += new System.EventHandler(this.viewFileToolStripMenuItem_Click);
            // 
            // viewWithInternalViewerToolStripMenuItem
            // 
            this.viewWithInternalViewerToolStripMenuItem.Enabled = false;
            this.viewWithInternalViewerToolStripMenuItem.Name = "viewWithInternalViewerToolStripMenuItem";
            this.viewWithInternalViewerToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.viewWithInternalViewerToolStripMenuItem.Text = "View with Internal Viewer...";
            this.viewWithInternalViewerToolStripMenuItem.Click += new System.EventHandler(this.viewWithInternalViewerToolStripMenuItem_Click);
            // 
            // deleteFilesToolStripMenuItem
            // 
            this.deleteFilesToolStripMenuItem.Enabled = false;
            this.deleteFilesToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("deleteFilesToolStripMenuItem.Image")));
            this.deleteFilesToolStripMenuItem.Name = "deleteFilesToolStripMenuItem";
            this.deleteFilesToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteFilesToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.deleteFilesToolStripMenuItem.Text = "Delete Files";
            this.deleteFilesToolStripMenuItem.Click += new System.EventHandler(this.deleteFilesToolStripMenuItem_Click);
            // 
            // renameFileToolStripMenuItem
            // 
            this.renameFileToolStripMenuItem.Enabled = false;
            this.renameFileToolStripMenuItem.Name = "renameFileToolStripMenuItem";
            this.renameFileToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.renameFileToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.renameFileToolStripMenuItem.Text = "Rename File";
            this.renameFileToolStripMenuItem.Click += new System.EventHandler(this.renameFileToolStripMenuItem_Click);
            // 
            // fileCommentToolStripMenuItem
            // 
            this.fileCommentToolStripMenuItem.Enabled = false;
            this.fileCommentToolStripMenuItem.Name = "fileCommentToolStripMenuItem";
            this.fileCommentToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.fileCommentToolStripMenuItem.Text = "File Comment...";
            this.fileCommentToolStripMenuItem.Click += new System.EventHandler(this.fileCommentToolStripMenuItem_Click);
            // 
            // moveToolStripMenuItem
            // 
            this.moveToolStripMenuItem.Enabled = false;
            this.moveToolStripMenuItem.Name = "moveToolStripMenuItem";
            this.moveToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.moveToolStripMenuItem.Text = "Move...";
            this.moveToolStripMenuItem.Click += new System.EventHandler(this.moveToolStripMenuItem_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(256, 6);
            // 
            // updateArchiveToolStripMenuItem
            // 
            this.updateArchiveToolStripMenuItem.Enabled = false;
            this.updateArchiveToolStripMenuItem.Name = "updateArchiveToolStripMenuItem";
            this.updateArchiveToolStripMenuItem.Size = new System.Drawing.Size(259, 22);
            this.updateArchiveToolStripMenuItem.Text = "Update Archive...";
            this.updateArchiveToolStripMenuItem.Click += new System.EventHandler(this.updateArchiveToolStripMenuItem_Click);
            // 
            // archiveToolStripMenuItem
            // 
            this.archiveToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createSFXToolStripMenuItem});
            this.archiveToolStripMenuItem.Name = "archiveToolStripMenuItem";
            this.archiveToolStripMenuItem.Size = new System.Drawing.Size(55, 20);
            this.archiveToolStripMenuItem.Text = "&Archive";
            // 
            // createSFXToolStripMenuItem
            // 
            this.createSFXToolStripMenuItem.Enabled = false;
            this.createSFXToolStripMenuItem.Name = "createSFXToolStripMenuItem";
            this.createSFXToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.createSFXToolStripMenuItem.Text = "&Create SFX...";
            this.createSFXToolStripMenuItem.Click += new System.EventHandler(this.createSFXToolStripMenuItem_Click);
            // 
            // toolbarMain
            // 
            this.toolbarMain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolbarMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNewArchive,
            this.tsbOpenArchive,
            this.tsbClose,
            this.tsbTestArchive,
            this.tsbSettings,
            this.toolStripSeparator,
            this.tsbDelete,
            this.tsbRefresh,
            this.tsbAbort,
            this.tsbView,
            this.tsbExtract,
            this.tsbAddFolder,
            this.tsbAddFiles});
            this.toolbarMain.Location = new System.Drawing.Point(0, 24);
            this.toolbarMain.Name = "toolbarMain";
            this.toolbarMain.Size = new System.Drawing.Size(721, 52);
            this.toolbarMain.TabIndex = 139;
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            this.toolStripSeparator.Size = new System.Drawing.Size(6, 52);
            // 
            // addressBar
            // 
            this.addressBar.Controls.Add(this.txtAddress);
            this.addressBar.Controls.Add(this.btnUpOneLevel);
            this.addressBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.addressBar.Enabled = false;
            this.addressBar.Location = new System.Drawing.Point(0, 76);
            this.addressBar.Name = "addressBar";
            this.addressBar.Size = new System.Drawing.Size(721, 29);
            this.addressBar.TabIndex = 141;
            // 
            // txtAddress
            // 
            this.txtAddress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddress.BackColor = System.Drawing.Color.White;
            this.txtAddress.Location = new System.Drawing.Point(41, 4);
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.ReadOnly = true;
            this.txtAddress.Size = new System.Drawing.Size(675, 20);
            this.txtAddress.TabIndex = 1;
            // 
            // btnUpOneLevel
            // 
            this.btnUpOneLevel.Image = ((System.Drawing.Image)(resources.GetObject("btnUpOneLevel.Image")));
            this.btnUpOneLevel.Location = new System.Drawing.Point(5, 3);
            this.btnUpOneLevel.Name = "btnUpOneLevel";
            this.btnUpOneLevel.Size = new System.Drawing.Size(32, 23);
            this.btnUpOneLevel.TabIndex = 0;
            this.btnUpOneLevel.TabStop = false;
            this.btnUpOneLevel.UseVisualStyleBackColor = true;
            this.btnUpOneLevel.Click += new System.EventHandler(this.btnUpOneLevel_Click);
            // 
            // ArchiveManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(721, 482);
            this.Controls.Add(this.listView);
            this.Controls.Add(this.addressBar);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolbarMain);
            this.Controls.Add(this.menuStrip);
            this.Name = "ArchiveManager";
            this.Text = "UltimateZip ArchiveManager";
            this.listContextMenu.ResumeLayout(false);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.toolbarMain.ResumeLayout(false);
            this.toolbarMain.PerformLayout();
            this.addressBar.ResumeLayout(false);
            this.addressBar.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader colName;
        private System.Windows.Forms.ColumnHeader colModified;
        private System.Windows.Forms.ColumnHeader colSize;
        private System.Windows.Forms.ColumnHeader colRatio;
        private System.Windows.Forms.ColumnHeader colPacked;
        private System.Windows.Forms.ColumnHeader colAttributes;
        private System.Windows.Forms.ColumnHeader colPath;
        private System.Windows.Forms.ToolStripButton tsbRefresh;
        private System.Windows.Forms.ToolStripButton tsbSettings;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsbDelete;
        private System.Windows.Forms.ToolStripButton tsbView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem newArchiveToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripProgressBar toolStripProgressBar;
        private System.Windows.Forms.ToolStripMenuItem openArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeArchiveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem passwordToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem selectAllToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem invertSelectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem archiveCommentToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripMenuItem refreshToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripButton tsbNewArchive;
        private System.Windows.Forms.ToolStripButton tsbOpenArchive;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.ToolStripButton tsbTestArchive;
        private System.Windows.Forms.ToolStripButton tsbAddFiles;
        private System.Windows.Forms.ToolStripButton tsbAddFolder;
        private System.Windows.Forms.ToolStripButton tsbExtract;
        private System.Windows.Forms.ToolStripMenuItem testArchiveToolStripMenuItem;
        private System.Windows.Forms.ContextMenuStrip listContextMenu;
        private System.Windows.Forms.ToolStripMenuItem addFilesContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addFolderContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewContextMenuItem;
        private System.Windows.Forms.ToolStripMenuItem renameContextMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem refreshContextMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusSelectionLabel;
        public System.Windows.Forms.ImageList imglist;
        private System.Windows.Forms.ToolStripButton tsbAbort;
        private System.Windows.Forms.ToolStrip toolbarMain;
        private ToolStripMenuItem fileMenu;
        private ToolStripSeparator toolStripSeparator;
        private ToolStripMenuItem commandsToolStripMenuItem;
        private ToolStripMenuItem addFilesToolStripMenuItem;
        private ToolStripMenuItem addFolderToArchiveToolStripMenuItem;
        private ToolStripMenuItem extractToFolderToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator8;
        private ToolStripMenuItem viewFileToolStripMenuItem;
        private ToolStripMenuItem deleteFilesToolStripMenuItem;
        private ToolStripMenuItem renameFileToolStripMenuItem;
        private Panel addressBar;
        private TextBox txtAddress;
        private Button btnUpOneLevel;
        private ColumnHeader colTypeName;
        private ColumnHeader colCrc;
        private ToolStripMenuItem createDirectoryToolStripMenuItem;
        private ToolStripMenuItem moveToolStripMenuItem;
        private ToolStripMenuItem createDirectoryContextMenuItem;
        private ToolStripSeparator toolStripSeparator9;
        private ToolStripMenuItem updateArchiveToolStripMenuItem;
        private ToolStripMenuItem fileCommentToolStripMenuItem;
        private ToolStripMenuItem fileCommentContextMenuItem;
        private ToolStripMenuItem moveContextMenuItem;
        private ToolStripProgressBar progressBarTotal;
        private ToolStripMenuItem calculateDirectorySizeToolStripMenuItem;
        private ToolStripMenuItem calculateTotalSizeContextMenuItem;
        private ToolStripMenuItem archiveToolStripMenuItem;
        private ToolStripMenuItem createSFXToolStripMenuItem;
        private ToolStripMenuItem viewWithInternalViewerContextMenuItem;
        private ToolStripMenuItem viewWithInternalViewerToolStripMenuItem;
    }
}

