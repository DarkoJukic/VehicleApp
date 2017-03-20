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

        function GetModelsByMakeId(Id) {
            return $resource('/api/models/:Id', { Id: "@id" }).query({ Id: Id });
        }
    }
})();