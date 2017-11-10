(function () {

    angular.module("peopleSearchApp").factory("personService", ["$http", "$q", personService]);

    /**
     * Manages person data
     * @param {Object} $http - Responsible for sending ajax calls
     * @param {Object} $q    - Used for the creation of promises
     * @return {Object} returns an API
     */
    function personService($http, $q) {

        var api = {
            Search: search
        };

        var apiRoot = "http://localhost:32612/api";

        /**
         * Searchs for people
         * @param {Object} criteria - search criteria. Contains a name property.
         * @return {Object} returns a promise
         */
        function search(criteria) {
            var url = apiRoot + "/person/search"
            return $http.post(url, criteria);
        }

        return api;
    }

}());