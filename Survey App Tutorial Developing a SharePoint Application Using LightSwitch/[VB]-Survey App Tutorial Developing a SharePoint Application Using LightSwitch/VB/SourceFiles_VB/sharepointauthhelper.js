$(document).ready(function () {
    function getQueryStringParameter(name) {
        var match = RegExp('[?&]' + name + '=([^&]*)')
                        .exec(window.location.search);
        return match && decodeURIComponent(match[1].replace(/\+/g, ' '));
    }

    var appweburl = getAppWebFromCookie();

    if (appweburl) {
        var authproxy = appweburl + "/_layouts/15/appwebproxy.aspx"
        var iframe = $("<iframe src='" + authproxy + "' style='width: 0px; height: 0px; border: 0px'/>");
        $("body").append(iframe);
    }
});

function getAppWebFromCookie() {
    var allCookies = document.cookie.split(";");
    for (var ii = 0; ii < allCookies.length; ++ii) {
        if (allCookies[ii].match(/^msls-client-parameters=/)) {
            var ourCookies = allCookies[ii].substring(allCookies[ii].indexOf("=") + 1);
            var splitCookies = ourCookies.split("&");
            for (var jj = 0; jj < splitCookies.length; ++jj) {
                if (splitCookies[jj].match(/^SPAppWebUrl=/)) {
                    return splitCookies[jj].split('=')[1];
                }
            }
        }
    }
    return null;
}