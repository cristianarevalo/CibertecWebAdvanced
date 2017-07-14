(function () {
    'use strict';

    angular.module('app')
        .directive('productCard', productCard);

    function productCard() {
        return {
            restrict: 'E', //alcance de como se va utilizar la directiva
            transclude: true, //permite inclustar html dentro de la directiva
            scope: {
                id: '@', //@: interpolar
                productName: '@',
                supplierId: '@',
                unitPrice: '@',
                package: '@',
                isDiscontinued: '=' //=: mismo objeto
            },
            templateUrl: 'app/private/product/directives/product-card/product-card.html',
            controller: directiveController
        };
    }

    function directiveController() {

    }
})();