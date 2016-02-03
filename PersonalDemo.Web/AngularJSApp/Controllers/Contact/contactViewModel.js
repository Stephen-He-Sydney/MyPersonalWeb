appMainModule.controller("contactViewModel", ["$scope", "$rootScope", function ($scope, $rootScope) {

    $rootScope.$broadcast("changeNavBar", { status: "contact" });
    // emit would let parent scope only hear it

    $scope.submitForm = function (isValid) {

        if (isValid) {
            alert('Valid!!!');
        }
    };

}]);