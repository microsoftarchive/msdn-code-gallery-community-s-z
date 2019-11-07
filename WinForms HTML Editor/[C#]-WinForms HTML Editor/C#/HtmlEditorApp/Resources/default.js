function showElements() {
    var tag_names = "";
    for (i=0; i<document.all.length; i++)
        tag_names = tag_names + document.all(i).tagName + " ";
    alert("This document contains: " + tag_names);
}
