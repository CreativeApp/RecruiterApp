(function () {
    'use strict';

    angular.module('recruiter.shared.route', ['ui.router']);

    angular.module('recruiter.shared.route')
        .config(['$stateProvider', '$urlRouterProvider', '$locationProvider', function ($stateProvider, $urlRouterProvider, $locationProvider) {
            $locationProvider.html5Mode(true).hashPrefix('!');
            $urlRouterProvider.otherwise("/");
        }]).run(function ($rootScope, $state) {
            $rootScope.$on('$stateChangeSuccess', function (event, toState, toParams, fromState) {
                $state.previous = fromState;
            });
        });
})();