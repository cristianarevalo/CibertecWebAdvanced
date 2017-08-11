(function () { //auto ejecucion de IIFE
    'use strict'; //para que las variables sea declaradas

    angular.module('app', ['ui.router', 'LocalStorageModule','ui.bootstrap']); //creamos el modulo app e injectando la libreria ui.router
})(); //() ejecuta la funcion
(function () {
    'use strict'; //Exijimos que valide las variables

    angular.module('app')
        .config(routeConfig); //configurando el modulo, setea la funcion routeConfig

    routeConfig.$inject = ['$stateProvider', '$urlRouterProvider']; //injección de dependiencias, esta entre comillas para el DOM no lo cambie cuando se minifique
    //$stateProvider: permite saber el estado en el cual estamos trabajando, cualquier que no concuerda se va al 'otherwise'
    //$urlRouterProvider:
    //cuando se navega antepone los simbolos # y !: para busqueda SEO(Buscadores, ranking)

    function routeConfig($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state("home", {
                url: "/home",
                templateUrl: './app/home.html'
            })
            .state("login", {
                url: "/login",
                templateUrl: './app/public/login/index.html'
            })
            .state("product", {
                url: "/product",
                templateUrl:'./app/private/product/index.html'
            })
            .state("csv-viewer", {
                url: "/csv-viewer",
                templateUrl: './app/private/product/directives/csv-viewer/index.html'
            })
            .state("otherwise", {
                url: '*path',
                templateUrl: './app/home.html'
            });
    }

})();
(function () {
    'use strict';

    angular.module('app').config(setup).run(run);

    setup.$inject = ['$compileProvider'];

    function setup($compileProvider) {
        //deshabilitando el modo debug de angular
        $compileProvider.debugInfoEnabled(false);
    }

    run.$inject = ['$http', '$state', 'localStorageService', 'configService'];

    function run($http, $state, localStorageService, configService) {
        var user = localStorageService.get('userToken');
        if (user && user.token) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + localStorageService.get('userToken').token;
            configService.setLogin(true);
        }
        else $state.go('login');
    }

})();
(function () {
    'use strict';

    angular.module('app')
        .controller('applicationController', applicationController);

    applicationController.$inject = ['$scope', 'configService', 'authenticationService', 'localStorageService']

    function applicationController($scope, configService, authenticationService, localStorageService) {
        var vm = this; //vm: view model
        vm.validate = validate;
        vm.logout = logout;

        $scope.init = function (url) {
            configService.setApiUrl(url);
        }

        function validate() {
            return configService.getLogin();
        }

        function logout() {
            authenticationService.logout();
        }

    }
})();