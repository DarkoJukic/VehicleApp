// delete-model-modal.controller.js

(function () {
    "use strict"
    angular
		.module('VehicleApp')
		.controller('DeleteModelModalController', DeleteModelModalController);

    DeleteModelModalController.$inject = [
		'$scope',
		'$uibModalInstance',
        'ModelsDataService',
		'model'
    ];
    function DeleteModelModalController($scope, $uibModalInstance, ModelsDataService, model) {

        $scope.model = model;
        $scope.DeleteModel = function (id) {
            var promise = ModelsDataService.DeleteModel(id);
            promise.$promise.then(function (response) {
                toastr.success("Model deleted");
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