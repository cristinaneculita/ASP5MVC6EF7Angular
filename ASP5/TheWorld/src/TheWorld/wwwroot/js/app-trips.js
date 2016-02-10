(function () {
    "use strict";

    //creating the module due to the second parameter
    angular.module("app-trips", ["simpleControls", "ngRoute"])
    .config(function($routeProvider) {
            $routeProvider.when("/", {
                controller: "tripsController",
                controllerAs: "vm",
                templateUrl:"/views/tripsView.html"
            });
            $routeProvider.when("/editor/:tripName", {
                controller: "tripEditorController",
                controllerAs: "vm",
                templateUrl: "/views/tripEditorView.html"
            });
            $routeProvider.otherwise({ redirectTo: "/" });
        });
})();