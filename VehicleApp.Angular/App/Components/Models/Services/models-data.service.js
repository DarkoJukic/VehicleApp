// models-data.service.js

(function () {
    angular
		.module('VehicleApp')
		.factory('ModelsDataService', ModelsDataService);

    ModelsDataService.$inject = ['$resource', 'appSettings'];
    function ModelsDataService($resource, appSettings) {
        var service = {
            GetModelsByMakeId: GetModelsByMakeId
        };

        return service;

        function GetModelsByMakeId(id) {
            return $resource( appSettings.apiServerPath + '/api/models/:id', { id: "@id" }).query({ id: id });
        }
    }
})();