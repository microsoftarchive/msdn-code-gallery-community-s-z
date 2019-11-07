using System.Windows.Controls;
using Tasks.Show.ViewModels;

namespace Tasks.Show.Views
{
    public partial class FolderView : UserControl
    {
        public FolderView()
        {
            InitializeComponent();
                }

        private void DetailsDropDown_RequestFolderRename(object sender, UserControls.RequestFolderRenameEventArgs e)
            {
            App.Root.TaskData.RenameFolder(e.Folder, e.NewName);
                }
                }
        }
