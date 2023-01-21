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
        //$p.ShowMessageBox(window.ProjectTitle, " Insert  Director Name ")
        alert("Insert DirectorName");
        return returnFlag;
    }
    if ($('[data-member="Designation"]').val() == '') {
        //$p.ShowMessageBox(window.ProjectTitle, " Insert Designation ")
        return returnFlag;
    }
    
}