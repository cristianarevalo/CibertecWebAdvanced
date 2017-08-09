describe('dataService', function () {

    beforeEach(module('app'));

    it('Get Data OK',
        inject(function (dataService, $httpBackend) {
            $httpBackend.expectGET('/test').respond(200, 'OK');
            dataService.getData('/test').then(function (response) {
                expect(response.data).toEqual('OK');
            });
            $httpBackend.flush();
        })
    );
    
    it('Post Data OK',
        inject(function(dataService, $httpBackend){
            var data = {};
            $httpBackend.expectPOST('/test').respond(200, 'OK');
            dataService.postData('/test',data).then(function (response){
                expect(response.data).toEqual('OK');
            });
            $httpBackend.flush();
        })
    );
});