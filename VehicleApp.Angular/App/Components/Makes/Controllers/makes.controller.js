//makes-controller.js
(function () {
    "use strict"
    angular
        .module('VehicleApp')
        .controller('MakesController', MakesController);

    MakesController.$inject = ['$scope', 'makesModalService', 'makesDataService', 'makes'];
    function MakesController($scope, makesModalService, makesDataService, makes) {

        $scope.state = {
            searchTerm: "",
            pageNumber: 1,
            pageSize: 5
        }

        $scope.previous = function () {
            $scope.state.pageNumber--;
            if ($scope.state.pageNumber < 1)
                $scope.state.pageNumber = 1;
                makesDataService.GetAllMakes($scope.state.searchTerm, $scope.state.pageNumber, $scope.state.pageSize).$promise.then(
                function (response) {
                    console.log("response" + JSON.stringify(response));
                    $scope.makes = response;
                });
        }

        $scope.next = function () {
            console.log("fucntion next called");
            $scope.state.pageNumber++;

            makesDataService.GetAllMakes($scope.state.searchTerm, $scope.state.pageNumber, $scope.state.pageSize).$promise.then(
                function (response) {
                    console.log("response" + JSON.stringify(response));
                    if (response.length == 0) {
                        $scope.state.pageNumber--;
                        makesDataService.GetAllMakes($scope.state.searchTerm, $scope.state.pageNumber, $scope.state.pageSize).$promise.then(
                            function (response) {
                                console.log("response" + JSON.stringify(response));
                                $scope.makes = response;
                            });
                    }
                    $scope.makes = response;
                });
        };


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
