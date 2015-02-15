isAuthorized = 'false'

hello.on('auth.login', function (auth) {
    // call user information, for the given network
    hello(auth.network).api('/me').then(function (r) {
        if (auth.authResponse.access_token) {
            sessionStorage.setItem("token", auth.authResponse.access_token);
            isAuthorized = true;

            // Inject it into the container
            var label = document.getElementById("profile_" + auth.network);
            if (!label) {
                label = document.createElement('div');
                label.id = "profile_" + auth.network;
                document.getElementById('profile').appendChild(label);
            }
            label.innerHTML = '<img src="' + r.thumbnail + '" /> Hey ' + r.name;
        }
    });
});

loginWithGoogle = function () {
    hello('google').login();
    initAuthorization();
}

initAuthorization = function () {
    var auth = hello.getAuthResponse('google');
    if (auth != null) {
        console.log(auth);
        sessionStorage.setItem("token", auth.access_token);
        isAuthorized = true;
        
        $('#login-nav').hide();
        $('#user-nav').show();
    } else {
        isAuthorized = false;

        $('#login-nav').Show();
        $('#user-nav').Hide();
    }
    return isAuthorized;
}