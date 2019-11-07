using System;
using System.ComponentModel;

namespace Tasks.Show.Models
{
    public class Task : BaseTask
    {
        public Folder Folder
        {
            get { return m_folder; }
            set
            {
                var args = new FolderChangingEventArgs(value);
                OnFolderChanging(args);
                if (args.Cancel)
                {
                    throw new OperationCanceledException();
                }
                else
                {
                    if (m_folder != null)
                    {
                        m_folder.PropertyChanged -= folder_propertyChanged;
                    }
                    m_folder = value;
                    if (m_folder != null)
                    {
                        m_folder.PropertyChanged += folder_propertyChanged;
                    }
                    OnPropertyChanged(new PropertyChangedEventArgs("Folder"));
                    OnPropertyChanged(new PropertyChangedEventArgs("EffectiveFolder"));
                    OnPropertyChanged(new PropertyChangedEventArgs("FolderName"));
                }
            }
        }

        public override string FolderName
        {
            get
            {
                return EffectiveFolder.Name;
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public BaseFolder EffectiveFolder { get { return m_folder == null ? SpecialFolder.InboxFolder : (BaseFolder)m_folder; } }

        public event EventHandler<FolderChangingEventArgs> FolderChanging;

        protected virtual void OnFolderChanging(FolderChangingEventArgs args)
        {
            var handler = FolderChanging;
            if (handler != null)
            {
                handler(this, args);
            }
        }

        private void folder_propertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Name")
            {
                OnPropertyChanged(new PropertyChangedEventArgs("FolderName"));
            }
        }

        private Folder m_folder;
    }
}
