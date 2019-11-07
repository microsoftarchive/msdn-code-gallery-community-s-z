applicationModule.factory('productsService', function ($http, $q) {
    return {
        get: function() {
            var deferred = $q.defer();
            $http.get('/api/Products').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        }
    };
});