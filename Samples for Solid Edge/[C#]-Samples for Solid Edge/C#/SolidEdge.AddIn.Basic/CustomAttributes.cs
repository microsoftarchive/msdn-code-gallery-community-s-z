using System;

namespace SolidEdge.AddIn.Basic
{
    /// <summary>
    /// Set AutoConnect DWORD flag. If true, addin be enabled by default.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AddInAutoConnectAttribute
        : System.Attribute
    {
        private bool _autoConnect = true;

        public AddInAutoConnectAttribute()
            : this(true)
        {
        }

        public AddInAutoConnectAttribute(bool autoConnect)
        {
            _autoConnect = autoConnect;
        }

        public bool AutoConnect { get { return _autoConnect; } }
    }

    /// <summary>
    /// Environment Categories the addin is registered to.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class AddInEnvironmentCategoryAttribute
        : System.Attribute
    {
        private Guid _guid = Guid.Empty;

        public AddInEnvironmentCategoryAttribute(string guid)
            : this(new Guid(guid))
        {
        }

        public AddInEnvironmentCategoryAttribute(Guid guid)
        {
            _guid = guid;
        }

        public Guid Guid { get { return _guid; } }
    }

    /// <summary>
    /// Information about the addin.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class AddInInfoAttribute
        : System.Attribute
    {
        private string _title = String.Empty;
        private string _summary = String.Empty;

        public AddInInfoAttribute(string title, string summary)
        {
            _title = title;
            _summary = summary;
        }

        public string Title { get { return _title; } }
        public string Summary { get { return _summary; } }
    }
}
