// add-or-update-make-modal.controller.js

(function () {
    angular
		.module('VehicleApp')
		.controller('AddOrUpdateMakeModalController', AddOrUpdateMakeModalController)

    AddOrUpdateMakeModalController.$inject = [
		'$scope',
		'$uibModalInstance',
        'makesDataService',
        'make'
    ];

    function AddOrUpdateMakeModalController($scope, $uibModalInstance, makesDataService, make) {

        $scope.make = angular.copy(make);

        $scope.CreateMake = function (make) {
            var promise = makesDataService.CreateMake(make);
            // this needs to be added when status codes are returned.
            promise.$promise.then(function (response) {
            });
            // later instead of reload edited make should be added to list locally
            window.location.reload();
            $uibModalInstance.close();
        }

        $scope.EditMake = function (make, id) {
            var promise = makesDataService.EditMake(make, id);
            // this needs to be added when status codes are returned.
            promise.$promise.then(function (response) {
            });
            // later instead of reload edited make should be changed on list locally
            window.location.reload();
            $uibModalInstance.close();
        }

        $scope.cancel = function () {
            $uibModalInstance.dismiss();
        };
    }
})();