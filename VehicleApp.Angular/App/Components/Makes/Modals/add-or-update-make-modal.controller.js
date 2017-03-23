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

        // copy object that is passed in modal
        $scope.make = angular.copy(make);

        // resets make to previous value.
        $scope.reset = function () {
            $scope.make = angular.copy(make);
        }

        $scope.CreateMake = function (make) {
            var promise = makesDataService.CreateMake(make);
            promise.$promise.then(function (response) {
                toastr.success("New make created");
                $uibModalInstance.close(response);
            }, function error(response) {
                toastr.error("Error");
            });
        }

        $scope.EditMake = function (make, id) {
            var promise = makesDataService.EditMake(make, id);
            promise.$promise.then(function (response) {
                toastr.success("Make edited");
                $uibModalInstance.close(response);
            }, function error(response) {
                toastr.error("Error")
            });
        }

        $scope.cancel = function () {
            $uibModalInstance.dismiss();
        };
    }
})();