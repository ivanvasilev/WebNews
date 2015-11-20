angular.module('CrowdSourcedNews').factory('LoggedProvider', function ($http, $q) {

    var url = 'http://localhost:61701/Token';

    function login(loginData) {
        var data = "grant_type=password&username=" + loginData.Username + "&password=" + loginData.Password;
        var deferred = $q.defer();
        $http.post(url, data, { headers: { 'Content-Type': 'application/x-www-form-urlencoded' } }).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    function getAllCategories() {
        var deferred = $q.defer();

        $http.get(url1).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    return {
        login: login,
        getAllCategories: getAllCategories
    };
});