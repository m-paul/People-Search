(function () {

    angular.module("peopleSearchApp").controller("searchController", ["$scope", "overlayService", "personService", searchController]);

    function searchController($scope, overlayService, personService) {

        var searchVm = this;
        searchVm.search = search;

        init();

        function init() {
            searchVm.criteria = {};
            search();
        }

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