angular.module('CrowdSourcedNews').controller('MainController', function ($scope, $location, $window) {

    $scope.loggedUser = localStorage.username;

    $scope.logout = function () {
        localStorage.clear();
        $window.location.reload();
        $location.path('/Home');
    }

    if (localStorage.getItem('username')) {

        $('#logoutbar').show();
        $('#addnewsarticlesbar').show();
        $('#chat').show();
        $('#loggedbar').show();
        $('#loginbar').hide();
        $('#registerbar').hide();
    }
    else {
        $('#logoutbar').hide();
        $('#addnewsarticlesbar').hide();
        $('#chat').hide();
        $('#loggedbar').hide();
        $('#loginbar').show();
        $('#registerbar').show();
    }
})