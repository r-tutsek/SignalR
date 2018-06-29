(function () {
    var app = angular.module('quoteManagementApp', []);
    var uri = '/api/QuoteManagement';
    var hub = $.connection.quoteManagementHub
    
    app.controller('quoteManagementController', ['$http', '$scope', function ($http, $scope) {
        $scope.quotes = [];

        $scope.addQuote = function () {
            if ($scope.quote !== undefined) {
                var requestModel = {
                    Value: $scope.quote
                };
                $http.post(uri + "/AddQuote", requestModel)          
                    .then(function successCallback(response) {
                        console.log(response);
                    }, function errorCallback(response) {
                        console.log(response);
                    });
            }
        };

        $scope.updateQuote = function (quoteId) {
            if ($scope.quote !== undefined && quoteId !== undefined) {
                var requestModel = {
                    Id: quoteId,
                    Value: $scope.quote
                };
                $http.post(uri + "/UpdateQuote", requestModel)
                    .then(function successCallback(response) {
                        console.log(response);
                    }, function errorCallback(response) {
                        console.log(response);
                    });
            }
        };

        $scope.deleteQuote = function (quoteId) {
            var requestModel = {
                Id: quoteId
            };
            $http.post(uri + "/DeleteQuote", requestModel)
                .then(function successCallback(response) {
                    console.log(response);
                }, function errorCallback(response) {
                    console.log(response);
                });
        };
        
        hub.client.addQuote = function (item) {
            $scope.quotes.push(item);
            $scope.$apply();
        }

        hub.client.deleteQuote = function (item) {
            var index = $scope.quotes.indexOf(item);
            $scope.quotes.splice(index, 1);
            $scope.$apply();
        }

        $.connection.hub.start();

        /*$scope.getAll = function () {
            
        };
        $scope.postOne = function () {
            $http.post(uri, {
                COMPLAINT_ID: 0,
                CUSTOMER_ID: $scope.customerId,
                DESCRIPTION: $scope.descToAdd
            })
                .success(function (data, status) {
                    $scope.errorToAdd = null;
                    $scope.descToAdd = null;
                })
                .error(function (data, status) {
                    $scope.errorToAdd = errorMessage(data, status);
                })
        };
        $scope.putOne = function () {
            $http.put(uri + '/' + $scope.idToUpdate, {
                COMPLAINT_ID: $scope.idToUpdate,
                CUSTOMER_ID: $scope.customerId,
                DESCRIPTION: $scope.descToUpdate
            })
                .success(function (data, status) {
                    $scope.errorToUpdate = null;
                    $scope.idToUpdate = null;
                    $scope.descToUpdate = null;
                })
                .error(function (data, status) {
                    $scope.errorToUpdate = errorMessage(data, status);
                })
        };
        $scope.deleteOne = function (item) {
            $http.delete(uri + '/' + item.COMPLAINT_ID)
                .success(function (data, status) {
                    $scope.errorToDelete = null;
                })
                .error(function (data, status) {
                    $scope.errorToDelete = errorMessage(data, status);
                })
        };
        $scope.editIt = function (item) {
            $scope.idToUpdate = item.COMPLAINT_ID;
            $scope.descToUpdate = item.DESCRIPTION;
        };
        $scope.toShow = function () {
            return $scope.complaints && $scope.complaints.length > 0;
        };

        //signalr client functions
        hub.client.addItem = function (item) {
            $scope.complaints.push(item);
            $scope.$apply();
        }
        hub.client.deleteItem = function (item) {
            var array = $scope.complaints;
            for (var i = array.length - 1; i >= 0; i--) {
                if (array[i].COMPLAINT_ID === item.COMPLAINT_ID) {
                    array.splice(i, 1);
                    $scope.$apply();
                }
            }
        }
        hub.client.updateItem = function (item) {
            var array = $scope.complaints;
            for (var i = array.length - 1; i >= 0; i--) {
                if (array[i].COMPLAINT_ID === item.COMPLAINT_ID) {
                    array[i].DESCRIPTION = item.DESCRIPTION;
                    $scope.$apply();
                }
            }
        }
        $.connection.hub.start();*/
    }]);
})();