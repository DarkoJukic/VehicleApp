// makes-data.service.js

(function () {
    angular
		.module('VehicleApp')
		.factory('makesDataService', makesDataService);

    makesDataService.$inject = ['$resource', 'appSettings'];
    function makesDataService($resource, appSettings) {
        var service = {
            GetAllMakes: GetAllMakes,
            CreateMake: CreateMake,
            EditMake: EditMake,
            DeleteMake: DeleteMake
        };

        return service;

        function GetAllMakes(searchTerm, pageNumber, pageSize) {
            return $resource(appSettings.apiServerPath + '/api/makes', { searchTerm: searchTerm, pageNumber: pageNumber, pageSize: pageSize }).query();
        }

        function CreateMake(make) {
            var response = $resource(appSettings.apiServerPath + '/api/makes').save(make);
            return response
        }

        function EditMake(make, id) {
            var response = $resource(appSettings.apiServerPath + '/api/makes/:id', null, {
                'update': { method: 'PUT' }
            }).update({ id: id }, make);
            return response
        }

        function DeleteMake(id) {
            var response = $resource(appSettings.apiServerPath + '/api/makes/:id', { id: '@id' }).delete({ id: id });
            return response
        }
    }
})();