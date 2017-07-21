(function () { //auto ejecucion de IIFE
    'use strict'; //para que las variables sea declaradas

    angular.module('app', ['ui.router', 'LocalStorageModule','ui.bootstrap']); //creamos el modulo app e injectando la libreria ui.router
})(); //() ejecuta la funcion