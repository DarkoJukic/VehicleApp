// models-data.service.js

(function () {
    angular
		.module('VehicleApp')
		.factory('ModelsDataService', ModelsDataService);

    ModelsDataService.$inject = ['$resource'];
    function ModelsDataService($resource) {
        var service = {
            GetModelsByMakeId: GetModelsByMakeId
        };

        return service;

        function GetModelsByMakeId(id) {
            return $resource('/api/models/:id', { id: "@id" }).query({ id: id });
        }
    }
})();