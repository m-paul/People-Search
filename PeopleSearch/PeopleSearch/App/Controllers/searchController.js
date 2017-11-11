(function () {

    angular.module("peopleSearchApp").controller("searchController", ["$scope", "overlayService", "personService", searchController]);

    /**
     * Controller for a search page
     * @param {Object} $scope         - controller scope
     * @param {Object} overlayService - service used to display or hide overlay
     * @param {Object} personService  - service used to interact with people
     */
    function searchController($scope, overlayService, personService) {

        var searchVm = this;
        searchVm.search = search;

        init();

        /**
         * Initializes the controller
         */
        function init() {
            searchVm.criteria = {};
            search();
        }

        /**
         * Searchs for people
         * @param {Object} criteria - search criteria. Contains a name property.
         */
        function search(criteria) {
            searchVm.showResults = false;
            searchVm.hasError = false;

            overlayService.Show();

            personService.Search(criteria)
                .then(
                    function (response) {
                        searchVm.data = response.data;
                        searchVm.showResults = true;
                        overlayService.Hide();
                    },
                    function (response) {
                        searchVm.isSearching = false;
                        searchVm.hasError = true;
                        overlayService.Hide();
                    });
        }
    }

}());