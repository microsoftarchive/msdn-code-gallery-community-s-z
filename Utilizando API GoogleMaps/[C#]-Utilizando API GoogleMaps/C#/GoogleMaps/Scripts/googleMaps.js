window.onload = function () {
    var mapOptions = {
        center: new google.maps.LatLng(markers[0].lat, markers[0].lng),
        zoom: 18,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var infoWindow = new google.maps.InfoWindow();
    var map = new google.maps.Map(document.getElementById("dvMap"), mapOptions);

    for (i = 0; i < markers.length; i++) {
        var data = markers[i]
        var myLatlng = new google.maps.LatLng(data.lat, data.lng);
        var marker = new google.maps.Marker({
            position: myLatlng,
            map: map,
            title: data.title
        });

        (function (marker, data) {
            google.maps.event.addListener(marker, "click", function (e) {
                infoWindow.setContent(data.description);
                infoWindow.open(map, marker);
            });

        })(marker, data);
    }
}