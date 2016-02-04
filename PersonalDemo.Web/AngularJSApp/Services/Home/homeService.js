appMainModule.service('homeService', ['serviceHelper', function (serviceHelper) {
    this.getBriefIntro = function ($scope) {
        serviceHelper.apiGet($scope, "api/briefIntro").success(function (data) {
            $scope.mybriefIntro = data;
        })
        .error(function () {
        });
    };

    this.getMyReferees = function ($scope) {
        serviceHelper.apiGet($scope, "api/referees").success(function (data) {
            $scope.myReferees = data;
        })
        .error(function () {
          
        });
    };
}]);
