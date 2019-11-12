applicationModule.controller('productsController',
    function ($scope, productsService, productMessageHub) {
    productsService.get().then(function (products) { $scope.products = products; });

    $scope.applicationBlocked = false;
    $scope.tableBlocked = false;
    $scope.selectedProduct = null;
    $scope.newProductAdded = false;

    $scope.messagesList = [];

    // Method which receives data.
    productMessageHub.client.handleProductMessage = function(message) {
        // Method which handles messages.
        $scope.receivedMessageHandler(message);
    };

    $scope.tableRowClick = function(product) {
        if ($scope.tableBlocked === true) {
            return;
        }

        if ($scope.newProductAdded === true && $scope.tableBlocked === false) {
            $scope.tableBlocked = true;
            return;
        }

        $scope.selectedProduct = product;
    };

    $scope.addNewProduct = function () {
        var newProduct = { id: null, name: null, description: null };
        $scope.products.push(newProduct);
        $scope.selectedProduct = newProduct;
        $scope.newProductAdded = true;
        $scope.tableBlocked = true;
    };

    $scope.saveProduct = function () {
        $scope.applicationBlocked = true;

        if ($scope.newProductAdded == true) {
            // Message type – 1, data for insert.
            $scope.sendProductDataMessage(1);
        } else {
            // Message type – 2, data for update.
            $scope.sendProductDataMessage(2);
        }
    };

    $scope.deleteProduct = function () {
        if ($scope.newProductAdded === true) {
            $scope.removeProductById($scope.selectedProduct.id);
            $scope.resetState();
        } else {
            // Message type – 3, data for delete.
            $scope.sendProductDataMessage(3);
        }
    };

    $scope.sendProductDataMessage = function(messageType) {

        // Create the new message for sending.
        var productDataMessage = new Object();
        productDataMessage.Product = new Object();

        // Set message type.
        productDataMessage.MessageType = messageType;

        // Set message data.
        productDataMessage.Product.Id = $scope.selectedProduct.id;
        productDataMessage.Product.Name = $scope.selectedProduct.name;
        productDataMessage.Product.Description = $scope.selectedProduct.description;

        // Send data to server.
        productMessageHub.server.handleProductMessage(JSON.stringify(productDataMessage));
    };

    $scope.receivedMessageHandler = function (productDataMessageJsonString) {
        var productDataMessage = JSON.parse(productDataMessageJsonString);
        $scope.applicationBlocked = false;

        if (productDataMessage.DataProcessedSuccessfully) {

            switch (productDataMessage.MessageType) {
            case 1: // New record.
                $scope.insertProduct(productDataMessage.Product);
                break;
            case 2: // Update existing record.
                $scope.updateProduct(productDataMessage.Product);
                break;
            case 3: // Delete record.
                $scope.removeProductById(productDataMessage.Product.Id);
                $scope.resetState();
                break;
            default:
                return;
            }
        }

        $scope.setOperationResulStatus(productDataMessage.ResponseMessage);
    };

    $scope.resetState = function() {
        $scope.tableBlocked = false;
        $scope.selectedProduct = null;
        $scope.newProductAdded = false;
    };

    $scope.setOperationResulStatus = function (statusString) {
        var date = new Date();
        var dateString = date.getHours() + ':' + date.getMinutes() + ':' + date.getSeconds();
        $scope.messagesList.push({ dateString: dateString, statusString: statusString });
        $scope.$apply();
    }

    $scope.insertProduct = function (product) {
        if ($scope.getProductById(product.Id) == null) {
            var newProduct = {
                id: product.Id,
                name: product.Name,
                description: product.Description
            };
            $scope.products.push(newProduct);
        } else {
            $scope.updateProduct(product);
            $scope.tableBlocked = false;
            $scope.newProductAdded = false;
        }
    };

    $scope.updateProduct = function (updatedProduct) {
        var product = $scope.getProductById((updatedProduct.Id));
        product.name = updatedProduct.Name;
        product.description = updatedProduct.Description;
    };

    $scope.removeProductById = function (productId)
    {
        var i = $scope.products.length;

        while (i--) {
            if ($scope.products[i].id == productId) {
                $scope.products.splice(i, 1);
                $scope.$apply();
                return;
            }
        }
    }

    $scope.getProductById = function(productId)
    {
        for (var i = 0; i < $scope.products.length; i++) {
            if ($scope.products[i].id == productId) {
                return $scope.products[i];
            }
        }

        return null;
    }
});