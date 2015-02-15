tripCollection = [];

buildTripList = function () {
    var token = sessionStorage.getItem('token');
    $.ajax({
        url: "http://epam.azurewebsites.net/api/trip",
        type: "POST",
        contentType: 'application/json; charset=utf-8',
        headers: { "PickUpMe-UserToken": token, "PickUpMe-UserTokenSource": "Google" },
        success: function (data) { console.log(data)},
        error: function (ex) { console.log(ex) }
    })
}

var drawList = function(data){
    $.each(data, function(){

    })
}