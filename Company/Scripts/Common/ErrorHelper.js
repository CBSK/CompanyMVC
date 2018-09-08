function showSuccess(msg) {
    $('.msgDiv').html('');
    $.LoadingOverlay("hide");
    $('.msgDiv').html('<div class="alert alert-success fade in"><button class="close" data-dismiss="alert" type="button">×</button><i class="fa-fw fa fa-check"></i><strong>' + msg + '</strong> </div>');
    $('html, body').animate({ scrollTop: 0 }, 800);
}

function showError(msg) {
     
    $('.msgDiv').html('');
    $.LoadingOverlay("hide");
    //$('.msgDiv').html('<div class="alert alert-danger alert-dismissable"> <button aria-hidden="true" data-dismiss="alert" class="close" type="button">×</button>' + msg + '</div>');
    $('.msgDiv').html('<div class="alert alert-info fade in"> <button class="close" data-dismiss="alert" type="button">×</button><i class="fa-fw fa fa-info"></i><strong>' + msg + '</strong></div>');
    $('html, body').animate({ scrollTop: 0 }, 800);
}

function showLoading() {
    $('.msgDiv').html('');
    $.LoadingOverlay("hide");
    $.LoadingOverlay("show", {
        image: "",
        fontawesome: "fa fa-spinner fa-spin"
    });  
}
function hideLoading() {
    $('.msgDiv').html('');
    $.LoadingOverlay("hide");  
}