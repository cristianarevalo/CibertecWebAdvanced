﻿(function () {
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

        //Funciones
        vm.getProduct = getProduct;
        vm.create = create;
        vm.edit = edit;
        vm.delete = productDelete;
        vm.pageChanged = pageChanged;

        init();

        function init() {
            if (!configService.getLogin()) return $state.go('login');
            configurePagination();
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

        function getProduct(id) {
            vm.product = null;
            dataService.getData(apiUrl + '/product/' + id)
                .then(function (result) {
                    vm.product = resulta.data;
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
            angular.element('#modal-container').modal('hise');
        }

    }
})();