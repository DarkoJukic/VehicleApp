//makes-controller.js
(function () {
    "use strict"
    angular
        .module('VehicleApp')
        .controller('MakesController', MakesController);

    MakesController.$inject = ['$scope', 'MakesDataService', 'MakesModalService', 'makes'];
    function MakesController($scope, MakesDataService,MakesModalService, makes) {

        $scope.makes = makes;

        $scope.AddOrUpdateMakeModal = function (make) {
            var modalInstance = MakesModalService.AddOrUpdateMakeModal(make);
        };

        $scope.DeleteMakeModal = function (make) {
            var modalInstance = MakesModalService.DeleteMakeModal(make);
        };
    }
})()
