applicationModule.directive('treeview', function () {
    return {
        restrict: "E",
        replace: true,
        scope: {
            nodes: '=',
            tempData: '='
        },
        template: '<ul><node ng-repeat="node in nodes" ' +
            'node="node" temp-data="tempData" adjacent-nodes="nodes"></node></ul>'
    };
}
);

applicationModule.directive('node', [
    '$compile', function ($compile) {
        return {
            restrict: "E",

            replace: true,

            scope: {
                node: '=',
                tempData: '=',
                adjacentNodes: '='
            },

            template: '<li><div ng-if="node.childNodes.length > 0" ' +
                'ng-click="expandOrCollapseNode(node);" ' +
                'ng-class="{true:\'hitarea collapsable\', ' +
                'false:\'hitarea expandable\'}[node.isExpanded]"></div>' +
                '<span ng-class="{true: \'selectedNode\'}[node.isSelected]" ' +
                'ng-click="nodeClick(node, $event);" temp-data="tempData">' +
                '{{node.nodeName}}</span></li>',

            controller: [
                '$scope', '$element', function ($scope, $element) {
                    $scope.nodeClick = function (node, event) {

                        if ($scope.tempData.selectedNode) {
                            $scope.tempData.selectedNode.isSelected = false;
                        }

                        $scope.tempData.selectedNode = node;
                        $scope.tempData.adjacentNodes = $scope.adjacentNodes;
                        node.isSelected = true;

                        event.stopImmediatePropagation();
                    };

                    $scope.expandOrCollapseNode = function (pageNode) {

                        if (pageNode.isExpanded == true) {
                            pageNode.isExpanded = false;
                        } else {
                            pageNode.isExpanded = true;
                        }
                    };
                }
            ],

            link: function (scope, element, attrs) {
                //console.log(angular.isArray(scope.node.childNodes));
                if (angular.isArray(scope.node.childNodes)) {
                    var content = $compile('<treeview ng-if="node.isExpanded"' +
                        'nodes="node.childNodes" temp-data="tempData"></treeview>')(scope);
                    element.append(content);
                }
            }
        };
    }
]);
