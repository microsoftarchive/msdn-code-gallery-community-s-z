applicationModule.controller('treePageController',
    function ($scope, treePageService) {
        treePageService.get().then(function(treePageItem) {
            $scope.treePageItem = treePageItem;
        });

        $scope.applicationBlocked = false;

        $scope.tempData = {};
        $scope.tempData.selectedNode = null;
        $scope.tempData.adjacentNodes = null;

        $scope.clearSelectedNode = function() {
            if ($scope.tempData.selectedNode) {
                $scope.tempData.selectedNode.isSelected = false;
                $scope.tempData.selectedNode = null;
                $scope.tempData.adjacentNodes = null;
            }
        };

        $scope.addNewNode = function() {
            var nodeName = prompt("Please enter node name.", "Node name");
            if (!nodeName) {
                alert("Value for node name is not valid.");
            }

            var rootNodes = $scope.treePageItem.treeViewPageNodes;

            if ($scope.tempData.selectedNode) {
                rootNodes = $scope.tempData.selectedNode.childNodes;
            }

            var parentId = $scope.tempData.selectedNode ? $scope.tempData.selectedNode.id : null;

            var newNode = {
                "isExpanded": false,
                "childNodes": [],
                "id": null,
                "parentId": parentId,
                "nodeName": nodeName,
                "isSelected": false
            }

            rootNodes.push(newNode);
        };

        $scope.removeNode = function() {
            if (!$scope.tempData.selectedNode) {
                alert("Please select node for remove.");
            }

            var index = $scope.tempData.adjacentNodes
                .indexOf($scope.tempData.selectedNode);

            if (index > -1) {
                $scope.tempData.adjacentNodes.splice(index, 1);
            }
        };

        $scope.saveTreeData = function () {
            $scope.applicationBlocked = true;
            treePageService.update($scope.treePageItem.treeViewPageNodes)
                .success(function (treeDataMessage) {
                if (treeDataMessage.dataProcessedSuccessfully) {
                    alert("Data saved.");
                } else {
                    alert("Was error on server.");
                }

                $scope.applicationBlocked = false;
            });
        };
    });