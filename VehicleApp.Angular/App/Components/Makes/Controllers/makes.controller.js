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
            pageSize: 5,
            firstPage: true,
            lastPage: false
        }
        //initially list of makes is obtained from resolve.
        $scope.makes = makes;

        //get previous page
        $scope.previous = function () {
            $scope.state.pageNumber--;
            if ($scope.state.pageNumber <= 1) {
                $scope.state.pageNumber = 1;
                // if first page then disable previous button($scope.state.firstPage is used in ng-disabled directive for previous button).
                $scope.state.firstPage = true;
            }
            // if previous page button is pressed then it is not last page, enable next page button.
            $scope.state.lastPage = false;
            makesDataService.GetAllMakes($scope.state.searchTerm, $scope.state.pageNumber, $scope.state.pageSize).$promise.then(
            function (response) {
                // if response.length is < than pageSize then it is last page. Disable next page button.
                if (response.length < $scope.state.pageSize) {
                    $scope.state.lastPage = true;
                }
                $scope.makes = response;
            });
        }
        //get next page
        $scope.next = function () {
            $scope.state.pageNumber++;
            // if next page button is pressed then it is not first page, enable previous page button.
            $scope.state.firstPage = false;
            makesDataService.GetAllMakes($scope.state.searchTerm, $scope.state.pageNumber, $scope.state.pageSize).$promise.then(
                function (response) {
                    // if response.length is < than pageSize then it is last page. Disable next page button.
                    if (response.length < $scope.state.pageSize) {
                        $scope.state.lastPage = true;
                    }
                    // if response.length is  0, then go to previous page and disable next page button since we are on last page.
                    if (response.length == 0) {
                        $scope.state.pageNumber--;
                        $scope.state.lastPage = true;
                        makesDataService.GetAllMakes($scope.state.searchTerm, $scope.state.pageNumber, $scope.state.pageSize).$promise.then(
                            function (response) {
                                $scope.makes = response;
                            });
                    }
                    $scope.makes = response;
                });
        };

        // when button search is press, call function for getting first page with searchTerm
        $scope.FilterMakes = function () {
            $scope.state.pageNumber = 1;
            $scope.previous();
        }

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
