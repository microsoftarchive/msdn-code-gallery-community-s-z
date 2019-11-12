//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Configuration;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace CustomToolBar
{
    public partial class Default : System.Web.UI.Page
    {
        /// <summary>
        /// Define the report to use in Page_Init. The ReportViewer uses view state to persist its data, you should use Page_Init instead of Page_Load to specify 
        /// ReportViewer properties that are constant for the life of the page. Since Page_Load occurs after the view state is loaded, setting the report parameters,
        /// for example, in Page_Load can cause the ReportViewer control to treat the specified data as newer than the one in the view state and re-process the report. 
        /// You can also avoid this in Page_Load by specifying ReportViewer data in an if(!IsPostBack){} block.
        /// </summary>
        protected void Page_Init(object sender, EventArgs e)
        {
            ReportViewer1.ProcessingMode = ProcessingMode.Remote;

            // Get report path from configuration file
            ReportViewer1.ServerReport.ReportServerUrl = new Uri(ConfigurationManager.AppSettings["ReportServerUrl"]);
            ReportViewer1.ServerReport.ReportPath = String.Format("{0}/{1}{2}",
                ConfigurationManager.AppSettings["SampleReportsPath"],                                           // folder or site path
                "Employee Sales Summary 2008",                                                                   // report name
                (ConfigurationManager.AppSettings["ReportServerMode"] == "SharePoint" ? ".rdl" : String.Empty)); // extension, depending on the report server mode
                                                                                                                 // (for information on the report path format, 
                                                                                                                 // see http://msdn.microsoft.com/en-us/library/ms252075.aspx)

            // Set export options for the report. In this example, since a static report is displayed, so the export options are always the same. The options should
            // be repopulated if the report is dynamically changed in your page.
            RenderingExtension[] extensions = ReportViewer1.ServerReport.ListRenderingExtensions();
            foreach (RenderingExtension extension in extensions)
            {
                // Remove the non-visible rendering formats from the drop-down list.
                if(extension.Visible)
                    DropDownListExport.Items.Add(new ListItem(extension.LocalizedName, extension.Name));
            }

            // Use the RegisterPostBackControl() method to register the custom toolbar items with the ReportViewer control,
            // so that actions on these items can cause the wait control to be displayed.
            ReportViewer1.RegisterPostBackControl(ButtonFirstPage);
            ReportViewer1.RegisterPostBackControl(ButtonPreviousPage);
            ReportViewer1.RegisterPostBackControl(TextBoxPageNumber);
            ReportViewer1.RegisterPostBackControl(ButtonNextPage);
            ReportViewer1.RegisterPostBackControl(ButtonLastPage);
            ReportViewer1.RegisterPostBackControl(ButtonBackToParent);
            ReportViewer1.RegisterPostBackControl(TextBoxFindString);
            ReportViewer1.RegisterPostBackControl(ButtonFind);
            ReportViewer1.RegisterPostBackControl(ButtonNext);
            ReportViewer1.RegisterPostBackControl(ButtonRefresh);
        }

        /// <summary>
        /// Use the PreRenderComplete event to set the states of the custom toolbar items, since all report processing and rendering is complete in the PreRender 
        /// stage. Note that this update is cached on the client side by the javascript code, so the actual update in the browser doesn't happen immediately when 
        /// the postback page is rendered. Otherwise, the toolbar might be enabled before the report actually finishes loading.
        /// </summary>
        protected void Page_PreRenderComplete(object sender, EventArgs e)
        {
            // Serialize the state object to the hidden field. This state object will be accessed by the javascript 
            // updateToolBarState() function.
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            ToolBarSerializedState.Value = serializer.Serialize(GetToolBarState());
        }

        /// <summary>
        /// Called by Page_PreRenderComplete to retrieve the toolbar state that can be serialized and sent to the client side.
        /// </summary>
        /// <returns>An object that contains the toolbar state</returns>
        private ToolBarState GetToolBarState()
        {
            ToolBarState state = new ToolBarState();

            // If the report area contains a report page, it means that a report is successfully
            // processed and rendered. Set the appropriate toolbar items
            if (ReportViewer1.ReportAreaContentType == ReportAreaContent.ReportPage)
            {
                state.PageNumberString = ReportViewer1.CurrentPage.ToString();

                // Set states for first/previous page buttons
                if (ReportViewer1.CurrentPage > 1)
                {
                    state.IsButtonFirstPageEnabled = true;
                    state.IsButtonPreviousPageEnabled = true;
                }

                // Set label for total pages
                PageCountMode mode;
                int totalpages = ReportViewer1.ServerReport.GetTotalPages(out mode);
                LabelTotalPages.Text = String.Format("{0} {1}{2}",
                                                     "of",
                                                     totalpages,
                                                     (mode == PageCountMode.Estimate) ? "?" : String.Empty);

                // Set states for next/last page buttons 
                if (ReportViewer1.CurrentPage < totalpages)
                {
                    state.IsButtonNextPageEnabled = true;
                    state.IsButtonLastPageEnabled = true;
                }

                // Set state of back to parent button
                state.IsButtonBackToParentEnabled = ReportViewer1.ServerReport.IsDrillthroughReport;

                // Set states of Find/Next buttons
                if (ReportViewer1.SearchState == null)
                {
                    // SearchState is null. This can mean one of the following:
                    // - Search was initiated using Find button or pressing Enter on the search text box, but no hits. Disable both buttons and clear the search text box
                    // - Search was continued using Next button but no hits. Disable both buttons and clear the search text box
                    // - Search was not initiated. Will handle it separately to check the search text box.
                    state.FindString = String.Empty;
                }
                else
                {
                    // SearchState is not null. There's an existing search operation.
                    state.IsButtonFindEnabled = true;
                    state.IsButtonNextEnabled = true;
                    state.FindString = ReportViewer1.SearchState.Text;
                }

                // If search was not initiated and search text box has text, enable the Find button.
                state.IsButtonFindEnabled = (state.FindString.Length > 0);

                // Set state of Print button
                state.IsButtonPrintEnabled = true;
            }

            // If the report area contains something (Error or ReportPage), it means that there is a report to process.
            // Set Refresh button state accordingly. Note that if report area content is not None, the only possible states 
            // are ReportPage and Error since in all processing and rendering is complete at this stage of the page life 
            // cycle.
            state.IsButtonRefreshEnabled = (ReportViewer1.ReportAreaContentType != ReportAreaContent.None);

            return state;
        }

        protected void ButtonFirstPage_Click(object sender, ImageClickEventArgs e)
        {
            // Go to the first page
            ReportViewer1.CurrentPage = 1;
        }

        protected void ButtonPreviousPage_Click(object sender, ImageClickEventArgs e)
        {
            // Go to the previous page.
            try 
            { 
                ReportViewer1.CurrentPage -= 1; 
            }
            catch (ArgumentOutOfRangeException) // thrown if integer < 1
            {
                // Show a message box in the browser.
                ScriptManager.RegisterStartupScript(ButtonPreviousPage, this.GetType(), "Page0Requested", @"<script type='text/javascript'>alert('Already at page 1.');</script>", false);
            } 
        }

        /// <summary>
        /// The TextBoxPageNumber control is set to only cause a postback when the user presses the ENTER key. For more information, see the inspectTextBoxPageNumberKey() 
        /// function in CustomToolBar.js. 
        /// </summary>
        protected void TextBoxPageNumber_TextChanged(object sender, EventArgs e)
        {
            // Make sure the the postback is caused by pressing ENTER in the TextBoxPageNumber control before proceeding. This eliminates the cases when the user change the 
            // text without pressing ENTER and interacted with another UI in the page. For more information, see the inspectTextBoxPageNumberKey() function in CustomToolBar.js. 
            if (ScriptManager.GetCurrent(this).AsyncPostBackSourceElementID == "TextBoxPageNumber")
            {
                int result = 0;
                bool error = false;

                // Go to the page number specified in the text box
                try
                {
                    if (Int32.TryParse(TextBoxPageNumber.Text, out result))
                        ReportViewer1.CurrentPage = result;
                    else
                        // Show a message box in the browser.
                        error = true;
                }
                catch (FormatException)             // thrown if input value is not integer
                {
                    error = true;
                }
                catch (ArgumentOutOfRangeException) // thrown if integer < 1
                {
                    error = true;
                }
                catch (InvalidOperationException)   // thrown if integer >= 1 but is not a valid page number
                {
                    error = true;
                }
                finally
                {
                    // In all the above error, restore the text box value in the view state and show a message box in the browser.
                    if (error)
                    {
                        TextBoxPageNumber.Text = ReportViewer1.CurrentPage.ToString();
                        ScriptManager.RegisterStartupScript(TextBoxPageNumber, this.GetType(), "InvalidPage", @"<script type='text/javascript'>alert('Enter a valid page number.');</script>", false);
                    }
                }
            }
        }

        protected void ButtonNextPage_Click(object sender, ImageClickEventArgs e)
        {
            // Go to the next page.
            try 
            { 
                ReportViewer1.CurrentPage++; 
            }
            catch (InvalidOperationException) // thrown if integer >= 1 but is not a valid page number
            {
                // Show a message box in the browser.
                ScriptManager.RegisterStartupScript(ButtonNextPage, this.GetType(), "LastPageRequested", @"<script type='text/javascript'>alert('Already at the last page in the report.');</script>", false);
            }
        }

        protected void ButtonLastPage_Click(object sender, ImageClickEventArgs e)
        {
            int page;
            PageCountMode mode;

            // If PageCountMode is Actual, simply set CurrentPage to GetTotalPages(). But if PageCountMode is Estimate, 
            // set CurrentPage to the MaximumPageCount constant to indicate the last page is requested.
            page = ReportViewer1.ServerReport.GetTotalPages(out mode);

            if (mode == PageCountMode.Estimate)
                page = ReportViewer.MaximumPageCount;

            ReportViewer1.CurrentPage = page;
        }

        protected void ButtonBackToParent_Click(object sender, ImageClickEventArgs e)
        {
            // Go back to the parent report and keep the private report variable consistent.
            ReportViewer1.PerformBack();
        }
    }
}