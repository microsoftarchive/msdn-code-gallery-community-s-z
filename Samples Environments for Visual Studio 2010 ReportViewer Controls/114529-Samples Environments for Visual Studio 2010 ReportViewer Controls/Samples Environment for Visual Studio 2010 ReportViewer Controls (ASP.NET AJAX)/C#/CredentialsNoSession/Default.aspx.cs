//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Net;
using System.Security.Principal;
using Microsoft.Reporting.WebForms;

namespace CredentialsNoSession
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ReportViewer1.ProcessingMode = ProcessingMode.Remote;

                // Get report path from configuration file.
                // ReportViewer1.ServerReport.ReportServerUrl is set by the MyReportServerConnection class.
                ReportViewer1.ServerReport.ReportPath = String.Format("{0}/{1}{2}",
                    ConfigurationManager.AppSettings["SampleReportsPath"],                                           // folder or site path
                    "Employee Sales Summary 2008",                                                                   // report name
                    (ConfigurationManager.AppSettings["ReportServerMode"] == "SharePoint" ? ".rdl" : String.Empty)); // extension, depending on the report server mode
                                                                                                                     // (for information on the report path format, 
                                                                                                                     // see http://msdn.microsoft.com/en-us/library/ms252075.aspx)
            }
        }
    }

    /// <summary>
    /// This IReportServerConnection2 implementation is specified in the project's Web.config file. At run time, the ReportViewer control uses
    /// the connection information specified in this class instead of the controls' public properties, and does not store the information
    /// in the ASP.NET session.
    /// </summary>
    [Serializable]
    public sealed class MyReportServerConnection : IReportServerConnection2
    {
        public WindowsIdentity ImpersonationUser
        {
            get
            {
                // Use the default Windows user.  Credentials will be
                // provided by the NetworkCredentials property.
                return null;
            }
        }

        public ICredentials NetworkCredentials
        {
            get
            {
                // Read the user information from the web.config file. By reading the information on demand instead of 
                // storing it, the credentials will not be stored in session, reducing the vulnerable surface area to the
                // web.config file, which can be secured with an ACL.

                // User name
                string userName = ConfigurationManager.AppSettings["MyReportViewerUser"];

                if (string.IsNullOrEmpty(userName))
                    throw new InvalidOperationException("Please specify the user name in the project's Web.config file.");

                // Password
                string password = ConfigurationManager.AppSettings["MyReportViewerPassword"];

                if (string.IsNullOrEmpty(password))
                    throw new InvalidOperationException("Please specify the password in the project's Web.config file");

                // Domain
                string domain = ConfigurationManager.AppSettings["MyReportViewerDomain"];

                if (string.IsNullOrEmpty(domain))
                    throw new InvalidOperationException("Please specify the domain in the project's Web.config file");

                return new NetworkCredential(userName, password, domain);
            }
        }

        public bool GetFormsCredentials(out Cookie authCookie, out string userName, out string password, out string authority)
        {
            authCookie = null;
            userName = null;
            password = null;
            authority = null;

            // Not using form credentials
            return false;
        }

        public Uri ReportServerUrl
        {
            get
            {
                string url = ConfigurationManager.AppSettings["MyReportServerUrl"];

                if (string.IsNullOrEmpty(url))
                    throw new InvalidOperationException("Please specify the report server URL in the project's Web.config file");

                return new Uri(url);
            }
        }

        public int Timeout
        {
            get
            {
                return 60000; // 60 seconds
            }
        }

        public IEnumerable<Cookie> Cookies
        {
            get
            {
                // No custom cookies
                return null;
            }
        }

        public IEnumerable<string> Headers
        {
            get
            {
                // No custom headers
                return null;
            }
        }
    }
}