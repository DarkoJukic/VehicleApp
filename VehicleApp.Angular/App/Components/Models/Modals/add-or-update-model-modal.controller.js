// add-or-update-model-modal.controller.js

(function () {
    angular
		.module('VehicleApp')
		.controller('AddOrUpdateModelModalController', AddOrUpdateModelModalController)

    AddOrUpdateModelModalController.$inject = [
		'$scope',
		'$uibModalInstance',
        'ModelsDataService',
        'model',
        '$stateParams'
    ];

    function AddOrUpdateModelModalController($scope, $uibModalInstance, ModelsDataService, model, $stateParams) {

        // copy object that is passed in modal
        $scope.model = angular.copy(model) || {};
        $scope.model.VehicleMakeId = $stateParams.id;
        console.log($scope.model)

        // resets model to previous value.
        $scope.reset = function () {
            $scope.model = angular.copy(model);
        }

        $scope.CreateModel = function (model) {
            var promise = ModelsDataService.CreateModel(model);
            promise.$promise.then(function (response) {
                toastr.success("New model created");
                $uibModalInstance.close(response);
            }, function error(response) {
                toastr.error("Error");
            });
        }

        $scope.EditModel = function (model, id) {
            var promise = ModelsDataService.EditModel(model, id);
            promise.$promise.then(function (response) {
                toastr.success("Model edited");
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