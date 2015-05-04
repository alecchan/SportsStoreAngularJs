(function () {
    'use strict';

    var app = angular.module("sportsStoreAdmin");
    app.constant("authUrl", "http://localhost:63564/api/user/login");
    app.constant("ordersUrl", "http://localhost:63564/api/order");
    app.controller("authCtrl", function ($scope, $http, $location, authUrl) {
        $scope.authenticate = function (user, pass) {
            $http.post(authUrl, {
                username: user,
                password: pass
            }, {
                withCredential: true
            }).success(function (data) {
                $location.path("/main");
            }).error(function (error) {
                $scope.authenticateError = error;
            });
        }
    });

    app.controller("mainCtrl", function ($scope) {
        $scope.screens = ["products", "orders"];
        $scope.current = $scope.screens[0];

        $scope.setScreen = function (index) {
            $scope.current = $scope.screens[index];
        };

        $scope.getScreen = function () {
            return $scope.current == "products" ? "app/views/adminProducts.html" : "app/views/adminOrders.html";
        };
    });

    app.controller("ordersCtrl", function ($scope, $http, ordersUrl) {
        $http.get(ordersUrl, {withCredentials: true})
            .success(function (data) {
                $scope.orders = data;
            })
            .error(function (error) {
                $scope.error = error;
            });

        $scope.selectedOrder = null;

        $scope.selectOrder = function (order) {
            $scope.selectedOrder = order;
        };

        $scope.calcTotal = function (order) {
            var total = 0;
            for (var i = 0; i < order.orderItems.length; i++) {
                total += order.orderItems[i].count * order.orderItems[i].price;
            }
            return total;
        };


    });
})();