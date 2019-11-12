var viewerID = "ReportViewer1";

// Reset the scroll position to the top left of the report.
function resetScroll() {
    var viewer = $find(viewerID);

    // Check the isLoading client-side property before using the reportAreaScrollPosition property.
    // Otherwise an exception will be thrown.
    if (!viewer.get_isLoading()) {
        viewer.set_reportAreaScrollPosition(new Sys.UI.Point(0,0));
    }
}

