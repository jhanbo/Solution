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
    $("#SelectDestinationDialogID").dialog({
        autoOpen: false,
        show: "blind",
        hide: "explode",
        modal: true
    });

    $("#selectDestBtn").click(function () {
        $("#SelectDestinationDialogID").dialog("open");
        return false;
    });
});

$(function () {
    $("#SelectDestinationsCCDialogID").dialog({
        autoOpen: false,
        show: "blind",
        hide: "explode",
        modal: true
    });

    $("#selectDestCCBtn").click(function () {
        $("#SelectDestinationsCCDialogID").dialog("open");
        return false;
    });
});


$(function () {
    $(".datefield").datepicker();
});


function selectingOrgunit(orgID, orgName, field, dialogID, closeDialog, multiple) {
    var val = document.getElementById(field).value;
    var displayVal = document.getElementById(field + 'Label').value;
    if (multiple == 'True') {

        if (val == null || val == '') {
            val = orgID;
        } else {
            val = val + "," + orgID;
        }

        if (displayVal == null || displayVal == '') {
            displayVal = orgName;
        } else {
            displayVal = displayVal + "/" + orgName;
        }
        

    } else {
        val = orgID;
        displayVal = orgName;
    }
//    alert(val);
    document.getElementById(field).value = val;
    document.getElementById(field + 'Label').value = displayVal;
    if (closeDialog) {
        $("#" + dialogID).dialog("close");
    }
}

