
$(document).ready(function () {

    //getDataTable();
    //alert('working');


    $('#photoList').DataTable({
        bProcessing: true,
        bLenghtChange: true,
        lengthMenu: [5, 10, 15, 20],
        bfilter: true,
        bSort: true,
        bPagination: true,
        rowReorder: {
            selector: 'td:nth-child(2)'
        },
        //columnDefs: [
        //    {
        //        targets: -1,
        //        className: 'dt-body-center'
        //    }
        //],
        columnDefs: [
            { width: "20%", "targets": 0, className: 'dt-body-center', "orderable": true },
            { width: "20%", "targets": 1, className: 'dt-body-center', "orderable": true },
            { width: "30%", "targets": 2, className: 'dt-body-center', "orderable": false },
            { width: "20%", "targets": 3, className: 'dt-body-center', "orderable": false },
            { width: "10%", "targets": 4, className: 'dt-body-center', "orderable": false },
        ],
        responsive: true
    });


    //GetAllGalleryPhoto();
});

function GetAllGalleryPhoto() {
    $.ajax({
        url: '/Gallery/GetGalleryPhoto',
        type: 'Get',
        datatype: 'json',
        success: OnSuccess
    })

}
function getDataTable() {
    $('#photoList').DataTable({
        bProcessing: true,
        bLenghtChange: true,
        lengthMenu: [5, 10, 15, 20],
        bfilter: true,
        bSort: true,
        bPagination: true,
        rowReorder: {
            selector: 'td:nth-child(2)'
        },
        //columnDefs: [
        //    {
        //        targets: -1,
        //        className: 'dt-body-center'
        //    }
        //],
        columnDefs: [
            { width: "20%", "targets": 0, className: 'dt-body-center', "orderable": true },
            { width: "20%", "targets": 1, className: 'dt-body-center', "orderable": true },
            { width: "30%", "targets": 2, className: 'dt-body-center', "orderable": false },
            { width: "20%", "targets": 3, className: 'dt-body-center', "orderable": false },
            { width: "10%", "targets": 4, className: 'dt-body-center', "orderable": false },
        ],
        responsive: true
    });

}


function btnDelete(id) {
    //alert('ok');
    //swal({
    //    title: "Good job!",
    //    text: "You clicked the button!",
    //    icon: "success",
    //    button: "Aww yiss!",
    //}).then(result => {
    //    if (result.isConfirmed) {

    //    }
    //});
    
    swal({
        title: "Are you sure?",
        text: "Once deleted, you will not be able to recover this Image!",
        icon: "warning",
        buttons: true,
        dangerMode: true,
    })
        .then((willDelete) => {
            if (willDelete) {
                debugger;
                DeletePhoto(id);
                setTimeout(() => {
                    swal("Poof! Your file has been deleted!", {
                        icon: "success",
                    });
                }, 2000);

                setTimeout(() => {
                    location.reload();
                }, 3500);
                
                

            } else {
                swal("Your file is safe! You cancelled to Deletion");
            }
        });

}

function DeletePhoto(id) {
    debugger;
    var formData = new FormData();
    formData.append("id", id);
    $.ajax({
        url: '/Gallery/GalleryPhotoDelete' + '/' + id,
        type: 'Get',
        //data: formData,
        //datatype: 'json',
        
    })




    //$.ajax({
    //    url: '/Gallery/GalleryPhotoDelete',
    //    type: 'Post',
    //    data: formData,
    //    processData: false,
    //    contentType: false,
    //    async: true,
    //    success: function (data) {
    //        swal("Poof! Your imaginary file has been deleted!", {
    //            icon: "success",
    //        });
    //    },
    //})


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
                data: "Name", render: function (data, type, row, meta) {
                    return '<p align="justify">' + row.name + '</p>'
                }, width: "15%"
            },

            {
                data: "Flag", render: function (data, type, row, meta) { return '<p align="justify">' + row.flag + '</p>' }, width: "15%"
            },
            {
                data: "Details", render: function (data, type, row, meta) {
                    return '<p align="justify">' + row.details + '</p>';
                }, align: 'center', width: "40%", orderable: false
            },
            {
                data: "Image", render: function (data, type, row, meta) {
                    return '&nbsp;' + '<img src="' + row.image + '" height="100" width="200" style="display: block;" />';
                }, align: 'center', width: "20%", orderable: false
            },
            {
                data: "Action", render: function (data, type, row, meta) {
                    return ' <a asp-action="EditGalleryPhoto" class="" asp-route-id="' + row.imageId + '"><i class="fas fa-edit" style="font-size: 30px; color:black"></i></a>|' +
                        ' <a asp-action="GalleryphotoDelete" asp-route-id="' + row.imageId + '" > <i class="fas fa-trash-alt" style="font-size: 30px; color:red"></i></a>'
                }, width: "20%", orderable: false
            }
        ]

    });
    $('#photoList tbody').on('dblclick', 'tr', function () {
        var data = table.row(this).data();
        alert('You clicked on ' + data[0] + '\'s row');
    });
}

