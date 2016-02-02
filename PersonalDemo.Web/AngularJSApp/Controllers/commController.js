appMainModule.controller("navController", ["$scope", function ($scope) {

    $scope.allMenus = ["home", "resume", "portfolio", "blog", "contact"];

    $scope.select = function (aMenu) {
        $scope.selected = aMenu;
    };

    $scope.isActive = function (aMenu) {
        return $scope.selected === aMenu;
    }

    $scope.$on('changeNavBar', function (e, obj) {
        $scope.select(obj.status);
        $scope.isActive(obj.status);
    });
}]);