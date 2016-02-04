appMainModule.controller("portfolioViewModel", ["$rootScope", function ($rootScope) {

    $rootScope.$broadcast("changeNavBar", { status: "portfolio" });
    // emit would let parent scope only hear it
}]);