/// <reference path="jquery-1.8.2-vsdoc.js" />
/// <reference path="jquery-ui-1.8.23.js" />


$.fx.speeds._default = 1000;
$(function () {
    $("#SelectOrgunitDialogID").dialog({
        autoOpen: false,
        show: "blind",
        hide: "explode",
        modal: true
    });

    $("#selectOrgunitBtn").click(function () {
        $("#SelectOrgunitDialogID").dialog("open");
        return false;
    });
});


$(function () {
    $(".datefield").datepicker();
});


function selectingOrgunit(orgID, orgName, field, dialogID, closeDialog, multiple) {
    //            alert(orgName + ' ' + field);
    alert(multiple);
    var val = '';
    if (multiple == 'True') {

        $('<input>').attr({
            type: 'hidden',
            id: field,
            name: field,
            val: orgID
        }).appendTo('form');

        alert('done');
        //        val = document.getElementById(field).value;
        //        if (val == null || val == '') {
        //            val = orgID;

        //        } else {
        //            val = val + "," + orgID;
        //        }
        //        alert(val);
    } else {
        val = orgID;
    }
    document.getElementById(field).value = val = val;
    document.getElementById(field + 'Label').value = orgName;
    if (closeDialog) {
        $("#" + dialogID).dialog("close");
    }
}
