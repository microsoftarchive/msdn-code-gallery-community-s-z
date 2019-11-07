using System.ComponentModel;
using PixelLab.Common;

namespace Tasks.Show.Models
{
    public class DraftTask : BaseTask
    {
        public override string FolderName
        {
            get
            {
                return m_folderName;
            }
            set
            {
                if (value != m_folderName)
                {
                    m_folderName = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("FolderName"));
                }
            }
        }

        private string m_folderName;
    }
}
