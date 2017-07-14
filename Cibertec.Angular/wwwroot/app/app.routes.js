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
                templateUrl: 'app/home.html'
            })
            .state("login", {
                url: "/login",
                templateUrl: 'app/public/login/index.html'
            })
            .state("product", {
                url: "/product",
                templateUrl:'app/private/product/index.html'
            })
            .state("otherwise", {
                url: '*path',
                templateUrl: 'app/home.html'
            });
    }

})();