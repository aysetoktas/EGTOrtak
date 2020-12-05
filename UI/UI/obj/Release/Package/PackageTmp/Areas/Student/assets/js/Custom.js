
function myfunction() {
    var form = $('#xxx');

    $.ajax({
        type: "POST",
        url: '/Login/CheckLogin',
        data: form.serialize(),
        content: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {
            if (data != null) {
                window.location.href = '/Home/Index';
            }
        },
        error: function (request, status, error) {
            // similate 2s delay
            setTimeout(function () {
                btn.removeClass('kt-spinner kt-spinner--right kt-spinner--sm kt-spinner--light').attr('disabled', false);
                showErrorMsg(form, 'danger', 'Kullanici adi veya sifre yanlis. Lutfen tekrar deneyiniz.');
            }, 2000);
        }
    });
}