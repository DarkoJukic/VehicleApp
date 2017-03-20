//makes-controller.js
(function () {
    "use strict"
    angular
        .module('VehicleApp')
        .controller('MakesController', MakesController);

    MakesController.$inject = ['$scope',  'makesModalService', 'makes'];
    function MakesController($scope, makesModalService, makes) {

        $scope.makes = makes;

        $scope.AddOrUpdateMakeModal = function (make) {
            var modalInstance = makesModalService.AddOrUpdateMakeModal(make);
        };

        $scope.DeleteMakeModal = function (make) {
            var modalInstance = makesModalService.DeleteMakeModal(make);
        };
    }
})()
