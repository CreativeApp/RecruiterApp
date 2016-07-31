(function () {
    'use strict';
    angular.module('recruiter.shared.service')
    .factory('ApplicantResource', ['$resource', ApplicantResource]);

    function ApplicantResource($resource) {
        return $resource('http://localhost:60109/dashboard/:key/:action', null, {
            getApplicants: {
                method: 'GET',
                isArray: true,
                params: {
                    key: 1,
                    action: 'GetApplicants'
                }
            }
        });
    }
})();