var appMainModule = angular.module('mainModel', ['ngRoute'])
                            .config(["$routeProvider", "$locationProvider", function ($routeProvider, $locationProvider) {
                                $routeProvider.when('/', { templateUrl: '/AngularJSApp/Views/Home.html', controller: 'homeViewModel' });
                                $routeProvider.when('/home', { templateUrl: '/AngularJSApp/Views/Home.html', controller: 'homeViewModel' });
                                $routeProvider.when('/resume', { templateUrl: '/AngularJSApp/Views/Resume.html', controller: 'resumeViewModel' });
                                $routeProvider.when('/portfolio', { templateUrl: '/AngularJSApp/Views/Portfolio.html', controller: 'portfolioViewModel' });
                                $routeProvider.when('/blog', { templateUrl: '/AngularJSApp/Views/Blog.html' });
                                $routeProvider.when('/contact', { templateUrl: '/AngularJSApp/Views/Contact.html', controller: 'contactViewModel' });
                                $routeProvider.otherwise({
                                    redirectTo: '/'  //Work together with RoutConfig.cs
                                });

                                $locationProvider.html5Mode({
                                    enabled: true,
                                    requireBase: false
                                });

                                //$locationProvider.html5Mode(true);
                            }]);

appMainModule.service('serviceHelper', ['$http', function ($http) {

    this.apiGet = function ($scope, url) {
        return $http({
            method: "GET",
            url: url,
            headers: { 'Content-Type': 'application/json' }
        }).success(function (data) {
            //$scope.data = data;

        }).error(function (data) {
            //$scope.state = "Server side error. Please refresh page";
        });
    };
}]);


