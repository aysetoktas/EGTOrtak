$('#educationSelect').change(function myfunction() {
    debugger
    var eduId = $(this).val();
    $.get('/Admin/Lesson/GetUnitsByEducationId/' + eduId, function (data) {
        $("#unitSelect").find('option').remove();
        for (let prop of data) {
            $("#unitSelect").append('<option value="' + prop['ID'] + '">' + prop['Name'] + '</option>');
        }
    });
});