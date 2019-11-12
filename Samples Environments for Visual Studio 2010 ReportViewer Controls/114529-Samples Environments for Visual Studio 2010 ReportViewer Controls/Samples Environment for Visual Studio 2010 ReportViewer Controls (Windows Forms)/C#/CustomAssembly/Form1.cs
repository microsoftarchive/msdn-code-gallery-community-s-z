//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Net;
using System.Security;
using System.Security.Permissions;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;

namespace CustomAssembly
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // The Build Action property of ReportWithCustomAssembly.rdlc is set to "None" instead of "Embedded Resource" in
            // order to avoid build errors while attempting to load the MyLibrary.dll assembly, so specify the report path here. 
            // In the ReportViewer Tasks smart tag, the ReportViewer adds a report as an embedded resource, so we need to manually 
            // set the report path instead since it is no longer an enbedded resource.
            ReportViewer1.LocalReport.ReportPath = @"..\..\ReportWithCustomAssembly.rdlc";
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string filePath = System.IO.Path.GetFullPath(@"..\..\ContentFile.txt");
            string pageUrl = @"http://www.microsoft.com/en/us/default.aspx?redir=true";

            // Create a byte array representing the public key token for MyLibrary.dll
            byte[] publicKey = new byte[8] { 0x8c, 0x2c, 0x20, 0x92, 0xee, 0xa1, 0xf1, 0xab };

            // Create a strong name object for MyLibrary.dll. This assembly is built by the MyLibrary project and can 
            // be found in the <solution_root>\MyLibrary\bin\Debug directory.
            System.Security.Policy.StrongName sn = new System.Security.Policy.StrongName(
                new System.Security.Permissions.StrongNamePublicKeyBlob(publicKey),
                "MyLibrary",
                new Version("1.0.0.0"));

            // Add MyLibrary to the list of assemblies that are trusted to execute in the sandboxed application domain
            ReportViewer1.LocalReport.AddFullTrustModuleInSandboxAppDomain(sn);

            PermissionSet permissions = new PermissionSet(PermissionState.None);
            //// Need Execution permission to execute expressions in the report and any referenced custom assembly. This 
            //// is the default permission.
            permissions.AddPermission(new SecurityPermission(SecurityPermissionFlag.Execution));
            //// Need FileIOPermission for the referenced assembly to read the file
            permissions.AddPermission(new FileIOPermission(FileIOPermissionAccess.Read, filePath));
            //// Need WebPermission to execute Web requests
            permissions.AddPermission(new WebPermission(PermissionState.Unrestricted));

            // Set the permissions
            ReportViewer1.LocalReport.SetBasePermissionsForSandboxAppDomain(permissions);

            // Set the file path and URL that will be accessed by the report
            List<ReportParameter> parameters = new List<ReportParameter>();
            parameters.Add(new ReportParameter("FilePath", filePath));
            parameters.Add(new ReportParameter("PageUrl", pageUrl));
            ReportViewer1.LocalReport.SetParameters(parameters);

            this.ReportViewer1.RefreshReport();
        }
    }
}
