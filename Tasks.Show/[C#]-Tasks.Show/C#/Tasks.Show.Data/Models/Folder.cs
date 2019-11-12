using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Windows.Media;
using PixelLab.Common;
using Tasks.Show.Helpers;

namespace Tasks.Show.Models
{
    public abstract class BaseFolder
    {
        #region Fields

        public const string AllFolderName = "All", InboxFolderName = "Inbox";
        public static readonly ReadOnlyCollection<string> ReservedFolderNames = new ReadOnlyCollection<string>(new string[] { AllFolderName, InboxFolderName });

        #endregion Fields

        #region Properties

        public abstract Color Color { get; set; }

        public bool IsSpecial { get { return Name == AllFolderName || Name == InboxFolderName; } }

        public abstract string Name { get; }

        #endregion Properties

        #region Public Methods

        public bool ContainsTask(Task task)
        {
            Util.RequireNotNull(task, "task");
            if (this == SpecialFolder.AllFolder)
            {
                return true;
            }
            else
            {
                return task.EffectiveFolder == this;
            }
        }

        public static bool IsValidFolderName(string name)
        {
            name = name.SuperTrim();
            if (name == null)
            {
                return false;
            }
            else
            {
                return !ReservedFolderNames.Any(folderName => folderName.EasyEquals(name));
            }
        }

        public override string ToString()
        {
            return base.ToString() + (" (" + (this.Name == null ? "null" : this.Name) + ")");
        }

        #endregion Public Methods
    }

    public sealed class SpecialFolder : BaseFolder, IEquatable<SpecialFolder>
    {
        #region Fields

        public static readonly SpecialFolder AllFolder = new SpecialFolder(AllFolderName);
        public static readonly SpecialFolder InboxFolder = new SpecialFolder(InboxFolderName);
        private readonly string m_name;

        #endregion Fields

        #region Constructors

        private SpecialFolder(string name)
        {
            m_name = name;
        }

        #endregion Constructors

        #region Properties

        public override Color Color
        {
            get { return Colors.Transparent; }
            set { throw new NotSupportedException(); }
        }

        public override string Name
        {
            get { return m_name; }
        }

        #endregion Properties

        public bool Equals(SpecialFolder other)
        {
            return other != null && m_name.Equals(other.m_name);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as SpecialFolder);
        }

        public override int GetHashCode()
        {
            return Util.GetHashCode(m_name);
        }
    }

    public sealed class Folder : BaseFolder, INotifyPropertyChanged, IEquatable<Folder>
    {
        #region Fields

        private Color m_color;
        private string m_name;

        #endregion Fields

        #region Constructors

        public Folder(string name, Color color)
        {
            UpdateName(name);
            m_color = color;
        }

        #endregion Constructors

        #region Properties

        public override Color Color
        {
            get
            {
                Debug.Assert(m_color != default(Color), "should never happen");
                return m_color;
            }
            set
            {
                if (m_color != value)
                {
                    m_color = value;
                    OnPropertyChanged(new PropertyChangedEventArgs("Color"));

                    RefreshTaskColors();
                }
            }
        }

        public override string Name
        {
            get
            {
                Debug.Assert(IsValidFolderName(m_name), "Should never happen...");
                return m_name;
            }
        }

        #endregion Properties

        #region Events

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion Events

        #region Protected Methods

        private void OnPropertyChanged(PropertyChangedEventArgs e)
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        #endregion Protected Methods

        internal void UpdateName(string name)
        {
            Util.RequireArgument(name == name.SuperTrim(), "name's must be trimmed");
            Util.RequireNotNullOrEmpty(name, "name");
            Util.RequireArgument(IsValidFolderName(name), "name", "The provided value is reserved");

            m_name = name;
            OnPropertyChanged(new PropertyChangedEventArgs("Name"));
        }

        #region Private Methods

        private void RefreshTaskColors()
        {
            /*
            if (Root.Current != null)
            {
                Root.Current.Tasks.AllTasks
                    .Where(tvm => ContainsTask(tvm.Task))
                    .ForEach(tvm => tvm.UpdateColor());
            }*/
        }

        #endregion Private Methods

        public bool Equals(Folder other)
        {
            return other != null && m_name.Equals(other.m_name) && m_color.Equals(other.m_color);
        }

        public override bool Equals(object obj)
        {
            return Equals(obj as Folder);
        }

        public override int GetHashCode()
        {
            return Util.GetHashCode(m_name, m_color);
        }
    }
}
