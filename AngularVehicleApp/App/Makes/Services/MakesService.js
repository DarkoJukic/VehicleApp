(function () {
    angular
        .module('VehicleApp')
        .service('MakesService', MakesService);

    MakesService.$inject = ['$http'];
    function MakesService($http) {
        var service = {
            GetMakes: GetMakes,
            AddMake: AddMake
        };
        return service;

        function GetMakes() {
            return $http.get('/api/Makes')
                .then(Success)
                .catch(Failed)

            function Success(response) {
                return response.data;
            }
            function Failed(error) {
                alert("Error")
            }
        }


        function AddMake(make) {
            return $http.post('/api/Makes', make)
                .then(Success)
                .catch(Failed)

            function Success(response) {
                return response.data;
            }
            function Failed(error) {
                alert("Error")
            }
        }

    }
})()
