// makes-data.service.js

(function () {
    angular
		.module('VehicleApp')
		.factory('makesDataService', makesDataService);

    makesDataService.$inject = ['$resource'];
    function makesDataService($resource) {
        var service = {
            GetAllMakes: GetAllMakes,
            CreateMake: CreateMake,
            EditMake: EditMake,
            DeleteMake: DeleteMake
        };

        return service;

        function GetAllMakes() {
            return $resource('/api/makes').query();
        }

        function CreateMake(make) {
            console.log("podaci koje saljem, " + make);
            var response = $resource('/api/makes').save(make);
            console.log("response is" + JSON.stringify(response));
            return response
        }

        function EditMake(make, id) {
            var response = $resource('/api/makes/:id', null, {
                'update': { method: 'PUT' }
            }).update({ id: id }, make);
            return response
        }

        function DeleteMake(id) {
            var response = $resource('/api/makes/:id', { id: '@id' }).delete({ id: id });
            return response
        }

    }
})();




//(function () {
//    angular
//        .module('VehicleApp')
//        .service('MakesDataService', MakesDataService);

//    MakesDataService.$inject = ['$http'];
//    function MakesDataService($http) {
//        var service = {
//            GetMakes: GetMakes,
//            AddMake: AddMake
//        };
//        return service;

//        function GetMakes() {
//            return $http.get('/api/Makes')
//                .then(Success)
//                .catch(Failed)

//            function Success(response) {
//                return response.data;
//            }
//            function Failed(error) {
//                alert("Error")
//            }
//        }


//        function AddMake(make) {
//            return $http.post('/api/Makes', make)
//                .then(Success)
//                .catch(Failed)

//            function Success(response) {
//                return response.data;
//            }
//            function Failed(error) {
//                alert("Error")
//            }
//        }

//    }
//})()
