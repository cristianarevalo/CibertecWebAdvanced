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