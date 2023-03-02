


$(document).ready(function () {
    //alert('working');

    GetAllGalleryPhoto();
});

function GetAllGalleryPhoto() {
    $.ajax({
        url: '/Gallery/GetGalleryPhoto',
        type: 'Get',
        datatype: 'json',
        success: OnSuccess
    })
    //"columnDefs": [
    //    { "width": 20 %, "targets": 0, "orderable": true },
    //],

    //"columns": [
    //    { data: "ID", name: "ID" },
    //    { data: "Name", name: "Name" },
    //]

}
function OnSuccess(response) {
    $('#photoList').DataTable({
        bProcessing: true,
        bLenghtChange: true,
        lengthMenu: [5, 10, 15, 20],
        bfilter: true,
        bSort: true,
        bPagination: true,
        data: response,
        columns: [
            {
                data: "ID", render: function (data, type, row, meta) { return row.name },  width: "20%"
            },
            {
                data: "Name", render: function (data, type, row, meta) {
                    return '<img width="50%" src="' + row.image + '" />'
                }, width: "20%"
            },
            {
                data: "Image", render: function (data, type, row, meta) { return row.flag }, width: "10%"
            },
            {
                data: "Flag", render: function (data, type, row, meta) { return row.details }, align: 'center', width: "30%", orderable: false
            },
            {
                data: "Flag", render: function (data, type, row, meta) {
                    return '<a asp-controller="Gallery" asp-action="EditGalleryPhoto" asp-route-id="'+row.imageId+'">Update</a>'
                        + '|' + '<a class="btn btn-danger" asp-controller="Gallery" asp-action="Delete" asp-route-id="' + row.imageId + '">Delete</a>'
                        + '<button type="button" class="btn btn-secondary btn-fab btn-sm"><i class="icon-table-edit"></i></button>'
                }, align: 'center', width: "10%", orderable: false
            }
        ]
    });
}

