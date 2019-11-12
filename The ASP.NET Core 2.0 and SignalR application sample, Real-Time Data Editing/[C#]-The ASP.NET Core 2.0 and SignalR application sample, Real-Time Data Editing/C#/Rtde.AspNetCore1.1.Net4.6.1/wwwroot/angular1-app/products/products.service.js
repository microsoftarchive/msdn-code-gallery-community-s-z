(function () {
    'use strict';
    angular.module('application').factory('productsService', productsService);

    productsService.$inject = ['$http'];

    function productsService($http) {
        var service = {
            get: get
        }

        function get() {
            return $http.get('/api/Products')
                .then(function (response) {
                    return response.data;
                });
        }

        return service;
    }
})();