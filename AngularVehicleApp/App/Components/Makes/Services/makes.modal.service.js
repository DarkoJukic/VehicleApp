 //makes-modal.service.js

(function () {
    "use strict"
    angular
		.module('VehicleApp')
		.factory('makesModalService', makesModalService);

    makesModalService.$inject = ['$uibModal', 'makesDataService'];
    function makesModalService($uibModal) {
        var service = {
            AddOrUpdateMakeModal: AddOrUpdateMakeModal,
            DeleteMakeModal: DeleteMakeModal
        };

        return service;

        function AddOrUpdateMakeModal(make) {
            var modalInstance = $uibModal.open({
                templateUrl: '/app/components/makes/modals/add-or-update-make-modal.html',
                controller: 'AddOrUpdateMakeModalController',
                size: 'md',
                resolve: {
                    make: function () {
                        return make;
                    }
                }
            });
        }

        function DeleteMakeModal(make) {
            var modalInstance = $uibModal.open({
                templateUrl: '/app/components/makes/modals/delete-make-modal.html',
                controller: 'DeleteMakeModalController',
                size: 'md',
                resolve: {
                    make: function () {
                        return make;
                    }
                }
            });
        }
    }
})();

