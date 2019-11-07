using System.ComponentModel;

namespace Tasks.Show.Models
{
    public class FolderChangingEventArgs : CancelEventArgs
    {
        public FolderChangingEventArgs(Folder newFolder)
            : base()
        {
            m_folder = newFolder;
        }

        public Folder Folder { get { return m_folder; } }

        private readonly Folder m_folder;
    }
}
