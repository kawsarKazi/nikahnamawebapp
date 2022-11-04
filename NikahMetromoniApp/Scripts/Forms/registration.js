$(document).ready(function () {
    $(document).ready(function () {
        $("#DivisionId").select2();
        $("#DistrictId").select2();
        $("#UpozilaId").select2();

        $.get("/api/Locations/Division", function (data) {
            var $el = $("#DivisionId");
            $el.empty(); // remove old options
            $el.append($("<option></option>")
                .attr("value", '').text(''));
            $.each(data, function (value, key) {
                $el.append($('<option>', {
                    value: key.id,
                    text: key.nameEnglish
                }));
            });
        });

    });
});


$(document.body).on("change", "#DivisionId", function () {
    var divisionId = $("#DivisionId").val();
    $("#DistrictId").empty();
    $("#UpozilaId").empty();
    if (divisionId > 0) {
        $.ajax({
            type: "GET",
            url: "/api/Locations/District",
            contentType: "application/json; charset=utf-8",
            data: { divisionId: divisionId },
            success: function (data) {
                var $el = $("#DistrictId");
                $el.empty(); // remove old options
                $el.append($("<option></option>")
                    .attr("value", '').text(''));
                $.each(data, function (value, key) {
                    $el.append($('<option>', {
                        value: key.id,
                        text: key.nameEnglish
                    }));
                });
            }
        });
    }
});


$(document.body).on("change","#DistrictId",function() {
        var districtId = $("#DistrictId").val();
        $("#UpozilaId").empty();
        if (districtId > 0) {
            $.ajax({
                type: "GET",
                url: "/api/Locations/Upozila",
                contentType: "application/json; charset=utf-8",
                data: { districtId: districtId },
                success: function(data) {
                    var $el = $("#UpozilaId");
                    $el.empty(); // remove old options
                    $el.append($("<option></option>")
                        .attr("value", '').text(''));
                    $.each(data,
                        function(value, key) {
                            $el.append($('<option>',
                                {
                                    value: key.id,
                                    text: key.nameEnglish
                                }));
                        });
                }
            });
        }
    });