appMainModule.controller("homeViewModel", ["$scope", "homeService", function ($scope, homeService) {

    homeService.getBriefIntro($scope);

    homeService.getMyReferees($scope);

}]);