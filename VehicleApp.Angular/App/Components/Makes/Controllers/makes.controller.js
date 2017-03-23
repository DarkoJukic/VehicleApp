//makes-controller.js
(function () {
    "use strict"
    angular
        .module('VehicleApp')
        .controller('MakesController', MakesController);

    MakesController.$inject = ['$scope',  'makesModalService', 'makes'];
    function MakesController($scope, makesModalService, makes) {

        $scope.makes = makes;
        $scope.AddOrUpdateMakeModal = function (make, index) {

            var modalInstance = makesModalService.AddOrUpdateMakeModal(make);
            // after Make is created or edited change it locally, without need of refresh.
            modalInstance.result.then(function (make) {
                // if index is not sent in function AddOrUpdateMakeModal then it's new make. 
                //After creating new make push it locally into makes list without refreshing page 
                //if it is existing make, then edit existing make locally.
                if (index == undefined) {
                    $scope.makes.push(make);
                } else {
                    $scope.makes[index] = make;
                }
            });
        };

        $scope.DeleteMakeModal = function (make, index) {
            var modalInstance = makesModalService.DeleteMakeModal(make);
            // after Make is deleted remove it locally, without need of refresh.
            modalInstance.result.then(function () {
                $scope.makes.splice(index, 1);
            });
        };
    }
})()
