tripCollection = [];

buildTripList = function () {
    var token = sessionStorage.getItem('token');
    var trip = {
        Origination: "Mogilev",
        Destination: "Minsk",
        Capacity: 0,
        Cost: 0,
        PackageAllowed: false,
        Datetime: new Date($.now())
    };

    var json = JSON.stringify(trip);

    $.ajax({
        url: "http://epam.azurewebsites.net/api/trip",
        type: "POST",
        data: JSON.stringify({ Trip: trip, Action: "Find" }),
        headers: { "PickUpMe-UserToken": token, "PickUpMe-UserTokenSource": "Google" },
        contentType: 'application/json; charset=utf-8',
        success: function (data) { console.log(data) },
        error: function (ex) {  }
    });

    
}

var createTrip = function () {
    
    $('#CreateTripDriver').closeModal();
}

function toast() {
    '<span>Notification Sended</span><a class=&quot;btn-flat yellow-text&quot; href=&quot;#!&quot;>OK<a>', 5000
}
