var myApp = angular.module('webClient', []);

myApp.controller('mainController', ['$scope', function ($scope) {
    $scope.tripList = [];
}]);