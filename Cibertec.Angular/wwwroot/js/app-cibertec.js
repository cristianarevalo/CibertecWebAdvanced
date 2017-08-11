(function () {
    angular
        .module('app')
        .factory('authenticationService', authenticationService);

    authenticationService.$inject = ['$http', '$state', 'localStorageService', 'configService','$q'];

    function authenticationService($http, $state, localStorageService, configService, $q)
    {
        var service = {};
        service.login = login;
        service.logout = logout;

        return service;

        function login(user) {
            var defer = $q.defer();
            var url = configService.getApiUrl() + '/Token';
            var data = "username=" + user.userName + "&password=" + user.password;

            $http.post(url,
                data,
                {
                    headers: {
                        'Content-Type': 'application/x-www-form-urlencoded'
                    }
                })
                .then(function (result) {
                    $http.defaults.headers.common.Authorization = 'Bearer ' + result.data.access_token;

                    localStorageService.set('userToken',
                        {
                            token: result.data.access_token,
                            userName: user.userName
                        });
                    configService.setLogin(true);
                    $state.go('home');
                    defer.reject(true);
                },
                function error() {
                    defer.reject(false);
                });

            return defer.promise;
        }

        function logout() {
            $http.defaults.headers.common.Authorization = '';
            localStorageService.remove('userToken');
            configService.setLogin(false);
        }
    }
})();
(function () {
    angular
        .module('app')
        .factory('dataService', dataService);

    dataService.$inject = ['$http'];

    function dataService($http) {
        var service = {};
        service.getData = getData;
        service.postData = postData;
        service.putData = putData;
        service.deleteData = deleteData;

        return service;

        function getData(url) {
            return $http.get(url);
        }

        function postData(url, data) {
            return $http.post(url, data);
        }

        function putData(url, data) {
            return $http.put(url, data);
        }

        function deleteData(url) {
            return $http.delete(url);
        }

    }
})();
(function () {
    'use strict';

    angular
        .module('app')
        .factory('configService', configService);

    function configService() {
        var service = {};
        var apiUrl = undefined;
        var isLogged = false;
        service.setLogin = setLogin;
        service.getLogin = getLogin;
        service.setApiUrl = setApiUrl;
        service.getApiUrl = getApiUrl;

        return service;

        function setLogin(state) {
            isLogged = state;
        }

        function getLogin() {
            return isLogged;
        }

        function getApiUrl() {
            return apiUrl;
        }

        function setApiUrl(url) {
            apiUrl = url;
        }
    }
})();
(function () {
    angular.module('app')
        .directive('modalPanel', modalPanel);

    function modalPanel() {
        return {
            templateUrl: 'app/components/modal/modal-directive.html',
            restrict: 'E',
            transclude: true,
            scope: {
                title: '@',
                buttonTitle: '@',
                saveFunction: '=',
                closeFunction: '=',
                readOnly: '=',
                isDelete: '='
            }
        };
    }
})();
(function () {
    'use strict';

    angular.module('app')
        .controller('loginController', loginController);

    loginController.$inject = ['$http', 'authenticationService', 'configService', '$state'];

    function loginController($http, authenticationService, configService, $state) {
        var vm = this;
        vm.user = {};
        vm.title = 'login';
        vm.login = login;
        vm.showError = false;

        init();

        function init() {
            if (configService.getLogin()) $state.go('home');
            authenticationService.logout();
        }

        function login() {
            authenticationService.login(vm.user)
                .then(function (result) {
                    vm.showError = false;
                    $state.go("home");
                }
                , function (error) {
                    vm.showError = true;
                });
        }
    }
})();
(function () {
    'use strict';

    angular.module('app')
        .controller('productController', productController);

    productController.$inject = ['dataService', 'configService', '$state'];

    function productController(dataService, configService, $state)
    {
        var apiUrl = configService.getApiUrl();
        var vm = this;

        vm.product = {};
        vm.productList = [];
        vm.modalButtonTitle = '';
        vm.readOnly = false;
        vm.isDelete = false;
        vm.modalTitle = '';
        vm.showCreate = false;

        vm.totalRecords = 0;
        vm.currentPage = 1;
        vm.maxSize = 10;
        vm.itemsPerPage = 10;

        vm.notificationHubProxy = {};
        vm.blockedIds = [];
        vm.isEdited = false;

        //Funciones
        vm.getProduct = getProduct;
        vm.create = create;
        vm.edit = edit;
        vm.delete = productDelete;
        vm.pageChanged = pageChanged;
        vm.closeModal = closeModal;

        init();

        function init() {
            if (!configService.getLogin()) return $state.go('login');
            configurePagination();
            startSignaR();
        }

        function startSignaR() {
            $.connection.hub.logging = true;
            vm.notificationHubProxy = $.connection.notificationHub;

            //callback
            vm.notificationHubProxy.client.addProductId = function (list) {
                console.log(list);
                vm.blockedIds = list;
            };

            vm.notificationHubProxy.client.removeProductId = function (list) {
                console.log(list);
                vm.blockedIds = list;
            };

            $.connection.hub.start()
                .done(function () {
                    console.log("Hub started success");
                })
                .fail(function (error) {
                    console.log(error);
                });
        }

        function configurePagination()
        {
            var widthScreen = (window.innerWidth > 0) ? window.innerWidth : screen.width;
            if (widthScreen < 420) vm.maxSize = 5;
            totalRecords();
        }

        function pageChanged()
        {
            getPageRecords(vm.currentPage);
        }

        function totalRecords()
        {
            dataService.getData(apiUrl + '/product/count')
                .then(function (result)
                {
                    vm.totalRecords = result.data;
                    getPageRecords(vm.currentPage);
                }, function (error) {
                    console.log(error);
                });
        }

        function getPageRecords(page)
        {
            dataService.getData(apiUrl + '/product/listPaginated?page=' + page + '&pageSize=' + vm.itemsPerPage)
                .then(function (result) {
                    vm.productList = result.data;
                }, function (error) {
                    vm.productList = [];
                    console.log(error);
                });
        }

        function list() {
            dataService.getData(apiUrl + '/product')
                .then(
                function (result) {
                    vm.productList = result.data;
                },
                function (error) {
                    vm.productList = [];
                    console.log(error);
                });
        }

        function checkId(id) {
            var index = vm.blockedIds.indexOf(id);
            return (index > -1);
        }

        function getProduct(id) {

            vm.isEdited = false;
            if (checkId(id)) {
                vm.isEdited = true;
                return;
            }            
            

            vm.product = null;
            dataService.getData(apiUrl + '/product/' + id)
                .then(function (result) {
                    vm.product = result.data;
                    debugger;
                    vm.notificationHubProxy.server.addProductId(vm.blockedIds, id);
                },
                function (error) {
                    vm.product = null;
                    console.log(error);
                });
        }

        function updateProduct() {
            if (!vm.product) return;
            dataService.putData(apiUrl + '/product', vm.product)
                .then(function (result) {
                    vm.product = {};
                    list();
                    closeModal();
                },
                function (error) {
                    vm.product = {};
                    console.log(error);
                });
        }

        function createProduct() {
            if (!vm.product) return;
            dataService.postData(apiUrl + '/product', vm.product)
                .then(function () {
                    getProduct(result.data.id);
                    list();
                    vm.showCreate = true;
                }, function (error) {
                    console.log(error);
                });
        }

        function deleteProduct() {
            dataService.deleteData(apiUrl + '/product' + vm.product.id)
                .then(function (result) {
                    list();
                    closeModal();
                }, function (error) {
                    console.log(error);
                });
        }

        function create() {
            vm.product = {};
            vm.modalTitle = 'New Product';
            vm.modalButtonTitle = 'Create';
            vm.readOnly = false;
            vm.modalFunction = createProduct;
            vm.isDelete = false;
        }

        function edit() {
            vm.showCreate = false;
            vm.modalTitle = 'Edit Product';
            vm.modalButtonTitle = 'Update';
            vm.readOnly = false,
            vm.modalFunction = updateProduct;
            vm.isDelete = false;

            if(vm.isEdited === false)
                angular.element('#modal-container').modal('show');
        }

        function detail() {
            vm.product = {};
            vm.modalTitle = 'Created Product';
            vm.modalButtonTitle = '';
            vm.readOnly = true;
            vm.modalFunction = null;
            vm.isDelete = false;
        }

        function productDelete() {
            vm.showCreate = false;
            vm.modalTitle = 'Delete Product';
            vm.modalButtonTitle = 'Delete';
            vm.readOnly = false,
                vm.modalFunction = updateProduct;
            vm.isDelete = false;
        }

        function closeModal() {
            if(vm.product)
                vm.notificationHubProxy.server.removeProductId(vm.blockedIds, vm.product.id)
            angular.element('#modal-container').modal('hide');
        }

    }
})();
(function () {
    'use strict';
    angular.module('app')
        .controller('csvController', loginController);


    function loginController(configService, $state) {
        var vm = this;
        //vm.user = {};
        vm.csvLines = [];

        vm.processFile = processFile;

        var fileInput = document.getElementById("csvViewer");        

        init();

        function init() {
            if (!configService.getLogin()) $state.go("login");
            //fileInput.addEventListener('change', readFile);
        }

        function processFile() {
            vm.csvLines = [];
            readFile(function (result) {
                var list = [];
                var totalLines = result.length;
                var count = 0;
                var csvWorker = new Worker("/js/worker.js");

                csvWorker.addEventListener('message', function (message) { //Evento que recibe la respuesta del woker
                    //el evento message recibe un mensaje y tambien devuelve un mensaje
                    list.push(message.data);
                    console.log('Processing...');
                    count++;
                    if (count >= totalLines) csvWorker.terminate();
                });

                for (var i = 0; i < result.length; i++) {
                    csvWorker.postMessage(result[i]); //llamando al worker
                }                

            });

        }
      
        function readFile(callback) {            
            var reader = new FileReader();
            reader.onload = function () { //onload: una vez de terminaste de cargar el archivo
                return callback(reader.result.split('\r\n'));
            };
            reader.readAsBinaryString(fileInput.files[0]);
        };

        
    }
})();
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
(function () {
    'use strict';

    angular.module('app')
        .directive('productForm', productForm);

    function productForm() {
        return {
            restrict: 'E',
            scope: {
                product: '='
            },
            templateUrl: 'app/private/product/directives/product-form/product-form.html'
        };
    }
})();