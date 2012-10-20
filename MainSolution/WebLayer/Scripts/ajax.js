/// <reference path="jquery-1.8.2-vsdoc.js" />

//$(document).ready(function () {
//    $.getJSON("/Correspondence/GetCorrespondencesCount", null, function (jsonData) {
//        alert("xx");
//        $('label[for=ExternalIncomeTotalCountLabel]').html("(" + jsonData['internalIncome'] + ")");
//        $('label[for=InternalIncomeTotalCountLabel]').html("(" + jsonData['internalOutcome'] + ")");
//        $('label[for=ExternalOutcomeTotalCountLabel]').html("(" + jsonData['externalIncome'] + ")");
//        $('label[for=InternalOutcomeTotalCountLabel]').html("(" + jsonData['externalOutcome'] + ")");
//    });


//});

$(document).ready(function () {
    $.post("/Correspondence/GetCorrespondencesCount", null, function (jsonData) {
        $('label[for=ExternalIncomeTotalCountLabel]').html(jsonData['externalIncome']);
        $('label[for=InternalIncomeTotalCountLabel]').html(jsonData['internalIncome']);
        $('label[for=ExternalOutcomeTotalCountLabel]').html(jsonData['externalOutcome']);
        $('label[for=InternalOutcomeTotalCountLabel]').html(jsonData['internalOutcome']);

        $('label[for=OutcomingDecisionsTotalCountLabel]').html(jsonData['outcomeDecisions']);
        $('label[for=IncomingDecisionsTotalCountLabel]').html(jsonData['incomeDecisions']);

    }, "json");
});




 
                                                 