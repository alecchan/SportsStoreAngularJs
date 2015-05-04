(function () {
    'use strict';
    var app = angular.module("sportsStoreAdmin");
    app.constant("productUrl", "http://localhost:63564/api/product");
    app.config(function ($httpProvider) {
        $httpProvider.defaults.withCredentials = true;
    });
    app.controller("productCtrl", function ($scope, $resource, productUrl) {
        $scope.productsResource = $resource(productUrl + ":id", {id: "@id"});

        $scope.products = [{name: "alec", category: "apple", price: 234}];
        $scope.listProducts = function () {
            $scope.products = $scope.productsResource.query(function () {
                console.log($scope.products);
            });
        };

        $scope.deleteProduct = function (product) {
            product.$delete().then(function () {
                $scope.products.splice($scope.products.indexof(product), 1);
            });
        };

        $scope.createProduct = function (product) {
            new $scope.productsResource(product).$save()
                .then(function (newProduct) {
                    $scope.products.push(newProduct);
                    $scope.editedProduct = null;
                });
        };

        $scope.updateProduct = function (product) {
        //   product.$save();

            for (var i = 0; i < $scope.products.length; i++) {
                if (product.productID == $scope.products[i].productID) {
                    angular.copy(product, $scope.products[i]);
                    break;
                }
            }
            $scope.editedProduct = null;
        };

        $scope.startEdit = function (product) {
            var pCopy = {};
            angular.copy(product, pCopy)
            $scope.editedProduct = pCopy;
        };

        $scope.cancelEdit = function () {
            $scope.editedProduct = null;
        };

        $scope.listProducts();

    });
})();