//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Configuration;
using Microsoft.Reporting.WebForms;

namespace RenderingAndPostBack
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // The following line displays the timestamp in the page on page load and whenever a synchronous postback occurs in order to
            // illustrate the different postback behavior of the ReportViewer control based on the value of ReportViewer.InteractivityPostBackMode.
            LabelTime.Text = DateTime.Now.ToString();

            if (!IsPostBack)
            {
                // Get report path from configuration file
                ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"]);
                ReportViewer1.ServerReport.ReportPath = String.Format("{0}/{1}{2}",
                    ConfigurationManager.AppSettings["SampleReportsPath"],                                           // folder or site path
                    "Employee Sales Summary 2008",                                                                   // report name
                    (ConfigurationManager.AppSettings["ReportServerMode"] == "SharePoint" ? ".rdl" : String.Empty)); // extension, depending on the report server mode
                                                                                                                     // (for information on the report path format, 
                                                                                                                     // see http://msdn.microsoft.com/en-us/library/ms252075.aspx)

                // Use the "async" parameter to initialize the ReportViewer.AsyncRendering property to show the property effect when the page
                // is first loaded. See RadioButtonListAsyncRendering_SelectedIndexChanged for more information.
                string asyncparam = Request.QueryString.Get("async");
                if (asyncparam != null)
                {
                    try 
                    { 
                        ReportViewer1.AsyncRendering = Convert.ToBoolean(Request.QueryString.Get("async")); 
                    }
                    catch (FormatException) 
                    { 
                    }
                }

                // Initialize the radio buttons
                RadioButtonListAsyncRendering.SelectedIndex = ReportViewer1.AsyncRendering ? 0 : 1;
                switch (ReportViewer1.InteractivityPostBackMode)
                {
                    case InteractivityPostBackMode.AlwaysAsynchronous:
                        RadioButtonListInteractivityPostBackMode.SelectedIndex = 0;
                        break;
                    case InteractivityPostBackMode.AlwaysSynchronous:
                        RadioButtonListInteractivityPostBackMode.SelectedIndex = 1;
                        break;
                    default:
                        RadioButtonListInteractivityPostBackMode.SelectedIndex = 2;
                        break;
                }
            }
        }

        protected void RadioButtonListAsyncRendering_SelectedIndexChanged(object sender, EventArgs e)
        {
            // The ReportViewer.AsyncRendering property has an effect only when the page is first loaded, so 
            // terminate the current page and start a new instance of the page by passing in an "async" parameter
            // to help initialize the ReportViewer.AsyncRendering property accordingly.
            Response.Redirect(String.Format("{0}?async={1}", Request.Path, RadioButtonListAsyncRendering.SelectedValue), true);
        }

        protected void RadioButtonListInteractivityPostBackMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Set the ReportViewer1.InteractivityPostBackMode property per user selection
            ReportViewer1.InteractivityPostBackMode = (InteractivityPostBackMode)System.Enum.Parse(
                typeof(InteractivityPostBackMode), RadioButtonListInteractivityPostBackMode.SelectedValue, true);
        }
    }
}