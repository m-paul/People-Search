(function () {

    angular.module("peopleSearchApp").factory("overlayService", ["$http", "$q", overlayService]);

    /**
     * Coordinates the display of an overlay
     * @param {Object} $http - Responsible for sending ajax calls
     * @param {Object} $q    - Used for the creation of promises
     * @return {Object} returns an API
     */
    function overlayService($http, $q) {

        var api = {
            Show: show,
            Hide: hide
        };

        /**
         * Displays the overlay. Removes any existing focus.
         */
        function show() {
            document.activeElement.blur();
            $("body").css("overflow", "hidden");
            $("#overlay").show();
        }

        /**
         * Hides the overlay
         */
        function hide() {
            $("body").css("overflow", "auto");
            $("#overlay").hide();
        }

        return api;
    }

}());