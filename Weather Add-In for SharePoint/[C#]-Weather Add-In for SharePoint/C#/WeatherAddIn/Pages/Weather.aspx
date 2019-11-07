<%@ Page Language="C#" Inherits="Microsoft.SharePoint.WebPartPages.WebPartPage, Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register TagPrefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<WebPartPages:AllowFraming ID="AllowFraming" runat="server" />

<html>
<head>
    <title></title>

    <script type="text/javascript" src="/_layouts/1033/init.js"></script>
    <script type="text/javascript" src="/_layouts/sp.core.js"></script>
    <script type="text/javascript" src="../Scripts/jquery-1.9.1.min.js"></script>
    <script type="text/javascript" src="/_layouts/15/MicrosoftAjax.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.runtime.js"></script>
    <script type="text/javascript" src="/_layouts/15/sp.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.svg3dtagcloud.min.js"></script>
    <script type="text/javascript" src="../Scripts/app.js"></script>
    <script src='https://cdnjs.cloudflare.com/ajax/libs/twitter-bootstrap/4.0.0-alpha.6/js/bootstrap.min.js'></script>
    <script type="text/javascript">
        // Set the style of the client web part page to be consistent with the host web.
        (function () {
            'use strict';

            var hostUrl = '';
            if (document.URL.indexOf('?') != -1) {
                var params = document.URL.split('?')[1].split('&');
                for (var i = 0; i < params.length; i++) {
                    var p = decodeURIComponent(params[i]);
                    if (/^SPHostUrl=/i.test(p)) {
                        hostUrl = p.split('=')[1];
                        document.write('<link rel="stylesheet" href="' + hostUrl + '/_layouts/15/defaultcss.ashx" />');
                        break;
                    }
                }
            }
            if (hostUrl == '') {
                document.write('<link rel="stylesheet" href="/_layouts/15/1033/styles/themable/corev15.css" />');
            }
        })();

        $(document).ready(function () {
            // get location from user's IP address
            $.getJSON('https://ipinfo.io', function (info) {
                var locString = info.loc.split(', ');
                var latitude = parseFloat(locString[0]);
                var longitude = parseFloat(locString[1]);
                $('#location').html('Location: ' + info.city + ', ' + info.region + ', ' + info.country)

                // get weather using OpenWeatherMap API
                $.getJSON('https://cors.5apps.com/?uri=http://api.openweathermap.org/data/2.5/weather?lat=' + latitude + '&lon=' + longitude + '&units=metric&APPID=c3e00c8860695fd6096fe32896042eda', function (data) {
                    var windSpeedkmh = Math.round(data.wind.speed * 3.6);
                    var Celsius = Math.round(data.main.temp)
                    var iconId = data.weather[0].icon;
                    var weatherURL = "http://openweathermap.org/img/w/" +
                            iconId + ".png";

                    var iconImg = "<img src='" + weatherURL + "'>";
                    $('#sky-image').html(iconImg);
                    $('#weather-id').html('Skies: ' + data.weather[0].description);

                    $('#temperature').html(Celsius);
                    $('#toFahrenheit').click(function () {
                        $('#temperature').html(Math.round((9 / 5) * Celsius + 32));
                        $('#wind-speed').html(Math.round(windSpeedkmh * 0.621) + ' mph')
                    })
                    $('#toCelsius').click(function () {
                        $('#temperature').html(Celsius);
                        $('#wind-speed').html(windSpeedkmh + ' km/hr')
                    })

                    $('#wind-speed').html(windSpeedkmh + ' km/h');
                    $('#humidity').html('Humidity: ' + data.main.humidity + ' %');

                })
            })
        })
    </script>
</head>
<body>
    <div class="row">
        <div class="col-6">
            <div id="sky-image"></div>
            <div id="location"></div>
            <div id="weather-id"></div>
            <div>Temperature: <span id="temperature"></span>&deg<a href="#" id="toCelsius">C</a> | &deg<a href="#" id="toFahrenheit">F</a></div>
            <div>Wind speed: <span id="wind-speed"></span></div>
            <div id="humidity"></div>
        </div>
    </div>
</body>
</html>
