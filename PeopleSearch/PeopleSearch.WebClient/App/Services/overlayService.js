(function () {

    angular.module("peopleSearchApp").factory("overlayService", ["$http", "$q", overlayService]);

    function overlayService($http, $q) {

        var api = {
            Show: show,
            Hide: hide
        };

        function show(criteria) {
            document.activeElement.blur();
            $("body").css("overflow", "hidden");
            $("#overlay").show();
        }

        function hide(criteria) {
            $("body").css("overflow", "auto");
            $("#overlay").hide();
        }

        return api;
    }

}());