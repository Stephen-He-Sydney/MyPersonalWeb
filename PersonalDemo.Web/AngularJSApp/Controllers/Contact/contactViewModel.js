appMainModule.controller("contactViewModel", ["$rootScope", function ($rootScope) {

    $rootScope.$broadcast("changeNavBar", { status: "contact" });
    // emit would let parent scope only hear it
}]);