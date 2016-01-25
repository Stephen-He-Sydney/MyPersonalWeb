appMainModule.service('resumeService', ['serviceHelper', function (serviceHelper) {
 
    this.getMyProfile = function ($scope) {
        serviceHelper.apiGet($scope, "api/profile").success(function (data) {
            $scope.myProfile = data;
        })
        .error(function () {
        });
    };

    this.getMySkillSummary = function ($scope) {
        serviceHelper.apiGet($scope, "api/skillSummary").success(function (data) {
            $scope.mySkillSummary = data;
        })
        .error(function () {
        });
    };

    this.getMyEduBackground = function ($scope) {
        serviceHelper.apiGet($scope, "api/education").success(function (data) {
            $scope.myEduBackground = data;
        })
        .error(function () {
        });
    };

    this.getMyProjects = function ($scope) {
        serviceHelper.apiGet($scope, "api/projects").success(function (data) {
            $scope.myProjects = data;
        })
        .error(function () {
        });
    };

    this.getMyWorkExps = function ($scope) {
        serviceHelper.apiGet($scope, "api/workExps").success(function (data) {
            $scope.myWorkExps = data;
        })
        .error(function () {
        });
    };

}]);