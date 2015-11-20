angular.module('CrowdSourcedNews').controller('LoginController', function ($scope, $location, $window, LoginProvider) {

    $scope.loginData = {};

    $scope.login = function () {

        LoginProvider.login($scope.loginData).then(function (response) {
            localStorage.setItem('token', response.data.access_token);
            localStorage.setItem('username', response.data.userName);
            toastr.success('You have successfully logged in!');
            $window.location.reload();
            $location.path('/NewsArticles');
        }, function (err) {
            toastr.error(err.data.error_description);
        })
    }
})