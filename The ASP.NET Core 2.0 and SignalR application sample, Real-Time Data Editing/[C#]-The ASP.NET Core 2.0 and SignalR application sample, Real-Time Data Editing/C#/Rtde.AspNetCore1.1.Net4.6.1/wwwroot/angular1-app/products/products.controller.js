(function () {
    'use strict';
    angular.module('application').controller('productsController', productsController);

    productsController.$inject = ['$scope', 'productsService', 'productMessageHub'];

    function productsController($scope, productsService, productMessageHub) {
        var vm = this;

        vm.applicationBlocked = false;
        vm.products = [];
        vm.tableBlocked = false;
        vm.selectedProduct = null;
        vm.newProductAdded = false;

        vm.messagesList = [];

        vm.tableRowClick = tableRowClick;
        vm.addNewProduct = addNewProduct;
        vm.saveProduct = saveProduct;
        vm.deleteProduct = deleteProduct;

        activate();

        function activate() {
            
            productMessageHub.client.productAdded = function (product) {
                productAdded(product);
                setOperationResulStatus('Product with Id ' + product.id + ' added');
            };

            productMessageHub.client.productUpdated = function(product) {
                productUpdated(product);
                setOperationResulStatus('Product with Id ' + product.id + ' updated');
            };

            productMessageHub.client.productRemoved = function(productId) {
                productRemoved(productId);
                setOperationResulStatus('Product with Id ' + productId + ' deleted');
            };

            return getProducts().then(function() {
                console.log('All products were loaded.');
            });
        }

        function getProducts() {
            return productsService.get()
                .then(function(data) {
                    vm.products = data;
                    return vm.products;
                });

        }

        function tableRowClick(product) {
            if (vm.tableBlocked === true) {
                return;
            }

            if (vm.newProductAdded === true && vm.tableBlocked === false) {
                vm.tableBlocked = true;
                return;
            }

            vm.selectedProduct = product;
        }

        function addNewProduct() {
            var newProduct = { id: null, name: null, description: null };
            vm.selectedProduct = newProduct;
            vm.newProductAdded = true;
        }

        function saveProduct() {
            if (vm.newProductAdded === true) {
                productMessageHub.invoke('addProduct', vm.selectedProduct);
            } else {
                productMessageHub.invoke('updateProduct', vm.selectedProduct);
            }

            resetState();
        }

        function deleteProduct() {
            if (vm.newProductAdded === true) {
                resetState();
            } else {
                productMessageHub.invoke('removeProduct', vm.selectedProduct.id);
            }
        }

        function resetState() {
            vm.tableBlocked = false;
            vm.selectedProduct = null;
            vm.newProductAdded = false;
        }

        function setOperationResulStatus(statusString) {
            var date = new Date();
            var dateString = date.getHours() + ':' + date.getMinutes() + ':' + date.getSeconds();
            vm.messagesList.push({ dateString: dateString, statusString: statusString });
            $scope.$apply();
        }

        function productAdded(product) {

            var newProduct = {
                id: product.Id,
                name: product.Name,
                description: product.Description
            };

            vm.products.push(newProduct);
        }

        function productUpdated(product) {
            var updatedProduct = getProductById(product.Id);
            updatedProduct.name = product.Name;
            updatedProduct.description = product.Description;
        }

        function productRemoved(productId) {
            removeProductById(productId);
            resetState();
        }

        function removeProductById(productId){
            var i = vm.products.length;
            var copy = vm.products.slice();

            while (i--) {
                if (copy[i].id === productId) {
                    copy.splice(i, 1);
                    vm.products = copy;
                    return;
                }
            }
        }

        function getProductById(productId) {
            for (var i = 0; i < vm.products.length; i++) {
                if (vm.products[i].id === productId) {
                    return vm.products[i];
                }
            }

            return null;
        }
    }
})();