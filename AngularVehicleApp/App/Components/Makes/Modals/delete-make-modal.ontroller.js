// delete-make-modal.controller.js

(function () {
    "use strict"
    angular
		.module('VehicleApp')
		.controller('DeleteMakeModalController', DeleteMakeModalController);

    DeleteMakeModalController.$inject = [
		'$scope',
		'$uibModalInstance',
        'makesDataService',
		'make'
    ];
    function DeleteMakeModalController($scope, $uibModalInstance, makesDataService, make) {

        $scope.make = make;
        console.log($scope.make)
        $scope.DeleteMake = function (id) {

            var promise = makesDataService.DeleteMake(id);
            $uibModalInstance.close();
            // this needs to be added when status codes are returned.
            promise.$promise.then(function (response) {
            });
            window.location.reload();
            $uibModalInstance.close();
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss();
        };
    }
})();