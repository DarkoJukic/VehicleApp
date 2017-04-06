//models-modal.service.js

(function () {
    "use strict"
    angular
		.module('VehicleApp')
		.factory('ModelsModalService', ModelsModalService);

    ModelsModalService.$inject = ['$uibModal', 'ModelsDataService'];
    function ModelsModalService($uibModal) {
        var service = {
            AddOrUpdateModelModal: AddOrUpdateModelModal,
            DeleteModelModal: DeleteModelModal
        };

        return service;

        function AddOrUpdateModelModal(model) {
            return $uibModal.open({
                templateUrl: '/app/components/models/modals/add-or-update-model-modal.html',
                controller: 'AddOrUpdateModelModalController',
                size: 'md',
                resolve: {
                    model: function () {
                        return model;
                    }
                }
            });
        }

        function DeleteModelModal(model) {
            return $uibModal.open({
                templateUrl: '/app/components/models/modals/delete-model-modal.html',
                controller: 'DeleteModelModalController',
                size: 'md',
                resolve: {
                    model: function () {
                        return model;
                    }
                }
            });
        }
    }
})();

