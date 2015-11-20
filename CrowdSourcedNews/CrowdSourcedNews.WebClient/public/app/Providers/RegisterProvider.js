angular.module('CrowdSourcedNews').factory('RegisterProvider', function ($http, $q) {

    var url = 'http://localhost:61701/api/Account/Register';

    function register(user) {
        var deferred = $q.defer();

        $http.post(url, user).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    return {
        register: register
    };
});