(function () {
    'use strict';

    angular
		.module('CrowdSourcedNews')
		.directive('fileModel', fileModel);

    fileModel.$inject = ['$parse', '$q'];

    function fileModel($parse, $q) {
        return {
            restrict: 'A',
            link: function (scope, element, attr) {
                var model = $parse(attr.fileModel);

                element.bind('change', function () {
                    var files = Array.prototype.slice.call(element[0].files);

                    $q.all(files.map(readFile))
						.then(function (data) {
						    model.assign(scope, data);
						});
                });

                function readFile(file) {
                    var reader = new FileReader(),
						deferred = $q.defer();

                    reader.onload = function (e) {
                        var convertedFile = e.target.result;
                        var result = {
                            OriginalFileName: file.name.substr(0, file.name.lastIndexOf('.')),
                            FileExtension: file.name.substr(file.name.lastIndexOf('.') + 1).toLowerCase(),
                            Base64Content: convertedFile.substr(convertedFile.indexOf(',') + 1)
                        };

                        deferred.resolve(result);
                    };

                    reader.onerror = function (e) {
                        deferred.reject(e);
                    };

                    reader.readAsDataURL(file);

                    return deferred.promise;
                }
            }
        };
    }
}());