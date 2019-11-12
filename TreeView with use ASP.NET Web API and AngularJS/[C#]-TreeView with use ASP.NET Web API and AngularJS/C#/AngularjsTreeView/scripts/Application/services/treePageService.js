applicationModule.factory('treePageService', function ($http, $q) {
    return {
        get: function() {
            var deferred = $q.defer();
            $http.get('/api/TreePage').success(deferred.resolve).error(deferred.reject);
            return deferred.promise;
        },

        update: function (treeViewPageNodes) {
            var request = $http({
                method: "post",
                url: "/api/TreePage",
                data: treeViewPageNodes
            });

            return request;
        }
    };
});