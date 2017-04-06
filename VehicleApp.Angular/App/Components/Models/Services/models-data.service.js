// models-data.service.js

(function () {
    angular
		.module('VehicleApp')
		.factory('ModelsDataService', ModelsDataService);

    ModelsDataService.$inject = ['$resource', 'appSettings'];
    function ModelsDataService($resource, appSettings) {
        var service = {
            GetModelsByMakeId: GetModelsByMakeId,
            CreateModel: CreateModel,
            EditModel: EditModel,
            DeleteModel: DeleteModel
        };

        return service;

        function GetModelsByMakeId(id) {
            return $resource( appSettings.apiServerPath + '/api/models/:id', { id: "@id" }).query({ id: id });
        }

        function CreateModel(model) {
            var response = $resource(appSettings.apiServerPath + '/api/models/:VehicleMakeId', { VehicleMakeId: "@VehicleMakeId" }).save(model);
            return response
        }

        function EditModel(model, id) {
            var response = $resource(appSettings.apiServerPath + '/api/models/:id', null, {
                'update': { method: 'PUT' }
            }).update({ id: id }, model);
            return response
        }

        function DeleteModel(id) {
            var response = $resource(appSettings.apiServerPath + '/api/models/:id', { id: '@id' }).delete({ id: id });
            return response
        }

    }
})();