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


        //get page
        $scope.getPage = function (searchTerm, pageNumber, pageSize) {
            console.log("search term " + searchTerm, "page number " + pageNumber, "page size" + pageSize)
            $scope.state.pageNumber = pageNumber;
            makesDataService.GetAllMakes(searchTerm, pageNumber, pageSize).$promise.then(
            function (response) {
                $scope.makes = response;
                if ($scope.state.pageNumber <= 1) {
                    $scope.state.pageNumber = 1;
                    // if first page then disable button for previous page($scope.state.firstPage is used in ng-disabled directive for previous button).
                    $scope.state.firstPage = true;
                } else {
                    $scope.state.firstPage = false;
                }
                // if response.length is < than pageSize then it is last page. Disable next page button.
                if (response.length < $scope.state.pageSize) {
                    $scope.state.lastPage = true;
                    // if response.length is  0, then go to previous page and disable next page button since we are on last page.
                    if (response.length == 0) {
                        pageNumber--;
                        $scope.state.lastPage = true;
                        makesDataService.GetAllMakes(searchTerm, pageNumber, pageSize).$promise.then(
                            function (response) {
                                $scope.makes = response;
                            });
                    }
                } else {
                    // if previous page button is pressed then it is not last page, enable next page button.
                    $scope.state.lastPage = false;
                }
            });
        }

        // when button search is press, call function for getting first page with searchTerm
        $scope.FilterMakes = function (searchTerm, pageNumber, pageSize) {
            pageNumber = 1;
            $scope.getPage(searchTerm, pageNumber, pageSize);
        }

        $scope.AddOrUpdateMakeModal = function (make, index) {
            var modalInstance = makesModalService.AddOrUpdateMakeModal(make);
            // after Make is created or edited change it locally, without need of refresh.
            modalInstance.result.then(function (make) {
                // if index is not sent in function AddOrUpdateMakeModal then it's new make. 
                //After creating new make get current page again to refresh the list
                //if it is existing make, then edit existing make locally.
                if (index == undefined) {
                    // After creating new make get current page again
                    $scope.getPage($scope.state.searchTerm, $scope.state.pageNumber, $scope.state.pageSize)
                    //$scope.makes.push(make);
                } else {
                    $scope.makes[index] = make;
                }
            });
        };

        $scope.DeleteMakeModal = function (make, index) {
            var modalInstance = makesModalService.DeleteMakeModal(make);
            modalInstance.result.then(function () {
                //after Make is deleted get current page again to refresh the list
                $scope.getPage($scope.state.searchTerm, $scope.state.pageNumber, $scope.state.pageSize)
            });
        };
    }
})()
