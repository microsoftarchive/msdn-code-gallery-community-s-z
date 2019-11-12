using System;
using System.Reflection;
using System.Text;

namespace Cubisoft.Winrt.Ftp
{
    public class FtpItem
    {
        FtpFileSystemObjectType m_Type = FtpFileSystemObjectType.File;

        string m_Path;

        string m_Name;

        DateTime m_Modified = DateTime.MinValue;
        
        DateTime m_Created = DateTime.MinValue;

        long m_Size = -1;
        
        FtpSpecialPermissions m_SpecialPermissions = FtpSpecialPermissions.None;
        
        FtpPermission m_OwnerPermissions = FtpPermission.None;
        
        FtpPermission m_GroupPermissions = FtpPermission.None;

        FtpPermission m_OtherPermissions = FtpPermission.None;

        string m_Input;

        /// <summary>
        /// Gets the type of file system object. This property can be
        /// set however this functionality is intended to be done by
        /// custom parsers.
        /// </summary>
        public FtpFileSystemObjectType Type
        {
            get
            {
                return m_Type;
            }
            set
            {
                m_Type = value;
            }
        }

        /// <summary>
        /// Gets the full path name to the object. This property can be
        /// set however this functionality is intended to be done by
        /// custom parsers.
        /// </summary>
        public string FullName
        {
            get
            {
                return m_Path;
            }
            set
            {
                m_Path = value;
            }
        }
        
        /// <summary>
        /// Gets the name of the object. This property can be
        /// set however this functionality is intended to be done by
        /// custom parsers.
        /// </summary>
        public string Name
        {
            get
            {
                if (m_Name == null && m_Path != null)
                    return m_Path.GetFtpFileName();
                return m_Name;
            }
            set
            {
                m_Name = value;
            }
        }
        
        /// <summary>
        /// Gets the last write time of the object. This property can be
        /// set however this functionality is intended to be done by
        /// custom parsers.
        /// </summary>
        public DateTime Modified
        {
            get
            {
                return m_Modified;
            }
            set
            {
                m_Modified = value;
            }
        }
        
        /// <summary>
        /// Gets the created date of the object. This property can be
        /// set however this functionality is intended to be done by
        /// custom parsers.
        /// </summary>
        public DateTime Created
        {
            get
            {
                return m_Created;
            }
            set
            {
                m_Created = value;
            }
        }
        
        /// <summary>
        /// Gets the size of the object. This property can be
        /// set however this functionality is intended to be done by
        /// custom parsers.
        /// </summary>
        public long Size
        {
            get
            {
                return m_Size;
            }
            set
            {
                m_Size = value;
            }
        }
        
        /// <summary>
        /// Gets special UNIX permissions such as Stiky, SUID and SGID. This property can be
        /// set however this functionality is intended to be done by
        /// custom parsers.
        /// </summary>
        public FtpSpecialPermissions SpecialPermissions
        {
            get
            {
                return m_SpecialPermissions;
            }
            set
            {
                m_SpecialPermissions = value;
            }
        }
        
        /// <summary>
        /// Gets the owner permissions. This property can be
        /// set however this functionality is intended to be done by
        /// custom parsers.
        /// </summary>
        public FtpPermission OwnerPermissions
        {
            get
            {
                return m_OwnerPermissions;
            }
            set
            {
                m_OwnerPermissions = value;
            }
        }
   
        /// <summary>
        /// Gets the group permissions. This property can be
        /// set however this functionality is intended to be done by
        /// custom parsers.
        /// </summary>
        public FtpPermission GroupPermissions
        {
            get
            {
                return m_GroupPermissions;
            }
            set
            {
                m_GroupPermissions = value;
            }
        }

        /// <summary>
        /// Gets the others permissions. This property can be
        /// set however this functionality is intended to be done by
        /// custom parsers.
        /// </summary>
        public FtpPermission OthersPermissions
        {
            get
            {
                return m_OtherPermissions;
            }
            set
            {
                m_OtherPermissions = value;
            }
        }

        /// <summary>
        /// Gets the input string that was parsed to generate the
        /// values in this object. This property can be
        /// set however this functionality is intended to be done by
        /// custom parsers.
        /// </summary>
        public string Input
        {
            get
            {
                return m_Input;
            }
            private set
            {
                m_Input = value;
            }
        }

        /// <summary>
        /// Returns a string representation of this object and its properties
        /// </summary>
        /// <returns>A string value</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (PropertyInfo p in GetType().GetRuntimeProperties())
            {
                sb.AppendLine(string.Format("{0}: {1}", p.Name, p.GetValue(this, null)));
            }

            return sb.ToString();
        }
    }
}
