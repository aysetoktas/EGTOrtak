$('#CategorySelect').change(function myfunction() {
    debugger
    var categoryId = $(this).val();
    $.get('/OnlineLesson/GetStudentsByCategoryId/' + categoryId, function (data) {
        $("#StudentSelect").find('option').remove();
        for (let prop of data) {
            $("#StudentSelect").append('<option value="' + prop['ID'] + '">' + prop['FirstName'] + " " + prop['LastName'] + '</option>');
        }
    });
});