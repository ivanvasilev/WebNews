/// <reference path="AddNewsArticleController.js" />
angular.module('CrowdSourcedNews').controller('AddNewsArticleController', function ($scope, $window, AddNewsArticleProvider) {

    $scope.data = {};

    $scope.categories = [];

    $scope.add = function () {
        
        AddNewsArticleProvider.add($scope.data).then(function (response) {
            toastr.success('You have successfully added a news article!');
            $window.location.reload();
        }, function (err) {
            console.log(err.data);
            toastr.error("Invalid title or content!");
        })
    }

    $scope.getAllCategories = function () {

        AddNewsArticleProvider.getAllCategories().then(function (response) {
            $scope.categories = response.data;
        })
    }

    $scope.getAllCategories();
})