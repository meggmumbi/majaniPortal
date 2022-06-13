$(document).ready(function () {
 

    $("#checkBoxAllGoods").change(function () {
        if (this.checked) {
            $(".servicesSelected").each(function () {
                this.checked = true;
            });
        } else {
            $(".servicesSelected").each(function () {
                this.checked = false;
            });
        }
    });
    var td2 = $(".tblselectedServices")
    td2.on("change",
        "tbody tr .checkboxes",
        function () {
            var t = jQuery(this).is(":checked"), selected_arr = [];
            t ? ($(this).prop("checked", !0), $(this).parents("tr").addClass("active"))
                : ($(this).prop("checked", !1), $(this).parents("tr").removeClass("active"));
            // Read all checked checkboxes
            $("input:checkbox[class=checkboxes]:checked").each(function () {
                selected_arr.push($(this).val());
            });

            if (selected_arr.length > 0) {
                $("#rfiresponsefeedback").css("display", "block");

            } else {
                $("#rfiresponsefeedback").css("display", "none");
                selected_arr = [];
            }

        });

    var PrimaryInitiative = new Array();
    $(".btn_apply_SubmitServices").on("click",
        function (e) {
            e.preventDefault();
            PrimaryInitiative = [];
            $.each($(".tblselectedServices tr.active"), function () {
                //procurement category
                var checkbox_value = $('#servicesSelected').val();
                var Targets = {};
                Targets.comment = ($(this).find("TD input").eq(1).val());
                Targets.targetNumber = ($(this).find('td').eq(1).text());
                Targets.ApplicationNo = $("#txtAppNo").val();
                PrimaryInitiative.push(Targets);
            });
            var postData = {
                catgeories: PrimaryInitiative
            };
            console.log(JSON.stringify(PrimaryInitiative))
            Swal.fire({
                title: "Confirm Selected Question Responses?",
                text: "Are you sure you would like to proceed with submission?",
                type: "warning",
                showCancelButton: true,
                closeOnConfirm: true,
                confirmButtonText: "Yes, Proceed!",
                confirmButtonClass: "btn-success",
                confirmButtonColor: "#008000",
                position: "center"

            }).then((result) => {
                if (result.value) {
                    $.ajax({

                        type: "POST",
                        url: "NewClaimNotificationAgriculture.aspx/selectedServices",
                        data: '{targetNumber: ' + JSON.stringify(PrimaryInitiative) + '}',
                        contentType: "application/json; charset=utf-8",
                        dataType: "json"

                    }).done(function (status) {
                        var registerstatus = status.d;
                        console.log(JSON.stringify(registerstatus))
                        if (registerstatus == 'success') {
                            Swal.fire
                               ({
                                   title: "Responses Submitted!",
                                   text: "Your Responses have been successfully submitted.Kindly Proceed!",
                                   type: "success"
                               }).then(() => {
                                   $("#feedback").css("display", "block");
                                   $("#feedback").css("color", "green");
                                   $('#feedback').attr("class", "alert alert-success");
                                   $("#feedback").html("Your Responses have been successfully submitted.Kindly Proceed!");
                                   $("#feedback").css("display", "block");
                                   $("#feedback").css("color", "green");
                                   $("#feedback").html("Your Responses have been successfully submitted.Kindly Proceed!");
                                   location.reload(true);
                               });
                        }

                        else {
                            Swal.fire
                                    ({
                                        title: " Responses submission Error!!!",
                                        text: registerstatus,
                                        type: "error"
                                    }).then(() => {
                                        $("#feedback").css("display", "block");
                                        $("#feedback").css("color", "red");
                                        $('#feedback').addClass('alert alert-danger');
                                        $("#feedback").html("Your Responses could not be submitted.Kindly select again and try to submit!" + registerstatus);
                                        location.reload(true);
                                    });

                        }
                    
                    }
                    );
                } else if (result.dismiss === Swal.DismissReason.cancel) {
                    Swal.fire(
                       'Submission Cancelled',
                            'You cancelled your Responses submission details!',
                           'error'
                    );
                }
            });

        });
   
});