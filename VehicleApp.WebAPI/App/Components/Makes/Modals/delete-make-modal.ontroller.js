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
        $scope.DeleteMake = function (id) {
            var promise = makesDataService.DeleteMake(id);
            promise.$promise.then(function (response) {
                toastr.success("Make deleted");
                $uibModalInstance.close();
            }, function error(response) {
                toastr.error("Error")
            });
        }

        $scope.cancel = function () {
            $uibModalInstance.dismiss();
        };
    }
})();