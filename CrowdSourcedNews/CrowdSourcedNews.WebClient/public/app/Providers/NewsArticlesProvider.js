angular.module('CrowdSourcedNews').factory('NewsArticlesProvider', function ($http, $q) {

    var url = 'http://localhost:61701/api/NewsArticles';
    var url1 = 'http://localhost:61701/api/Categories';
    var url2 = 'http://localhost:61701/api/NewsArticles?category=';
    var commentsUrl = 'http://localhost:61701/api/Comments';

    function getAllNewsArticles() {
        var deferred = $q.defer();

        $http.get(url).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    function getAllArticlesByCurrentUser(data) {
        var deferred = $q.defer();

        $http.get(url, data).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    function getById(id) {
        var deferred = $q.defer();
        var urlA = url + '/' + id;
        $http.get(urlA).then(function (response) {
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

    function getArticlesByCategory(category) {
        var deferred = $q.defer();

        var url3 = url2 + category;

        $http.get(url3).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    function addComment(data, id) {
        var deferred = $q.defer();

        $http.post(commentsUrl, data, { headers: { 'Content-Type': 'application/json', 'Authorization': 'Bearer ' + localStorage.token } }).then(function (response) {
            deferred.resolve(response);
        }, function (error) {
            deferred.reject(error);
        })

        return deferred.promise;
    }

    return {
        getAllNewsArticles: getAllNewsArticles,
        getArticlesByCategory: getArticlesByCategory,
        getAllCategories: getAllCategories,
        getById: getById,
        addComment: addComment,
        getAllArticlesByCurrentUser: getAllArticlesByCurrentUser
    };
});

