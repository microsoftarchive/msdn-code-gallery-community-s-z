//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.IO;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Xml;

namespace Home
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Note: This page is used to link to all samples contained in the solution

            // Generate links and descriptions for the samples
            foreach (string dir in Directory.GetDirectories(String.Format("{0}..", Server.MapPath("/"))))
            {
                string name = new DirectoryInfo(dir).Name;

                if (name == "MyLibrary" || name == "Home")
                    continue;

                HyperLink link = null;
                HtmlGenericControl p = null;

                try 
                {
                    link = new HyperLink();
                    link.Text = name;
                    XmlDocument projxml = new XmlDocument();
                    projxml.Load(String.Format(@"{0}\{1}.csproj", dir, name));
                    link.NavigateUrl = String.Format("http://localhost:{0}", projxml.GetElementsByTagName("DevelopmentServerPort")[0].InnerText);
                    PlaceholderLinks.Controls.Add(link);

                    string description = String.Empty;

                    switch (name)
                    {
                        case "AjaxControls":
                            description = "AJAX Sample: Demonstrates how to use the ReportViewer control with other AJAX controls. This sample requires the AdventureWorks 2008 Sample Reports.";
                            break;
                        case "CredentialsNoSession":
                            description = "Demonstrates how to prevent the report server connection information from being stored in the ASP.NET session. This sample requires the AdventureWorks 2008 Sample Reports.";
                            break;
                        case "CustomAssembly":
                            description = "Demonstrates how to use custom assemblies with your RDLC report.";
                            break;
                        case "CustomSkin":
                            description = "Demonstrates how to change the skin of the ReportViewer control. This sample requires the AdventureWorks 2008 Sample Reports.";
                            break;
                        case "CustomStrings":
                            description = "Demonstrates how to use custom UI strings in the ReportViewer control. This sample requires the AdventureWorks 2008 Sample Reports.";
                            break;
                        case "CustomToolBar":
                            description = "AJAX Sample: Demonstrates how to use the client-side APIs to implement a custom toolbar for the ReportViewer control. This sample requires the AdventureWorks 2008 Sample Reports.";
                            break;
                        case "MapAndPrompt":
                            description = "AJAX Sample: Demonstrates how to change the collapsed state of the document map and parameter prompt area without causing a postback. This sample requires the AdventureWorks 2008 Sample Reports.";
                            break;
                        case "PopupDrillthrough":
                            description = "AJAX Sample: Demonstrates how to cause a ReportViewer control to open an AJAX popup when a drillthrough report is clicked. This sample requires the AdventureWorks 2008 Sample Reports.";
                            break;
                        case "RenderingAndPostBack":
                            description = "Demonstrates the rendering and postback behaviors of the ReportViewer control. This sample requires the AdventureWorks 2008 Sample Reports.";
                            break;
                        case "ReportFromStream":
                            description = "Demonstrates how to load an RDLC report from a stream.";
                            break;
                        case "ResettingScrollPosition":
                            description = "AJAX Sample: Demonstrates how to programmatically set the report area scroll position without causing a postback. This sample requires the AdventureWorks 2008 Sample Reports.";
                            break;
                        case "ResizingViewer":
                            description = "AJAX Sample: Demonstrates how to recalculate the ReportViewer layout when its container changes size. This sample requires the AdventureWorks 2008 Sample Reports.";
                            break;
                        case "SupplyingData":
                            description = "Demonstrates how to supply data to an RDLC report, as well as any subreport or drillthrough report. It also demonstrates how to change the RDLC report at run time.";
                            break;
                        case "SupplyingParameters":
                            description = "Demonstrates how to supply parameters to a server report. This sample requires the AdventureWorks 2008 Sample Reports.";
                            break;
                        default:
                            break;
                    }

                    p = new HtmlGenericControl("p");
                    p.InnerText = description;
                    PlaceholderLinks.Controls.Add(p);
                }
                finally 
                {
                    link.Dispose();
                    p.Dispose();
                }
            }
        }
    }
}