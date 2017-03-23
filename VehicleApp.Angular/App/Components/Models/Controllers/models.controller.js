//models-controller.js
(function () {
    "use strict"
    angular
        .module('VehicleApp')
        .controller('ModelsController', ModelsController);

    ModelsController.$inject = ['$scope', 'ModelsDataService', 'models'];
    function ModelsController($scope, ModelsDataService, models) {
        $scope.models = models;
    }
})()
