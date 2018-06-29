(function () {

    var app = angular.module('quoteManagementApp', []);
    var uri = '/api/QuoteManagement';
    var hub = $.connection.quoteManagementHub
    
    app.controller('quoteManagementController', ['$http', '$scope', function ($http, $scope) {
        $scope.quotes = [];

        $scope.getAllQuotes = function () {
            $http.get(uri + "/GetAllQuotes")
                .then(function successCallback(response) {
                    if (response.data !== undefined) {
                        $scope.quotes = response.data;
                    }
                }, function errorCallback(response) {
                    console.log(response);
                });
        };
        $scope.getAllQuotes();

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
            if ($scope.quotes !== undefined) {
                angular.forEach($scope.quotes, function (value, key) {
                    if (value.Id == item) {
                        $scope.quotes.splice(key, 1);
                        $scope.$apply();
                        return false;
                    }
                });   
            }
        }

        $.connection.hub.start();
    }]);
})();