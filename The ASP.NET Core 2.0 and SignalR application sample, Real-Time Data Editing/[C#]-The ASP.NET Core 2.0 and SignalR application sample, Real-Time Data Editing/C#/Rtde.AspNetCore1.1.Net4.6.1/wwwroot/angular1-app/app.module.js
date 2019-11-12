(function() {
    'use strict';
    angular.module('application', []);

    // SignalR's hub object.
    var productMessageHub = $.connection.productMessageHub;

    $.connection.hub.logging = true;
    $.connection.hub.start();

    angular.module('application').value('productMessageHub', productMessageHub);
})();