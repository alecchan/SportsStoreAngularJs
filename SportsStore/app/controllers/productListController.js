(function () {

    var app = angular.module("sportsStore");
    app.constant("productListActiveClass", "btn-primary");
    app.constant("productListPageCount", 3);
    app.controller("productListCtrl", function ($scope, $filter, productListActiveClass, productListPageCount, cart) {
        var selectedCategory = null;

        $scope.selectCategory = function (newCategory) {
            selectedCategory = newCategory;
            $scope.selectedPage = 1;
        };

        $scope.categoryFilterFn = function (product) {
            return selectedCategory == null || product.category == selectedCategory;
        };

        $scope.getCategoryClass = function (category) {
            return selectedCategory == category ? productListActiveClass : "";
        };

        $scope.selectedPage = 1;
        $scope.pageSize = productListPageCount;

        $scope.selectPage = function (newPage) {
            $scope.selectedPage = newPage;
        };

        $scope.getPageClass = function (page) {
            return $scope.selectedPage == page ? productListActiveClass : "";
        };

        $scope.addProductToCart = function(product){
            cart.addProduct(product.productID, product.name, product.price);
        };
    });

})();