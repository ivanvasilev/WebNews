angular.module('CrowdSourcedNews').controller('ArticleDetailsController', function ($scope, $routeParams, $window, NewsArticlesProvider) {

    var id = $routeParams.id;

    $scope.data = {};

    NewsArticlesProvider.getById(id).then(function (response) {
        $scope.article = response.data;
    })

    $scope.addComment = function () {
        $scope.data.NewsArticleId = $scope.article.Id;
        NewsArticlesProvider.addComment($scope.data).then(function (response) {
            console.log(response);
            $window.location.reload();
            toastr.success('You have successfully added a comment!');
        }, function (err) {
            toastr.error("Invalid content!");
        })
    }

    if (localStorage.getItem('username')) {
        $('#commentbar').show();
    }
    else {
        $('#commentbar').hide();
    }
})

