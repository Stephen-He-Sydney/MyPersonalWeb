appMainModule.controller("resumeViewModel", ["$scope", "resumeService", "$rootScope", function ($scope, resumeService, $rootScope) {

    $rootScope.$broadcast("changeNavBar", { status: "resume" });
    // emit would let parent scope only hear it

    resumeService.getMyProfile($scope);

    resumeService.getMySkillSummary($scope);

    resumeService.getMyEduBackground($scope);

    resumeService.getMyProjects($scope);

    resumeService.getMyWorkExps($scope);

}]);