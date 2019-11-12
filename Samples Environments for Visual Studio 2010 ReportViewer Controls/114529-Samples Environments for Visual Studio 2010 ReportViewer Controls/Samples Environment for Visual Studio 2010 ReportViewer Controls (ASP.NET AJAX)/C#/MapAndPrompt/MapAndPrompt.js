var viewerID = "ReportViewer1";

/*
Toggle the collapsed state of the document map in the client-side viewer
*/
function toggleDocMap() {
    var viewer = $find(viewerID);

    // Check the isLoading client-side property before accessing the documentMapCollapsed property.
    // Otherwise an exception will be thrown.
    if (!viewer.get_isLoading()) {
        viewer.set_documentMapCollapsed(!viewer.get_documentMapCollapsed());
    }
}

/*
Toggle the collapsed state of the prompt area in the client-side viewer
*/
function togglePrompt() {
    var viewer = $find(viewerID);

    // Check the isLoading client-side property before accessing the promptAreaCollapsed property.
    // Otherwise an exception will be thrown.
    if (!viewer.get_isLoading()) {
        viewer.set_promptAreaCollapsed(!viewer.get_promptAreaCollapsed());
    }
}