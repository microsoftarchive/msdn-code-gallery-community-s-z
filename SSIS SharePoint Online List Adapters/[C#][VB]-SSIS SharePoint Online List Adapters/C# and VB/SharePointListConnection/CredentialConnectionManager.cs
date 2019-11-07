using System;
using System.Net;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Text.RegularExpressions;
using Microsoft.SqlServer.Dts.Pipeline;
using Microsoft.SqlServer.Dts.Runtime;
using System.Globalization;
using System.ComponentModel;
[assembly: CLSCompliant(true)]

namespace Microsoft.Samples.SqlServer.SSIS.SharePointListConnectionManager
{
    [DtsConnection(
        ConnectionType = "SPCRED",
        DisplayName = "SharePoint Credential",
        Description = "Connection manager for SharePoint connections",
        UITypeName = "Microsoft.Samples.SqlServer.SSIS.SharePointListConnectionManager.CredentialConnectionManagerUI, SharePointListConnectionManager, Version=1.0.0.0, Culture=neutral,PublicKeyToken=f4b3011e1ece9d47"
    )]
    public sealed class CredentialConnectionManager : ConnectionManagerBase, IDTSComponentPersist
    {
        /// <summary>
        /// Holds the values in our connection string. This class will
        /// not be instantiated.
        /// </summary>
        private class ConnectionStringItemList
        {
            public const string UserName = "UserName";
            public const string Password = "Password";
            public static string[] Items = { UserName, Password};

            private ConnectionStringItemList()
            {
            }
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
        public override bool Equals(object otherObj)
        {
            return base.Equals(otherObj);
        }
        public override Microsoft.SqlServer.Dts.Runtime.DTSProtectionLevel ProtectionLevel
        {
            get
            {
                return base.ProtectionLevel;
            }
            set
            {
                base.ProtectionLevel = value;
            }
        }
        public override object AcquireConnection(object txn)
        {
            NetworkCredential credential = null;
            if (userName.Length > 0)
            {
                if (userName.Contains(@"\"))
                {
                    var userNameElements = userName.Split('\\');
                    if (userNameElements.Length == 2)
                    {
                        credential = new NetworkCredential(userNameElements[1], password, userNameElements[0]);
                    }
                }
                else
                {
                    credential = new NetworkCredential(userName, password);
                }
            }

            if (credential == null)
            {
                credential = CredentialCache.DefaultNetworkCredentials;
            }
            return credential;
        }

        public override void ReleaseConnection(object connection)
        {
            base.ReleaseConnection(connection);
            connection = null;
        }


        #region Properties
        private string userName = String.Empty;
        public string UserName
        {
            get
            {
                return userName;
            }
            set
            {
                userName = value;
            }
        }

        private string password = String.Empty;
        public string Password
        {
            set
            {
                password = value;
            }
        }
        internal string GetPassword()
        {
            return password;
        }
        #endregion

        #region IDTSComponentPersist Members

        #region String Constants
        private const string PERSIST_XML_ELEMENT = "SPConnectionManager";
        private const string PERSIST_XML_PASSWORD = "PassWord";
        private const string PERSIST_XML_SENSITIVE = "Sensitive";
        #endregion

        void IDTSComponentPersist.LoadFromXML(XmlElement rootNode, IDTSInfoEvents infoEvents)
        {
            // Create an root node for the data
            if (rootNode.Name != PERSIST_XML_ELEMENT)
            {
                throw new ArgumentException("Unexpected element");
            }

            // Unpersist the password
            // The SSIS runtime will already have decrypted it for us
            foreach (XmlNode childNode in rootNode.ChildNodes)
            {
                if (childNode.Name == PERSIST_XML_PASSWORD)
                {
                    password = childNode.InnerText;
                }
            }

        }

        void IDTSComponentPersist.SaveToXML(XmlDocument doc, IDTSInfoEvents infoEvents)
        {
            // Create a root node for the data
            XmlElement rootElement = doc.CreateElement(String.Empty, PERSIST_XML_ELEMENT, String.Empty);
            doc.AppendChild(rootElement);

            // Persist the password separately
            if (!String.IsNullOrEmpty(password))
            {
                XmlNode node = doc.CreateNode(XmlNodeType.Element, PERSIST_XML_PASSWORD, String.Empty);
                XmlElement pswdElement = node as XmlElement;
                rootElement.AppendChild(node);

                // Adding the sensitive attribute tells the SSIS runtime that
                // this value should be protected according to the 
                // ProtectionLevel of the package
                pswdElement.InnerText = password;
                XmlAttribute pwAttr = doc.CreateAttribute(PERSIST_XML_SENSITIVE);
                pwAttr.Value = "1";
                pswdElement.Attributes.Append(pwAttr);
            }
        }

        #endregion
    }
}
