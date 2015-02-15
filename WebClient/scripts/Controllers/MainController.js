var myApp = angular.module('webClient', []);

myApp.controller('mainController', ['$scope', function ($scope) {
    $scope.tripList =
       [{
           "Id": 24, "Origination": "Mogilev", "Destination": "Minsk", "DateTime": "2015-02-15T13:52:16.857", "Car": null, "Driver": { "Id": 1, "Token": "Duott", "Source": "Google", "FirstName": "Andrei", "LastName": "Afanaseka", "Phone": "555345523", "AvatarUri": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSratdZeWL9v9ozu-XvoO2flsaf0BZ4ykp8FLC72_3l4_iOYwe423xaCRQ", "Cars": [] }, "Passengers": [{ "Id": 1, "Token": "Duott", "Source": "Google", "FirstName": "Andrei", "LastName": "Afanaseka", "Phone": "555345523", "AvatarUri": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSratdZeWL9v9ozu-XvoO2flsaf0BZ4ykp8FLC72_3l4_iOYwe423xaCRQ", "Cars": [] },
                { "Id": 1, "Token": "Duott", "Source": "Google", "FirstName": "Andrei", "LastName": "Afanaseka", "Phone": "555345523", "AvatarUri": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSratdZeWL9v9ozu-XvoO2flsaf0BZ4ykp8FLC72_3l4_iOYwe423xaCRQ", "Cars": [] }, { "Id": 1, "Token": "Duott", "Source": "Google", "FirstName": "Andrei", "LastName": "Afanaseka", "Phone": "555345523", "AvatarUri": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSratdZeWL9v9ozu-XvoO2flsaf0BZ4ykp8FLC72_3l4_iOYwe423xaCRQ", "Cars": [] },
                { "Id": 1, "Token": "Duott", "Source": "Google", "FirstName": "Andrei", "LastName": "Afanaseka", "Phone": "555345523", "AvatarUri": "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcSratdZeWL9v9ozu-XvoO2flsaf0BZ4ykp8FLC72_3l4_iOYwe423xaCRQ", "Cars": [] }], "Capacity": 4, "Cost": 75000, "PackageAllowed": false
       }]
    $scope.print = function () { console.log($scope.tripList) }
}]);