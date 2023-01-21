window.ProjectTitle = 'Marine Hive';


$(document).ready(function () {
    initializeButtonEvent();
    

});

function initializeButtonEvent() {

   

    $(btnSaveDirector).click(function () {
        BeforeSaveDirector(btnSaveDirector);
    }
    );
}
function BeforeSaveDirector() {
    var returnFlag = false;

    var formData = new FormData();
    if ($('[data-member="DirectorName"]').val() == '') {
        //ShowMessageBox(window.ProjectTitle, " Insert  Director Name ")
        alert("Insert DirectorName");
        return returnFlag;
    }
    if ($('[data-member="Designation"]').val() == '') {
        //$p.ShowMessageBox(window.ProjectTitle, " Insert Designation ")
        return returnFlag;
    }
    
}

//function ShowConfirmBox(title, message, onOkClick, onCancelClick) {
//    noty({
//        text: message,
//        type: 'warning',
//        layout: 'dialog',
//        theme: 'defaultTheme',
//        template: '<div class="modal-header">' + title + '</div><div class="noty_message"><span class="noty_text"></span></div></div><div class="noty_close">',
//        modal: true,
//        css: { display: 'none', width: '400px' },
//        closeWith: ['escape', 'button'],
//        //animation: {
//        //    open: 'animated flipInX',
//        //    close: 'animated flipOutX',
//        //    easing: 'swing',
//        //    speed: 500
//        //},
//        buttons: [
//            {
//                addClass: 'btn btn-danger fuse-ripple-ready', text: 'Cancel', onClick: function ($noty) {
//                    $noty.close();
//                    if (onCancelClick) onCancelClick();
//                }
//            },
//            {
//                addClass: 'btn btn-secondary fuse-ripple-ready', text: 'Ok', onClick: function ($noty) {
//                    $noty.close();
//                    if (onOkClick) onOkClick();
//                }
//            }
//        ]
//    });
//}

//function ShowMessageBox(title, message, onOkClick) {
//    noty({
//        text: message,
//        type: 'warning',
//        layout: 'dialog',
//        theme: 'defaultTheme',
//        template: '<div class="modal-header">' + title + '</div><div class="noty_message"><span class="noty_text"></span></div></div><div class="noty_close">',
//        modal: true,
//        css: { display: 'none', width: '400px' },
//        closeWith: ['escape', 'button'],
//        //animation: {
//        //    open: 'animated flipInX',
//        //    close: 'animated flipOutX',
//        //    easing: 'swing',
//        //    speed: 500
//        //},
//        buttons: [
//            {
//                addClass: 'btn btn-secondary fuse-ripple-ready', text: 'Ok', onClick: function ($noty) {
//                    $noty.close();
//                    if (onOkClick) onOkClick();
//                }
//            }
//        ]
//    });
//}