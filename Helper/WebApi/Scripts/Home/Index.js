﻿function selectView(view) {
    $('.display').not('#' + view + "Display").hide();
    $('#' + view + "Display").show();
}
function getData() {
    $.ajax({
        type: "GET",
        url: "/All",
        success: function (data) {
            $('#tableBody').empty();
            for (var i = 0; i < data.length; i++) {
                $('#tableBody').append('<tr><td><input id="id" name="id" type="radio"'
                    + 'value="' + data[i].Id + '" /></td>'
                    +'<td >'+data[i].Number+'</td ></tr >');
            }
            $('input:radio')[0].checked = "checked";
            selectView("summary");
        }
    });
}
$(document).ready(function () {
    selectView("summary");
    getData();
    $("button").click(function (e) {
        var selectedRadio = $('input:radio:checked')
        switch (e.target.id) {
            case "refresh":
                getData();
                break;
            case "delete":
                $.ajax({
                    type: "DELETE",
                    url: "/DeleteOne",
                    success: function (data) {
                        selectedRadio.closest('tr').remove();
                    }
                });
                break;
            case "add":
                selectView("add");
                break;
            case "edit":
                $.ajax({
                    type: "GET",
                    url: "/api/Values/" + selectedRadio.attr('value'),
                    success: function (data) {
                        $('#editId').val(data[0].Id);
                        $('#editNumber').val(data[0].Number);
                        
                    }
                });
                selectView("edit");
                break;
            case "submitEdit":
                $.ajax({
                    type: "PUT",
                    url: "/PutOne",
                    data: $('#editForm').serialize(),
                    success: function (result) {
                        if (result) {
                            var cells = selectedRadio.closest('tr').children();
                            cells[1].innerText = $('#editNumber').val();
                            selectView("summary");
                        }
                    }
                });
                break;
        }
    });
});