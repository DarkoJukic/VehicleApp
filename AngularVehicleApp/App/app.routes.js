(function () {
    "use strict"
    angular
       .module('VehicleApp')
       .config(config);


    config.$inject = ['$stateProvider', '$urlRouterProvider', '$locationProvider'];

    function config($stateProvider, $urlRouterProvider, $locationProvider) {

        $urlRouterProvider.otherwise('/Makes');
        $stateProvider
            .state('Makes', {
                url: '/Makes',
                templateUrl: '/App/Views/makes.html',
                controller: 'MakesController',
                resolve: {
                    makes: function (makesDataService) {
                        return makesDataService.GetAllMakes().$promise;
                    }
                }
            })

            .state('Models', {
                url: '/Models/:Id',
                templateUrl: '/App/Views/models.html',
                controller: 'ModelsController',
                resolve: {
                    models: function (ModelsDataService, $stateParams) {
                        return ModelsDataService.GetModelsByMakeId($stateParams.Id).$promise;
                    }
                }
            });

        $locationProvider.html5Mode(true);
    };
})();



