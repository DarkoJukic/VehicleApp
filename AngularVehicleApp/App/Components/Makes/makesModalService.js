 //makes-modal.service.js

(function () {
    "use strict"
    angular
		.module('VehicleApp')
		.factory('MakesModalService', MakesModalService);

    MakesModalService.$inject = ['$uibModal', 'MakesDataService'];
    function MakesModalService($uibModal) {
        var service = {
            AddOrUpdateMakeModal: AddOrUpdateMakeModal,
            DeleteMakeModal: DeleteMakeModal
        };

        return service;

        function AddOrUpdateMakeModal(make) {
            var modalInstance = $uibModal.open({
                templateUrl: '/app/components/makes/modals/AddOrUpdateMakeModal.html',
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
                templateUrl: '/app/components/makes/modals/DeleteMakeModal.html',
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

