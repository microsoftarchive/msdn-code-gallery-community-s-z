//-----------------------------------------------------------------------
// <copyright company="Microsoft Corporation">
//     Copyright (c) Microsoft Corporation.  All rights reserved.
// </copyright>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using Microsoft.Reporting.WebForms;

namespace CustomStrings
{
    /// <summary>
    /// This IReportViewerMessages3 implementation is specified in the project's Web.config file. At run time the ReportViewer control
    /// uses this class for custom UI strings.
    /// </summary>
    public class CustomMessages : IReportViewerMessages3
    {
        public string CalendarLoading
        {
            get { return "Loading calendar..."; }
        }

        public string CancelLinkText
        {
            get { return "Cancel"; }
        }

        public string TotalPages(int pageCount, PageCountMode pageCountMode)
        {
            // For estimate page count, add a "~" before the page count
            string qualifier = (pageCountMode == PageCountMode.Estimate) ? "~" : String.Empty;
            return qualifier + pageCount.ToString(CultureInfo.CurrentCulture);
        }

        public string ClientNoScript
        {
            get { return "This page requires scripting to be enabled in your browser to work properly. Please contact support@example.com for help."; }
        }

        public string ClientPrintControlLoadFailed
        {
            get { return "We are experiencing issues printing your report. Please contact support@example.com for help."; }
        }

        public string CredentialMissingUserNameError(string dataSourcePrompt)
        {
            return "The data source credentials '" + dataSourcePrompt + "' is missing the user name.";
        }

        public string GetLocalizedNameForRenderingExtension(string format)
        {
            return "Export to " + format;
        }

        public string ParameterDropDownToolTip
        {
            get { return "Please select from one of the options."; }
        }

        public string ParameterMissingSelectionError(string parameterPrompt)
        {
            return "You have not yet selected a value in the '" + parameterPrompt + "' parameter.";
        }

        public string ParameterMissingValueError(string parameterPrompt)
        {
            return "You have not yet specified a value for the '" + parameterPrompt + "' parameter.";
        }

        public string BackButtonToolTip
        {
            get { return "Go back to the parent report of the current drillthough report."; }
        }

        public string ChangeCredentialsText
        {
            get { return "Change My Credentials"; }
        }

        public string ChangeCredentialsToolTip
        {
            get { return "Change your data source credentials here"; }
        }

        public string CurrentPageTextBoxToolTip
        {
            get { return "Specify a page number and press ENTER to go to that page."; }
        }

        public string DocumentMap
        {
            get { return "Bookmarks"; }
        }

        public string DocumentMapButtonToolTip
        {
            get { return "Click to collapse or show the bookmarks area."; }
        }

        public string ExportButtonText
        {
            get { return String.Empty; }
        }

        public string ExportButtonToolTip
        {
            get { return "Click to export this report to your preferred format."; }
        }

        public string ExportFormatsToolTip
        {
            get { return "Select an export format from the dropdown list"; }
        }

        public string FalseValueText
        {
            get { return "No"; }
        }

        public string FindButtonText
        {
            get { return "Start Search"; }
        }

        public string FindButtonToolTip
        {
            get { return "Click to start searching the report for the specified string, beginning with the current page."; }
        }

        public string FindNextButtonText
        {
            get { return "Next Hit"; }
        }

        public string FindNextButtonToolTip
        {
            get { return "Click to find the next search hit in the report"; }
        }

        public string FirstPageButtonToolTip
        {
            get { return "Go to the first page"; }
        }

        public string InvalidPageNumber
        {
            get { return "Please enter a valid page number."; }
        }

        public string LastPageButtonToolTip
        {
            get { return "Go to the last page"; }
        }

        public string NextPageButtonToolTip
        {
            get { return "Go to the next page"; }
        }

        public string NoMoreMatches
        {
            get { return "Search has reached the end of the report."; }
        }

        public string NullCheckBoxText
        {
            get { return "Use null value"; }
        }

        public string NullValueText
        {
            get { return "Use null value"; }
        }

        public string PageOf
        {
            get { return "/"; }
        }

        public string ParameterAreaButtonToolTip
        {
            get { return "Click to collapse or show the parameter prompt area"; }
        }

        public string PasswordPrompt
        {
            get { return "Password:"; }
        }

        public string PreviousPageButtonToolTip
        {
            get { return "Go to the previous page"; }
        }

        public string PrintButtonToolTip
        {
            get { return "Print your report to a local printer"; }
        }

        public string ProgressText
        {
            get { return "On moment please..."; }
        }

        public string RefreshButtonToolTip
        {
            get { return "Refresh your report with new data"; }
        }

        public string SearchTextBoxToolTip
        {
            get { return "Type the string you want to search for"; }
        }

        public string SelectAValue
        {
            get { return "Select a value from the list"; }
        }

        public string SelectAll
        {
            get { return "Select all values in list"; }
        }

        public string SelectFormat
        {
            get { return "Select an export format"; }
        }

        public string TextNotFound
        {
            get { return "The string you specified is not found in your report."; }
        }

        public string TodayIs
        {
            get { return String.Empty; }
        }

        public string TrueValueText
        {
            get { return "Yes"; }
        }

        public string UserNamePrompt
        {
            get { return "User Name:"; }
        }

        public string ViewReportButtonText
        {
            get { return "View My Report"; }
        }

        public string ZoomControlToolTip
        {
            get { return "Select a zoom level for the report area"; }
        }

        public string ZoomToPageWidth
        {
            get { return "Show page with"; }
        }

        public string ZoomToWholePage
        {
            get { return "Show entire page"; }
        }
    }
}