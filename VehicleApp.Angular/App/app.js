(function () {
    "use strict"
    angular
       .module('VehicleApp', ['ngResource', 'ui.router', 'ui.bootstrap'])
       .constant("appSettings", {
           apiServerPath: "http://localhost:64802"
       })
})();