(function () {
    "use strict";
    //getting the existing moduler (just one parameter)
    angular.module("app-trips")
        .controller("tripsController", tripsController);

    function tripsController($http) {

        var vm = this;

        vm.name = "Shawn";

        vm.trips = [
            //{
            //    name: "US Trips",
            //    created: new Date()
            //}, {
            //    name: "World Trips",
            //    created: new Date()
            //}
        ];

        vm.newTrip = {};
        vm.isBusy = true;
        vm.errorMessage = "";
        $http.get("/api/trips")
            .then(function(response) {
                //success
                angular.copy(response.data, vm.trips);

            }, function(error) {
                //failure
                vm.errorMessage = "failed to load data " + error;
            }).finally(function() {
                vm.isBusy = false;
                }
            );

        vm.addTrip = function() {

            vm.isBusy = true;
            vm.errorMessage = "";

            $http.post("/api/trips", vm.newTrip)
                .then(function(response) {
                        //success
                        vm.trips.push(response.data);
                        vm.newTrip = {};
                    },
                    function() {
                        //failure
                        vm.errorMessage = "failed to save new trip";
                    })
                .finally(function() {
                    vm.isBusy = false;
                });
        }



    }
})();