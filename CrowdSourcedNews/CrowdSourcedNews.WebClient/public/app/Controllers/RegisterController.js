angular.module('CrowdSourcedNews').controller('RegisterController', function ($scope, $location, RegisterProvider) {

    $scope.user = {};

    $scope.register = function () {

        RegisterProvider.register($scope.user).then(function (response) {
            toastr.success('You have successfully registered!\nYou can now log in in your profile.');
            $location.path('/Home');
        }, function (err) {
            if (err.data.ModelState['model.Email'] != undefined) {
                toastr.error(err.data.ModelState['model.Email'][0]);
            }
            if (err.data.ModelState['model.Password'] != undefined) {
                toastr.error(err.data.ModelState['model.Password'][0]);
            }
        })
    }
})