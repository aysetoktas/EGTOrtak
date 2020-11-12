$('#btnLogin').click(function myfunction() {
    debugger
    var form = $('#loginForm');
    $.ajax({
        type: "POST",
        url: '/Login/CheckLogin',
        data: form.serialize(),
        success: function (data) {
            if (data != null) {
                window.location.href = '/Home/Index';
            }
        },
        error: function (request, status, error) {
            alert("Kullanici adi ya da parola yanlis.");
        }
    });
})