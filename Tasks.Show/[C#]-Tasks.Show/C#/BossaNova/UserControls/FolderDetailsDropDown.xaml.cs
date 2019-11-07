using System;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using Tasks.Show.Models;
using Tasks.Show.ViewModels;
using System.Windows.Controls;


namespace Tasks.Show.UserControls
{
    public partial class FolderDetailsDropDown : UserControl
    {
        #region Constructors

        public FolderDetailsDropDown()
        {
            InitializeComponent();

            this.PreviewKeyDown += UserControl_KeyDown;
            m_newFolderTextBox.PreviewKeyUp += UserControl_KeyDown;
        }

        #endregion Constructors

        public event EventHandler<RequestFolderRenameEventArgs> RequestFolderRename;

        #region Event Handlers

        private void Popup_Opened(object sender, EventArgs e)
        {
            ColorListBox.SelectedItem = null;
            m_newFolderTextBox.Text = Folder == null ? "" : Folder.Name;
            m_newFolderTextBox.Focus();
            m_newFolderTextBox.SelectAll();

            // only show the remove button if the folder is empty

            Tasks.Show.Models.Folder f = this.DataContext as Tasks.Show.Models.Folder;

            if (f != null)
            {
                bool hasItems = App.Root.TaskData.Tasks.Any(t => t.Folder == f);
                if (!hasItems)
                {
                    RemoveButtonGrid.Visibility = Visibility.Visible;
            }
                else
                {
                    RemoveButtonGrid.Visibility = Visibility.Collapsed;
        }
            }
        }

        private void UserControl_KeyDown(object sender, KeyEventArgs e)
        {
            if (this.Popup.IsOpen)
            {
                if (e.Key == Key.Enter || e.Key == Key.Return || e.Key == Key.Escape)
                {
                    Close();
                }
                    }
                }

        #endregion Event Handlers

        #region Private Methods

        private void Close()
        {
            if (Folder != null && !m_newFolderTextBox.Text.Equals(Folder.Name) && Folder.IsValidFolderName(m_newFolderTextBox.Text))
            {
                var handler = RequestFolderRename;
                if (handler != null)
                {
                    handler(this, new RequestFolderRenameEventArgs(Folder, m_newFolderTextBox.Text));
            }
            }
            this.Popup.IsOpen = false;
        }

        #endregion Private Methods

        private Folder Folder { get { return DataContext as Folder; } }

        private void ColorListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (ColorListBox.SelectedItem is Color && Folder != null)
            {
                // update the folder color
                Folder.Color = (Color)ColorListBox.SelectedItem;
                this.Close();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Tasks.Show.Models.Folder f = this.DataContext as Tasks.Show.Models.Folder;

            if (f != null )
            {
                bool hasItems = App.Root.TaskData.Tasks.Any(t => t.Folder == f);
                if (!hasItems)
                {
                    App.Root.TaskData.RemoveFolder(f);
            }
        }

            
    }
}

    public class RequestFolderRenameEventArgs : EventArgs
    {
        public RequestFolderRenameEventArgs(Folder folder, string newName)
        {
            Folder = folder;
            NewName = newName;
        }

        public Folder Folder { get; private set; }
        public string NewName { get; private set; }
    }
}
