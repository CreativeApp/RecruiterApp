(function () {
    'use strict';
    angular.module('recruiter.applicant')
    .controller('ApplicantController', ['$scope', 'ApplicantService', ApplicantController])

    function ApplicantController($scope, ApplicantService) {
        var vm;
        vm = this;

        vm.getApplicants = function getApplicants() {
            var appl = ApplicantService.getApplicants();
        }
    }
})();