// Hard-code the viewer's client-side ID here. Note that this approach does not allow the viewer toolbar to be used on multiple ReportViewer
// controls at the same time.
var viewerID = "ReportViewer1";

var isRunOnce = false;
var toolBarDisabled;

/// <summary>
/// When the page is first loaded, subscribe to the ReportViewer's property change events, and initialize the disabled toolbar state
///
/// Note: In most cases, the Sys.Application.load event is the right place to register the propertyChanged event for the client-side ReportViewer
/// control, but some client-side properties can change in other Sys.Application.load event handlers (the reportAreaScrollPosition property, for
/// example). In these cases, changes to the property of your interest may not raise the event for your handler simply because the handler is 
/// registered after the property change occurs. While this is typically not an issue, you can use the Sys.Application.init event instead if needed.
/// However, to use the Sys.Application.init event instead requires you to exercise care in placing the add_init handler code after the client-side 
/// ReportViewer is created. In such cases, you cannot take advantage of script references in your ScriptManager object because it causes your 
/// script to be executed before the initialization code for the client-side ReportViewer, hence $find(viewerID) will return NULL.
/// </summary>
Sys.Application.add_load(pageLoadHandler);

function pageLoadHandler() {
    if (!isRunOnce) {
        $find(viewerID).add_propertyChanged(viewerPropertyChanged);
        toolBarDisabled = Sys.Serialization.JavaScriptSerializer.deserialize($get("ToolBarSerializedState").value);
        isRunOnce = true;
    }
}

/// <summary>
/// Handler for the ReportViewer.propertyChanged event. It is used to enable and disable the custom toolbar buttons based on the status of the 
/// ReportViewer. This handler is hooked up wherever a toolbar action requires an asynchronous postback.
/// </summary>
function viewerPropertyChanged(sender, e) {
    var viewer = $find(viewerID);

    if (e.get_propertyName() === "isLoading") {
        if (viewer.get_isLoading()) {
            // ReportViewer started loading report. Disable the toolbar.
            updateToolBarState(toolBarDisabled);
        }
        else if (viewer.get_reportAreaContentType() != Microsoft.Reporting.WebFormsClient.ReportAreaContent.None) {
            // ReportViewer stopped loading report. Restore the toolbar state from the hidden field.
            updateToolBarState(Sys.Serialization.JavaScriptSerializer.deserialize($get("ToolBarSerializedState").value));
        }
    }
    // Check the isLoading client-side property before using the reportAreaContentType property.
    // Otherwise an exception will be thrown.
    else if (e.get_propertyName() === "reportAreaContentType") {
        if (!viewer.get_isLoading()) {
            if (viewer.get_reportAreaContentType() != Microsoft.Reporting.WebFormsClient.ReportAreaContent.None) {
                // ReportViewer finished loading report. Deserialize the toolbar state from the hidden field and update the toolbar state.
                updateToolBarState( Sys.Serialization.JavaScriptSerializer.deserialize($get("ToolBarSerializedState").value) );
            }
        }
    }
}

/// <summary>
/// Helper method to update the toolbar state
/// </summary>
function updateToolBarState(state) {
    var viewer = $find(viewerID);

    // Set navigation controls
    $get("ButtonFirstPage").className = state.IsButtonFirstPageEnabled ? "ToolBarImageVisible" : "ToolBarImageHidden";
    $get("ButtonFirstPageDisabled").className = state.IsButtonFirstPageEnabled ? "ToolBarImageHidden" : "ToolBarImageVisible";
    $get("ButtonPreviousPage").className = state.IsButtonPreviousPageEnabled ? "ToolBarImageVisible" : "ToolBarImageHidden";
    $get("ButtonPreviousPageDisabled").className = state.IsButtonPreviousPageEnabled ? "ToolBarImageHidden" : "ToolBarImageVisible";
    $get("ButtonNextPage").className = state.IsButtonNextPageEnabled ? "ToolBarImageVisible" : "ToolBarImageHidden";
    $get("ButtonNextPageDisabled").className = state.IsButtonNextPageEnabled ? "ToolBarImageHidden" : "ToolBarImageVisible";
    $get("ButtonLastPage").className = state.IsButtonLastPageEnabled ? "ToolBarImageVisible" : "ToolBarImageHidden";
    $get("ButtonLastPageDisabled").className = state.IsButtonLastPageEnabled ? "ToolBarImageHidden" : "ToolBarImageVisible";
    $get("ButtonBackToParent").className = state.IsButtonBackToParentEnabled ? "ToolBarImageVisible" : "ToolBarImageHidden";
    $get("ButtonBackToParentDisabled").className = state.IsButtonBackToParentEnabled ? "ToolBarImageHidden" : "ToolBarImageVisible";

    // Set find controls
    $get("TextBoxFindString").value = state.FindString;
    $get("ButtonFind").disabled = state.IsButtonFindEnabled ? false : true;
    if (state.IsButtonFindEnabled) {
        $addHandler($get("ButtonFind"), "click", function () { return findString($get('TextBoxFindString').value); });
    }
    $get("ButtonNext").disabled = state.IsButtonNextEnabled ? false : true;
    if (state.IsButtonNextEnabled) {
        $addHandler($get("ButtonNext"), "click", function () { return findNext(); });
    }

    // Toggle textboxes and dropdown lists
    $get("TextBoxPageNumber").disabled = viewer.get_isLoading();
    $get("DropDownListZoom").disabled = viewer.get_isLoading();
    $get("TextBoxFindString").disabled = viewer.get_isLoading();
    $get("DropDownListExport").disabled = viewer.get_isLoading();
    if (!viewer.get_isLoading()) {
        // Change the TextBoxPageNumber value only when on page update, so that we don't cause an extra postback due to the page number being changed.
        $get("TextBoxPageNumber").value = state.PageNumberString;

        $addHandler($get("TextBoxPageNumber"), "keypress", function () { return inspectTextBoxPageNumberKey(event); });
        $addHandler($get("TextBoxFindString"), "keyup", function () { return setFindButton(event); });
        $addHandler($get("DropDownListZoom"), "change", function () { return rezoom(); });
        $addHandler($get("DropDownListExport"), "change", function () { return exportReport(); });
    }

    // Set refresh button
    $get("ButtonRefresh").className = state.IsButtonRefreshEnabled ? "ToolBarImageVisible" : "ToolBarImageHidden";
    $get("ButtonRefreshDisabled").className = state.IsButtonRefreshEnabled ? "ToolBarImageHidden" : "ToolBarImageVisible";
    if (state.IsButtonRefreshEnabled) {
        $addHandler($get("ButtonRefresh"), "click", function () { return refresh(); });
    }

    // Set print button
    $get("ButtonPrint").className = state.IsButtonPrintEnabled ? "ToolBarImageVisible" : "ToolBarImageHidden";
    $get("ButtonPrintDisabled").className = state.IsButtonPrintEnabled ? "ToolBarImageHidden" : "ToolBarImageVisible";
    if (state.IsButtonPrintEnabled) {
        $addHandler($get("ButtonPrint"), "click", function () { return printDialog(); });
    }
}

/// <summary>
/// Changes the zoom level of the report area using the client-side ReportViewer.zoomLevel property.
/// </summary>
function rezoom() {
    var dropdown = $get("DropDownListZoom");
    var level = dropdown.options[dropdown.selectedIndex].value;
    var viewer = $find(viewerID);
    // Double-check the isLoading client-side property is disabled before using the zoomLevel property. Otherwise an exception will be thrown.
    // In this method, isLoading should already be disabled, since the dropdown list itself wouldn't have been enabled otherwise.
    if (!viewer.get_isLoading() && viewer.get_zoomLevel() != level)
        viewer.set_zoomLevel(level);

    return false;
}

/// <summary>
/// Toggle the ButtonFind button depending on whether TextBoxFindString has value. If the key entered is ENTER, start searching for the string.
/// </summary>
function setFindButton(e) {
    // Key code for the ENTER key is 13.
    if (e.keyCode === 13 || e.which === 13) {
        findString($get("TextBoxFindString").value);
    }
    else {
        findbutton = $get("ButtonFind");
        if (findString.length > 0) {
            findbutton.disabled = false;
            $addHandler($get("ButtonFind"), "click", function () { return findString($get('TextBoxFindString').value); });
        }
        else {
            $get("ButtonFind").disabled = true;
            $clearHandlers($get("ButtonFind"));
        }
    }

    return false;
}

/// <summary>
/// Find the search string using the client-side ReportViewer.find() method.
/// </summary>
function findString(value) {
    var viewer = $find(viewerID);
    // Double-check the isLoading client-side property is disabled before using the find() method. Otherwise an exception will be thrown.
    // In this method, isLoading should already be disabled, since the find link itself wouldn't have been enabled otherwise.
    if (!viewer.get_isLoading())
        viewer.find(value);

    return false;
}

/// <summary>
/// Find the next search using the client-side ReportViewer.findNext() method.
/// </summary>
function findNext() {
    var viewer = $find(viewerID);
    // Double-check the isLoading client-side property is disabled before using the findNext() method. Otherwise an exception will be thrown.
    // In this method, isLoading should already be disabled, since the find next link itself wouldn't have been enabled otherwise.
    if (!viewer.get_isLoading())
        viewer.findNext();

    return false;
}

/// <summary>
/// Refresh the report using the client-side ReportViewer.refreshReport() method.
/// </summary>
function refresh() {
    var viewer = $find(viewerID);
    // Double-check the isLoading client-side property is disabled before using the refreshReport() method. Otherwise an exception will be thrown.
    // In this method, isLoading should already be disabled, since the refresh button itself wouldn't have been enabled otherwise.
    if (!viewer.get_isLoading())
        viewer.refreshReport();

    return false;
}

/// <summary>
/// Launch the ActiveX print dialog using the client-side ReportViewer.invokePrintDialog() method.
/// </summary>
function printDialog() {
    var viewer = $find(viewerID);
    // Double-check the isLoading client-side property is disabled before using the invokePrintDialog() method. Otherwise an exception will be thrown.
    // In this method, isLoading should already be disabled, since the print button itself wouldn't have been enabled otherwise.
    if (!viewer.get_isLoading()) {
        viewer.invokePrintDialog();
    }

    return false;
}

/// <summary>
/// Export the report using the client-side ReportViewer.exportReport() method.
/// </summary>
function exportReport() {
    var dropdown = $get("DropDownListExport");
    var format = dropdown.options[dropdown.selectedIndex].value;
    var viewer = $find(viewerID);
    // Double-check the isLoading client-side property before using the exportReport() method. Otherwise an exception will be thrown.
    // In this method, isLoading should already be disabled, since the dropdown list itself wouldn't have been enabled otherwise.
    if (!viewer.get_isLoading()) {
        viewer.exportReport(format);
    }

    return false;
}

/// <summary>
/// This method determines when to postback to the server for the TextBoxPageNumber control. The server-side TextBoxPageNumber_TextChanged handler will discard all other TextChanged
/// events except for the postback caused by this method.
/// </summary>
function inspectTextBoxPageNumberKey(e) {
    if (e.keyCode === 13 || e.which === 13) {
        __doPostBack("TextBoxPageNumber", "");
    }
}
