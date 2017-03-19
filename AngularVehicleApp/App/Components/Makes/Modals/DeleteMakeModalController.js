// delete-make-modal.controller.js

(function () {
    "use strict"
    angular
		.module('VehicleApp')
		.controller('DeleteMakeModalController', DeleteMakeModalController);

    DeleteMakeModalController.$inject = [
		'$scope',
		'$uibModalInstance',
        'MakesDataService',
		'make'
    ];
    function DeleteMakeModalController($scope, $uibModalInstance, MakesDataService, make) {

        $scope.make = make;
        console.log($scope.make)
        $scope.DeleteMake = function (id) {

            var promise = MakesDataService.DeleteMake(id);
            $uibModalInstance.close();
            // this needs to be added when status codes are returned.
            promise.$promise.then(function (response) {
            });
            $uibModalInstance.close();
        };

        $scope.cancel = function () {
            $uibModalInstance.dismiss();
        };
    }
})();