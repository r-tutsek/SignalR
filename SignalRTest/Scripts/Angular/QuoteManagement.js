(function () {

    var app = angular.module('quoteManagementApp', []);
    var uri = '/api/QuoteManagement';
    var hub = $.connection.quoteManagementHub;
    //console.log($.connection);
        
    app.controller('quoteManagementController', ['$http', '$scope', function ($http, $scope) {
        $scope.subscribableEvents = ["add", "update", "delete"];
        $scope.subscribedEvents = [];
        $scope.quotes = [];
        $scope.editing = false;
        $scope.addOrUpdateBtnText = "Add";
        $scope.editedQuoteId = 0;

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

        $scope.addOrUpdateQuote = function () {
            if ($scope.quote !== undefined && $scope.quote !== "") {
                var requestModel = {
                    Value: $scope.quote
                };
                if ($scope.editedQuoteId !== undefined & $scope.editedQuoteId !== 0) {
                    requestModel["Id"] = $scope.editedQuoteId;
                    $http.post(uri + "/UpdateQuote", requestModel)
                        .then(function successCallback(response) {
                            console.log(response);
                        }, function errorCallback(response) {
                            console.log(response);
                        });                   
                } else {
                    $http.post(uri + "/AddQuote", requestModel)
                        .then(function successCallback(response) {
                            console.log(response);
                        }, function errorCallback(response) {
                            console.log(response);
                        });                   
                }
                $scope.editing = false;
                $scope.editedQuoteId = 0;
                $scope.editedQuote = "";
                $scope.quote = "";
                $scope.addOrUpdateBtnText = "Add";
            }
        };

        $scope.editAction = function (quoteId, quote) {
            $scope.editing = true;
            $scope.editedQuoteId = quoteId;
            $scope.editedQuote = quote;
            $scope.quote = quote;
            $scope.addOrUpdateBtnText = "Update";
        };

        $scope.cancelEditAction = function () {
            $scope.editing = false;
            $scope.editedQuoteId = 0;
            $scope.editedQuote = "";
            $scope.quote = "";
            $scope.addOrUpdateBtnText = "Add";
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

        $scope.subscribeToEvent = function () {
            if ($scope.subscribedEvents.indexOf($scope.events) == -1) {
                $scope.subscribedEvents.push($scope.events);
                hub.server.joinGroup($scope.subscribedEvents);
            }
        };

        $scope.unsubscribeFromEvent = function (event) {
            var index = -1;
            if ((index = $scope.subscribedEvents.indexOf(event)) !== -1) {
                $scope.subscribedEvents.splice(index, 1);
                hub.server.leaveGroup(event);
            }
        };

        hub.client.addQuote = function (item) {
            $scope.quotes.push(item);
            $scope.$apply();
        }
        
        hub.client.updateQuote = function (item) {
            angular.forEach($scope.quotes, function (value, key) {
                if (value.Id == item.Id) {
                    $scope.quotes[key] = item;
                    $scope.$apply();
                    return false;
                }
            });
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