angular.module('CrowdSourcedNews').controller('NewsArticlesController', function ($scope, NewsArticlesProvider) {

    $scope.articles = [];

    $scope.categories = [];

    $scope.getAllNewsArticles = function () {

        NewsArticlesProvider.getAllNewsArticles().then(function (response) {
            $scope.articles = response.data;
        });
    }

    $scope.getAllNewsArticles();

    $scope.getAllCategories = function () {

        NewsArticlesProvider.getAllCategories().then(function (response){
            $scope.categories = response.data;
        })
    }

    $scope.getAllCategories();

    $scope.getArticlesByCategory = function () {
        NewsArticlesProvider.getArticlesByCategory($scope.category).then(function (response) {
            $scope.articles = response.data;
        }, function (err) {
            toastr.warning('There are no articles in this category!');
            $scope.articles = [];
        });
    }
})