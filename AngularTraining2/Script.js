
var app = angular
    .module("myModule", [])
    .controller("myController", function ($scope, $http,$log) {
        //get request not diplaying result for that we have make some configurations in web.config for it
        //this request will be executed asynchronoluy so data is not show immediatly when the request completes then function executes
        //short hand get method
        //$http.get('EmployeeService.asmx/GetAllEmployees')
        //    .then(function (response) {
        //        $scope.employees = response.data;
        //    });

        //separate functions for success and error callbacks functions
        var successCallBack = function (response) {
            $scope.employees = response.data;
        }
        var errorCallBack = function (response) {
            $scope.error = response.data;
        }
        $http({
            method: 'GET',
            //for error generation
            //url: 'EmployeeService.asmx/GetAllEmployee'

            url: 'EmployeeService.asmx/GetAllEmployees'
        })
            .then(
                successCallBack, errorCallBack)

                //$scope.employees = response.data;
                //$log.info(response);
                
            //},
                //function (reason) {
                //    $scope.error = reason.data;
                //    $log.info(reason);

                
            //});

    });
    