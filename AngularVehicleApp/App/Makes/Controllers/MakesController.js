(function () {
    angular
        .module('VehicleApp')
        .controller('MakesController', MakesController);

    MakesController.$inject = ['$scope', 'MakesService'];
    function MakesController($scope, MakesService) {

        $scope.make = {
            name: "Test",
            abrv: "Test"
        };


        MakesService.GetMakes().then(function (data) {
            $scope.makes = data;
        }, function () {
          console.log("Error");
        });

        $scope.CreateNewMake = function () {
            console.log("function called")
            MakesService.AddMake($scope.make).then(function (response) {
                console.log("success")
            }, function () {
                console.log("Error");
            });   
        }
    }
})()
