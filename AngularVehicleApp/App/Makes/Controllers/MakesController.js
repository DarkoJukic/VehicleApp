angular
    .module('VehicleApp')
    .controller('MakesController', MakesController);

function MakesController($scope, $http) {
    console.log(11)
    $scope.make = "24554546";
    console.log($scope.make)

    $http.get('/api/Makes').then(
        function (response) {
            $scope.makes = response.data;
            console.log(response)
        },
        function () {
            alert("error");
        })

}