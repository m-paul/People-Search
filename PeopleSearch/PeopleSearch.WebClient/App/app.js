// IIFE - immediately invoked function expression to avoid adding to the js global namespace
(function () {

    var peopleSearchApp = angular.module("peopleSearchApp", ["ngRoute"]);

    peopleSearchApp.config(function ($routeProvider) {

        $routeProvider

            // Route for the home page
            .when("/", {
                templateUrl: "/App/Views/search.html",
                controller: "searchController",
                controllerAs: "searchVm"
            });

    });

}());