describe('loginController', function(){
    var controller, service;

    beforeEach(function(){
        module('app');
    });

    beforeEach(
        inject(function($controller,_authenticationService_, $q){
            service = _authenticationService_;

            spyOn(service, "login").and.callFake(function(user){
                var deferred = $q.defer();
                deferred.resolve('Response');

                return deferred.promise;
            });

            //injectando a mi controller este nuevo servicio creado
            controller = $controller('loginController',{
                authenticationService: service
            });
        })
    );

    describe('Login Test', function(){
        it('Login', inject(function(){
            controller.login({});
            expect(controller.showError).toEqual(false);
        }));
    });

});