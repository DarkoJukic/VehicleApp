//models-controller.js
(function () {
    "use strict"
    angular
        .module('VehicleApp')
        .controller('ModelsController', ModelsController);

    ModelsController.$inject = ['$scope', 'ModelsModalService', 'models', 'ModelsDataService', "$stateParams"];
    function ModelsController($scope, ModelsModalService, models, ModelsDataService, $stateParams) {
        $scope.models = models;

        $scope.AddOrUpdateModelModal = function (model, index) {
            var modalInstance = ModelsModalService.AddOrUpdateModelModal(model);
            modalInstance.result.then(function (model) {
                $scope.reloadPage();
            });
        };

        $scope.DeleteModelModal = function (model, index) {
            var modalInstance = ModelsModalService.DeleteModelModal(model);
            modalInstance.result.then(function () {
                modalInstance.result.then(function (model) {
                    $scope.reloadPage();
                });
            });
        };

        $scope.reloadPage = function () {
            var promise = ModelsDataService.GetModelsByMakeId($stateParams.id).$promise.then(
                function (response) {
                    $scope.models = response;
                })        
        }
    }
})()
