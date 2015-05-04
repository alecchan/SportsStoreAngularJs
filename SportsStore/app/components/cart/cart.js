(function () {
    'use strict';

    function cartFunc() {
        var cartData = [];

        function addProduct (id, name, price) {
            var addedToExistingItem = false;
            for(var i =0; i < cartData.length; i++) {
                if (cartData[i].id == id) {
                    cartData[i].count++;
                    addedToExistingItem = true;
                    break;
                }
            }
            if (!addedToExistingItem) {
                cartData.push({
                    count: 1,
                    productId: id,
                    price: price,
                    name: name
                });
            }
        }

        function removeProduct(id) {
            for (var i = 0; i < cartData.length; i++) {
                if (cartData[i].id == id) {
                    cartData.splice(i, 1);
                    break;
                }
            }
        }

        function getProducts(){
            return cartData;
        }

        return {
            addProduct: addProduct,
            removeProduct: removeProduct,
            getProducts: getProducts
        };
    }

    var app = angular.module("cart", []);
    app.factory("cart", cartFunc);
    app.directive("cartSummary", function (cart) {
        return {
            restrict: "E",
            templateUrl: "/app/components/cart/cartSummary.html",
            controller: function ($scope) {
                var cartData = cart.getProducts();

                $scope.total = function () {
                    var total = 0;
                    for (var i = 0; i < cartData.length; i++) {
                        total += (cartData[i].price * cartData[i].count);
                    }
                    return total;
                }

                $scope.itemCount = function () {
                    var total = 0;
                    for (var i = 0; i < cartData.length; i++) {
                        total += cartData[i].count;
                    }
                    return total;
                }
            }
        };
    });
}());