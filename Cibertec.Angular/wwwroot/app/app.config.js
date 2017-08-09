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

            //cargando configuracion solo cuando los usuario sean autenticados
            startSignaR();

        }
        else $state.go('login');
    }

    function startSignaR() {
        $.connection.hub.logging = true;
        var notificationHubProxy = $.connection.notificationHub;

        //callback
        notificationHubProxy.client.updateProduct = function (id) {
            console.log(id);
        };

        $.connection.hub.start()
            .done(function () {
                console.log("Hub started success");
            })
            .fail(function (error) {
                console.log(error);
            });


    }

})();