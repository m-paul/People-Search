(function () {

    angular.module("peopleSearchApp").factory("personService", ["$http", "$q", personService]);

    function personService($http, $q) {

        var api = {
            Search: search
        };

        var apiRoot = "http://localhost:32612/api";

        function search(criteria) {
            var url = apiRoot + "/person/search"
            return $http.post(url, criteria);
        }

        return api;
    }

}());