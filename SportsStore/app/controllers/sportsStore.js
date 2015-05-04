(function () {
    "use strict";

    function sportsStoreCtrl($scope, $http, $location, dataUrl, orderUrl, cart) {

        $scope.data = {};

        $http.get(dataUrl)
            .success(function (data) {
                $scope.data.products = data;
            })
            .error(function (error) {
                $scope.data.error = error;
            });

        //$scope.data = {
        //    products: [{ name: "Product 1", description: "a product", category: "category a", price: 100 },
        //        { name: "Product 2", description: "b product", category: "category a", price: 100 },
        //        { name: "Product 3", description: "c product", category: "category b", price: 150 },
        //        { name: "Product 4", description: "d product", category: "category a", price: 100 },
        //        { name: "Product 5", description: "e product", category: "category b", price: 150 }]
        //};

        $scope.sendOrder = function (shippingDetails) {
            var order = angular.copy(shippingDetails);
            order.orderItems = cart.getProducts();

            //var products = cart.getProducts();

            //var order = {
            //    shippingDetails: shippingDetails,
            //    products: cart.getProducts()
            //};

            $http.post(orderUrl, order)
                .success(function (data) {
                    $scope.data.orderId = data;
                    cart.getProducts().length = 0;
                    $scope.data.error = null;
                })
                .error(function (error) {
                    $scope.data.error = error;
                })
                .finally(function () {
                    $location.path("/complete");
                });

        }
    };

    var controllerId = "sportsStoreCtrl";
    var app = angular.module("sportsStore");
    app.constant("dataUrl", "http://localhost:63564/api/product");
    app.constant("orderUrl", "http://localhost:63564/api/order");
    app.controller(controllerId, ["$scope", "$http", "$location", "dataUrl", "orderUrl", "cart", sportsStoreCtrl]);

})();