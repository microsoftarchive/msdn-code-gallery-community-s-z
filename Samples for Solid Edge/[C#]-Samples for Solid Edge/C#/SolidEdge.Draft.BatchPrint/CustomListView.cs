using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SolidEdge.Draft.BatchPrint
{
    public class CustomListView : ListView
    {
        private bool _useExplorerTheme;
        public DraftPrintUtilityOptions DraftPrintUtilityOptions;

        public CustomListView()
            : base()
        {
            // Turn on double buffering.
            DoubleBuffered = true;

            // Setup image list.
            SmallImageList = new ImageList();
            SmallImageList.ColorDepth = ColorDepth.Depth32Bit;
        }

        protected override void OnCreateControl()
        {
            base.OnCreateControl();

            // If set in designer, UseExplorerTheme will get called before control is actually created thus calling it a 2nd time here. 
            UseExplorerTheme = _useExplorerTheme;
        }

        protected override void OnDragOver(DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        protected override void OnDragDrop(DragEventArgs e)
        {
            // Can only drop folders\files, so check
            if (!e.Data.GetDataPresent(DataFormats.FileDrop)) 
            {
                return;
            }

            // Get the paths to the dropped items.
            string[] paths = (string[])e.Data.GetData(DataFormats.FileDrop);

            // Process each path.
            foreach (string path in paths)
            {
                // Determine if path is directory or file.
                if (Directory.Exists(path))
                {
                    SearchOption searchOption = SearchOption.TopDirectoryOnly;
                    DirectoryInfo directoryInfo = new DirectoryInfo(path);
                    DirectoryInfo[] subDirectoryInfos = directoryInfo.GetDirectories();

                    // If directory has subdirectories, ask user if we should process those as well.
                    if (subDirectoryInfos.Length > 0)
                    {
                        // Build the question to ask the user.
                        string message = String.Format("'{0}' contains subdirectories. Would you like to include those in the search?", directoryInfo.FullName);

                        // Ask the question.
                        switch (MessageBox.Show(message, "Process subdirectories?", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                        {
                            case DialogResult.Yes:
                                searchOption = SearchOption.AllDirectories;
                                break;
                            case DialogResult.Cancel:
                                // Bail out of entire OnDragDrop().
                                return;
                        }
                    }

                    AddFolder(directoryInfo, searchOption);
                }
                else
                {
                    FileInfo fileInfo = new FileInfo(path);
                    
                    // We are only interested in Draft files.
                    if (fileInfo.Extension.Equals(".dft", StringComparison.OrdinalIgnoreCase))
                    {
                        AddFile(fileInfo);
                    }
                }
            }

            // Adjust column(s) width to fit the item content.
            AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            base.OnKeyDown(e);

            try
            {
                // Disable ListView updating while adding items.
                BeginUpdate();

                // Determine the key pressed.
                switch (e.KeyCode)
                {
                    case Keys.A: // CTRL + A = Select All
                        if (e.Control)
                        {
                            foreach (ListViewItem item in Items)
                            {
                                item.Selected = true;
                            }
                        }
                        break;
                    case Keys.Delete: // DELETE = Remove selected items.
                        while (SelectedItems.Count > 0)
                        {
                            SelectedItems[0].Remove();
                        }
                        break;
                }
            }
            catch
            {
                throw;
            }
            finally
            {
                // Enable ListView updating.
                EndUpdate();
            }
        }

        public void AddFolder(DirectoryInfo directoryInfo)
        {
            AddFolder(directoryInfo, SearchOption.TopDirectoryOnly);
        }

        public void AddFolder(DirectoryInfo directoryInfo, SearchOption searchOption)
        {
            AddFiles(directoryInfo.GetFiles("*.dft", searchOption));
        }

        public void AddFiles(FileInfo[] fileInfos)
        {
            foreach (FileInfo fileInfo in fileInfos)
            {
                AddFile(fileInfo);
            }
        }

        public void AddFile(FileInfo fileInfo)
        {
            // Only add .dft files.
            if (!fileInfo.Extension.Equals(".dft", StringComparison.OrdinalIgnoreCase))
            {
                return;
            }

            // If the file has already been added, ignore it.
            if (Items.ContainsKey(fileInfo.FullName))
            {
                return;
            }

            // Add the icon to the image list if it's not there.
            if (!SmallImageList.Images.ContainsKey(fileInfo.Extension))
            {
                // Note: GetSmallIcon() is an extension method.
                Icon icon = fileInfo.GetSmallIcon();
                SmallImageList.Images.Add(fileInfo.Extension, icon);
            }

            
            // Add the list view item.
            ListViewItem listViewItem = Items.Add(
                key: fileInfo.FullName,
                text: fileInfo.FullName,
                imageKey: fileInfo.Extension);

            // Make a clone of the DraftPrintUtility settings for this individual item.
            listViewItem.Tag = DraftPrintUtilityOptions.Clone();
        }

        public bool UseExplorerTheme
        {
            get
            {
                return _useExplorerTheme;
            }
            set
            {
                _useExplorerTheme = value;
                if (this.Created)
                {
                    NativeMethods.SetWindowTheme(this.Handle, value ? "explorer" : "", null);
                }
            }
        }
    }
}
