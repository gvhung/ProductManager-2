var ListCtrl = function ($scope, $location, products) {
    
    console.log("Start Collecting");
    $scope.products = products.query();
    console.log($scope.products);

    //Calculate price Section
    $scope.CalulateMultiply = function (productPrice, productQuantity) {
        $scope.CalculatedProductValue = CalulateMultiply(productPrice, productQuantity);
    };

    //Removes the current item
    $scope.removeOfferItem = function(index) {
        $scope.OfferItems.splice(index, 1);
    };
    
    //Add products to Offer Section
    $scope.OfferItems = OfferItems;

    $scope.AddProductToOffer = function (currentProduct, productQuantity) {
        if (typeof currentProduct !== 'undefined') {
            if (productQuantity == 0 || typeof productQuantity == 'undefined') {
                productQuantity = 1;
            }
            //console.log("Adding: ");
            //console.log(productQuantity);
            //console.log(currentProduct);

            var totalPriceCurrentProduct = CalulateMultiply(currentProduct.Prijs, productQuantity);

            $scope.OfferItems.push({
                ProductName: currentProduct.Naam,
                ProductNumber: currentProduct.Nummer,
                ProductPrice: currentProduct.Prijs,
                productQuantity: productQuantity,
                BtwPercentage: currentProduct.BtwId,
                TotalPrice: totalPriceCurrentProduct
            });
        };
    };

    //Calculate total price offer
    $scope.totalPriceCurrentProduct = function() {        
        var total = 0;
        for (var i = 0; i < $scope.OfferItems.length; i++) {
            var product = $scope.OfferItems[i];
            total += (product.ProductPrice * product.productQuantity);
        }
        return total;
    };   
};

var totalPriceOffer = 0;


var OfferItems = [{
    ProductName: "",
    ProductNumber: 0,
    ProductPrice: 0,
    productQuantity: 0,
    BtwPercentage: 0,
    TotalPrice: 0
}];

//var OfferProduct = {
//    ProductName: "",
//    ProductNumber: 0,
//    ProductPrice: 0,
//    productQuantity: 0,
//    BtwPercentage: 0
//};

var CalulateMultiply = function (price, amount) {
    if (price == null) {
        price = 0;
    }
    if (amount == 0 || amount == null) {
        amount = 1;
    }
    return amount * price;
};

var TodoApp = angular.module("ProductApp", [
        "ngResource",
        "ngRoute"
    ])
    .config(function($routeProvider) {
        $routeProvider.
            when('/', {
                controller: ListCtrl,
                templateUrl: 'Static/Product.html'
            })
            .otherwise({
                redirectTo: '/'
            });
    })
    .factory('products', function($resource) {
        return $resource('Calculator/JsonResultProductList/:id', { id: '@id' }, { update: { method: 'PUT' } });
    })
    // Returns a date which Angular van convert in the view
    // usage {{OriginalDateString | jsDate | Date : 'format'}}
    // {{product.WijziginsDatum | jsDate | date : 'EEE dd MMM yyyy H:mm:ss' }}
    .filter("jsDate", function() {
        return function(x) {
            return new Date(parseInt(x.substr(6)));
        };
    });















// Declare the model
calculatorModel = {
    result: 0, // Holds the actual result in memory
    operation: "",
    currentNumber: "0",
    currentDisplay: "", // Shows the input until the result is shown

    reset: function () {
        this.result = 0;
        this.operation = "";
        this.currentNumber = "0";
        this.currentDisplay = "";
    },

    setOperation: function (operationToSet) {
        this.operation = operationToSet;
        if (calculatorModel.currentNumber === "0") {
            this.currentDisplay += "0";
        }

        this.currentDisplay += " " + this.operation + " ";
        this.calculate();

        this.currentNumber = "";
    },

    calculate: function () {

        switch (this.operation) {
            case "+":
                this.result = this.result + parseFloat(this.currentNumber);
                break;

            case "-":
                this.result = this.result - parseFloat(this.currentNumber);
                break;
        }
    }

};

// declare the calculator-module
var calculatorApp = angular.module('calculatorApp', ['calculatorModule']);
var calculatorModule = angular.module('calculatorModule', []);

// Add the calculator-controller to module
calculatorModule.controller('calculatorController', ['$scope', function ($scope) {
    $scope.calculator = calculatorModel;
    $scope.numberButtonClicked = function (clickedNumber) {
        if (calculatorModel.currentNumber === "0") {
            calculatorModel.currentNumber = "";
            calculatorModel.currentDisplay = "";
        }

        calculatorModel.currentNumber += clickedNumber;
        calculatorModel.currentDisplay += clickedNumber;
    };

    $scope.operationButtonClicked = function (clickedOperation) {
        calculatorModel.setOperation(clickedOperation);
    };

    $scope.enterClicked = function () {
        calculatorModel.calculate();
        calculatorModel.currentDisplay = calculatorModel.result;
    };

    $scope.resetClicked = function () {
        calculatorModel.reset();
    };
}]);