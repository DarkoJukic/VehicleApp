(function () {
    "use strict"
    angular
       .module('VehicleApp')
       .config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];

    function config($stateProvider, $urlRouterProvider, $locationProvider) {

        $stateProvider
            .state('Makes', {
                url: '/Makes',
                templateUrl: '/App/Components/Makes/makes.html',
                controller: 'MakesController',
                resolve: {
                    makes: function (makesDataService) {
                        return makesDataService.GetAllMakes().$promise;
                    }
                }
            })

            .state('Models', {
                url: '/Models/:id',
                templateUrl: '/App/Components/Models/models.html',
                controller: 'ModelsController',
                resolve: {
                    models: function (ModelsDataService, $stateParams) {
                        return ModelsDataService.GetModelsByMakeId($stateParams.id).$promise;
                    }
                }
            });

        $urlRouterProvider.otherwise('/Makes');
        //// html5Mode currently doesn't work, connecting to server when url directly visited. Need to implement server redirect to index.
        //$locationProvider.html5Mode(true);
    };
})();



