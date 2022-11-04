$(document).ready(function () {
    loadTable();
});

function loadTable() {

    $("#infoTable").DataTable().destroy();

    $("#infoTable").DataTable({
        ajax: {
            url: "/api/Registrations/GetDivorceList",
            dataSrc: ""
        },
        columns: [
            {
                data: "groomName"
            },
            {
                data: "groomFatherName"
            },
            {
                data: "groomIdentity"
            },
            {
                data: "brideName"
            },
            {
                data: "brideIdentity"
            },
            {
                data: "registerVolumeNo"
            },
            {
                data: "pageNo"
            },
            {
                data: "divorceType"
            },
            {
                data: "address"
            },
            {
                data: "divorceDate",
                render: function(data) {
                    if (data) {
                        return DateTimeFormatDDMMYYYY(data);
                    } else {
                        return "";
                    }
                }
            },
            {
                data: "filePath",
                render: function (data, type, res) {
                    if (res.downloadPermission == 1) {
                        return "<a class='btn btn-info btn-sm' href='/Registrations/DownloadPaper?fileName=" + res.filePath + "'><i class='fa fa-download fa-2x ' aria-hidden='false'></i></a>";
                    } else {
                        return "";
                    }

                }
            }
            //{
            //    data: "id",
            //    render: function (data) {
            //        return "<a class='btn-link js-delete'  data-id=" + data + "><i class='fa fa-trash fa-2x' aria-hidden='true' style='color: #d9534f;'></i></a>";
            //    }
            //}
        ]
    });
}
