/// <reference path="jquery-ui-1.8.11.js" />
/// <reference path="jquery-1.8.2.js" />

$(function () {
    $(".datefield").datepicker();
});

$(function () {
    $("#tabs").tabs();
});


$(function () {
    $(".auto-dialog").dialog();
});

$.fx.speeds._default = 1000;
$(function () {
    $(".manual-dialog").dialog({
        autoOpen: false,
        show: "blind",
        hide: "explode"
    });

    $(".dialog-opener").click(function () {
        $(".manual-dialog").dialog("open");
        return false;
    });
});

$.fx.speeds._default = 1000;
$(function () {
    $(".modal-dialog").dialog({
        autoOpen: false,
        show: "blind",
        hide: "explode",
        modal: true
    });

    $(".modal-dialog-opener").click(function () {
        $(".modal-dialog").dialog("open");
        return false;
    });
});


$(document).ready(function () {
    // Store variables
    var accordion_head = $('.accordion > li > a'),
				accordion_body = $('.accordion li > .sub-menu');
    // Open the first tab on load
    accordion_head.first().addClass('active').next().slideDown('normal');
    // Click function
    accordion_head.on('click', function (event) {
        // Disable header links
        event.preventDefault();
        // Show and hide the tabs on click
        if ($(this).attr('class') != 'active') {
            accordion_body.slideUp('normal');
            $(this).next().stop(true, true).slideToggle('normal');
            accordion_head.removeClass('active');
            $(this).addClass('active');
        }
    });
});

$(function () {
    $("input[type=submit],button")
        .button();
});