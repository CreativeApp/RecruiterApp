(function () {
    'use strict';
    angular.module('recruiter.applicant', ['recruiter.shared.service'])
    .config(['$stateProvider', '$urlRouterProvider', function ($stateProvider) {
        $stateProvider
                    .state('recruiter', {
                        url: '/recruiter',

                        templateUrl: 'application/applicant/recruiterHome.html'
                    })
                    .state('recruiter.home', {
                        url: '/home',
                        templateUrl: 'application/applicant/recruiterView.html',
                        controller: 'ApplicantController',
                        controllerAs: 'vm'
                    })
    }]);
})();