function showAchievement() {
    var table = '';
    var tableTag = '<table id="mytable" class="table" style="margin-top:10px;">';
    var tableHead = '<thead><tr><th>#</th><th>Ders</th><th>Not</th><th>Tarih</th><th>';
    var tableFooter = '</tbody></table>';
    var rows = '';
    var id = $('#classList').val();
    $.get('/Home/GetLessonList/' + id, function (data) {
        //document.getElementById("info").innerHTML = '<div><div class="col-md-4">' + data['classroom'] + '</div><div class="col-md-4">' + data['education'] + '</div><div class="col-md-4"><button class="btn btn-success" onclick="OpenAchievement(' + data['classId'] + ')">Kazanım Ekle</button></div></div>';
        tableHead += '<button class="btn btn-success" onclick="OpenAchievement(' + data['classId'] + ')">Ders Ekle</button></th ></tr ></thead ><tbody>'
        var i = 1;
        for (let prop of data['achievements']) {
            var dateStr = new Date(parseInt(prop['date'].substr(6)));
            var mounth = dateStr.getMonth() + 1;
            dateStr = dateStr.getDate() + '.' + mounth + '.' + dateStr.getFullYear();
            rows += '<tr><td>' + i + '</td><td>' + prop['lesson'] + '</td><td>' + prop['note'] + '</td><td>' + dateStr + '</td><td width="250"><button class="btn btn-info" onclick="OpenInspection(' + prop['id'] + ')">Yoklama Al</button> <button class="btn btn-warning" onclick="EditAchievement(' + prop['id'] + ')">Düzenle</button>  <button onclick="DeleteAchievement(' + prop['id'] + ')" class="btn btn-danger" value="' + prop['id'] + '">Sil</button></td></tr>';
            i++;
        }
        table = tableTag + tableHead + rows + tableFooter;
        document.getElementById("fillTable").innerHTML = table;
        var j = 1;
        var lessList = '';
        for (let prop of data['lessons']) {
            lessList += '<option value="' + prop['id'] + '">' + j + '. ' + prop['name'] + '</option>';
            j++;
        }
        $("#lessonList").find('option').remove();
        $('#lessonList').append('<option disabled selected value="">Lütfen ders seçiniz.</option>' + lessList);
    });
}

function EditAchievement(id) {
    $.get('/Home/GetAchiementById/' + id, function (data) {
        for (let prop in data) {
            $('#editAchievement .editachi').each((key, val) => {
                let $element = $(val);
                if (prop === $element.attr('id')) {
                    debugger
                    if (prop === "date") {
                        debugger
                        var dateStr = new Date(parseInt(data[prop].substr(6)));
                        var mounth = dateStr.getMonth() + 1;
                        dateStr = dateStr.getDate() + '.' + mounth + '.' + dateStr.getFullYear();
                        $element.val(dateStr);
                    }
                    else {
                        $element.val(data[prop]);
                    }
                    return;
                }
            });
        }
        $('#editAchievement').modal('show');
    });
}

function OpenAchievement(id) {
    $('#clsID').val(id);
    $('#insertAchievementModal').modal('show');
}

function DeleteAchievement(id) {
    $.get('/Home/DeleteAchievement/' + id, function (data) {
        showAchievement();
    });
}

$("#insertRow").submit(function (event) {
    event.preventDefault();
    var form = $(this);
    var url = form.attr('action');
    $.ajax({
        type: "POST",
        url: url,
        data: form.serialize(),
        success: function (data) {
            $('#insertAchievementModal').modal("hide");
            showAchievement();
        }
    });
});

$("#updateRow").submit(function (event) {
    event.preventDefault();
    var form = $(this);
    var url = form.attr('action');
    $.ajax({
        type: "POST",
        url: url,
        data: form.serialize(),
        success: function (data) {
            $('#editAchievement').modal("hide");
            showAchievement();
        }
    });
});

function OpenInspection(id) { // Yoklama al butonuna basıldığında InspectioModal Modalının içi dolacak ve açılacak
    document.getElementById("stdList").innerHTML = "";
    var table = '';
    var tableTag = '<table id="mytable" class="table">';
    var tableHead = '<thead><tr><th>#</th><th>Ad</th><th>Soyad</th><th>Katılım</th</tr></thead><tbody>';
    var tableFooter = '</tbody></table>';
    var rows = '';
    $.get('/Home/GetStudents/' + id, function (data) {
        debugger
        var i = 1;
        for (let prop of data['studentList']) {
            $('#achId').val(prop['currentAchId']);
            if (prop['isCome'] == true) {
                checkBox = '<input onchange="changeValue(this)" name="isCome" type="checkbox" value="' + prop['isCome'] + '" checked data-id="' + prop['stdId'] + '"/>';
            }
            else {
                checkBox = '<input onchange="changeValue(this)" name="isCome" type="checkbox"  value="' + prop['isCome'] + '" data-id="' + prop['stdId'] + '"/>';
            }
            rows += '<tr><td>' + i + '<td>' + prop['firstName'] + '</td><td>' + prop['lastName'] + '</td><td>' + checkBox + '</td></tr>';
            i++;
        }
        table = tableTag + tableHead + rows + tableFooter;
        $('#stdList').append(table);
    });
    $('#InspectioModal').modal('show');
}

function changeValue(id) {
    debugger
    if (!$(id).prop('checked')) {
        $(id).val(false);
        $(id).prop('checked', false);
    } else {
        $(id).val(true);
        $(id).prop('checked', true);
    }
}

$(function () {
    $('.selectpicker').selectpicker();
});


$("#AddInspection").submit(function (event) {
    var inspection = [];
    $.each($("input[name='isCome']"), function () {
        inspection.push({ "isCome": $(this).val(), "stdID": $(this).attr("data-id"), "achId": $('#achId').val() });
    });
    console.log(inspection);
    event.preventDefault();
    var form = $(this);
    var url = form.attr('action');
    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(inspection),
        success: function (data) {
            $('#InspectioModal').modal("hide");
        }
    });
});

function UpdateAccount() {
    var form = $('#allForm');
    var formData = new FormData(document.getElementById("allForm"));
    $.ajax({
        url: '/Profile/UpdateAccount',
        type: 'POST',
        data: formData,
        success: function (data) {
            location.reload();
        },
        cache: false,
        contentType: false,
        processData: false
    });
}