(function () {
    'use strict';
    angular.module('recruiter.applicant')
    .factory('ApplicantService', ApplicantService);

    ApplicantService.$inject = ['SharedService', 'ApplicantResource']

    function ApplicantService(SharedService, ApplicantResource) {

        var service = {
            getApplicants: getApplicants
        }

        function getApplicants() {
            var v = ApplicantResource.getApplicants().$promise;

            return v;
        }

        return service;
    };
})();