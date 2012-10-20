/// <reference path="jquery-1.8.2-vsdoc.js" />


$(function () {

    $(".wizard-step:first").fadeIn(); // show first step
    $("#saveAsDraftBtn").hide();
    $("#saveFormBtn").hide();

    // attach backStep button handler
    // hide on first step





    $("#cancel-button").click(function () {
        var reply = confirm('This will discard all your changes, continue?');
        if (!reply) { return false; }
        window.location.href = "/Correspondence/Index";
        return true;
    });


    $("#saveFormBtn").click(function () {
        var $step = $("form"); // get current step
        var validator = $("form").validate(); // obtain validator
        var anyError = false;
        $step.find("input").each(function () {
            if (!validator.element(this)) { // validate every input element inside this step
                anyError = true;
            }
        });
        alert(anyError);

        if (anyError) {
            return false; // exit if any error found
        }
        $("form").submit();
    });

    $("#saveAsDraftBtn").click(function () {
//        $("form").append('<input type="hidden" value="true" id="saveAsDraftHidden"/>');
        $("form").submit();
    });

    $("#back-step").hide().click(function () {
        var $step = $(".wizard-step:visible"); // get current step

        if ($step.prev().hasClass("wizard-step")) { // is there any previous step?
            $step.hide().prev().fadeIn();  // show it and hide current step

            // disable backstep button?
            if (!$step.prev().prev().hasClass("wizard-step")) {
                $("#back-step").hide();
            }
        }

        $("#saveAsDraftBtn").hide();
        $("#saveFormBtn").hide();
        $("#next-step").show();
    });


    // attach nextStep button handler       
    $("#next-step").click(function () {

        var $step = $(".wizard-step:visible"); // get current step




        if ($step.next().hasClass("confirm")) { // is it confirmation?
            // show confirmation asynchronously

            $.post("/Correspondence/Confirm", $("form").serialize(), function (r) {
                // inject response in confirmation step
                $(".wizard-step.confirm").html(r);
            });

            $("#saveAsDraftBtn").show();
            $("#saveFormBtn").show();
            $("#next-step").hide();

        } else {
            $("#saveAsDraftBtn").hide();
            $("#saveFormBtn").hide();
        }

        if ($step.next().hasClass("wizard-step")) { // is there any next step?
            $step.hide().next().fadeIn();  // show it and hide current step
            $("#back-step").show();   // recall to show backStep button
        }

        else { // this is last step, submit form

                        var validator = $("form").validate(); // obtain validator
                        var anyError = false;
                        $step.find("input").each(function () {
                            if (!validator.element(this)) { // validate every input element inside this step
                                anyError = true;
                            }
                        });
                        alert(anyError);

                        if (anyError) {
                            return false; // exit if any error found
                        }

            $("form").submit();
        }


    });

});
