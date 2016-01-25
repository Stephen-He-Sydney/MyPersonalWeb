appMainModule.controller("resumeViewModel",["$scope", "resumeService", function ($scope, resumeService) {

    resumeService.getMyProfile($scope);

    resumeService.getMySkillSummary($scope);

    resumeService.getMyEduBackground($scope);

    resumeService.getMyProjects($scope);

    resumeService.getMyWorkExps($scope);

}]);