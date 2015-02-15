var directionsDisplay;
var directionsService = new google.maps.DirectionsService();
var map;

function initialize() {
    directionsDisplay = new google.maps.DirectionsRenderer();
    var Mogilev = new google.maps.LatLng(53.9016528, 30.3515768);
    var mapOptions = {
        zoom: 12,
        center: Mogilev
    };
    map = new google.maps.Map(document.getElementById('map-canvas'), mapOptions);
    directionsDisplay.setMap(map);
}

function calcRoute() {
    var start = document.getElementById('origination').value;
    var end = document.getElementById('destination').value;
    drawRoute(start, end);
}
function buildRoute(element) {
    var orig = $(element).find('.orig')[0].innerText;
    var dest = $(element).find('.dest')[0].innerText;

    drawRoute(orig, dest);
}

function drawRoute(orig, dest) {
    var request = {
        origin: orig,
        destination: dest,
        travelMode: google.maps.TravelMode.DRIVING
    };
    directionsService.route(request, function (response, status) {
        if (status == google.maps.DirectionsStatus.OK) {
            directionsDisplay.setDirections(response);
        }
    });
}

google.maps.event.addDomListener(window, 'load', initialize);