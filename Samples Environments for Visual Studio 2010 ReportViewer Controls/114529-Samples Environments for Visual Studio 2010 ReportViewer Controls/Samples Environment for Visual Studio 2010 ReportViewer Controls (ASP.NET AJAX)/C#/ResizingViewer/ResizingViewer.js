var viewerID = "ReportViewer1";

/*
This method is used to change the size of the container table in the browser page.
And if the Auto-recalculate radio button is selected, then also recalculate the viewer layout.
*/
function resizeTable() {

    var table = document.getElementById("ViewerTable");
    table.height = Math.floor(700 * Math.random() + 250);
    table.width = Math.floor(500 * Math.random()) + 250;

    document.getElementById("Width").innerText = table.width;
    document.getElementById("Height").innerText = table.height;

    if(document.getElementById("RadioRecalculate").checked)
        $find(viewerID).recalculateLayout(); // recalculate the viewer layout

}
