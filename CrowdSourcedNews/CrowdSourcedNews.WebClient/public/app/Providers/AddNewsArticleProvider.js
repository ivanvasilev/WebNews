angular.module('CrowdSourcedNews').factory('AddNewsArticleProvider', function ($http, $q) {

    var url = 'http://localhost:61701/api/NewsArticles';
    var url1 = 'http://localhost:61701/api/Categories';

    function add(data) {
        console.log(data);
        var deferred = $q.defer();
        $http.post(url, data, { headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + localStorage.token } }).then(function (response) {
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
        add: add,
        getAllCategories: getAllCategories
    };
});