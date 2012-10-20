/// <reference path="jquery-1.8.2-vsdoc.js" />
/// <reference path="jquery-ui-1.8.23.js" />


$.fx.speeds._default = 1000;
$(function () {
    $("#AddNoteDialog").dialog({
        autoOpen: false,
        show: "blind",
        hide: "explode",
        modal: true,
        buttons: {
            "حفظ": function () {
                var postData = {
                    CorrespondenceID: $("#CorrespondenceID").val(),
                    Note: $("#noteArea").val()
                };

                var bValid = true;
                bValid = bValid && postData.Note.length > 0;
                if (bValid) {
                    var answer = confirm("are you sure?");
                    if (!answer) { return false; }
                    $.post("/Correspondence/Note", postData, function (data) {
                        alert(data["result"]);
                    }, "json");

                    $(this).dialog("close");
                } else {
                    alert("error");
                }
            },
            إلغاء: function () {
                $(this).dialog("close");
            }
        }
    });

    $("#addNoteLink").click(function () {
        $("#AddNoteDialog").dialog("open");
        return false;
    });
});
